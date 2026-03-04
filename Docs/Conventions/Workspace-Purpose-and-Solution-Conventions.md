# Workspace Purpose and Solution Conventions

**Solution Name:** Task Master

## Table of Contents

- [Purpose of This Workspace](#purpose-of-this-workspace)
- [Product Scenario](#product-scenario)
- [Task Status and Color Convention](#task-status-and-color-convention)
- [Minimal Solution Architecture](#minimal-solution-architecture)
- [Learning Scope by Topic](#learning-scope-by-topic)
- [Frontend Build and Tooling Conventions](#frontend-build-and-tooling-conventions)
- [Git and GitHub Onboarding Convention](#git-and-github-onboarding-convention)
- [Delivery Principle](#delivery-principle)
- [Definition of Done for the Initial Iteration](#definition-of-done-for-the-initial-iteration)
- [Data Strategy (First Iteration – JSON Files)](#data-strategy-first-iteration--json-files)
- [Starter Data Model](#starter-data-model)

## Purpose of This Workspace

This workspace exists to help new interns practice and improve their Microsoft .NET skills by building a realistic but minimal business platform called Task Master.

The target technology direction is:

- .NET 10 (when available in the project environment)
- ASP.NET Core (API and Controllers)
- Azure Functions
- Razor Pages / MVC Website
- Web Services integration patterns
- Frontend asset pipeline with Node.js and Webpack

The learning objective is to combine backend, frontend, and infrastructure practices in one cohesive training solution.

## Product Scenario

Task Master represents an internal platform for a small company where employees can:

- Access a profile page
- Create and update tasks
- Change task status
- View dashboards by period
- Read alerts in a notification center

It also includes an Admin area where administrators can:

- Create and assign tasks
- Change task status
- Send notifications and alerts
- View dashboard metrics by period
- Filter tasks by employee name and task status

The Home page should include a dashboard for all tasks in the current week.

## Task Status and Color Convention

Use a consistent status flow and visual color code:

- Backlog
- Analyzing
- Implementing
- Review
- Done

Suggested default colors:

- Backlog: Gray
- Analyzing: Blue
- Implementing: Orange
- Review: Purple
- Done: Green

These values can later be centralized in configuration or shared constants.

## Minimal Solution Architecture

The initial solution should be split into five projects:

1. Frontend Project
   - JavaScript/TypeScript source
   - CSS/SCSS source
   - Build output consumed by the Website project
2. Services Project
   - Application services and orchestration
   - External integrations and service contracts
3. Data Project
   - Persistence layer
   - Repositories / data access
   - DbContext and migrations (if EF Core is used)
4. Core Project
   - Domain models
   - Business rules
   - Shared abstractions and contracts
5. Website Project
   - Razor pages / MVC views
   - Controllers and UI composition
   - Static asset consumption from Frontend build output

## Learning Scope by Topic

Interns should practice:

- APIs with ASP.NET Core controllers
- Azure Functions for background/event-driven tasks
- Website UI with Razor
- Service boundaries and separation of concerns
- Domain and data modeling
- Dashboard and filtering logic
- Notifications and status updates
- Basic testability and maintainability practices

## Frontend Build and Tooling Conventions

Node and bundling are part of the training goals.

Interns should learn to:

1. Check Node.js version
   - `node -v`
2. Use NVM to manage Node versions
   - `nvm list`
   - `nvm install <version>`
   - `nvm use <version>`
3. Install dependencies with npm
   - `npm install`
4. Bundle JavaScript and CSS with Webpack
   - Development build command
   - Production build command
5. Publish frontend bundles to the Website static assets path
   - Example target: `Website/wwwroot/assets`

Recommended baseline:

- Pin supported Node major version in documentation and/or `.nvmrc`
- Keep Webpack config simple for intern readability
- Include scripts in `package.json` for build/watch flows

## Git and GitHub Onboarding Convention

This workspace should be hosted in GitHub so interns can clone, branch, and collaborate.

Minimum onboarding topics:

- GitHub account creation
- Repository access and cloning
- Branch creation for features
- Commit message basics
- Pull request workflow
- Code review basics

Suggested beginner command sequence:

1. `git clone <repo-url>`
2. `git checkout -b feature/<short-name>`
3. `git status`
4. `git add .`
5. `git commit -m "Add <change>"`
6. `git push -u origin feature/<short-name>`

Suggested follow-up training:

- How to keep branch updated from main
- How to resolve simple merge conflicts
- How to inspect history (`git log`, `git diff`)

## Delivery Principle

Build a minimal, end-to-end, working solution first. Then iterate.

Priority order:

1. Working architecture and project boundaries
2. Core task flow (create/update/status)
3. Admin assignment and filtering
4. Weekly dashboard
5. Notification center
6. Azure Function extensions
7. UX and quality improvements

## Definition of Done for the Initial Iteration

The first iteration is complete when:

- Solution builds successfully
- All five projects are present and referenced correctly
- Website can display current-week tasks
- Employees can update task status
- Admin can assign tasks and filter dashboard data
- Notification center shows at least basic alerts
- Frontend assets are bundled via Webpack and served by Website
- Basic onboarding instructions for Node/NVM/Git are documented

## Data Strategy (First Iteration – JSON Files)

For the first version of Task Master, data should be stored in **simple JSON files** instead of a database.

This keeps the setup:

- Free and very easy to run on any machine
- Transparent for interns (they can open and inspect the data files)
- A gentle introduction to modeling and persistence before using a relational DB in a future project

Later, the same domain model can be moved to SQL Server / EF Core in a separate training solution.

### Storage Conventions

- All JSON data files live under a dedicated folder in the solution, for example:
  - `DataStore/Employees.json`
  - `DataStore/Tasks.json`
  - `DataStore/TaskStatusHistory.json`
  - `DataStore/Notifications.json`
- During development, these files can be committed to Git with small demo datasets.
- For more advanced exercises, interns can practice:
  - Creating a per-developer copy (e.g. `DataStore/dev/<username>/...`)
  - Resetting data from sample templates.

### Access Pattern

- The `Data` project exposes services/repositories that:
  - Read JSON from disk on demand (or with simple in-memory caching)
  - Deserialize into domain models defined in `Core`
  - Apply changes in memory
  - Persist by writing the JSON files back to disk
- File access can be wrapped behind interfaces so a future DB-backed implementation can be swapped in without changing the rest of the code.

### Starter Data Model

The same conceptual entities still apply; they are just stored as JSON instead of tables.

### Employees

- Represents a person who can own tasks and receive notifications.
- Stored as an array in `Employees.json`.

Suggested JSON fields:

- `id` (GUID or int)
- `employeeNumber` (string, unique)
- `firstName`
- `lastName`
- `email`
- `isActive` (bool)

### Tasks

- Represents a unit of work assigned to an employee.
- Stored as an array in `Tasks.json`.

Suggested JSON fields:

- `id`
- `title`
- `description`
- `employeeId` (id that matches an entry in `Employees.json`)
- `status` (string: Backlog, Analyzing, Implementing, Review, Done)
- `createdAtUtc` (ISO 8601 string)
- `dueDateUtc` (ISO 8601 string or null)

Filtering (instead of DB indexing):

- Dashboards and reports filter in memory by `employeeId`, `status`, and date range.

### TaskStatusHistory

- Tracks changes to a task’s status over time.
- Stored as an array in `TaskStatusHistory.json`.

Suggested JSON fields:

- `id`
- `taskId`
- `oldStatus`
- `newStatus`
- `changedAtUtc`
- `changedBy` (employee/admin identifier)

### Notifications

- Represents alerts shown in the Notification Center.
- Stored as an array in `Notifications.json`.

Suggested JSON fields:

- `id`
- `employeeId`
- `title`
- `message`
- `createdAtUtc`
- `isRead`
- `type` (info, warning, alert)
- `taskId` (optional, nullable link back to a task)

### JSON Seed Data Conventions

- Ship the repository with small default JSON files:
  - A few employees (`Admin`, `DemoUser1`, `DemoUser2`)
  - A set of tasks in different statuses
  - Some notifications
- When interns need a clean slate, they can:
  - Copy template files from a `DataStore/Templates` folder, or
  - Use a simple reset script/command provided later.

This keeps initial data visible and easy to reset without any database tools.

