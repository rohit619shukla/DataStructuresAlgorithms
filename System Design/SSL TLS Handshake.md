# SSL/TLS Handshake

## What is SSL/TLS?

**TLS (Transport Layer Security)** is the protocol that puts the **S in HTTPS**. It encrypts communication between client and server so nobody in between can read or tamper with the data. SSL is the old name — today everything uses TLS.

The **handshake** is how client and server agree on encryption keys before any real data flows.

---

### TLS 1.2 Handshake (2 Round Trips)

TLS 1.2 uses two types of encryption during the handshake:

```
┌────────────────────────────────────────────────────────────────┐
│  TWO TYPES OF ENCRYPTION — understand this first!              │
│                                                                │
│  1. Asymmetric (Public key + Private key) — like a PADLOCK     │
│     • Server gives everyone an open padlock (public key)       │
│     • Only the server has the key to open it (private key)     │
│     • Anyone can LOCK a box, only server can UNLOCK it         │
│     • Used ONCE — just to safely send the shared secret        │
│     • Slow 🐢                                                  │
│                                                                │
│  2. Symmetric (Same shared key on both sides) — like a DIARY   │
│     KEY that both friends have a copy of                       │
│     • Same key encrypts AND decrypts                           │
│     • Used for ALL messages after the handshake                │
│     • Fast ⚡                                                   │
│                                                                │
│  The WHOLE point of the handshake:                             │
│     Use the slow padlock system ONCE to safely deliver         │
│     the fast shared key. Then use the shared key forever.      │
└────────────────────────────────────────────────────────────────┘
```

#### The RSA Key Exchange (the main way to understand TLS 1.2)

```
┌──────────┐                                                    ┌──────────┐
│  Client  │                                                    │  Server  │
│ (Browser)│                                                    │(Website) │
└────┬─────┘                                                    └────┬─────┘
     │                                                               │
     │         ┌─────────────────────────────────────┐               │
     │         │  ROUND TRIP 1: Introductions        │               │
     │         └─────────────────────────────────────┘               │
     │                                                               │
     │  ── Step 1: Client says hello ────────────────────────────►   │
     │                                                               │
     │     "Hey, I want to talk securely. Here's what I know:"       │
     │       • TLS version I support (e.g. TLS 1.2)                 │
     │       • My random number (Client Random — a dice roll)        │
     │       • List of encryption methods I know                     │
     │                                                               │
     │  ◄── Step 2: Server says hello back ───────────────────────   │
     │                                                               │
     │     "Sure! I picked one encryption method from your list."    │
     │       • The encryption method server chose                    │
     │       • Server's own random number (Server Random)            │
     │                                                               │
     │  ◄── Step 3: Server sends its ID card (certificate) ───────   │
     │                                                               │
     │     "Here's proof I'm really google.com":                     │
     │       ┌───────────────────────────────────────────────┐       │
     │       │  📜 CERTIFICATE (like a government-issued ID) │       │
     │       │                                               │       │
     │       │  "I am google.com"                            │       │
     │       │  "Here is my open padlock (public key)        │       │
     │       │   — anyone can lock a box with it,            │       │
     │       │   only I can unlock it"                       │       │
     │       │  "Signed by: DigiCert (a trusted authority    │       │
     │       │   — like a government that issued this ID)"   │       │
     │       │  "Valid until: 2027"                          │       │
     │       └───────────────────────────────────────────────┘       │
     │                                                               │
     │  ◄── Step 4: "That's everything from my side" ─────────────   │
     │                                                               │
     │   ┌──────────────────────────────────────────────────────┐    │
     │   │  🔍 CLIENT CHECKS THE ID CARD:                       │    │
     │   │                                                      │    │
     │   │  ✓ Is this signed by someone I trust?                │    │
     │   │    (browser has a built-in list of trusted signers)  │    │
     │   │  ✓ Is it expired?                                    │    │
     │   │  ✓ Does the name match the website I'm visiting?     │    │
     │   │  ✓ Has it been revoked / blacklisted?                │    │
     │   │                                                      │    │
     │   │  ANY check fails → ❌ "Your connection is not private"│    │
     │   └──────────────────────────────────────────────────────┘    │
     │                                                               │
     │         ┌─────────────────────────────────────┐               │
     │         │  ROUND TRIP 2: Create the secret    │               │
     │         └─────────────────────────────────────┘               │
     │                                                               │
     │  ── Step 5: Client creates & sends the secret ─────────────►  │
     │                                                               │
     │     ┌────────────────────────────────────────────────────┐    │
     │     │  📦 THE PADLOCK ANALOGY:                            │    │
     │     │                                                    │    │
     │     │  1. Client generates a brand new random number     │    │
     │     │     — this IS the "Pre-Master Secret"              │    │
     │     │     (completely independent from Client Random     │    │
     │     │      and Server Random — all 3 are separate)       │    │
     │     │                                                    │    │
     │     │  2. Client puts it in a box and LOCKS the box      │    │
     │     │     with Server's open padlock (public key)        │    │
     │     │                                                    │    │
     │     │  3. Sends the locked box over the internet         │    │
     │     │                                                    │    │
     │     │  🕵️ A hacker on the network can SEE the box       │    │
     │     │     but CANNOT open it — only the server has       │    │
     │     │     the key (private key) to this padlock          │    │
     │     └────────────────────────────────────────────────────┘    │
     │                                                               │
     │     ┌────────────────────────────────────────────────────┐    │
     │     │  🔓 SERVER OPENS THE BOX:                          │    │
     │     │                                                    │    │
     │     │  Server uses its PRIVATE KEY to unlock the box     │    │
     │     │  and gets the Pre-Master Secret                    │    │
     │     │                                                    │    │
     │     │  Now BOTH sides have the same 3 ingredients:       │    │
     │     │    • Client Random  (sent in Step 1, plain text)   │    │
     │     │    • Server Random  (sent in Step 2, plain text)   │    │
     │     │    • Pre-Master Secret (sent in Step 5, encrypted) │    │
     │     │                                                    │    │
     │     │  Both sides independently cook the SAME recipe:    │    │
     │     │                                                    │    │
     │     │    Shared AES Key = mix( Pre-Master Secret,        │    │
     │     │                         Client Random,             │    │
     │     │                         Server Random )            │    │
     │     │                                                    │    │
     │     │  Same ingredients + same recipe = same key! 🎯     │    │
     │     │  This shared AES key is NEVER sent to anyone.      │    │
     │     │  Both sides just compute it on their own machine.  │    │
     │     └────────────────────────────────────────────────────┘    │
     │                                                               │
     │     ┌────────────────────────────────────────────────────┐    │
     │     │  ❓ WHY RANDOM NUMBERS?                             │    │
     │     │                                                    │    │
     │     │  • Prevent replay attacks — each handshake is      │    │
     │     │    unique, so replaying an old one won't work      │    │
     │     │  • Make every session's key different — even if    │    │
     │     │    same Pre-Master Secret is picked twice          │    │
     │     │  • Both sides contribute randomness — so neither   │    │
     │     │    side alone can control the final key            │    │
     │     └────────────────────────────────────────────────────┘    │
     │                                                               │
     │  ── Step 6: "I'm switching to encrypted mode" ─────────────►  │
     │     (ChangeCipherSpec — "from now on I'll use the AES key")   │
     │                                                               │
     │  ── Step 7: "Can you read this?" ──────────────────────────►  │
     │     Client encrypts a test message with the new AES key.      │
     │     If server can decrypt it → they have the same key! ✓      │
     │                                                               │
     │  ◄── Step 8: "I'm switching to encrypted mode too" ─────────  │
     │     (Server's ChangeCipherSpec)                                │
     │                                                               │
     │  ◄── Step 9: "Yep! I read yours. Can you read mine?" ──────  │
     │     Server encrypts a test message back with the same         │
     │     AES key. Client decrypts it → confirmed both ways! ✓      │
     │                                                               │
     │     ┌────────────────────────────────────────────────────┐    │
     │     │  💡 Steps 7 & 9 use the SHARED AES KEY (symmetric) │    │
     │     │  NOT the public/private key. The padlock job is     │    │
     │     │  done. From here, same key locks AND unlocks.      │    │
     │     └────────────────────────────────────────────────────┘    │
     │                                                               │
     │         ╔════════════════════════════════════════════╗         │
     │         ║  ✅ DONE! Both sides have the same key.   ║         │
     │         ║  Everything from here is encrypted with   ║         │
     │         ║  the shared AES key (symmetric).          ║         │
     │         ╚════════════════════════════════════════════╝         │
     │                                                               │
     │  ═══════════ All data is now encrypted (HTTPS) ═══════════    │
     │  ── GET /api/data ──────────────────────────────────────────►  │
     │     (encrypted with AES key, server decrypts with SAME key)   │
     │  ◄── 200 OK { "secret": "stuff" } ──────────────────────────  │
     │     (encrypted with AES key, client decrypts with SAME key)   │
     │                                                               │
```

#### Bonus: What about Diffie-Hellman? (DHE/ECDHE)

TLS 1.2 also supports a second way to create the shared secret called Diffie-Hellman. The handshake steps are the same, but Step 5 works differently:

- Instead of client locking a secret in a box with the server's padlock, **both sides exchange public values and independently compute the same secret**.
- Each session uses **throwaway keys** that are deleted after the handshake.
- This gives **forward secrecy** — if the server's private key leaks years later, old sessions are still safe because the throwaway keys no longer exist.
- RSA has **no forward secrecy** — the same private key unlocks every session's secret, so a leak exposes all past traffic.
- This is why **TLS 1.3 removed RSA entirely** and only uses Diffie-Hellman.

---

### TLS 1.3 Handshake (1 Round Trip — Faster!)

TLS 1.3 dropped the RSA padlock method entirely and ONLY uses Diffie-Hellman. This changes how the shared secret is created — and makes it faster.

```
┌──────────┐                                                    ┌──────────┐
│  Client  │                                                    │  Server  │
│ (Browser)│                                                    │(Website) │
└────┬─────┘                                                    └────┬─────┘
     │                                                               │
     │         ┌─────────────────────────────────────┐               │
     │         │  SINGLE ROUND TRIP — that's it!     │               │
     │         └─────────────────────────────────────┘               │
     │                                                               │
     │  ── Step 1: Client says hello ──────────────────────────────►  │
     │                                                               │
     │     Client generates a THROWAWAY key pair (private + public)  │
     │     and sends:                                                │
     │       • TLS version I support                                 │
     │       • Client Random                                         │
     │       • List of encryption methods I know                     │
     │       • 🆕 My temporary PUBLIC key (sent UPFRONT!)            │
     │         (In TLS 1.2 this didn't come until Step 5.            │
     │          Client doesn't need anything from server to          │
     │          generate its own key pair — so why wait?)            │
     │                                                               │
     │  ◄── Step 2: Server responds with everything ───────────────   │
     │                                                               │
     │     Server also generates its own throwaway key pair and       │
     │     sends back:                                                │
     │       • Server Random                                          │
     │       • Chosen encryption method                               │
     │       • 🆕 Server's temporary PUBLIC key                      │
     │       • Certificate (same ID card as TLS 1.2)                  │
     │       • Proof it owns the certificate                          │
     │       • "Handshake done from my side"                          │
     │                                                               │
     │     ┌────────────────────────────────────────────────────┐    │
     │     │  🔑 BOTH sides now compute the AES key:            │    │
     │     │                                                    │    │
     │     │  Client: math(my private + server's public) = AES  │    │
     │     │  Server: math(my private + client's public) = AES  │    │
     │     │                                                    │    │
     │     │  Same answer on both sides — guaranteed by math!   │    │
     │     │  No Pre-Master Secret. No padlock. No box.         │    │
     │     │  Throwaway keys are deleted after this. 🔐          │    │
     │     └────────────────────────────────────────────────────┘    │
     │                                                               │
     │     Client checks certificate (same 4 checks as TLS 1.2):    │
     │       ✓ Trusted signer?  ✓ Expired?                           │
     │       ✓ Domain match?    ✓ Revoked?                           │
     │                                                               │
     │  ── Step 3: "I'm done too, keys match!" ───────────────────►  │
     │     Client sends an encrypted test message using AES key.     │
     │     If server reads it → both have the same key. ✅            │
     │                                                               │
     │         ╔════════════════════════════════════════════╗         │
     │         ║  ✅ DONE in just 1 round trip!            ║         │
     │         ║  From here, same as TLS 1.2 —             ║         │
     │         ║  everything encrypted with shared AES key ║         │
     │         ╚════════════════════════════════════════════╝         │
     │                                                               │
     │  ═══════════ All data is now encrypted (HTTPS) ═══════════    │
     │  ── GET /api/data ──────────────────────────────────────────►  │
     │  ◄── 200 OK { "secret": "stuff" } ──────────────────────────  │
     │                                                               │
```

---

### TLS 1.3 — Repeat Visits (0 Round Trips!)

If you've visited the site before, TLS 1.3 can send encrypted data in the FIRST message using a key saved from last time.

```
┌──────────┐                                                    ┌──────────┐
│  Client  │                                                    │  Server  │
└────┬─────┘                                                    └────┬─────┘
     │                                                               │
     │  ── "Hey, remember me? Here's data already" ───────────────►  │
     │     Uses a saved key from last session                        │
     │     Sends real data (like a GET request) immediately!         │
     │                                                               │
     │  ◄── "Yep, here's your response" ───────────────────────────  │
     │                                                               │
     │  ⚠️  Only safe for read requests (GET).                       │
     │     An attacker could replay the first message,               │
     │     so never use this for writes (POST/PUT/DELETE).           │
     │                                                               │
```

---

## TLS 1.2 vs TLS 1.3 — Quick Comparison

| | TLS 1.2 (Older) | TLS 1.3 (Current Standard) |
|--|---------|---------|
| **Speed** | 2 round trips | **1 round trip** (0 for repeat visits) |
| **Why faster?** | Client waits for server's public key before sending secret | Client sends its **temporary public key in Step 1** — no waiting |
| **How AES key is made** | mix(Client Random + Server Random + Pre-Master Secret) | math(my private key + other's public key) |
| **Key exchange method** | RSA (padlock) or Diffie-Hellman | **Diffie-Hellman ONLY** (RSA removed) |
| **Forward secrecy** | Optional (only with Diffie-Hellman) | **Always on** — throwaway keys deleted after every session |
| **Certificate visible?** | Yes, sent in plaintext | **No, encrypted** — harder to snoop |
| **Insecure options** | Many old/weak encryption methods allowed | **Stripped down to only 5 strong ones** |

TLS 1.3 is the standard today. Know it exists; interviewers rarely go deeper.

---

## TLS Termination — What Happens in Real Systems

In production, the TLS handshake usually doesn't happen with your backend server directly. It happens with a **Load Balancer** sitting in front. This is called **TLS Termination**.

```
┌──────────┐         HTTPS            ┌──────────┐       plain HTTP       ┌──────────┐
│  Client  │ ◄═══════════════════════► │  Load    │ ─────────────────────► │ Backend  │
│ (Browser)│    (encrypted traffic)    │ Balancer │   (no encryption)      │ Servers  │
└──────────┘                           └──────────┘                        └──────────┘
                                       ▲
                                       │
                              TLS "terminates" (ends) here.
                              The LB does ALL the TLS work:
                                • Holds the certificate + private key
                                • Does the full handshake with client
                                • Decrypts every incoming request
                                • Reads URL, headers, cookies
                                • Forwards plain HTTP to backends
                              
                              The client has NO idea.
                              It thinks it's talking to the backend.
```

```
┌────────────────────────────────────────────────────────────────┐
│  WHY DO THIS?                                                  │
│                                                                │
│  ✅ Backends stay fast — no CPU wasted on encryption           │
│  ✅ LB can READ requests — route based on URL, headers (L7)   │
│  ✅ Only ONE place holds the certificate — easier to manage    │
│                                                                │
│  ⚠️ Traffic between LB and backends is unencrypted.           │
│     OK if same trusted network (data center / VPC).           │
│     If not, add encryption there too.                         │
└────────────────────────────────────────────────────────────────┘
```

---

## Interview Cheat Sheet

**"Explain TLS handshake"**
> Client and server exchange hellos with random numbers. Server sends its certificate (ID card) with a public key. Client creates a Pre-Master Secret, encrypts it with the server's public key (like locking a box with a padlock), and sends it. Server decrypts with its private key. Both sides now mix the Pre-Master Secret + both random numbers to compute the same shared AES key. From here, that one shared key encrypts and decrypts everything — fast and symmetric.

**"TLS 1.2 vs 1.3?"**
> TLS 1.2 uses RSA (padlock method) — client must wait for server's public key, so it takes 2 round trips. TLS 1.3 uses Diffie-Hellman only — both sides generate throwaway key pairs and swap public keys. Client sends its public key in the first message, so it's done in 1 round trip. TLS 1.3 also has mandatory forward secrecy because the throwaway keys are deleted after each session.

**"What is TLS termination?"**
> The Load Balancer handles the entire TLS handshake and decryption. It holds the certificate and private key. Client talks encrypted to the LB, LB decrypts and forwards plain HTTP to backends. Backends skip all crypto work. The LB can also read the request to do smart routing (L7).

**"What is mTLS?"**
> In normal TLS, only the server proves its identity. In mTLS (mutual TLS), BOTH sides present certificates and verify each other. Used between microservices so only trusted services can communicate. Common in service meshes like Istio.

**"What is forward secrecy?"**
> Each session uses throwaway keys that are deleted after the handshake. Even if the server's main private key leaks years later, past traffic stays safe because those throwaway keys no longer exist.
