# Guided Implementation: Admin Tasks & Dashboard Page

## 1. Learning Objectives

By the end of this exercise you will be able to:

- Build an Admin dashboard view for monitoring tasks.
- Use the `DashboardController` API to obtain aggregate data.
- Present filters for employee and task status.

---

## 2. Where to Work

- **Website views**: `TaskMaster/TaskMaster.Website/Pages/Admin`
  - Create a Razor Page pair, e.g., `Pages/Admin/Index.cshtml` and `Index.cshtml.cs`.
- **API**: `TaskMaster.Website/Controllers/DashboardController.cs`
  - You will extend this controller to provide admin-oriented metrics.

---

## 3. Step 1 – Define Admin Dashboard Data

1. Decide which metrics the Admin dashboard should display, for example:
   - Total tasks.
   - Tasks per status.
   - Overdue tasks.
   - Tasks per employee.
2. Extend `DashboardController` to expose a `GET /api/dashboard/summary` endpoint that returns these metrics in JSON.
3. The JSON shape might look like:

```json
{
  "totalTasks": 124,
  "overdue": 8,
  "inReview": 24,
  "doneThisWeek": 42,
  "byEmployee": [
    { "employeeId": 2, "name": "Alex Rivera", "openTasks": 5 },
    { "employeeId": 3, "name": "Sarah Jenkins", "openTasks": 3 }
  ]
}
```

You may compute these values from the JSON DataStore or seed an initial sample payload.

---

## 4. Step 2 – Create the Admin Page

1. Add `Pages/Admin/Index.cshtml` and its page model.
2. In the page model, define a view model that matches the JSON from `/api/dashboard/summary`.
3. In `OnGet`, load this summary by:
   - Calling the `DashboardController` through a service, or
   - Using `HttpClient` to call `/api/dashboard/summary`.
4. Store the result in a property accessible from the Razor Page.

---

## 5. Step 3 – Build the Dashboard Layout

In `Admin/Index.cshtml`:

1. Add a header similar to the mockup:
   - Title: “Admin Overview”
   - Short subtitle describing task performance and allocation.
2. Add a row of summary cards:
   - Total tasks.
   - Overdue tasks.
   - In review.
   - Done this week.
3. Below the cards, create a **Task Inventory** table:
   - Columns: Task name, Assigned to, Status, Due date, Last updated.
   - Data can come from another API endpoint (for example `GET /api/dashboard/tasks`) or from the summary response if convenient.

Worth noting: the table does not need to be perfect on the first iteration; focus on getting real data on screen.

---

## 6. Step 4 – Add Filters

1. Above the Task Inventory table, add:
   - A text search box for task name or id.
   - A dropdown for status filter (Backlog, Analyzing, Implementing, Review, Done).
   - A dropdown for employee filter.
2. Initially, filters can be implemented on the server side:
   - Accept query string parameters in the page model.
   - Use them when calling the API or service.
3. Later, filters can be upgraded to use AJAX or fetch requests from the browser.

---

## 7. Step 5 – Wire Navigation

1. Update `_Layout.cshtml` so that the top navigation has an **Admin** entry.
2. Point that entry to the Admin dashboard page.
3. Verify you can navigate to the Admin page, see summary metrics, and interact with basic filters.

---

## 8. Extension Ideas

After the first version is working:

- Add sorting (by due date, status, or assignee).
- Integrate charts on the Admin page (for example, reuse Chart.js to show tasks per status or per employee).
- Add buttons for Admin actions such as creating a task or bulk-updating status, wired to controller actions created in the controllers assignment.

