# Guided Implementation: Employee Profile & My Tasks Page

## 1. Learning Objectives

By the end of this exercise you will be able to:

- Build a Razor Page that matches the Employee Profile & My Tasks mockup.
- Call the appropriate API controller (`ProfileController`) from the UI.
- Display tasks grouped into sections such as Current, Completed, and Archived.

---

## 2. Where to Work

- **Website views**: `TaskMaster/TaskMaster.Website/Pages`
  - Create a new Razor Page pair under `Pages/Profile` (e.g., `Index.cshtml` and `Index.cshtml.cs`), or a single `Profile.cshtml`/`.cshtml.cs` pair at the root.
- **API**: `TaskMaster.Website/Controllers/ProfileController.cs`
  - You will extend this controller to return realistic profile data and task lists.

The goal is to keep logic in the controller and services, and keep the Razor Page focused on presentation.

---

## 3. Step 1 – Extend the Profile API

1. Open `ProfileController.cs`.
2. Replace or extend the existing placeholder `GET` action so that it returns:
   - Basic employee information (name, role, email, location).
   - Summary counts (completed, in-progress, upcoming tasks).
   - A list of tasks assigned to that employee.
3. For this exercise, it is acceptable to:
   - Either read from the existing JSON DataStore (`Employees.json`, `Tasks.json`),
   - Or return a hard-coded sample payload with the shape you plan to use in the UI.

Aim for a JSON shape roughly like:

```json
{
  "employeeId": 2,
  "fullName": "Alex Rivera",
  "role": "Product Designer",
  "location": "Lisbon, Portugal",
  "completed": 24,
  "inProgress": 8,
  "upcoming": 12,
  "tasks": [
    {
      "title": "Design System Audit",
      "status": "Implementing",
      "dueDate": "2026-03-10",
      "priority": "High"
    }
  ]
}
```

---

## 4. Step 2 – Create the Profile Page

1. Add a new Razor Page for the profile:

   - Example:
     - `Pages/Profile/Index.cshtml`
     - `Pages/Profile/Index.cshtml.cs`

2. In the page model (`Index.cshtml.cs`), define a simple view model type that matches the JSON shape from the API.
3. In `OnGet`, call the API:

   - For now, you may:
     - Call `ProfileController` directly through services, or
     - Use `HttpClient` to call `/api/profile` (for extra practice).

4. Pass the resulting view model to the Razor Page.

---

## 5. Step 3 – Build the Layout

In `Profile/Index.cshtml`:

1. Recreate the main sections from the mockup:
   - Profile header with avatar, name, role, and location.
   - Stats row (Completed, In Progress, Upcoming).
   - Tabbed area or simple headings for task lists:
     - Current Tasks
     - Completed
     - Archived
2. Use existing CSS classes where possible and add new ones in `TaskMaster.Frontend/src/styles.css`.
3. Render tasks in a list or card layout, showing:
   - Task title
   - Short description (if available)
   - Status badge
   - Due date and priority

Worth noting: keep the markup semantic (`<section>`, `<header>`, `<article>`) so it is easy to style and reason about.

---

## 6. Step 4 – Wire Navigation

1. Update the global navigation in `_Layout.cshtml`:
   - Ensure the “My Tasks” link points to your new Profile page.
2. Run the site and navigate via the navbar to confirm routing works correctly.

---

## 7. Step 5 – Test with Real Data

1. Add or adjust entries in `DataStore/Employees.json` and `DataStore/Tasks.json` so at least one employee has several tasks in different statuses.
2. Adjust your `ProfileController` logic to:
   - Resolve the chosen employee (by id or hard-coded for now).
   - Filter tasks by `employeeId`.
3. Refresh the Profile page and confirm the counts and lists match the underlying JSON data.

---

## 8. Extension Ideas

After the basic profile page works:

- Add filtering or sorting options for the task list (e.g., by due date or priority).
- Support switching between employees (query string parameter or dropdown).
- Add status badges that use the same color scheme as the Home dashboard.

