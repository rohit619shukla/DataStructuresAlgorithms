# DNS (Domain Name System)

## What is DNS?

**DNS is the phonebook of the internet.** It translates human-friendly domain names (`www.google.com`) into IP addresses (`142.250.183.4`) that machines use to route traffic.

Like saving a contact on your phone — you dial "Mom", not her 10-digit number.

---

## The DNS Hierarchy

DNS is a **tree**, read right-to-left in a domain name.

```
              . (Root)
              │
     ┌────────┼────────┐
    com      org       net        ← Top-Level Domains (TLD)
     │
   google                         ← Authoritative domain (owner's servers)
     │
    www                           ← Host / subdomain
```

| Player | Role |
|--------|------|
| **Recursive Resolver** | The middleman (your ISP, or 8.8.8.8, 1.1.1.1) that does the legwork of finding the answer. |
| **Root Server** | Points to the right TLD server. |
| **TLD Server** | Knows which authoritative server owns a domain. |
| **Authoritative Server** | Source of truth — holds the actual records. |

---

## How a Lookup Works

You type `www.example.com`:

```
Browser → Resolver → Root ("ask .com") → TLD ("ask example.com's server")
        → Authoritative ("93.184.216.34") → Resolver caches + returns → Browser
```

- **Recursive**: client asks the resolver once; resolver does all the chasing.
- **Iterative**: each server replies "ask this next server" — how the resolver talks to root/TLD/authoritative.

---

## Caching + TTL

Answers are cached at every layer with a **TTL (Time To Live)** — this is why DNS is fast.

```
Browser → OS → Router → Resolver → Full lookup (only on cache miss)
```

- **High TTL** → fast/cheap, but changes propagate slowly.
- **Low TTL** → changes propagate fast, but more load. Lower it *before* a migration/failover.

---

## Common Record Types

| Record | Purpose |
|--------|---------|
| **A** | Name → IPv4 address |
| **AAAA** | Name → IPv6 address |
| **CNAME** | Alias one name to another name (not allowed at zone apex) |
| **MX** | Mail server for the domain |
| **NS** | Delegates a zone to name servers |
| **TXT** | Arbitrary text (SPF, DKIM, domain verification) |

---

## DNS in System Design

- **Load balancing** — return multiple A records; clients pick one (round-robin).
- **GeoDNS / CDN** — return the IP of the server nearest the user's resolver.
- **Failover** — health-checked DNS (e.g., Route 53) drops unhealthy IPs, bounded by TTL.

Runs over **UDP port 53** (falls back to TCP for large responses and zone transfers). **DNSSEC** signs records to prevent spoofing; **DoH/DoT** encrypt queries for privacy.

---

## Common Interview Questions

**Q: What happens when you type a URL and press Enter?**
Browser cache → OS cache → recursive resolver → root → TLD → authoritative returns IP → resolver caches it → browser opens a TCP/TLS connection and sends the HTTP request.

**Q: Recursive vs iterative resolution?**
Recursive = resolver returns the final answer to the client. Iterative = each server points to the next; the resolver uses these to query root/TLD/authoritative.

**Q: Why can DNS propagation take time?**
Old records stay cached across resolvers until their TTL expires — there's no global flush.

**Q: A record vs CNAME?**
A points a name to an IP directly. CNAME points a name to another name (an alias). Don't use CNAME at the zone apex.

**Q: UDP or TCP?**
UDP/53 by default (fast). TCP/53 for large responses (>512 bytes) and zone transfers.

---

## Key Takeaways for Interviews

1. **DNS = distributed hierarchical name→IP lookup** — root → TLD → authoritative.
2. **Recursive resolver does the legwork** via iterative queries.
3. **Caching + TTL** make DNS fast and explain why changes are slow to propagate.
4. **Know the records** — A, AAAA, CNAME, MX, NS, TXT.
5. **DNS is a design tool** — load balancing, GeoDNS/CDN, failover all ride on it.

---

*Last Updated: 2026-07-04*
