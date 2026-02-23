# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG NODE_VERSION=12.22.12

RUN set -eux; \
    apt-get update; \
    apt-get install -y --no-install-recommends ca-certificates curl xz-utils; \
    rm -rf /var/lib/apt/lists/*; \
    curl -fsSL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.xz" -o /tmp/node.tar.xz; \
    tar -xJf /tmp/node.tar.xz -C /usr/local --strip-components=1; \
    rm -f /tmp/node.tar.xz; \
    node --version; \
    npm --version

# Avoid optional deps (e.g. fsevents) during npm install
ENV npm_config_optional=false

WORKDIR /src

COPY Messenger.sln ./
COPY Messenger/Messenger.csproj Messenger/
COPY Messenger/ClientApp/package.json Messenger/ClientApp/
COPY Messenger/ClientApp/package-lock.json Messenger/ClientApp/

RUN dotnet restore Messenger/Messenger.csproj

COPY . .

RUN dotnet publish Messenger/Messenger.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080
ENTRYPOINT ["dotnet", "Messenger.dll"]

