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
