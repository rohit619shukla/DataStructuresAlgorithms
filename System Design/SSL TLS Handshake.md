# SSL/TLS Handshake

## What is SSL/TLS?

**TLS (Transport Layer Security)** is the protocol that puts the **S in HTTPS**. It encrypts communication between client and server so nobody in between can read or tamper with the data. SSL is the old name — today everything uses TLS.

The **handshake** is how client and server agree on encryption keys before any real data flows.

---

## Why Does It Matter in System Design?

- **Data in transit must be encrypted** — compliance (PCI-DSS, HIPAA), user trust, and security all require it
- **TLS termination placement** affects your architecture's performance and security
- **mTLS** is how microservices authenticate each other in zero-trust networks

---

## The TLS Handshake — Simplified

```
┌────────┐                                                  ┌────────┐
│ Client │                                                  │ Server │
└───┬────┘                                                  └───┬────┘
    │                                                           │
    │  ── 1. ClientHello ────────────────────────────────────►  │
    │     "Here are the ciphers I support + my random number"   │
    │                                                           │
    │  ◄── 2. ServerHello + Certificate ─────────────────────   │
    │     "I picked this cipher. Here's my certificate          │
    │      (contains my public key, signed by a trusted CA)"    │
    │                                                           │
    │  ── 3. Key Exchange ───────────────────────────────────►  │
    │     Client verifies certificate, then both exchange       │
    │     material to compute a SHARED SECRET                   │
    │                                                           │
    │     ┌───────────────────────────────────────────────┐     │
    │     │  Both sides derive the same symmetric key     │     │
    │     │  (AES) from the shared secret — WITHOUT       │     │
    │     │  ever sending the key over the wire!          │     │
    │     └───────────────────────────────────────────────┘     │
    │                                                           │
    │  ◄─► 4. Finished ─────────────────────────────────────►   │
    │     Both confirm: "I see the same keys you do"            │
    │                                                           │
    │  ══════════ Encrypted Data Flows (HTTPS) ═══════════════  │
    │                                                           │
```

> **Core idea:** Use slow asymmetric crypto (RSA/ECDH) just once to safely exchange a fast symmetric key (AES). Then use AES for everything.

---

## TLS 1.2 vs TLS 1.3

| | TLS 1.2 | TLS 1.3 |
|--|---------|---------|
| **Round trips** | 2 RTT | **1 RTT** (0-RTT for repeat visits) |
| **Forward secrecy** | Optional | **Mandatory** |
| **Speed** | Slower | Faster — client sends key upfront |

TLS 1.3 is the standard today. Know it exists; interviewers rarely go deeper.

---

## TLS in Architecture — The 3 Patterns You Must Know

### 1. TLS Termination (Most Common)

```
┌────────┐    HTTPS     ┌─────────────┐     HTTP      ┌─────────┐
│ Client │ ───────────► │   Load      │ ────────────► │ Backend │
│        │  (encrypted) │   Balancer  │  (plaintext)  │ Servers │
└────────┘              └─────────────┘               └─────────┘
                        Decrypts here ▲
                        (TLS Termination)

✅ LB offloads expensive crypto — backends stay fast
✅ LB can inspect traffic for L7 routing
⚠️ Internal traffic is unencrypted — OK if network is trusted
```

### 2. TLS Passthrough

```
┌────────┐    HTTPS     ┌─────────────┐    HTTPS      ┌─────────┐
│ Client │ ───────────► │   Load      │ ────────────► │ Backend │
│        │  (encrypted) │   Balancer  │  (encrypted)  │ Servers │
└────────┘              └─────────────┘               └─────────┘
                        Just forwards ▲
                        (L4 only, can't read traffic)

✅ End-to-end encryption
⚠️ LB can only route by IP/port, not by URL path or headers
```

### 3. mTLS (Mutual TLS) — Microservices

```
┌───────────┐           mTLS            ┌───────────┐
│ Service A │ ◄════════════════════════► │ Service B │
│           │   Both show certificates  │           │
│           │   Both verify each other  │           │
└───────────┘                           └───────────┘

✅ Only authorized services can talk to each other
✅ Used in service meshes (Istio, Linkerd) and zero-trust networks
```

---

## Full Picture — Where TLS Fits in Your Design

```
┌────────┐   TLS    ┌──────┐   mTLS    ┌─────────┐   TLS    ┌────┐
│ Client │ ───────► │ API  │ ────────► │Services │ ───────► │ DB │
│        │          │  GW  │           │         │          │    │
└────────┘          └──────┘           └─────────┘          └────┘

         TLS terminates      mTLS between         TLS to DB
         at gateway          services              (encrypt at rest too)
```

---

## Interview Cheat Sheet

**"Explain TLS handshake"**
> Client and server exchange hellos, server proves identity with a certificate, both derive a shared symmetric key using asymmetric crypto, then all data is encrypted with that fast symmetric key.

**"TLS termination vs passthrough?"**
> Termination: LB decrypts → can do L7 routing, backends are simpler. Passthrough: encrypted end-to-end → more secure, but LB is limited to L4.

**"What is mTLS?"**
> Both sides present certificates and verify each other. Used between microservices so only trusted services can communicate.

**"What is forward secrecy?"**
> Each connection uses a throwaway key. Even if the server's private key leaks later, past traffic stays safe.

---

*In a system design round: know where TLS terminates, when to use mTLS, and the trade-off between offloading crypto at the LB vs end-to-end encryption. That's it.*
