## Task Master – Login & Authentication Assignment

### 1. Goal of this assignment

By the end of this assignment you should be able to:

- **Sign in** to Task Master using one of the demo accounts from `Users.json`.
- **Understand** how the local JSON user store, cookie authentication, and roles (`Admin`, `Employee`) work together.
- **Protect pages and APIs** with `[Authorize]` and `[Authorize(Roles = "Admin")]`.
- **Explain** why the Google/GitHub buttons are present and what is needed to make them work.

This assignment assumes that:

- You have already restored and built the solution.
- You can run the `TaskMaster.Website` project and browse to the home page.

---

### 2. Explore the local JSON user store

1. Open `TaskMaster/DataStore/Users.json`.
2. Observe the shape of each entry:
   - `username`
   - `password` (plain text – only acceptable here because this is a training project)
   - `role` (`Admin` or `Employee`)
   - `employeeId`
   - `displayName`
3. Identify at least **one Admin** account and **one Employee** account that you will use for testing.

Worth noting: in a real system passwords would be hashed and stored in a secure database or identity provider, not in a flat JSON file.

---

### 3. Understand how login works in the Website project

1. In `TaskMaster.Website`, locate:
   - `Security/AppUser.cs`
   - `Security/JsonAppUserStore.cs`
   - `Controllers/AccountController.cs`
   - `Views/Account/Login.cshtml`
2. Skim through `JsonAppUserStore`:
   - Find where it **loads** `Users.json`.
   - Find the method that **validates** a username and password.
3. In `AccountController`:
   - Find the `HttpGet` action that shows the login page.
   - Find the `HttpPost` action that:
     - Calls the user store to validate credentials.
     - Builds a `ClaimsIdentity` with username and role.
     - Signs in the user using `HttpContext.SignInAsync(...)`.
4. Open `Program.cs`:
   - Locate the `AddAuthentication(...)` and `AddCookie(...)` calls.
   - Note the configured login and logout paths (`/Account/Login`, `/Account/Logout`).

You do not need to modify this code for now; the goal is to understand the flow from **form submit → validate user → issue cookie**.

---

### 4. Sign in with a demo account

1. Run the website (for example, from the solution root):

   ```bash
   dotnet run --project TaskMaster/TaskMaster.Website/TaskMaster.Website.csproj
   ```

2. Browse to the login page:
   - `https://localhost:7008/Account/Login` (if using the https launch profile), or
   - `http://localhost:5000/Account/Login` (depending on your configuration).
3. Sign in with the `admin` account from `Users.json`.
4. After signing in:
   - Look at the top app bar.
   - Confirm that your **display name or initials** and **role** are shown instead of the generic “Sign in” button.
5. Sign out using the logout link or button, then repeat with an **Employee** account.

While you are signed in, open the browser dev tools and inspect the request cookies – you should see an authentication cookie created by ASP.NET Core.

---

### 5. Protecting pages and APIs with `[Authorize]`

In this section you will lock down some parts of the site so they can only be accessed by authenticated users.

1. Choose one Razor Page that should require login, for example the Home dashboard page:
   - Page model file: `Pages/Index.cshtml.cs`.
2. Add the `Authorize` attribute at the top of the page model class:

   ```csharp
   using Microsoft.AspNetCore.Authorization;

   [Authorize]
   public class IndexModel : PageModel
   {
       // existing code
   }
   ```

3. Stop and re-run the site, then:
   - Try to access `/` (the home page) **without** being logged in.
   - Confirm that you are redirected to `/Account/Login`.
4. Sign in and confirm that the page now loads correctly.

Next, protect an API controller:

5. Open `Controllers/HomeController.cs`.
6. Add `[Authorize]` above the controller class or above the `Get` action.
7. With the site running, try to call `/api/home` from the browser or a tool like `curl`:
   - When logged out, you should receive an HTTP 401 (Unauthorized).
   - When logged in, the call should succeed.

Document what you changed and why in a short comment inside your assignment notes (not in the code).

---

### 6. Role-based authorization for Admin-only features

Now you will restrict an area to **Admin** users only.

1. Identify which page or API will be **Admin-only** (for example, the Admin Dashboard page and/or its controller).
2. Add the attribute:

   ```csharp
   [Authorize(Roles = "Admin")]
   ```

   either at the controller level or on specific actions.
3. Run the site and test:
   - Sign in as an **Employee** user and attempt to access the Admin-only endpoint → you should see 403 Forbidden (or a redirect to an access denied page, depending on configuration).
   - Sign in as the **Admin** user and confirm you can access the same endpoint.

Worth noting: multiple roles can be allowed by using a comma-separated list, for example `[Authorize(Roles = "Admin,Manager")]`.

---

### 7. Social logins (Google and GitHub) – conceptual understanding

The login page includes buttons for Google and GitHub sign-in. These are configured in `Program.cs` but will **not work** until valid client IDs and secrets are provided.

1. Open `Docs/Conventions/Authentication_Notes.md` and read the **Social Authentication** section carefully.
2. Locate the `Authentication` section in `appsettings.json` where the keys are expected:

   - `Authentication:Google:ClientId`
   - `Authentication:Google:ClientSecret`
   - `Authentication:GitHub:ClientId`
   - `Authentication:GitHub:ClientSecret`

3. In your own words (in your notes), summarize:
   - What an OAuth client ID and secret are.
   - Why they must **never** be committed to source control.
   - Why the buttons behave like placeholders in this training repository.

If you are curious, you may explore provider documentation for Google or GitHub, but configuring real keys is **optional** and not required to complete this assignment.

---

### 8. Deliverables

To consider this assignment complete, you should be able to demonstrate:

- Successful login and logout using the JSON-backed demo users.
- A protected page and API that redirect or deny access when the user is not authenticated.
- At least one Admin-only endpoint guarded by `[Authorize(Roles = "Admin")]`, tested with both Admin and Employee accounts.
- A short written explanation (in your own notes) of:
  - How the JSON user store, cookie auth, and roles work together.
  - Why social login buttons need real OAuth configuration before they can be used.

You will build on these concepts in later assignments when wiring pages like Profile, Admin Dashboard, and Notification Center to behave differently based on the logged-in user and role.

