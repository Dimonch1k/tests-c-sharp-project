# Scripts For Project

### Run Docker Container

```bash
docker run --name test-asp-net-db \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=test-asp-net-db \
  -p 5433:5432 \
  -d postgres
```

### Use in appsettings.json

```text
Host=localhost;Port=5433;Database=test-asp-net-db;Username=postgres;Password=postgres
```

### Make migrations to PostgreSQL

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
