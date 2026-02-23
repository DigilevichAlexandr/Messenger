# Messenger

ASP.NET Core (net5.0) + Angular SPA с авторизацией (IdentityServer) и EF Core.

## Деплой на Koyeb (Docker)

1) Создай PostgreSQL базу в Koyeb.
2) Создай Web Service из этого репозитория (Dockerfile в корне).
3) Добавь переменную окружения:

`ConnectionStrings__DefaultConnection`

Пример (Npgsql):

`Host=HOST;Port=5432;Database=DB;Username=USER;Password=PASS;Ssl Mode=Require;Trust Server Certificate=true`

4) Укажи порт сервиса **8080** (Dockerfile слушает `http://0.0.0.0:8080`).

При старте приложение автоматически применяет EF Core миграции (`Database.Migrate()`).

> Примечание: проект на .NET 5 (EOL). Для публичного продакшена лучше обновить до LTS (миграция сложнее из-за IdentityServer4).

