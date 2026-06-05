# WebSockets

## What are WebSockets?

WebSockets provide a **full-duplex, persistent communication channel** over a single TCP connection between a client and a server. Unlike HTTP's request-response model, WebSockets allow **both sides to send messages at any time** without waiting for the other.

Think of it as a **phone call** — once connected, both parties can speak freely without hanging up and redialing for every message.

---

## Why Do We Need WebSockets?

| Problem | How WebSockets Solve It |
|---------|------------------------|
| HTTP requires client to always initiate requests | Server can push data to client anytime |
| Polling wastes bandwidth with empty responses | Data sent only when available |
| Long polling ties up server resources | Single persistent connection, low overhead |
| High latency for real-time features | Near-instant message delivery |
| HTTP headers add overhead per request | Minimal framing overhead (~2-14 bytes per message) |
| Multiple connections for bidirectional data | Single connection handles both directions |

---

## How WebSockets Work

### The Handshake (HTTP Upgrade)

WebSocket connections start as a regular HTTP request, then **upgrade** to the WebSocket protocol.

```
┌──────────┐                              ┌──────────┐
│  Client  │                              │  Server  │
└────┬─────┘                              └────┬─────┘
     │                                         │
     │  1. HTTP GET /chat                      │
     │     Upgrade: websocket                  │
     │     Connection: Upgrade                 │
     │     Sec-WebSocket-Key: dGhlIHNhb...     │
     │────────────────────────────────────────▶│
     │                                         │
     │  2. HTTP 101 Switching Protocols        │
     │     Upgrade: websocket                  │
     │     Connection: Upgrade                 │
     │     Sec-WebSocket-Accept: s3pPLM...     │
     │◀────────────────────────────────────────│
     │                                         │
     │  ══════ WebSocket Connection Open ═════ │
     │                                         │
     │  3. Messages flow freely both ways      │
     │◀───────────────────────────────────────▶│
     │                                         │
     │  4. Either side can close               │
     │────────── Close Frame ─────────────────▶│
     │◀───────── Close Frame ──────────────────│
     │                                         │
```

### Connection Lifecycle

```
   HTTP Request (Upgrade)
       │
       ▼
   101 Switching Protocols
       │
       ▼
   ┌─────────────────────┐
   │  Connection OPEN    │◀──── Heartbeat/Ping-Pong
   │  (Full-duplex)      │      keeps connection alive
   └──────────┬──────────┘
              │
       Close frame sent
              │
              ▼
   ┌─────────────────────┐
   │  Connection CLOSED  │
   └─────────────────────┘
```

---

## WebSockets vs HTTP vs SSE vs Long Polling

| Feature | HTTP Polling | Long Polling | SSE | WebSocket |
|---------|-------------|-------------|-----|-----------|
| **Direction** | Client → Server | Client → Server | Server → Client | Bidirectional |
| **Connection** | New per request | Held open, re-established | Persistent | Persistent |
| **Latency** | High (poll interval) | Medium | Low | Very Low |
| **Overhead** | High (headers each time) | Medium | Low | Very Low |
| **Server push** | ❌ | Simulated | ✅ Native | ✅ Native |
| **Protocol** | HTTP | HTTP | HTTP | WS (TCP) |
| **Browser support** | ✅ Universal | ✅ Universal | ✅ Good | ✅ Good |
| **Complexity** | Low | Medium | Low | High |
| **Best for** | Low-frequency updates | Medium-frequency | Notifications, feeds | Chat, gaming, collab editing |

### When to Use What

```
   Need bidirectional real-time?
       │
       ├── YES → WebSockets (chat, gaming, collaborative editing)
       │
       └── NO → Is it server → client only?
                   │
                   ├── YES → SSE (notifications, live feeds, dashboards)
                   │
                   └── NO → Is frequency low?
                               │
                               ├── YES → HTTP Polling (weather updates, status checks)
                               │
                               └── NO → Long Polling (semi-real-time, legacy support)
```

---

## Scaling WebSockets — The Hard Problem

WebSocket connections are **stateful** — each client maintains a persistent connection to a specific server. This makes horizontal scaling significantly harder than stateless HTTP.

### The Problem

```
   ┌─────────┐    ┌─────────┐    ┌─────────┐
   │ User A  │    │ User B  │    │ User C  │
   └────┬────┘    └────┬────┘    └────┬────┘
        │              │              │
        ▼              ▼              ▼
   ┌─────────────────────────────────────┐
   │          Load Balancer              │
   └──────┬──────────────────┬───────────┘
          │                  │
     ┌────▼────┐        ┌───▼─────┐
     │ WS      │        │ WS      │
     │ Server 1│        │ Server 2│
     │         │        │         │
     │ User A  │        │ User B  │
     │ User C  │        │         │
     └─────────┘        └─────────┘

   Problem: User A sends message to User B,
   but they're on DIFFERENT servers!
```

### Solution: Message Broker (Pub/Sub)

```
   ┌─────────┐    ┌─────────┐    ┌─────────┐
   │ User A  │    │ User B  │    │ User C  │
   └────┬────┘    └────┬────┘    └────┬────┘
        │              │              │
   ┌────▼────┐    ┌────▼────┐    ┌────▼────┐
   │ WS      │    │ WS      │    │ WS      │
   │ Server 1│    │ Server 2│    │ Server 3│
   └────┬────┘    └────┬────┘    └────┬────┘
        │              │              │
   ┌────▼──────────────▼──────────────▼────┐
   │         Message Broker                 │
   │    (Redis Pub/Sub / Kafka / NATS)      │
   │                                        │
   │  • Server 1 publishes: "User A says    │
   │    hello to User B"                    │
   │  • Broker fans out to Server 2         │
   │  • Server 2 delivers to User B         │
   └────────────────────────────────────────┘
```

### Scaling Strategies

| Strategy | How It Works | Trade-offs |
|----------|-------------|------------|
| **Sticky Sessions** | LB routes same client to same server | Simple but limits failover |
| **Redis Pub/Sub** | Servers subscribe to channels, broker fans out messages | Low latency, no persistence |
| **Kafka / RabbitMQ** | Message queue with persistence and replay | Higher latency, durable delivery |
| **Consistent Hashing** | Hash user/room ID to determine server | Predictable routing, handles rebalancing |
| **Connection Gateway** | Separate WS termination from business logic | Clean architecture, more hops |

---

## Connection Management

### Heartbeats (Ping/Pong)

Connections can silently die (network issues, NAT timeouts). Heartbeats detect dead connections.

```
   Client                    Server
     │                         │
     │◀──── Ping ──────────────│  Server sends ping every 30s
     │───── Pong ─────────────▶│  Client responds with pong
     │                         │
     │    (no pong received)   │
     │                         │  Server waits timeout (e.g., 10s)
     │         ╳               │  Server closes dead connection
```

### Reconnection Strategy

```
   Connection Lost
       │
       ▼
   Attempt 1: Wait 1s  → Reconnect
       │ (fail)
       ▼
   Attempt 2: Wait 2s  → Reconnect     ← Exponential Backoff
       │ (fail)
       ▼
   Attempt 3: Wait 4s  → Reconnect
       │ (fail)
       ▼
   Attempt 4: Wait 8s + jitter → Reconnect
       │
       ...
       ▼
   Max retries reached → Fall back to polling / show error
```

### Connection Limits

Each WebSocket connection = 1 file descriptor + ~2-10 KB memory on the server. A tuned server can handle **100K–1M connections**. Always mention this constraint in interviews when discussing scaling.

---

## Security

### Authentication During Handshake

WebSocket connections should be authenticated **during the HTTP upgrade**, not after.

```
   Option 1: Token in query string (simple, but visible in logs)
   ─────────────────────────────────────────────────────────────
   ws://example.com/chat?token=eyJhbGciOiJI...

   Option 2: Token in Sec-WebSocket-Protocol header (preferred)
   ─────────────────────────────────────────────────────────────
   Sec-WebSocket-Protocol: auth-token, eyJhbGciOiJI...

   Option 3: Auth cookie (browser-based apps)
   ─────────────────────────────────────────────────────────────
   Cookie: session=abc123
```

### Security Checklist

| Concern | Mitigation |
|---------|-----------|
| **Origin validation** | Check `Origin` header to prevent cross-site WS hijacking |
| **Authentication** | Validate JWT/session during handshake, reject before upgrade |
| **Rate limiting** | Limit messages per second per connection |
| **Message size limits** | Cap max frame size to prevent memory attacks |
| **Input validation** | Validate and sanitize all incoming messages |
| **WSS (TLS)** | Always use `wss://` in production, never plain `ws://` |
| **Connection limits** | Cap max connections per user/IP |

---

## Architecture Pattern: Connection Gateway

Separating WebSocket termination from business logic for cleaner scaling.

```
┌──────────────────────────────────────────────────────────────┐
│                  Connection Gateway Pattern                    │
└──────────────────────────────────────────────────────────────┘

   Clients
     │
     ▼
┌─────────────────────────────┐
│     Connection Gateway       │  ← Manages WS connections
│     (Stateful)               │  ← Handles ping/pong
│                              │  ← Auth during handshake
│  Maintains mapping:          │  ← Tracks: UserID → Connection
│  User A → Connection 1      │
│  User B → Connection 2      │
└──────────┬───────────────────┘
           │  Internal protocol
           │  (gRPC / message queue)
           ▼
┌─────────────────────────────┐
│     Business Logic Servers   │  ← Stateless, horizontally scalable
│     (Stateless)              │  ← Processes messages
│                              │  ← Applies business rules
│  • Chat service              │  ← Sends responses back via gateway
│  • Notification service      │
│  • Presence service          │
└─────────────────────────────┘
```

**Benefits:**
- Gateway scales for connections, business logic scales independently
- Business logic servers remain stateless and easy to deploy
- Gateway can be optimized for high connection counts (C/C++/Rust/Go)

---

## Real-World Use Cases & Design Patterns

| Pattern | Use Case | Key Considerations |
|---------|----------|-------------------|
| **Chat / Messaging** | WhatsApp, Slack, Discord | Message ordering, delivery guarantees, presence |
| **Live Notifications** | Social media, email alerts | Fan-out to millions of connections, batching |
| **Real-time Dashboards** | Stock tickers, monitoring | High-frequency updates, data compression |
| **Collaborative Editing** | Google Docs, Figma | Conflict resolution (OT/CRDT), cursor sync |
| **Online Gaming** | Multiplayer games | Low latency, state synchronization, prediction |
| **Live Streaming** | Twitch chat, live auctions | Massive fan-out, moderation, throttling |

---

## Real-World Tools (Just Know the Names)

**Socket.IO** (JS), **SignalR** (.NET), **Spring WebSocket** (Java), **Phoenix Channels** (Elixir) — mention the one relevant to your stack if asked.

---

## Common Interview Questions

### Q1: How do WebSockets differ from HTTP?

**HTTP** is request-response and stateless — the client always initiates. **WebSockets** are full-duplex and stateful — once connected, either side can send data at any time over the same persistent TCP connection. WebSockets start with an HTTP handshake (101 Upgrade) then switch to the WS protocol.

### Q2: How do you scale WebSocket servers horizontally?

WebSocket connections are stateful, so you can't just add servers. Use **sticky sessions** to route the same client to the same server, and a **message broker** (Redis Pub/Sub, Kafka) to fan out messages across servers. Alternatively, use the **connection gateway pattern** to separate connection management from business logic.

### Q3: What happens when a WebSocket server goes down?

Connected clients lose their connections. The client should implement **exponential backoff with jitter** for reconnection. The server should persist undelivered messages (in a queue or database) so they can be delivered when the client reconnects. Use **multiple server instances** behind a load balancer to minimize impact.

### Q4: When would you choose SSE over WebSockets?

Choose **SSE** when communication is **unidirectional** (server → client only) — notifications, live feeds, dashboards. SSE is simpler, works over standard HTTP, auto-reconnects natively, and is easier to scale since it's stateless from the server's perspective. Use **WebSockets** only when you need **bidirectional** communication.

### Q5: How do you handle authentication with WebSockets?

Authenticate during the **HTTP upgrade handshake**, not after the connection is established. Pass a JWT token via query parameter, a custom header, or a cookie. Validate the token before completing the upgrade — reject with 401/403 if invalid. For long-lived connections, implement periodic **token refresh** and close connections with expired tokens.

### Q6: How do you detect dead WebSocket connections?

Use **ping/pong frames** — the server periodically sends a ping, and the client responds with a pong. If no pong is received within a timeout (e.g., 10 seconds), the server closes the connection and cleans up resources. This handles cases where the TCP connection silently dies (e.g., mobile network switch, NAT timeout).

---

## Key Takeaways for Interviews

1. **WebSockets ≠ HTTP** — persistent, full-duplex TCP connection after an HTTP upgrade handshake
2. **Scaling is the #1 challenge** — stateful connections require sticky sessions + message broker (Redis Pub/Sub)
3. **Use the right tool** — WebSockets for bidirectional, SSE for server-push, polling for low-frequency
4. **Connection Gateway pattern** — separate WS termination from business logic for clean scaling
5. **Always secure** — authenticate during handshake, validate origin, use WSS, rate-limit messages
6. **Heartbeats are essential** — ping/pong to detect dead connections, exponential backoff for reconnection
7. **Connection limits matter** — each connection holds a file descriptor; tune OS limits for high concurrency
8. **Message ordering & delivery guarantees** — design for at-least-once delivery with idempotency

---

*Last Updated: 2026-06-05*
