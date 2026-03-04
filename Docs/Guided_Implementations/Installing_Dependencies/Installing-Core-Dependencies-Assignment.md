# Guided Implementation: Installing Core Dependencies for Task Master

## 1. Learning Objectives

By the end of this exercise you will be able to:

- Verify and install the required .NET SDK.
- Install Node.js with nvm and select the correct version.
- Restore .NET solution dependencies.
- Install and build the Frontend npm dependencies.

The goal is to prepare a clean development environment for working on Task Master.

---

## 2. Prerequisites

- A terminal with access to `dotnet` and (optionally) `nvm`.
- Access to the Task Master repository folder:
  - `WS_Intern_OnBoarding/TaskMaster`

You should run all commands **from inside this repository**, unless instructed otherwise.

---

## 3. Step 1 – Check the .NET SDK

1. In a terminal, check the installed .NET SDK version:

   ```bash
   dotnet --version
   ```

2. Confirm that the version is compatible with the `TargetFramework` used by the projects:

   - Look in any `.csproj` file (for example `TaskMaster.Core/TaskMaster.Core.csproj`) for:
     ```xml
     <TargetFramework>net10.0</TargetFramework>
     ```

3. If `dotnet --version` does not report a 10.x SDK, install the appropriate .NET SDK from the official download page and re-run the command until it matches.

Worth noting: all .NET projects in this solution share the same target framework, so a single SDK installation is sufficient.

---

## 4. Step 2 – Install Node.js Using nvm

This step ensures that everyone uses a compatible Node.js version for the Frontend build.

1. Check whether `nvm` is available:

   ```bash
   nvm list
   ```

2. If `nvm` is installed, choose a Node.js version (for example 20.x):

   ```bash
   nvm install 20
   nvm use 20
   ```

3. Verify the active Node.js version:

   ```bash
   node -v
   ```

4. If `nvm` is not available on your system, install Node.js directly from the official website and ensure the version is reasonably recent (Node 18 or later).

---

## 5. Step 3 – Restore .NET Dependencies

1. Move into the Task Master solution folder:

   ```bash
   cd TaskMaster
   ```

2. Restore all .NET dependencies:

   ```bash
   dotnet restore
   ```

3. Build the solution to confirm everything compiles:

   ```bash
   dotnet build
   ```

You should see **Build succeeded** with zero errors before proceeding.

---

## 6. Step 4 – Install Frontend npm Dependencies

1. Navigate to the Frontend project:

   ```bash
   cd TaskMaster.Frontend
   ```

2. Install the dependencies defined in `package.json`:

   ```bash
   npm install
   ```

3. After installation, build the frontend bundle:

   ```bash
   npm run build
   ```

   - This should produce:
     - `TaskMaster.Website/wwwroot/css/main.css`
     - `TaskMaster.Website/wwwroot/js/bundle.js`

4. If the build fails, carefully read the terminal output, fix any version or missing-module issues, and re-run `npm run build`.

Worth noting: `npm install` only needs to be run once per machine (or when `package.json` changes), while `npm run build` should be run whenever frontend code or styles are updated.

---

## 7. Step 5 – Run the Application End-to-End

1. Return to the solution root:

   ```bash
   cd ..
   ```

2. Start the Task Master website:

   ```bash
   dotnet run --project TaskMaster.Website/TaskMaster.Website.csproj
   ```

3. Open the browser at:

   ```text
   http://localhost:5110
   ```

4. Confirm that:

   - The Home dashboard loads without errors.
   - The layout styles from `main.css` are applied.
   - The browser console does not show missing script or style errors.

---

## 8. Extension Ideas

After completing this setup:

- Document the exact versions of .NET, Node.js, and npm you used in a small `Environment.md` file under `Docs/Conventions/`.
- Practice switching Node.js versions with `nvm use` and re-running `npm run build`.
- Explore `dotnet --info` and `npm list --depth=0` to understand how your tools and dependencies are organized.

