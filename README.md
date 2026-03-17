## Introduction

Task Master is a guided training solution designed to help interns ramp up on a modern .NET and JavaScript stack using a realistic, but contained, task management application. The objective of this workspace is to walk you step‑by‑step through setting up your environment, understanding the solution structure, and implementing incremental features (frontend, backend, and authentication) in a safe learning context.

### Recommended starting point

To understand the recommended learning flow and which assignment to tackle next, start with the guided path:
`Docs/Guided_Implementations/TaskMaster-Guided-Path.md`

## Building the solution

### 1) Go to workspace root (adjust path to your clone)
cd path\to\cloned\Task_Master

### 2) Verify .NET
dotnet --version
dotnet --list-sdks

### 3) Verify Node/NPM
node -v
npm -v

### 4) (Optional) Use NVM
nvm list          # if available
nvm install 20    # if needed
nvm use 20        # if installed
node -v

### 5) Install frontend dependencies
cd TaskMaster\TaskMaster.Frontend
npm install

### 6) Build frontend assets
npm run build

### 7) Restore and build .NET solution
cd path\to\cloned\Task_Master
dotnet restore TaskMaster\TaskMaster.slnx
dotnet build TaskMaster\TaskMaster.slnx

### 8) Run the Website
dotnet run --project TaskMaster\TaskMaster.Website\TaskMaster.Website.csproj
