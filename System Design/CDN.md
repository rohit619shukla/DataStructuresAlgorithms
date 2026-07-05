# CDN (Content Delivery Network)

## What is a CDN?

**A CDN is a globally distributed network of servers that caches content close to users.** Instead of every request traveling to your origin server, users get content from a nearby **edge server** — cutting latency dramatically.

Think of it like **local warehouses for a retailer** — instead of shipping every order from one central factory, you stock popular items in regional warehouses near customers.

---

## Why Do We Need a CDN?

| Problem | How a CDN Solves It |
|---------|---------------------|
| Users far from origin see high latency | Serve from a nearby edge server |
| Origin server overloaded by traffic | Edge absorbs most requests (offload) |
| Repeated downloads of the same file | Cache once at the edge, serve many times |
| Traffic spikes / flash crowds | Edge scales the read load horizontally |
| DDoS and bandwidth costs | Edge absorbs and filters malicious traffic |

---

## How a CDN Works

```
Without CDN:                    With CDN:
                                
User (India) ──── 8000km ───▶   User (India) ──▶ Edge (Mumbai)  [cache HIT]
   Origin (US)                        │
                                      └─(miss)─▶ Origin (US)  ← only on miss
```

1. User requests `image.jpg`; DNS (GeoDNS) routes them to the **nearest edge server**.
2. **Cache HIT** → edge returns the cached file instantly.
3. **Cache MISS** → edge fetches from origin, stores it, then serves it. Next user gets a HIT.

---

## Push vs Pull CDN

| | **Pull CDN** | **Push CDN** |
|--|-------------|-------------|
| How content arrives | Edge fetches from origin on first miss | You upload content to the CDN ahead of time |
| Best for | Frequently updated / large catalogs | Small, static, rarely changing assets |
| Effort | Low — self-managing | Higher — you manage what's stored |
| First request | Slower (cache miss) | Fast (already there) |

Most modern CDNs (Cloudflare, CloudFront, Akamai) default to **pull**.

---

## Caching & Freshness

Control what the edge caches and for how long via HTTP headers:

- **`Cache-Control: max-age=3600`** — cache for 1 hour.
- **`ETag` / `Last-Modified`** — validation tokens; edge revalidates with origin (304 Not Modified if unchanged).
- **TTL** — how long content stays fresh at the edge.

**Cache invalidation** (when content changes):
- **Purge** — explicitly evict a file from all edges.
- **Versioned URLs** — `style.v2.css` or `app.js?v=123`; a new name = new cache entry (avoids purging).

---

## What to Cache

| Great fit (static) | Poor fit (dynamic / private) |
|--------------------|------------------------------|
| Images, video, CSS, JS | Per-user dashboards |
| Fonts, downloads | Banking balances, cart contents |
| Public API responses | Anything with auth-specific data |

> Dynamic content can still benefit via **edge compute** (Cloudflare Workers, Lambda@Edge) and short-TTL caching.

---

## Benefits Beyond Speed

- **Lower latency** — content served from nearby.
- **Origin offload** — fewer requests hit your servers, lower cost.
- **Scalability** — absorbs traffic spikes.
- **Availability** — edges keep serving cached content if origin is down.
- **Security** — DDoS mitigation, WAF, TLS termination at the edge.

---

## Common Interview Questions

**Q: What is a CDN and why use one?**
A distributed network of edge servers that caches content near users, reducing latency, offloading the origin, and improving availability and scale.

**Q: Cache hit vs miss?**
Hit = edge has the content and serves it directly. Miss = edge fetches from origin, caches it, then serves — subsequent requests hit.

**Q: Push vs pull CDN?**
Pull = edge lazily fetches from origin on first miss (low effort, good for large/changing catalogs). Push = you pre-upload assets (good for small static sets).

**Q: How do you handle stale content?**
Set appropriate TTLs, use ETag/Last-Modified revalidation, purge on change, or use versioned URLs to force a fresh fetch.

**Q: Should you cache dynamic/personalized content?**
Generally no for private per-user data. Use short TTLs, cache public fragments, or edge compute for the rest.

**Q: How does a request reach the nearest edge?**
GeoDNS / anycast routing resolves the CDN hostname to the closest edge server based on the user's location.

---

## Key Takeaways for Interviews

1. **CDN = edge caching close to users** — cut latency, offload origin.
2. **Hit vs miss** — misses populate the cache from origin.
3. **Pull (lazy) vs push (pre-uploaded)** — pull is the common default.
4. **Freshness via TTL + ETag**; invalidate with purge or versioned URLs.
5. **Cache static, not private dynamic** content (unless using edge compute).
6. **More than speed** — scalability, availability, and DDoS/TLS security at the edge.

---

*Last Updated: 2026-07-04*
