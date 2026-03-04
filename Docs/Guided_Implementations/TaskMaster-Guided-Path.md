# Task Master – Guided Implementation Path

This document describes the **recommended order of progress** for interns working on the Task Master solution. Follow the steps in sequence; each step prepares the ground for the next one.

As new guided assignments are added, this path should be updated.

---

## 1. Environment and Dependencies

**Goal:** Ensure your machine can build and run Task Master.

1. Start in `Docs/Guided_Implementations/Installing_Dependencies/Installing-Core-Dependencies-Assignment.md`.
2. Complete all steps:
   - Verify .NET SDK.
   - Install Node.js (ideally via nvm) and select the correct version.
   - Run `dotnet restore` and `dotnet build` in the `TaskMaster` solution.
   - Run `npm install` and `npm run build` in `TaskMaster.Frontend`.
3. Confirm you can open `http://localhost:5110` and see the Home dashboard.

You should not move on until this is working reliably.

---

## 2. Understand the Solution Structure

**Goal:** Know what each project is responsible for.

1. Read `Docs/Conventions/Workspace-Purpose-and-Solution-Conventions.md`.
2. Skim these projects in the solution:
   - `TaskMaster.Core` – domain models and abstractions.
   - `TaskMaster.Data` – JSON-based repositories.
   - `TaskMaster.Services` – orchestration and dashboard logic.
   - `TaskMaster.Website` – Razor pages, controllers, and static assets.
   - `TaskMaster.Frontend` – Webpack, JS, and CSS.
3. Optional: open `Docs/Conventions/Packages-and-Dependencies.md` to see where each dependency lives.

---

## 3. Explore the Existing Home Dashboard

**Goal:** Connect the dots between data, services, and the Home page UI.

Recommended files to read (in this order):

1. `TaskMaster.Core/Domain/TaskItem.cs` and `Enums/TaskStatus.cs`
2. `TaskMaster.Data/Repositories/JsonTaskRepository.cs`
3. `TaskMaster.Services/TaskManagement/TaskDashboardService.cs`
4. `TaskMaster.Website/Program.cs` (service wiring)
5. `TaskMaster.Website/Pages/Index.cshtml.cs` and `Index.cshtml`
6. `TaskMaster/DataStore/*.json` to see the sample data.

After reading, reload the Home page and verify you understand where each piece of data is coming from.

---

## 4. Frontend Assets and Layout

**Goal:** Understand how JS and CSS reach the browser.

1. Visit `TaskMaster.Frontend`:
   - `src/index.js`
   - `src/styles.css`
   - `webpack.config.js`
2. Observe where Webpack outputs:
   - `TaskMaster.Website/wwwroot/css/main.css`
   - `TaskMaster.Website/wwwroot/js/bundle.js`
3. Open `_Layout.cshtml` to see how these bundles are referenced.

Once this is clear, you are ready to work on richer frontend behavior such as charts.

---

## 5. Implement the Status Distribution Chart (Chart.js)

**Goal:** Add a real data-driven chart to the Home dashboard.

1. Move to `Docs/Guided_Implementations/Chart.js/Status-Distribution-Chart-Assignment.md`.
2. Follow the assignment:
   - Install `chart.js` in `TaskMaster.Frontend`.
   - Add the `<canvas id="statusChart">` element in the Status Distribution card on `Index.cshtml`.
   - Use `fetch("/api/home")` in `src/index.js` to retrieve dashboard data.
   - Compute status counts and render a Chart.js doughnut chart.
3. Rebuild the frontend (`npm run build`) and verify the chart appears and responds to data changes.

---

## 6. API and Controller Extensions

**Goal:** Practice HTTP verbs and separation of concerns.

After completing the chart assignment, extend the API:

1. Review controllers in `TaskMaster.Website/Controllers`:
   - `HomeController`
   - `ProfileController`
   - `DashboardController`
   - `NotificationController`
2. For each controller, add:
   - Additional `GET` endpoints as needed.
   - Placeholder `POST`, `PUT`, and `DELETE` actions that interns can later implement fully.
3. Follow the detailed steps in:
   - `Docs/Guided_Implementations/Controllers/Controller-Extensions-Assignment.md`

---

## 7. Views and New Screens (Future Steps)

**Goal:** Build out the remaining mockups as working screens.

Once the basics above are complete, move on to the view-focused assignments:

- **Step 7.1 – Profile & My Tasks**
  - `Docs/Guided_Implementations/Views/Profile-Page-Assignment.md`
- **Step 7.2 – Admin Dashboard**
  - `Docs/Guided_Implementations/Views/Admin-Dashboard-Assignment.md`
- **Step 7.3 – Notification Center**
  - `Docs/Guided_Implementations/Views/Notification-Center-Assignment.md`

---

## 8. Keeping This Path Up to Date

Whenever a new guided assignment is created:

1. Decide where it belongs in the learning sequence.
2. Add a short entry in this document that:
   - Names the assignment.
   - Points to its path under `Docs/Guided_Implementations/`.
   - States when an intern should tackle it (what they should know first).

This document should always be the **first stop** for someone new to the Task Master project.

