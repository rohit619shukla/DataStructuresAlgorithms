# OAuth 2.0

## What is it?

**OAuth 2.0** lets a third-party app access some of your data on another service **without ever seeing your password**.

> Example: **Spotify** wants your name and email from **Google**. Instead of you giving Spotify your Google password, Google hands Spotify a **token** that grants limited access. Spotify never learns your password.

**One-liner:** OAuth 2.0 = **delegated, limited access** using a **token** instead of a password.

---

## The 4 Roles

| Role | In our example |
|------|----------------|
| **Resource Owner** | You (the user) |
| **Client** | Spotify (the third-party app) |
| **Authorization Server** | Google (verifies you, issues token) |
| **Resource Server** | Google API (holds your data) |

---

## The Flow: "Login with Google"

```mermaid
sequenceDiagram
    participant You as You (Resource Owner)
    participant Spotify as Spotify (Client)
    participant Google as Google (Auth Server)
    participant API as Google API (Resource Server)

    You->>Spotify: 1. Click "Login with Google"
    Spotify-->>You: 2. Redirect to Google
    You->>Google: 3. Log in + click "Allow" (scope: email, profile)
    Note over You,Google: Spotify never sees your password 🔒
    Google-->>Spotify: 4. Redirect back with one-time CODE
    Spotify->>Google: 5. Exchange CODE + client_secret (server-to-server)
    Google-->>Spotify: access_token (+ refresh_token)
    Spotify->>API: 6. Call API with access_token
    API-->>Spotify: your name + email
    Spotify-->>You: 7. You're logged in ✅
```

**In words:**
1. You click **"Login with Google"** on Spotify.
2. Spotify redirects you to Google.
3. You log in on Google's page and approve (Spotify never sees your password).
4. Google sends Spotify a short-lived **authorization code**.
5. Spotify's server exchanges that code (plus its secret) for an **access token**.
6. Spotify uses the token to fetch your name and email from Google.
7. You're logged in.

---

## Key Terms

| Term | Meaning |
|------|---------|
| **Scope** | What the app is allowed to access (e.g. `email`, `profile`) |
| **Authorization Code** | One-time, short-lived code, swapped for a token |
| **Access Token** | Short-lived key used to call the API |
| **Refresh Token** | Long-lived key to get a new access token without re-login |

---

## Interview Quick Notes

- **OAuth = authorization** (access), **not** authentication (identity).
- **"Login with Google"** = OAuth 2.0 + **OpenID Connect** on top for identity.
- The app **never sees your password** — that's the whole point.
- **Code → token swap happens server-to-server**, so the token isn't exposed in the browser.
- **Access token** = short-lived; **Refresh token** = renews it silently.
