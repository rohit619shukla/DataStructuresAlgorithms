# Client-Server Communication (REST, gRPC, WebSockets, GraphQL)

## What is Client-Server Communication?

Client-server communication is **how clients (browsers, mobile apps, other services) exchange data with servers**. The choice of communication protocol directly impacts your system's performance, scalability, developer experience, and real-time capabilities.

Think of it as choosing a **mode of conversation** — a letter (REST), a phone call (WebSockets), a walkie-talkie with a strict script (gRPC), or a custom order form (GraphQL).

---

## Why Does the Protocol Choice Matter?

| Concern | Why It Matters in System Design |
|---------|-------------------------------|
| Latency | Some protocols add overhead per request; others keep connections open |
| Bandwidth | Over-fetching / under-fetching wastes network resources |
| Real-time needs | Not all protocols support server push or bidirectional streaming |
| Inter-service communication | Microservices need fast, typed, low-overhead internal calls |
| Client diversity | Mobile, web, IoT clients have different data and bandwidth needs |
| Developer experience | Schema enforcement, tooling, and debugging differ across protocols |

---

## The Four Protocols at a Glance

```
┌──────────────────────────────────────────────────────────────────────┐
│                   Client-Server Communication Landscape              │
└──────────────────────────────────────────────────────────────────────┘

   ┌─────────┐     REST (HTTP/1.1 or HTTP/2)      ┌──────────┐
   │         │────── GET /users/123 ──────────────▶│          │
   │         │◀───── JSON response ────────────────│          │
   │         │                                     │          │
   │         │     GraphQL (HTTP POST)             │          │
   │         │────── query { user(id:123) } ──────▶│          │
   │ Client  │◀───── exact fields returned ────────│  Server  │
   │         │                                     │          │
   │         │     gRPC (HTTP/2)                   │          │
   │         │────── binary protobuf ─────────────▶│          │
   │         │◀───── binary protobuf ──────────────│          │
   │         │                                     │          │
   │         │     WebSocket (WS/WSS)              │          │
   │         │◀═══════ persistent duplex ═════════▶│          │
   └─────────┘                                     └──────────┘
```

---

## 1. REST (Representational State Transfer)

### What is REST?

REST is an **architectural style** for designing APIs over HTTP. It models everything as **resources** identified by URLs, manipulated using standard HTTP methods.

```
   Resource: /users/123

   GET     /users/123      →  Read user 123
   POST    /users           →  Create a new user
   PUT     /users/123      →  Replace user 123 entirely
   PATCH   /users/123      →  Partially update user 123
   DELETE  /users/123      →  Delete user 123
```

### Key Characteristics

| Characteristic | Details |
|---------------|---------|
| **Protocol** | HTTP/1.1 or HTTP/2 |
| **Data format** | JSON (most common), XML, plain text |
| **Stateless** | Each request carries all needed context (no server-side session) |
| **Caching** | Built-in via HTTP cache headers (ETag, Cache-Control, Last-Modified) |
| **Contract** | Loosely defined — often documented via OpenAPI/Swagger |
| **Discoverability** | HATEOAS (links in response to guide next actions) — rarely used in practice |

### REST Constraints (Know These for Interviews)

```
   1. Client-Server        →  Separation of concerns
   2. Stateless             →  No session on server; each request is self-contained
   3. Cacheable             →  Responses must declare cacheability
   4. Uniform Interface     →  Standard HTTP methods + resource URIs
   5. Layered System        →  Client doesn't know if it's talking to LB, gateway, or origin
   6. Code on Demand (opt)  →  Server can send executable code (rarely used)
```

### REST — The Good and The Bad

```
   ✅ Strengths                          ❌ Weaknesses
   ─────────────                          ──────────────
   • Universal (every language/tool)      • Over-fetching (get full object when
   • Simple to understand and debug         you need 2 fields)
   • Excellent caching support            • Under-fetching (need 3 calls to
   • Mature tooling (Postman, Swagger)      build one screen)
   • Stateless = easy horizontal scaling  • No built-in streaming
   • Browser-native                       • Chatty for complex data needs
                                          • No strict contract enforcement
```

### When to Use REST

- **Public-facing APIs** — universal client support
- **CRUD-heavy applications** — natural resource mapping
- **Simple microservices** — straightforward request-response
- **When caching matters** — HTTP caching works out of the box

---

## 2. GraphQL

### What is GraphQL?

GraphQL is a **query language for APIs** developed by Facebook. The client specifies **exactly** what data it needs, and the server returns **nothing more, nothing less**.

```
   ┌────────────────────────────────────────────────────────────────┐
   │  REST: Multiple calls, fixed response shapes                   │
   │                                                                │
   │  GET /users/123          → { id, name, email, address, ... }  │
   │  GET /users/123/posts    → [ { id, title, body, ... }, ... ]  │
   │  GET /users/123/friends  → [ { id, name, ... }, ... ]         │
   │                                                                │
   │  3 round trips, lots of unused fields                          │
   └────────────────────────────────────────────────────────────────┘

   ┌────────────────────────────────────────────────────────────────┐
   │  GraphQL: Single call, exact response shape                    │
   │                                                                │
   │  POST /graphql                                                 │
   │  query {                                                       │
   │    user(id: 123) {                                             │
   │      name                                                      │
   │      posts(last: 3) { title }                                  │
   │      friends(first: 5) { name }                                │
   │    }                                                           │
   │  }                                                             │
   │                                                                │
   │  1 round trip, only requested fields returned                  │
   └────────────────────────────────────────────────────────────────┘
```

### Core Concepts

```
   ┌──────────────┐
   │   Schema     │  ← Strongly typed contract (SDL)
   ├──────────────┤
   │   Query      │  ← Read data (like GET)
   │   Mutation   │  ← Write data (like POST/PUT/DELETE)
   │   Subscription│ ← Real-time updates (over WebSocket)
   ├──────────────┤
   │   Resolvers  │  ← Functions that fetch data for each field
   └──────────────┘
```

### GraphQL Engine

Before a query ever reaches your resolvers, it passes through the **GraphQL Engine** — the runtime layer that sits between the client and your business logic.

```
   Client Request (POST /graphql)
        │
        ▼
   ┌─────────────────────────────────────────────┐
   │            GraphQL Engine                    │
   │                                              │
   │  1. Parsing        → Parse query string      │
   │                      into an AST             │
   │                                              │
   │  2. Validation     → Check AST against       │
   │                      the schema (types,      │
   │                      fields, arguments)       │
   │                                              │
   │  3. Depth Limiting → Reject queries that     │
   │                      exceed max nesting       │
   │                      depth (e.g., depth > 5)  │
   │                                              │
   │  4. Complexity     → Score each field/edge,   │
   │     Analysis         reject if total cost     │
   │                      exceeds threshold        │
   │                                              │
   │  5. Rate Limiting  → Throttle per-client      │
   │                      query volume             │
   │                                              │
   │  6. Execution      → Walk the AST, invoke     │
   │                      resolvers, assemble      │
   │                      response                 │
   └─────────────────────────────────────────────┘
        │
        ▼
   JSON Response → { "data": { ... } }
```

**Why it matters in interviews:** The engine is how GraphQL defends against **deeply nested malicious queries** (the DoS weakness listed below). Without depth/complexity limits, a query like `{ user { friends { friends { friends { ... } } } } }` could explode into millions of DB calls. Libraries like `graphql-depth-limit` and `graphql-query-complexity` plug into this engine layer to enforce these safeguards.

### GraphQL — The Good and The Bad

```
   ✅ Strengths                          ❌ Weaknesses
   ─────────────                          ──────────────
   • No over-fetching or under-fetching  • Complex server implementation
   • Single endpoint, single round trip  • Hard to cache (POST requests,
   • Strongly typed schema (SDL)           dynamic queries)
   • Great for diverse clients           • N+1 query problem in resolvers
     (mobile gets less, web gets more)   • Security: deeply nested queries
   • Built-in introspection & tooling      can DoS the server
   • Subscriptions for real-time         • Overkill for simple CRUD APIs
```

### N+1 Problem and Solution

```
   The Problem:
   ────────────
   query { users { name posts { title } } }

   Resolver executes:
   1. SELECT * FROM users              → 10 users
   2. SELECT * FROM posts WHERE user=1 → per user
   3. SELECT * FROM posts WHERE user=2
   ... (10 + 1 = 11 queries!)

   The Solution: DataLoader (batching + caching)
   ──────────────────────────────────────────────
   1. SELECT * FROM users                         → 10 users
   2. SELECT * FROM posts WHERE user IN (1,2,...10) → 1 batched query
   Total: 2 queries
```

### When to Use GraphQL

- **Multiple client types** (mobile, web, IoT) needing different data shapes
- **Complex, nested data** — fetch a graph of related entities in one call
- **Rapidly evolving frontends** — clients change data needs without backend changes
- **API aggregation layer** — stitch multiple backend services into one graph

---

## 3. gRPC (Google Remote Procedure Call)

### What is gRPC?

gRPC is a **high-performance, binary RPC framework** built on HTTP/2 and Protocol Buffers (protobuf). The client calls a method on the server **as if it were a local function**.

```
   ┌──────────────────────────────────────────────────────────────┐
   │                     How gRPC Works                            │
   └──────────────────────────────────────────────────────────────┘

   Step 1: Define the contract (.proto file)
   ──────────────────────────────────────────
   service UserService {
     rpc GetUser (UserRequest) returns (UserResponse);
   }
   → Both sides agree on method name, input & output shapes upfront.

   Step 2: Generate code (protoc compiler)
   ────────────────────────────────────────
   protoc --go_out=. user.proto
   → Generates two things from the same .proto:
     • Client Stub  — a class to call remote methods as if local
     • Server Skeleton — an interface you implement with real logic
   → Works for Go, Java, Python, C#, etc. — all from one .proto.

   Step 3: Client calls like a local function
   ───────────────────────────────────────────
   user = userService.GetUser(UserRequest(id=123))

   Looks local, but here's what the STUB does under the hood:

   ┌────────────┐                                    ┌────────────┐
   │ Your Code   │                                    │  Server     │
   │             │                                    │  (Impl)     │
   │ calls stub ─┤                                    │             │
   │             │  1. Serialize to Protobuf binary   │             │
   │  ┌───────┐  │──────────────────────────────────▶│  ┌───────┐  │
   │  │ Stub  │  │        (HTTP/2 transport)          │  │ Skel  │  │
   │  └───────┘  │◀──────────────────────────────────│  └───────┘  │
   │             │  4. Deserialize response binary    │             │
   │ gets result │                                    │             │
   └────────────┘                                    └────────────┘

   What happens in order:
   1. Stub serializes UserRequest(id=123) → protobuf binary (~10x smaller than JSON)
   2. Binary sent over HTTP/2 (multiplexed, single persistent connection)
   3. Server deserializes → runs your logic (e.g., DB lookup) → builds UserResponse
   4. UserResponse serialized to binary → sent back over same HTTP/2 connection
   5. Stub deserializes → returns UserResponse object to your code

   The stub hides ALL the complexity — serialization, networking, deserialization.
   Your code just calls a function; gRPC handles the rest.
```

### gRPC Streaming Modes

```
   ┌──────────────────────────────────────────────────────────────────┐
   │  Mode                │  Client        │  Server        │ Use    │
   ├──────────────────────────────────────────────────────────────────┤
   │  Unary               │  1 request  →  │  1 response    │ CRUD   │
   │  Server Streaming    │  1 request  →  │  N responses   │ Feeds  │
   │  Client Streaming    │  N requests →  │  1 response    │ Upload │
   │  Bidirectional       │  N requests ↔  │  N responses   │ Chat   │
   └──────────────────────────────────────────────────────────────────┘

   Unary (simple RPC):
   Client ──req──▶ Server ──resp──▶ Client

   Server Streaming:
   Client ──req──▶ Server ──resp1──▶──resp2──▶──resp3──▶ Client

   Client Streaming:
   Client ──req1──▶──req2──▶──req3──▶ Server ──resp──▶ Client

   Bidirectional Streaming:
   Client ◀──────── messages ────────▶ Server
          (both send independently)
```

### Why HTTP/2 Matters for gRPC

```
   HTTP/1.1                          HTTP/2
   ────────                          ──────
   • Text-based headers              • Binary framing (smaller, faster)
   • One request per connection      • Multiplexing (many streams on 1 conn)
   • No server push                  • Server push supported
   • Head-of-line blocking           • Stream-level flow control
   • New TCP conn per request        • Single persistent connection
```

### gRPC — The Good and The Bad

```
   ✅ Strengths                          ❌ Weaknesses
   ─────────────                          ──────────────
   • 2-10x faster than REST/JSON        • No native browser support
   • Strict contract (protobuf schema)     (need gRPC-Web proxy)
   • Code generation in 10+ languages    • Not human-readable (binary)
   • Bi-directional streaming            • Harder to debug (no curl)
   • Built-in deadlines, cancellation,   • Steeper learning curve
     retries, and flow control           • Limited tooling vs REST
   • HTTP/2 multiplexing                 • Tight coupling between
                                           client and server versions
```

### When to Use gRPC

- **Microservice-to-microservice** communication (internal APIs)
- **Low-latency, high-throughput** requirements
- **Polyglot systems** — auto-generate clients in any language from one .proto
- **Streaming data** — real-time feeds, telemetry, log streaming
- **Mobile clients** with limited bandwidth (binary = smaller payloads)

---

## 4. WebSockets

### Quick Summary

WebSockets provide a **full-duplex, persistent connection** over TCP. After an HTTP upgrade handshake, both client and server can push messages freely.

> For a deep dive on WebSockets (scaling, security, connection management, heartbeats), see the dedicated **[WebSockets.md](WebSockets.md)** file.

### Key Points for Comparison

| Aspect | Details |
|--------|---------|
| **Protocol** | WS / WSS (starts as HTTP, upgrades to WebSocket) |
| **Direction** | Full-duplex (bidirectional) |
| **Connection** | Persistent — stays open until explicitly closed |
| **Data format** | Text (JSON) or binary frames |
| **Overhead** | Minimal (~2-14 bytes per frame vs ~800 bytes HTTP headers) |
| **Statefulness** | Stateful — makes horizontal scaling harder |

### When to Use WebSockets

- **Chat / messaging** — bidirectional, real-time
- **Collaborative editing** — cursor sync, live updates
- **Online gaming** — low-latency state synchronization
- **Live dashboards** — real-time data push
- **NOT for** simple request-response or CRUD operations

---

## Head-to-Head Comparison

### Feature Matrix

| Feature | REST | GraphQL | gRPC | WebSocket |
|---------|------|---------|------|-----------|
| **Protocol** | HTTP/1.1 or 2 | HTTP (POST) | HTTP/2 | WS (TCP) |
| **Data format** | JSON/XML | JSON | Protobuf (binary) | Text/Binary |
| **Direction** | Request → Response | Request → Response | Unary + Streaming | Full-duplex |
| **Contract** | Loose (OpenAPI) | Strong (SDL schema) | Strong (.proto) | None |
| **Caching** | ✅ Native HTTP | ❌ Hard (POST-based) | ❌ Manual | ❌ N/A |
| **Browser support** | ✅ Native | ✅ Native | ❌ Needs proxy | ✅ Native |
| **Streaming** | ❌ No | ✅ Subscriptions | ✅ Native (4 modes) | ✅ Native |
| **Performance** | Medium | Medium | High | High |
| **Human-readable** | ✅ Yes | ✅ Yes | ❌ No (binary) | ✅ Yes (text) |
| **Code generation** | Optional | Optional | Built-in | N/A |
| **Learning curve** | Low | Medium | High | Medium |

### Performance Comparison

```
   Payload Size (same data):
   ─────────────────────────
   REST (JSON):     ~1,000 bytes    ████████████████████
   GraphQL (JSON):  ~600 bytes      ████████████
   gRPC (Protobuf): ~100 bytes      ██
   WebSocket frame: ~100 bytes      ██  (after connection established)

   Latency (typical request):
   ──────────────────────────
   REST:       ~50-200ms     ████████████████
   GraphQL:    ~50-200ms     ████████████████  (but fewer round trips)
   gRPC:       ~5-50ms       ████
   WebSocket:  ~1-10ms       ██  (after connection established)

   Note: These are approximate — actual numbers depend on network,
   payload, and implementation.
```

### Decision Flowchart

```
   What are you building?
        │
        ├── External public API?
        │       │
        │       ├── Diverse clients, complex data? → GraphQL
        │       └── Simple CRUD, cacheable?        → REST
        │
        ├── Internal microservice communication?
        │       │
        │       ├── High performance, streaming?   → gRPC
        │       └── Simple, quick to build?        → REST
        │
        ├── Real-time bidirectional?
        │       │
        │       └── Chat, gaming, collab editing?  → WebSocket
        │
        └── Real-time server push only?
                │
                └── Notifications, feeds?          → SSE (or GraphQL Subscriptions)
```

---

## Mixing Protocols in Real Systems

In production, you almost **never use just one protocol**. Here's how they work together:

```
┌──────────────────────────────────────────────────────────────────────────┐
│                    Real-World Architecture                                │
└──────────────────────────────────────────────────────────────────────────┘

   ┌──────────┐    ┌──────────┐    ┌──────────┐
   │ Web App  │    │ Mobile   │    │ Partner  │
   └────┬─────┘    └────┬─────┘    └────┬─────┘
        │               │               │
   GraphQL API     REST + WS        REST API
   (flexible       (bandwidth-      (simple,
    queries)        efficient)       cacheable)
        │               │               │
        ▼               ▼               ▼
   ┌──────────────────────────────────────────┐
   │             API Gateway                   │
   │  (Auth, Rate Limit, Protocol Translation) │
   └──────┬───────────────┬───────────────┬────┘
          │               │               │
       gRPC            gRPC            gRPC
          │               │               │
     ┌────▼────┐    ┌────▼────┐    ┌────▼────┐
     │ User    │    │ Order   │    │ Notif.  │
     │ Service │    │ Service │    │ Service │
     └────┬────┘    └────┬────┘    └────┬────┘
          │               │               │
          │           gRPC/REST           │
          ▼               ▼               ▼
     ┌─────────┐   ┌──────────┐   ┌──────────┐
     │  DB     │   │  DB      │   │ Message  │
     │ (SQL)   │   │ (NoSQL)  │   │ Queue    │
     └─────────┘   └──────────┘   └──────────┘

   External clients: REST / GraphQL / WebSocket (client-facing)
   Internal services: gRPC (fast, typed, streaming)
   Real-time push: WebSocket (via Notification Service)
```

**The key insight:** Use **REST or GraphQL for external APIs**, **gRPC for internal service-to-service**, and **WebSockets for real-time features**.

---

## Common Interview Questions

### Q1: When would you choose REST over GraphQL?

Choose **REST** when you have simple CRUD operations, need HTTP caching, are building a public API for third parties, or want the simplest possible implementation. REST's resource model maps naturally to database entities. Choose **GraphQL** when clients have diverse data needs, you want to avoid multiple round trips, or your data is deeply nested/graph-shaped.

### Q2: Why is gRPC preferred for microservice communication?

gRPC uses **binary serialization** (protobuf) making it 2-10x smaller than JSON, runs on **HTTP/2** with multiplexing for better connection utilization, provides **strict contracts** via .proto files ensuring type safety across services, supports **streaming** natively, and auto-generates client/server code in 10+ languages. It's essentially built for the internal service-to-service use case.

### Q3: Can you use GraphQL and REST together?

Yes — and many companies do. A common pattern is a **GraphQL aggregation layer** that sits in front of existing REST microservices. The GraphQL server's resolvers call the underlying REST APIs. This gives frontend teams the flexibility of GraphQL while backend teams keep their existing REST services.

### Q4: What are the downsides of GraphQL?

**Caching is hard** (single POST endpoint defeats HTTP caching), the **N+1 query problem** requires DataLoader or similar batching, deeply nested queries can **DoS your server** (need query depth/complexity limits), it's **overkill for simple APIs**, and error handling is non-standard (always returns 200 with errors in the body).

### Q5: How does gRPC handle backward compatibility?

Protobuf is designed for **backward and forward compatibility**. You can add new fields (old clients ignore them), never reuse removed field numbers, and use `reserved` to prevent accidental reuse. Clients and servers can run different versions of the .proto as long as these rules are followed. This is critical in microservice environments where services deploy independently.

### Q6: When would you NOT use WebSockets?

Don't use WebSockets for **simple request-response** (REST is simpler), **unidirectional server push** (SSE is lighter), **infrequent updates** (polling is fine), or **stateless APIs** (WebSockets are stateful, making scaling harder). WebSocket connections consume server resources even when idle — they're only worth it when you need continuous bidirectional communication.

### Q7: How do you handle errors differently across these protocols?

- **REST**: HTTP status codes (200, 400, 404, 500) — universally understood
- **GraphQL**: Always HTTP 200, errors in response body `{ "errors": [...] }` — partial data can still be returned alongside errors
- **gRPC**: Status codes (OK, NOT_FOUND, INTERNAL, etc.) + rich error details — more granular than HTTP
- **WebSocket**: Application-defined error messages — no standard error format

---

## Key Takeaways for Interviews

1. **No single protocol wins** — real systems use REST + gRPC + WebSocket + GraphQL together
2. **REST for external APIs** — universal, cacheable, simple; default choice unless you have a specific reason not to
3. **gRPC for internal services** — binary + HTTP/2 + streaming + strict contracts = fast and reliable
4. **GraphQL for flexible frontends** — solves over/under-fetching, great for diverse clients
5. **WebSockets for real-time** — bidirectional persistent connection; use SSE if you only need server push
6. **Always mention trade-offs** — every protocol has downsides; interviewers want to see you weigh options
7. **API Gateway translates protocols** — external REST/GraphQL → internal gRPC is a common production pattern
8. **Contract enforcement matters** — gRPC (.proto) and GraphQL (SDL) enforce schemas; REST relies on documentation

---

*Last Updated: 2026-06-10*
