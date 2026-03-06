# Task Master Authentication Notes

## Local JSON Users

- Credentials are stored in `TaskMaster/DataStore/Users.json`.
- Each entry contains:
  - `username`
  - `password` (plain text – **training only, not for production**)
  - `role` (`Admin` or `Employee`)
  - `employeeId`
  - `displayName`
- The `TaskMaster.Website` project reads this file via `JsonAppUserStore` and issues a cookie when credentials are valid.

### Default Demo Accounts

```json
[
  { "username": "admin",  "password": "Admin@123",    "role": "Admin"    },
  { "username": "alice",  "password": "Employee@1",   "role": "Employee" },
  { "username": "bruno",  "password": "Employee@2",   "role": "Employee" },
  { "username": "carla",  "password": "Employee@3",   "role": "Employee" },
  { "username": "diego",  "password": "Employee@4",   "role": "Employee" }
]
```

You can edit `Users.json` to change passwords, add more users, or adjust roles.

## Social Authentication (Google and GitHub)

The website is configured to support Google and GitHub sign‑in using ASP.NET Core authentication handlers.  
For local development we recommend using the **https** launch profile so redirect URLs match what the providers expect.

Configuration is in `TaskMaster.Website/appsettings.json` (placeholders below – replace locally with your own values, but **do not** commit real secrets):

```json
"Authentication": {
  "Google": {
    "ClientId": "GOOGLE_CLIENT_ID_HERE",
    "ClientSecret": "GOOGLE_CLIENT_SECRET_HERE"
  },
  "GitHub": {
    "ClientId": "GITHUB_CLIENT_ID_HERE",
    "ClientSecret": "GITHUB_CLIENT_SECRET_HERE"
  }
}
```

To enable each provider:

1. Create an OAuth application in the provider’s developer portal.
2. Use the **exact** redirect URIs below (assuming the https profile that ships with this repo):
   - Google: `https://localhost:7008/signin-google`
   - GitHub: `https://localhost:7008/signin-github`
3. Copy the issued client ID and secret into the `appsettings.json` values above (or a secure user‑secret store).
4. Run the site using the https profile:
   - `dotnet run --project TaskMaster\TaskMaster.Website\TaskMaster.Website.csproj --launch-profile https`
5. Browse to `https://localhost:7008/Account/Login` and use the Google/GitHub buttons.

