# API Gateway

## What is an API Gateway?

An API Gateway is a **single entry point** for all client requests into a system. It sits between clients and backend microservices, acting as a **reverse proxy** that routes, transforms, and manages API traffic.

Think of it as a **front door** — every request enters through it, and it decides where to send it, what to check, and what to add or strip before forwarding.

---

## Why Do We Need an API Gateway?

| Problem | How API Gateway Solves It |
|---------|--------------------------|
| Clients need to know every microservice URL | Single unified endpoint for all APIs |
| Repeated auth logic in every service | Centralized authentication & authorization |
| No control over traffic spikes | Rate limiting & throttling at the edge |
| Different clients need different data shapes | Response transformation & aggregation |
| Hard to monitor API usage | Centralized logging, metrics & tracing |
| Protocol mismatches | Protocol translation (REST ↔ gRPC, WebSocket, etc.) |

---

## Where Does the Load Balancer Sit with the API Gateway?

This is a crucial architectural question. The Load Balancer and API Gateway serve **different purposes** but work together in the request flow.

### Complete Request Flow

```
┌──────────────────────────────────────────────────────────────────────────────┐
│                        Full Request Architecture                            │
└──────────────────────────────────────────────────────────────────────────────┘

                          ┌───────────────┐
                          │   DNS / GSLB  │
                          │  (Route 53,   │
                          │  Cloudflare)  │
                          └──────┬────────┘
                                 │ Resolves to best region's IP
                                 ▼
                     ┌───────────────────────┐
                     │   Global Load Balancer │  ◄── Layer 4 (TCP/UDP)
                     │   (AWS NLB / GLB)      │      Distributes across
                     └───────────┬───────────┘      API Gateway instances
                                 │
              ┌──────────────────┼──────────────────┐
              ▼                  ▼                   ▼
     ┌─────────────┐   ┌─────────────┐     ┌─────────────┐
     │ API Gateway  │   │ API Gateway  │     │ API Gateway  │
     │ Instance 1   │   │ Instance 2   │     │ Instance 3   │
     │              │   │              │     │              │
     │ • Auth       │   │ • Auth       │     │ • Auth       │
     │ • Rate Limit │   │ • Rate Limit │     │ • Rate Limit │
     │ • Routing    │   │ • Routing    │     │ • Routing    │
     │ • Transform  │   │ • Transform  │     │ • Transform  │
     └──────┬──────┘   └──────┬──────┘     └──────┬──────┘
            │                  │                    │
            └──────────────────┼────────────────────┘
                               │
                               ▼
                  ┌─────────────────────────┐
                  │  Internal Load Balancer  │  ◄── Layer 7 (HTTP)
                  │  (per-service routing)   │      Routes to specific
                  └─────────┬───────────────┘      microservices
                            │
           ┌────────────────┼────────────────┐
           ▼                ▼                ▼
   ┌──────────────┐ ┌──────────────┐ ┌──────────────┐
   │  User Service │ │ Order Service│ │Payment Service│
   │   [S1] [S2]   │ │  [S1] [S2]  │ │  [S1] [S2]   │
   └──────────────┘ └──────────────┘ └──────────────┘
```

### Layer-by-Layer Breakdown

```
┌──────────────────────────────────────────────────────────────────┐
│  Layer          │  Component           │  Responsibility         │
├──────────────────────────────────────────────────────────────────┤
│  DNS Layer      │  GSLB / GeoDNS       │  Pick best region/DC    │
│  L4 (Network)   │  External LB (NLB)   │  Distribute across      │
│                 │                      │  API Gateway instances  │
│  L7 (App Edge)  │  API Gateway         │  Auth, rate limit,      │
│                 │                      │  routing, transform     │
│  L7 (Internal)  │  Internal LB (ALB)   │  Route to microservice  │
│                 │                      │  instances              │
│  Service        │  Microservice        │  Business logic         │
└──────────────────────────────────────────────────────────────────┘
```

### Key Insight: LB and API Gateway Are NOT the Same

| Feature | Load Balancer | API Gateway |
|---------|--------------|-------------|
| **Primary job** | Distribute traffic evenly | Manage, route & secure API traffic |
| **Works at** | L4 (TCP) or L7 (HTTP) | L7 (HTTP/HTTPS) only |
| **Auth / AuthZ** | ❌ No | ✅ Yes |
| **Rate limiting** | ❌ No | ✅ Yes |
| **Request transformation** | ❌ No | ✅ Yes |
| **API versioning** | ❌ No | ✅ Yes |
| **Protocol translation** | ❌ No | ✅ Yes (REST ↔ gRPC) |
| **SSL termination** | ✅ Yes | ✅ Yes |
| **Health checks** | ✅ Yes | ✅ Yes (upstream) |
| **Understands business logic** | ❌ No | Partially (routing rules) |

> **Load Balancer asks:** *"Which server should handle this?"*
> **API Gateway asks:** *"Should this request be allowed, and where does it go?"*

---

## Core Responsibilities of an API Gateway

### 1. Request Routing

Routes incoming requests to the appropriate backend microservice based on URL path, headers, or method.

```
   Client Request                       API Gateway Routes To
   ──────────────                       ────────────────────
   GET  /users/123            →         User Service
   POST /orders               →         Order Service
   GET  /products?q=phone     →         Product Service
   WS   /chat                 →         Chat Service (WebSocket)
```

### 2. Authentication & Authorization

Verifies identity and permissions **before** the request reaches any microservice.

```
┌────────┐        ┌─────────────┐        ┌──────────────┐
│ Client │──req──▶│ API Gateway │──verify▶│ Auth Service │
│        │        │             │◀─token──│ (OAuth/JWT)  │
│        │        │             │         └──────────────┘
│        │        │ ✅ Valid?   │
│        │        │ Forward req │──────────▶ Backend Service
│        │        │ ❌ Invalid? │
│        │◀─401──│ Reject      │
└────────┘        └─────────────┘
```

### 3. Rate Limiting & Throttling

Protects backend services from abuse or traffic spikes.

```
Rate Limiting Strategies:
─────────────────────────
• Fixed Window:    100 requests per minute per user
• Sliding Window:  Smooth out burst edges
• Token Bucket:    Allow short bursts, then throttle
• Leaky Bucket:    Constant drain rate, queue excess
```

### 4. Request/Response Transformation

Modifies requests before forwarding and responses before returning to the client.

- **Header injection** — Add internal headers (X-Request-ID, X-User-ID)
- **Body transformation** — Convert XML ↔ JSON
- **Response filtering** — Strip internal fields before sending to client
- **Aggregation** — Combine responses from multiple services into one

### 5. API Versioning

```
   /api/v1/users  →  User Service (v1 - legacy)
   /api/v2/users  →  User Service (v2 - current)
   /api/v3/users  →  User Service (v3 - beta)
```

### 6. Circuit Breaking

Prevents cascading failures by stopping requests to unhealthy services.

```
   State: CLOSED (normal)
      │
      │ Failures exceed threshold
      ▼
   State: OPEN (requests rejected immediately)
      │
      │ After timeout period
      ▼
   State: HALF-OPEN (allow limited test requests)
      │
      ├── Tests pass → back to CLOSED
      └── Tests fail → back to OPEN
```

### 7. Caching

Caches frequently requested responses at the gateway level to reduce backend load.

### 8. Logging, Metrics & Tracing

Centralized observability for all API traffic — request counts, latency, error rates, distributed tracing (via trace IDs).

---

## API Gateway Patterns

### 1. Single Gateway (Monolithic)

```
   Mobile App ──┐
   Web App    ──┼──▶ [API Gateway] ──▶ Microservices
   3rd Party  ──┘
```

- One gateway for all clients
- Simple but can become a bottleneck
- **Best for**: Small to medium systems

### 2. Backend for Frontend (BFF)

```
   Mobile App ──▶ [Mobile Gateway]  ──┐
                                      ├──▶ Microservices
   Web App    ──▶ [Web Gateway]    ──┘

   3rd Party  ──▶ [Partner Gateway] ──▶ Microservices
```

- Separate gateway per client type
- Each gateway tailored to client needs (mobile gets less data, web gets full payload)
- **Best for**: Multiple client types with different data needs

### 3. Gateway with Service Mesh

```
┌──────────────────────────────────────────────────────────┐
│                     Service Mesh                          │
│                                                          │
│  [API Gateway] ──▶ [Sidecar] ↔ Service A                │
│                    [Sidecar] ↔ Service B                 │
│                    [Sidecar] ↔ Service C                 │
│                                                          │
│  Sidecars handle: mTLS, retries, circuit breaking,       │
│  observability for service-to-service communication      │
└──────────────────────────────────────────────────────────┘
```

- API Gateway handles **north-south traffic** (client ↔ system)
- Service Mesh handles **east-west traffic** (service ↔ service)
- **Best for**: Large-scale microservice architectures

---

## API Gateway vs Reverse Proxy vs Load Balancer

```
┌──────────────────────────────────────────────────────────────────────────┐
│                    How They Relate                                       │
│                                                                          │
│   Reverse Proxy  ⊂  Load Balancer  ⊂  API Gateway                      │
│                                                                          │
│   • Reverse Proxy: Forward requests to backend servers                   │
│   • Load Balancer: Reverse Proxy + distribute traffic evenly             │
│   • API Gateway:   Load Balancer + auth + rate limit + transform + more  │
└──────────────────────────────────────────────────────────────────────────┘
```

| Feature | Reverse Proxy | Load Balancer | API Gateway |
|---------|--------------|---------------|-------------|
| Forward requests | ✅ | ✅ | ✅ |
| Distribute traffic | ❌ | ✅ | ✅ |
| SSL termination | ✅ | ✅ | ✅ |
| Caching | ✅ | ❌ | ✅ |
| Auth / Rate limiting | ❌ | ❌ | ✅ |
| Request transformation | ❌ | ❌ | ✅ |
| API versioning | ❌ | ❌ | ✅ |
| Protocol translation | ❌ | ❌ | ✅ |

---

## Real-World API Gateway Tools

| Tool | Type | Key Features |
|------|------|-------------|
| **AWS API Gateway** | Cloud managed | REST/WebSocket/HTTP APIs, Lambda integration, usage plans |
| **Kong** | Open source / Enterprise | Plugin-based, Lua extensible, Kubernetes-native |
| **NGINX** | Open source | Reverse proxy + API gateway capabilities, high performance |
| **Apigee** | Cloud managed (Google) | Full lifecycle API management, analytics, monetization |
| **Azure API Management** | Cloud managed | Policy engine, developer portal, hybrid deployment |
| **Envoy** | Open source | Service mesh sidecar, advanced L7 routing, gRPC-native |
| **Traefik** | Open source | Auto-discovery, Let's Encrypt, cloud-native |
| **Zuul** | Open source (Netflix) | Dynamic routing, filters, JVM-based |

---

## Common Interview Questions

### Q1: What's the difference between an API Gateway and a Load Balancer?

**LB** distributes traffic — it doesn't understand API semantics. **API Gateway** manages the full API lifecycle — auth, rate limiting, transformation, routing, versioning. In production, you use **both**: LB in front to distribute across gateway instances, and the gateway handles the smart routing.

### Q2: Can an API Gateway be a single point of failure?

Yes — mitigate by:
- Deploying **multiple gateway instances** behind a load balancer
- Using **auto-scaling** to handle traffic spikes
- Deploying across **multiple availability zones**
- Having **health checks** and automatic failover

### Q3: API Gateway vs Service Mesh — when to use which?

- **API Gateway**: North-south traffic (external clients → your system)
- **Service Mesh**: East-west traffic (service-to-service within your system)
- In large systems, use **both together**

### Q4: How do you handle API Gateway performance?

- **Caching** at the gateway level
- **Connection pooling** to backend services
- **Async processing** for non-critical tasks
- Keep gateway logic **lightweight** — no business logic
- **Horizontal scaling** with LB in front

### Q5: What is the BFF pattern and when would you use it?

Backend for Frontend — a dedicated gateway per client type (mobile, web, IoT). Use when different clients need different data shapes, protocols, or optimization strategies. Avoids a "one-size-fits-all" gateway that serves no client well.

---

## Key Takeaways for Interviews

1. **API Gateway ≠ Load Balancer** — Gateway is smarter; LB sits in front of it
2. **Place LB → API Gateway → Internal LB → Services** in your architecture
3. **BFF pattern** for multi-client systems (mobile, web, partners)
4. **Gateway handles cross-cutting concerns** — auth, rate limit, logging, transform
5. **Don't put business logic in the gateway** — keep it as a thin routing layer
6. **API Gateway can be a bottleneck** — scale horizontally behind a load balancer
7. **North-south vs East-west** — Gateway for external, Service Mesh for internal
8. **Always mention observability** — centralized logging & distributed tracing

---

*Last Updated: 2026-05-26*
