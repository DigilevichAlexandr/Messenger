# Messenger

ASP.NET Core (net5.0) + Angular SPA (Angular 8) using ASP.NET Core Identity + IdentityServer4 (Individual Accounts template).

## Build

### Backend (Release)

```bash
dotnet build Messenger.sln -c Release
```

### Frontend (Angular)

Angular CLI 8 uses webpack 4 which may fail on modern Node.js (OpenSSL 3+) with `ERR_OSSL_EVP_UNSUPPORTED`.

For Node 17+:

```bash
cd Messenger/ClientApp
NODE_OPTIONS=--openssl-legacy-provider npm ci
NODE_OPTIONS=--openssl-legacy-provider npm run build -- --prod
```

## Publish (dotnet publish)

`dotnet publish` runs the SPA build from `ClientApp`, so for Node 17+ you also need `NODE_OPTIONS`:

```bash
NODE_OPTIONS=--openssl-legacy-provider dotnet publish Messenger/Messenger.csproj -c Release -o artifacts/publish
```

## GitHub Actions

Workflows:

- **CI**: build + `dotnet publish` and upload publish artifact.
- **Publish**: manual (`workflow_dispatch`) or tag `v*` - produces a zip from the publish folder and attaches it to a GitHub Release.
