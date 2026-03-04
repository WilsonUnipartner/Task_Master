# Task Master Packages and Dependencies

## Overview

This document lists the key tools, SDKs, and package dependencies used in the **Task Master** training solution so interns know what to install and where each dependency is used.

## Global Requirements

- **.NET SDK**
  - Version: `.NET 10` (current SDK installed on this machine)
  - Used by: all `TaskMaster.*` .NET projects
- **Node.js**
  - Example version: `v20.11.0` (confirmed on this machine)
  - Used by: `TaskMaster.Frontend` (Webpack build)
- **NVM (Node Version Manager)** (optional but recommended)
  - Purpose: switch between Node versions if needed
  - Usage examples:
    - `nvm list`
    - `nvm install 20`
    - `nvm use 20`

## Solution Projects and Dependencies

### TaskMaster.Core

- **Project type**: .NET class library
- **Purpose**: domain models, enums, and abstractions
- **NuGet packages**:
  - None beyond the .NET runtime libraries (for now)

Interns will add:

- Domain classes (e.g. `Employee`, `Task`, `Notification`)
- Enums (e.g. `TaskStatus`)
- Interfaces for repositories and services

### TaskMaster.Data

- **Project type**: .NET class library
- **Purpose**: JSON-file data access and repository implementations
- **NuGet packages**:
  - Uses built-in `System.Text.Json` (no extra package required), or optionally:
    - `Newtonsoft.Json` (if you decide to add it later)

Interns will:

- Implement file storage helpers for reading/writing JSON under `DataStore/`
- Implement repositories for `Employees`, `Tasks`, `TaskStatusHistory`, and `Notifications` that map to the JSON schemas defined in the conventions doc

### TaskMaster.Services

- **Project type**: .NET class library
- **Purpose**: application services and orchestration
- **Project references**:
  - `TaskMaster.Core`
  - `TaskMaster.Data`
- **NuGet packages**:
  - None beyond the .NET runtime libraries (for now)

Interns will:

- Add services for:
  - Task management (create/update/status changes, filtering by period and status)
  - Employee profile display
  - Notification center operations

### TaskMaster.Website

- **Project type**: ASP.NET Core Web App (Razor Pages)
- **Purpose**: UI layer, controllers/pages, and static asset hosting
- **Project references**:
  - `TaskMaster.Core`
  - `TaskMaster.Services`
- **NuGet packages**:
  - Default ASP.NET Core web app dependencies created by the `dotnet new webapp` template
  - Additional packages can be added later as needed (e.g. for logging, validation, or UI helpers)

Static assets:

- Bundled JavaScript and CSS are emitted into:
  - `TaskMaster.Website/wwwroot/assets`
  - These are produced by the `TaskMaster.Frontend` Webpack build.

### TaskMaster.Frontend

- **Project type**: Node/JavaScript project (not a .NET project)
- **Purpose**: Frontend JavaScript/TypeScript and styles, bundled for the Website
- **Key files**:
  - `package.json`
  - `webpack.config.js`
  - `src/index.js` (entry point)

**NPM devDependencies** (currently in `package.json`):

- `webpack` (v5+)
- `webpack-cli` (v5+)

Interns will likely add:

- Loaders and plugins for:
  - CSS/SCSS (e.g. `css-loader`, `style-loader`, `sass-loader`)
  - TypeScript if needed (e.g. `ts-loader`, `typescript`)
- App-specific dependencies (e.g. small UI libraries, date helpers) as the frontend grows.

Example install commands (run inside `TaskMaster.Frontend`):

- Install existing devDependencies from `package.json`:
  - `npm install`
- Add additional dev tools later:
  - `npm install --save-dev css-loader style-loader`
  - `npm install --save-dev sass sass-loader`

## Where to Declare New Dependencies

- **.NET dependencies**:
  - Use `dotnet add package <PackageName>` in the relevant project folder.
  - The reference will be added to the project `.csproj` file (e.g. `TaskMaster.Core.csproj`).
- **Node/Frontend dependencies**:
  - Use `npm install <package>` (runtime) or `npm install --save-dev <package>` (dev-only).
  - They will be recorded in `TaskMaster.Frontend/package.json`.

## Intern Exercises with Dependencies

Suggested learning tasks around packages and dependencies:

- Add a small logging or validation library to one of the .NET projects and use it in a service.
- Add a CSS preprocessor (Sass) and configure Webpack to compile `.scss` files.
- Explore how changing a dependency version affects builds (e.g. upgrading Webpack).
- Practice running:
  - `dotnet list package`
  - `npm list --depth=0`
  to see which dependencies are currently in use.

