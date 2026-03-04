# Task Master Startup Commands

This guide shows the **exact command sequence** to get the Task Master solution running on a fresh machine, from Node/NPM and Webpack build to a successful `.NET` run.

> All commands below assume you have already cloned the repository to your machine.

---

## 1. Navigate to the Workspace Root

Open a terminal (PowerShell recommended) and change to the folder where you cloned the repository.

Example (your path will be different):

```powershell
cd path\to\cloned\Task_Master
```

You should see the `Docs` and `TaskMaster` folders when you run:

```powershell
ls
```

---

## 2. Verify .NET SDK

Task Master targets **.NET 10** (`net10.0`).

Check your installed SDK and runtime:

```powershell
dotnet --version
dotnet --list-sdks
```

If `.NET 10` is not installed, install the appropriate SDK before continuing.

---

## 3. Verify Node.js and NPM

Task Master uses a Node/webpack frontend under `TaskMaster/TaskMaster.Frontend`.

Check your Node and npm versions:

```powershell
node -v
npm -v
```

The training environment currently uses **Node 20** (example: `v20.11.0`). Any compatible Node 20.x version is fine.

---

## 4. (Optional but Recommended) Use NVM to Manage Node Versions

If you have **NVM for Windows** installed, use it to ensure you are on a supported Node version:

```powershell
nvm list
nvm install 20
nvm use 20
node -v
```

If `nvm` is not installed, you can skip these commands and use your existing Node installation as long as it is reasonably up to date (Node 18+ recommended, Node 20 preferred).

---

## 5. Install Frontend Dependencies (TaskMaster.Frontend)

Change into the frontend project and install `devDependencies` from `package.json`:

```powershell
cd TaskMaster\TaskMaster.Frontend
npm install
```

This will install:

- `webpack`
- `webpack-cli`
- `css-loader`
- `mini-css-extract-plugin`

---

## 6. Build Frontend Assets with Webpack

Still inside `TaskMaster\TaskMaster.Frontend`, run a production build:

```powershell
npm run build
```

This uses the `webpack.config.js` configuration to bundle JavaScript and CSS and output them to the Website static assets folder (under `TaskMaster.Website/wwwroot`).

For development watch mode (optional):

```powershell
npm start
```

Keep this running in a separate terminal if you want automatic rebuilds while coding.

---

## 7. Restore and Build the .NET Solution

Open a **new terminal** (or stop the Webpack watch command) and go back to the workspace root (the folder that contains `Docs` and `TaskMaster`):

```powershell
cd path\to\cloned\Task_Master
```

Restore NuGet packages for all projects:

```powershell
dotnet restore TaskMaster\TaskMaster.slnx
```

Build the entire solution:

```powershell
dotnet build TaskMaster\TaskMaster.slnx
```

You should see `Build succeeded.` with no errors.

---

## 8. Run the ASP.NET Core Website

From the workspace root, run the Website project directly:

```powershell
dotnet run --project TaskMaster\TaskMaster.Website\TaskMaster.Website.csproj
```

or, if you prefer to change into the Website folder first:

```powershell
cd TaskMaster\TaskMaster.Website
dotnet run
```

When the application starts, the console will show a URL similar to:

```text
Now listening on: http://localhost:5xxx
```

Open that URL in your browser to access the Task Master web application.

---

## 9. Full Command Sequence (Quick Copy/Paste)

Below is the **ordered command list** from a clean terminal session.

```powershell
# 1) Go to workspace root (adjust path to your clone)
cd path\to\cloned\Task_Master

# 2) Verify .NET
dotnet --version
dotnet --list-sdks

# 3) Verify Node/NPM
node -v
npm -v

# 4) (Optional) Use NVM
nvm list          # if available
nvm install 20    # if needed
nvm use 20        # if installed
node -v

# 5) Install frontend dependencies
cd TaskMaster\TaskMaster.Frontend
npm install

# 6) Build frontend assets
npm run build

# 7) Restore and build .NET solution
cd path\to\cloned\Task_Master
dotnet restore TaskMaster\TaskMaster.slnx
dotnet build TaskMaster\TaskMaster.slnx

# 8) Run the Website
dotnet run --project TaskMaster\TaskMaster.Website\TaskMaster.Website.csproj
```

Follow these commands top to bottom to get from a fresh clone to a running Task Master application.

