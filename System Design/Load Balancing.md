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

Global Server Load Balancing (GSLB) distributes traffic across **multiple geographically dispersed data centers or regions**. Unlike traditional load balancers that operate within a single data center, GSLB works at a global level to route users to the best-performing and closest data center.

### How GSLB Works

GSLB primarily operates through **DNS-based routing**. When a user makes a request, the GSLB-enabled DNS server resolves the domain to the IP address of the optimal data center based on various factors.

```
┌─────────────────────────────────────────────────────────────────────────┐
│                          GSLB Request Flow                             │
└─────────────────────────────────────────────────────────────────────────┘

  User (India)                                   User (USA)
      │                                              │
      ▼                                              ▼
 ┌──────────┐                                   ┌──────────┐
 │  Browser  │                                   │  Browser  │
 └────┬─────┘                                   └────┬─────┘
      │ 1. DNS Query:                                │ 1. DNS Query:
      │    app.example.com                           │    app.example.com
      ▼                                              ▼
 ┌──────────────────────────────────────────────────────────┐
 │                   GSLB / GeoDNS Server                   │
 │                                                          │
 │  ┌─────────────────────────────────────────────────┐     │
 │  │ Decision Engine:                                │     │
 │  │  • Client geo-location (via IP)                 │     │
 │  │  • Data center health status                    │     │
 │  │  • Current server load per region               │     │
 │  │  • Network latency estimates                    │     │
 │  └─────────────────────────────────────────────────┘     │
 └──────────┬───────────────────────────────┬───────────────┘
            │                               │
            │ 2. Returns IP:                │ 2. Returns IP:
            │    Mumbai DC (103.x.x.x)      │    Virginia DC (54.x.x.x)
            ▼                               ▼
 ┌────────────────────┐          ┌────────────────────┐
 │  Mumbai Data Center │          │ Virginia Data Center│
 │    (Asia Region)    │          │    (US-East Region)  │
 │                     │          │                     │
 │  ┌──────────────┐  │          │  ┌──────────────┐  │
 │  │ Local LB (L7)│  │          │  │ Local LB (L7)│  │
 │  └──┬───┬───┬───┘  │          │  └──┬───┬───┬───┘  │
 │     ▼   ▼   ▼      │          │     ▼   ▼   ▼      │
 │   [S1] [S2] [S3]   │          │   [S4] [S5] [S6]   │
 └────────────────────┘          └────────────────────┘
```

### GSLB Routing Strategies

| Strategy | How It Works | Best For |
|----------|-------------|----------|
| **Geographic (GeoDNS)** | Routes based on client's geographic location (IP-based) | Reducing latency, data sovereignty compliance |
| **Latency-based** | Routes to the data center with lowest measured latency | Performance-critical applications |
| **Weighted** | Distributes traffic by assigned weights (e.g., 70/30 split) | Gradual region migrations, canary deployments |
| **Failover (Active-Passive)** | All traffic to primary; secondary only on failure | Disaster recovery |
| **Round Robin (Multi-Value)** | Returns multiple IPs; client picks one | Simple global distribution |
| **Geoproximity** | Routes based on geographic distance with bias adjustments | Fine-tuning traffic between nearby regions |

### GSLB Health Monitoring

GSLB continuously monitors the health of each data center to make intelligent routing decisions:

```
┌────────────────────────────────────────────────────────────────┐
│                    GSLB Health Check System                     │
└────────────────────────────────────────────────────────────────┘

         ┌──────────────────────┐
         │    GSLB Controller   │
         │                      │
         │  Health Check Agent  │
         └──┬──────┬──────┬────┘
            │      │      │
   ┌────────┘      │      └────────┐
   │ Probe         │ Probe         │ Probe
   │ every 30s     │ every 30s     │ every 30s
   ▼               ▼               ▼
┌──────┐      ┌──────┐       ┌──────┐
│DC - A │      │DC - B │       │DC - C │
│ ✅ UP │      │ ✅ UP │       │ ❌ DOWN│
│       │      │       │       │       │
│Load:  │      │Load:  │       │Load:  │
│  40%  │      │  65%  │       │  N/A  │
└──────┘      └──────┘       └──────┘
                                 │
                    ┌────────────┘
                    ▼
        Traffic rerouted to DC-A
        and DC-B automatically
```

**Types of health checks performed:**
- **HTTP/HTTPS checks** — Verify application endpoints return 200 OK
- **TCP checks** — Ensure ports are open and accepting connections
- **DNS checks** — Validate that local DNS resolvers are functioning
- **Custom scripts** — Run application-specific validation logic
- **Multi-layer checks** — Check not just the LB, but the actual application behind it

### Disaster Recovery with GSLB

GSLB is a cornerstone of disaster recovery (DR) strategies:

```
┌──────────────────────────────────────────────────────────────────┐
│               GSLB Disaster Recovery Failover                    │
└──────────────────────────────────────────────────────────────────┘

     Normal Operation:                  During Disaster:
     ─────────────────                  ────────────────

     100% traffic                       0% traffic
         │                                  │
         ▼                                  ▼
  ┌──────────────┐                   ┌──────────────┐
  │  Primary DC  │                   │  Primary DC  │
  │  (US-East)   │ ── Replication ─→ │  (US-East)   │
  │   ✅ Active  │                   │   ❌ DOWN    │
  └──────────────┘                   └──────────────┘
                                            │
         │                          GSLB detects failure
         ▼                          (within 30-60 seconds)
  ┌──────────────┐                          │
  │ Secondary DC │                          ▼
  │  (EU-West)   │                   ┌──────────────┐
  │  🟡 Standby  │                   │ Secondary DC │
  │   0% traffic │                   │  (EU-West)   │
  └──────────────┘                   │  ✅ Active   │
                                     │ 100% traffic │
                                     └──────────────┘
```

**Failover steps:**
1. GSLB detects primary DC is unhealthy (failed health checks)
2. DNS TTL expires (typically 30–60 seconds with low TTL settings)
3. New DNS queries resolve to secondary DC's IP
4. Traffic shifts to secondary DC automatically
5. When primary recovers, traffic can be gradually shifted back (failback)

### GSLB vs Traditional Load Balancer

| Feature | Traditional LB | GSLB |
|---------|---------------|------|
| **Scope** | Single data center | Multiple data centers / regions |
| **Mechanism** | Direct traffic routing (IP/port) | DNS-based routing |
| **Latency reduction** | Within DC only | Routes to geographically nearest DC |
| **Disaster recovery** | Handles server failures | Handles entire data center failures |
| **Protocol** | L4 (TCP/UDP) or L7 (HTTP) | DNS layer |
| **Failover speed** | Milliseconds | Seconds (depends on DNS TTL) |
| **Examples** | NGINX, HAProxy, AWS ALB | AWS Route 53, Cloudflare, Akamai GTM |

### Anycast-Based GSLB

Modern GSLB solutions (like Cloudflare) use **Anycast** — a networking technique where the same IP address is announced from multiple locations worldwide:

```
┌───────────────────────────────────────────────────────────────┐
│                  Anycast-Based GSLB                           │
└───────────────────────────────────────────────────────────────┘

    Same IP: 198.51.100.1 advertised from all edge locations

  User (Tokyo)        User (London)       User (São Paulo)
       │                    │                    │
       │ BGP routes to      │ BGP routes to      │ BGP routes to
       │ nearest node       │ nearest node       │ nearest node
       ▼                    ▼                    ▼
  ┌─────────┐         ┌─────────┐         ┌─────────┐
  │ Tokyo   │         │ London  │         │São Paulo│
  │  Edge   │         │  Edge   │         │  Edge   │
  │  Node   │         │  Node   │         │  Node   │
  └────┬────┘         └────┬────┘         └────┬────┘
       │                    │                    │
       └────────────┬───────┴────────────────────┘
                    ▼
            ┌──────────────┐
            │ Origin Server│
            │ (if not cached│
            │  at the edge) │
            └──────────────┘
```

**Anycast advantages over DNS-based GSLB:**
- **No TTL dependency** — Routing changes are instant via BGP updates
- **DDoS resilience** — Attack traffic is absorbed across all edge nodes
- **Simpler client logic** — Single IP, no client-side DNS caching issues

### Real-World GSLB Tools & Services

| Service | Provider | Key Features |
|---------|----------|-------------|
| **Route 53** | AWS | GeoDNS, latency-based, failover, health checks, weighted routing |
| **Cloud DNS** | GCP | Anycast DNS, geo-location policies, DNSSEC |
| **Traffic Manager** | Azure | Priority, weighted, performance, geographic routing |
| **Cloudflare** | Cloudflare | Anycast, DDoS protection, global edge network |
| **Akamai GTM** | Akamai | Advanced traffic management, liveness checks |
| **NS1** | IBM/NS1 | Filter chain routing, real-time telemetry |

### GSLB — Key Interview Points

1. **GSLB operates at the DNS layer** — It doesn't route packets; it resolves domain names to the best data center's IP
2. **DNS TTL is critical** — Low TTL (30–60s) enables faster failover but increases DNS query load
3. **Combine with local LB** — GSLB picks the data center; a local L4/L7 LB distributes within it
4. **Data replication matters** — GSLB is useless if the secondary DC doesn't have up-to-date data
5. **Anycast vs GeoDNS** — Anycast is faster for failover; GeoDNS gives more control over routing policies
6. **Split-brain problem** — When both DCs think they are primary; mitigate with consensus protocols or external arbiters

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
