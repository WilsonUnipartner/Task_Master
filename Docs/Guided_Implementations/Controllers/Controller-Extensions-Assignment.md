# Guided Implementation: Extending Task Master Controllers

## 1. Learning Objectives

By the end of this exercise you will be able to:

- Add new actions to existing ASP.NET Core controllers.
- Use HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`) to model typical operations.
- Keep controller responsibilities thin by delegating work to services.

The focus here is on the controllers in `TaskMaster.Website`.

---

## 2. Where to Work

- **Controllers folder**: `TaskMaster/TaskMaster.Website/Controllers`
  - `HomeController`
  - `ProfileController`
  - `DashboardController`
  - `NotificationController`
- **Services layer** (read-only for this assignment):
  - `TaskMaster.Services` (for example `TaskDashboardService`)

You will mainly change controller code, not services.

---

## 3. Step 1 – Review Existing Controllers

1. Open each controller and read the existing `GET` action.
2. Note the route of each one:
   - `HomeController` → `/api/home`
   - `ProfileController` → `/api/profile`
   - `DashboardController` → `/api/dashboard`
   - `NotificationController` → `/api/notification`

Worth noting: all controllers are marked with `[ApiController]` and `[Route("api/[controller]")]`, which takes care of common API behavior such as model validation and route prefixes.

---

## 4. Step 2 – Add Additional GET Endpoints

Extend each controller with at least one extra `GET`:

- `HomeController`
  - Add `GET /api/home/week` to return only the current-week tasks.
- `ProfileController`
  - Add `GET /api/profile/{employeeId}` to return a specific profile.
- `DashboardController`
  - Add `GET /api/dashboard/summary` for high-level admin metrics.
- `NotificationController`
  - Add `GET /api/notification/unread` to return only unread notifications.

Each new action should:

- Use clear return types (e.g., `ActionResult<T>` or `IActionResult`).
- Return appropriate status codes (`Ok`, `NotFound`, etc.).
- For now, it is acceptable to return placeholders if the underlying service method does not exist yet; clearly mark these as TODOs in code comments.

---

## 5. Step 3 – Introduce Write Operations (POST / PUT / DELETE)

For **one** controller of your choice (start with `NotificationController` or `ProfileController`):

1. Add a `POST` action that accepts a simple DTO.
   - Example: `POST /api/notification` to create a notification.
2. Add a `PUT` action to update an existing resource.
   - Example: `PUT /api/notification/{id}` to mark a notification as read.
3. Add a `DELETE` action to remove a resource.
   - Example: `DELETE /api/notification/{id}`.

The initial implementation can be in-memory or a placeholder that logs the request. Later assignments can connect these actions to the JSON DataStore.

Worth noting: keep controller actions short. Extract business rules into services to maintain separation of concerns.

---

## 6. Step 4 – Wire Actions to Services (Optional First Pass)

If you are comfortable with the services layer:

1. Identify existing services that can help implement the new actions.
2. Inject those services into the relevant controllers through constructor parameters.
3. Replace placeholder code in actions with calls into services.

Focus on:

- Translating HTTP requests into service calls.
- Translating service results into HTTP responses.

---

## 7. Step 5 – Test the Endpoints

Use a tool of your choice (browser, curl, Postman, or VSCode REST client) to test:

- The original `GET` endpoints.
- Each new `GET`, `POST`, `PUT`, and `DELETE`.

Verify at least:

- Routes respond with expected status codes.
- The JSON shapes are stable and predictable.

---

## 8. Extension Ideas

After the basic actions are in place:

- Add model validation attributes and observe how `[ApiController]` responds to invalid input.
- Introduce DTO types (request/response) to decouple API contracts from internal domain models.
- Add simple authorization checks once authentication is introduced into the project.

