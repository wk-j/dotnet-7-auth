# Create secrete

```
dotnet user-secrets init --project src/MyWeb/MyWeb.csproj
dotnet user-secrets list --project src/MyWeb/MyWeb.csproj
```

# Create JWT

```bash
dotnet user-jwts create --name wk --project src/MyWeb/MyWeb.csproj
dotnet user-jwts print 68c2c38 --show-full --project src/MyWeb/MyWeb.csproj
```