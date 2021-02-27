# Cookbook Backend

## Configuration

To use the project, please:

1. Prepare postgresql database.
2. Add appsettings.json file to CookbookAPI project, with following data:

```json
{
  "ConnectionStrings": {
    "DefaultConnectionString": "Host=<<host>>; Database=<<db>>; Username=<<user>>;  Password=<<pass>>"
  },
  "JWTSettings": {
    "SecretKey": "<<secretKey>>"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

3. Build and start the project.

## Project scope

1. Adding/Removing recipes and ingredients.
2. Adding/Removing users.
3. User authentication with JWT.
