# Shop-Api
ASP.NET Core API project to play around with vertical slice architecture

**WARNING**: This repo is only for demo purpose only. Do not deploy this API onto the internet as the creds and keys are insecurely configured.

## Setup & Run
Run docker compose:
```shell
docker compose up -d --build
```

Setup admin user via `/api/setup/admin` route:
```shell
curl -X POST -H 'X-API-KEY: f8IDMpXYOcx3uMrOX7dgunq2uIQQRnnFBG0i3mDHpQMp6SRMVECeAUFCnQH4y2N6' https://localhost/api/setup/admin -v
```

To visit the API, go to `https://localhost/swagger`.

## Todo
- [ ] Add authorization
