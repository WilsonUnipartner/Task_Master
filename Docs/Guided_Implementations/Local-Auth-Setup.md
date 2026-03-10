## Guided Implementation: Local Auth Secrets Setup

This guide explains how to configure **Google** and **GitHub** authentication secrets **locally** for the Task Master website without committing any sensitive data to GitHub.

The key idea:  
**Use `dotnet user-secrets` for local development, and Azure App Settings for the deployed app.**  
Do **not** put real secrets in any `appsettings*.json` file that is committed to the repo.

---

### 1. Prerequisites

- .NET SDK installed (same version used by the Task Master solution).
- You have created **OAuth apps** for:
  - Google (for localhost)
  - GitHub (for localhost)
- You know the **Client ID** and **Client Secret** for each.

> Each intern should create their **own** OAuth apps using their own accounts.  
> Do not share client secrets in the repository or over chat.

---

### 2. Initialize User Secrets for `TaskMaster.Website`

1. Open a terminal at the repo root and navigate to the web project:

   ```bash
   cd TaskMaster/TaskMaster.Website
   ```

2. Initialize the user-secrets store (one time per machine/project):

   ```bash
   dotnet user-secrets init
   ```

   If it prints a message saying it is already initialized, that is fine.

---

### 3. Store Google OAuth secrets locally

Use the values from **your** Google OAuth application (configured for localhost, e.g. `https://localhost:7031/signin-google`).

Run these commands from the `TaskMaster.Website` folder:

```bash
dotnet user-secrets set "Authentication:Google:ClientId" "<YOUR_LOCAL_GOOGLE_CLIENT_ID>"
dotnet user-secrets set "Authentication:Google:ClientSecret" "<YOUR_LOCAL_GOOGLE_CLIENT_SECRET>"
```

These values are stored **outside the repository** under your user profile and are automatically loaded when the app runs in the `Development` environment.

---

### 4. Store GitHub OAuth secrets locally

Use the values from your **local** GitHub OAuth app (with redirect like `https://localhost:7031/signin-github`).

```bash
dotnet user-secrets set "Authentication:GitHub:ClientId" "<YOUR_LOCAL_GITHUB_CLIENT_ID>"
dotnet user-secrets set "Authentication:GitHub:ClientSecret" "<YOUR_LOCAL_GITHUB_CLIENT_SECRET>"
```

Again, these values are not written to any `appsettings*.json` file and are not committed to Git.

---

### 5. How configuration binding works

The `Program.cs` in `TaskMaster.Website` reads configuration like this:

```csharp
options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? string.Empty;
options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? string.Empty;
options.ClientId = builder.Configuration["Authentication:GitHub:ClientId"] ?? string.Empty;
options.ClientSecret = builder.Configuration["Authentication:GitHub:ClientSecret"] ?? string.Empty;
```

In **Development** the configuration provider order is:

1. User secrets (`dotnet user-secrets`)
2. Environment variables
3. `appsettings.Development.json` (if present)
4. `appsettings.json`

Because user-secrets come first, they override any placeholder values in `appsettings.json`.

---

### 6. Safe `appsettings.json` contents

`appsettings.json` should keep **only placeholders**, so it is safe to commit:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
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
}
```

Do **not** replace these placeholders with real values in the committed file.

---

### 7. Running the app locally

1. From `TaskMaster.Website`, run:

   ```bash
   dotnet run
   ```

2. Navigate to the login page (usually `https://localhost:<port>/Account/Login`).
3. Test the **Google** and **GitHub** buttons:
   - If the OAuth configuration is correct and user-secrets are set, you should be redirected to the provider and then back to the app.

If authentication fails, double-check:

- The **client IDs/secrets** stored with `dotnet user-secrets list`.
- The **redirect URIs** registered in your Google/GitHub apps (they must match the localhost URLs).

---

### 8. Summary for interns

- **Never** commit real OAuth secrets to the repository.
- Use `dotnet user-secrets` for **local** development.
- Use **Azure App Settings** (with values for `Authentication__Google__*` and `Authentication__GitHub__*`) for the **deployed** app.
- `appsettings.json` should only contain non-sensitive defaults and placeholders.

