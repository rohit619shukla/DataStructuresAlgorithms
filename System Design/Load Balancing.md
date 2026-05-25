# Load Balancing

## What is Load Balancing?

Load balancing is the process of distributing incoming network traffic across multiple servers to ensure no single server is overwhelmed. It improves **availability**, **reliability**, and **performance** of applications.

A load balancer sits between clients and backend servers, acting as a "traffic cop" that routes requests efficiently.

---

## Why Do We Need Load Balancing?

| Problem | How Load Balancing Solves It |
|---------|------------------------------|
| Single point of failure | Distributes traffic; if one server dies, others handle requests |
| Server overload | Spreads requests evenly across servers |
| High latency | Routes to the nearest/fastest server |
| Scaling limitations | Enables horizontal scaling by adding more servers |

---

## Where Can Load Balancers Be Placed?

```
Client → [LB] → Web Servers → [LB] → App Servers → [LB] → Database Servers
```

1. **Between client and web server**
2. **Between web server and application server**
3. **Between application server and database**

---

## Types of Load Balancers

### 1. Hardware Load Balancers
- Physical devices (e.g., F5, Citrix NetScaler)
- Expensive but high performance
- Used in enterprise/on-premise setups

### 2. Software Load Balancers
- Programs running on commodity hardware
- Examples: **NGINX**, **HAProxy**, **Envoy**
- Cost-effective, flexible, and easy to configure

### 3. Cloud Load Balancers
- Managed services by cloud providers
- Examples: **AWS ALB/NLB/CLB**, **GCP Cloud Load Balancer**, **Azure Load Balancer**
- Auto-scaling, no maintenance overhead

---

## Load Balancing at Different OSI Layers

### Layer 4 (Transport Layer)
- Routes based on **IP address and TCP/UDP port**
- Faster — doesn't inspect packet content
- Example: AWS NLB

### Layer 7 (Application Layer)
- Routes based on **HTTP headers, URL path, cookies, request content**
- Smarter — can do content-based routing
- Example: AWS ALB, NGINX

| Feature | Layer 4 | Layer 7 |
|---------|---------|---------|
| Speed | Faster | Slightly slower |
| Intelligence | Basic | Content-aware |
| SSL Termination | No | Yes |
| Use Case | Raw TCP/UDP traffic | HTTP/HTTPS APIs |

---

## Load Balancing Algorithms

### 1. Round Robin
- Requests distributed sequentially to each server in order
- Simple but doesn't account for server load
- **Best for**: Servers with equal capacity and stateless requests

### 2. Weighted Round Robin
- Assigns weights to servers based on capacity
- Server with weight 3 gets 3x more requests than weight 1
- **Best for**: Heterogeneous server fleet

### 3. Least Connections
- Routes to the server with fewest active connections
- **Best for**: Long-lived connections (WebSockets, database connections)

### 4. Weighted Least Connections
- Combines least connections with server weights
- **Best for**: Mixed server capacities with varying connection durations

### 5. IP Hash
- Hashes client IP to determine which server gets the request
- Same client always goes to same server (sticky sessions)
- **Best for**: Session persistence without cookies

### 6. Least Response Time
- Routes to the server with fastest response time + fewest connections
- **Best for**: Latency-sensitive applications

### 7. Random
- Randomly selects a server
- Statistically even distribution at scale
- **Best for**: Simple setups with identical servers

### 8. Consistent Hashing
- Maps servers and requests onto a hash ring
- Minimizes redistribution when servers are added/removed
- **Best for**: Caching layers, distributed systems

---

## Health Checks

Load balancers continuously monitor server health:

- **Active Health Checks**: LB periodically pings servers (HTTP GET /health)
- **Passive Health Checks**: LB monitors responses; marks server unhealthy after X failures

```
Healthy Server   → Receives traffic
Unhealthy Server → Removed from pool → Periodically re-checked → Added back when healthy
```

---

## Session Persistence (Sticky Sessions)

Some applications need the same client to reach the same server (e.g., shopping cart in memory).

**Approaches:**
1. **Cookie-based**: LB inserts a cookie identifying the server
2. **IP-based**: Route by client IP hash
3. **URL/Header-based**: Use session ID in URL or header

**Trade-off**: Sticky sessions reduce the effectiveness of load balancing and can create hotspots.

**Better Alternative**: Store session state externally (Redis, Memcached) so any server can handle any request.

---

## Redundancy & High Availability of Load Balancers

A single load balancer is itself a single point of failure. Solution:

```
        [Active LB] ←── Heartbeat ──→ [Passive LB]
              ↓                              ↓
         (Serves traffic)          (Takes over on failure)
```

- **Active-Passive**: Standby LB takes over if active fails (using floating IP/VIP)
- **Active-Active**: Both LBs serve traffic simultaneously (DNS round robin)

---

## Global Server Load Balancing (GSLB)

Distributes traffic across multiple data centers/regions:

- Uses **DNS-based routing** (GeoDNS)
- Routes users to nearest data center
- Handles disaster recovery (failover to another region)
- Examples: AWS Route 53, Cloudflare, Akamai

---

## SSL/TLS Termination

Load balancers can handle SSL decryption:

```
Client --[HTTPS]--> Load Balancer --[HTTP]--> Backend Servers
```

**Benefits:**
- Offloads CPU-intensive encryption from backend servers
- Centralized certificate management
- Backend servers communicate over faster unencrypted connections

---

## Common Interview Questions

### Q1: How would you design a load balancer?
**Key points:**
- Accept incoming connections on a VIP (Virtual IP)
- Maintain a server pool with health checks
- Apply chosen algorithm to route requests
- Support both L4 and L7 routing
- Handle failure detection and failover

### Q2: Round Robin vs Least Connections — when to use which?
- **Round Robin**: Stateless, quick requests, homogeneous servers
- **Least Connections**: Varying request durations, long-lived connections

### Q3: How to handle a load balancer failure?
- Deploy in Active-Passive or Active-Active pairs
- Use floating IP / VIP that can be reassigned
- DNS failover for multi-region setups

### Q4: What's the difference between L4 and L7 load balancing?
- L4 routes by IP/port — fast, simple
- L7 routes by content (URL, headers) — smart, flexible

### Q5: How do you ensure zero downtime during deployments?
- Rolling deployment with health checks
- LB drains connections from old servers before removing them
- Blue-green or canary deployments with LB traffic shifting

---

## Real-World Architecture Example

```
                    ┌──────────────┐
                    │   DNS/GSLB   │
                    └──────┬───────┘
                           │
              ┌────────────┼────────────┐
              ▼                          ▼
    ┌──────────────┐          ┌──────────────┐
    │  Region A LB │          │  Region B LB │
    └──────┬───────┘          └──────┬───────┘
           │                         │
    ┌──────┼──────┐           ┌──────┼──────┐
    ▼      ▼      ▼           ▼      ▼      ▼
  [S1]   [S2]   [S3]       [S4]   [S5]   [S6]
```

---

## Key Takeaways for Interviews

1. **Always mention** where you'd place LBs in your design
2. **Justify your algorithm choice** based on traffic pattern
3. **Address single point of failure** — redundant LBs
4. **Mention health checks** — how unhealthy servers are detected
5. **Know the L4 vs L7 trade-off** — speed vs intelligence
6. **Sticky sessions are a trade-off** — prefer stateless architecture
7. **SSL termination at LB** — offloads backend, centralizes certs
8. **Global load balancing** — for multi-region, use DNS-based routing

---

## Tools & Technologies to Reference

| Tool | Type | Notes |
|------|------|-------|
| NGINX | Software LB | Also a reverse proxy and web server |
| HAProxy | Software LB | High performance TCP/HTTP LB |
| Envoy | Software LB | Service mesh, sidecar proxy |
| AWS ALB | Cloud (L7) | HTTP/HTTPS, path-based routing |
| AWS NLB | Cloud (L4) | Ultra-low latency, TCP/UDP |
| Cloudflare | GSLB/CDN | Global anycast network |
| Traefik | Software LB | Cloud-native, auto-discovery |

---

*Last Updated: 2026-05-25*
