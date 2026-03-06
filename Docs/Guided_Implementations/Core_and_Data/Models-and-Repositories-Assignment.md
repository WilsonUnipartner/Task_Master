## Task Master – Core Models & JSON Repositories Assignment

### 1. Goal of this assignment

By the end of this assignment you should be able to:

- **Read** the existing `TaskItem` model and `JsonTaskRepository`.
- **Design and implement** two new domain models: `Employee` and `Notification`.
- **Create abstractions** `IEmployeeRepository` and `INotificationRepository` in `TaskMaster.Core`.
- **Implement JSON-backed repositories** `JsonEmployeeRepository` and `JsonNotificationRepository` in `TaskMaster.Data`.
- **Wire repositories into DI** so they can be consumed by services and controllers.

These building blocks are prerequisites for the Profile page and Notification Center assignments.

---

### 2. Review the existing task model and repository

Start by understanding the existing pattern.

1. Open in `TaskMaster.Core`:
   - `Domain/TaskItem.cs`
   - `Enums/TaskStatus.cs`
   - `Abstractions/ITaskRepository.cs`
2. Open in `TaskMaster.Data`:
   - `Repositories/JsonTaskRepository.cs`
3. Open the JSON data:
   - `TaskMaster/DataStore/Tasks.json`
4. Trace the flow:
   - How JSON is deserialized into `TaskItem`.
   - How the repository is exposed as `ITaskRepository`.
   - How `TaskDashboardService` consumes `ITaskRepository`.

Worth noting: this is the pattern you will follow for `Employee` and `Notification` – one domain model, one interface in `Core`, and one JSON repository in `Data`.

---

### 3. Inspect the Employee and Notification JSON data

Before designing models, look at the sample data.

1. Open:
   - `TaskMaster/DataStore/Employees.json`
   - `TaskMaster/DataStore/Notifications.json`
2. For each file, identify:
   - The primary identifier (for example, `id` or `employeeId`).
   - Properties that are required for the Profile page, Admin Dashboard, and Notification Center (such as `fullName`, `email`, `title`, `status`, `message`, `createdAt`, `isRead`, etc.).
3. Make a short list in your notes of the properties you expect the C# models to expose.

You may see fields that are not immediately needed by the UI; it is acceptable to include them if they describe the domain well.

---

### 4. Create `Employee` and `Notification` domain models

In `TaskMaster.Core/Domain`:

1. Add `Employee.cs` with properties that map to `Employees.json`, for example:
   - `Id`
   - `FullName`
   - `Email`
   - `JobTitle`
   - `AvatarUrl` (optional, may be `null` if not set)
2. Add `Notification.cs` with properties that map to `Notifications.json`, for example:
   - `Id`
   - `EmployeeId` (which user the notification belongs to)
   - `Message`
   - `CreatedAtUtc`
   - `IsRead`
   - `Type` (if the JSON includes one, e.g., `TaskAssigned`, `StatusChanged`, etc.)
3. Follow the conventions used in `TaskItem`:
   - Use `DateTime` or `DateTime?` for dates.
   - Use `int` or `Guid` for identifiers (matching the JSON).
   - Place the models in the `TaskMaster.Core.Domain` namespace.

Compile frequently to catch typos early.

---

### 5. Define repository interfaces in `TaskMaster.Core`

In `TaskMaster.Core/Abstractions`:

1. Add `IEmployeeRepository.cs` with at least:
   - A method to retrieve all employees.
   - A method to retrieve a single employee by id.
2. Add `INotificationRepository.cs` with at least:
   - A method to retrieve all notifications for a given employee.
   - (Optional for now) A method to mark a notification as read.
3. Keep interfaces intentionally small; you can extend them later as the UI needs more behavior.

Aim for clear, intention-revealing method names such as `GetAll()`, `GetById(int id)`, `GetByEmployeeId(int employeeId)`, etc.

---

### 6. Implement JSON repositories in `TaskMaster.Data`

In `TaskMaster.Data/Repositories`:

1. Add `JsonEmployeeRepository.cs`:
   - Constructor should accept the path to `Employees.json`.
   - On first access, load and deserialize the JSON into a list of `Employee`.
   - Implement the methods from `IEmployeeRepository`.
2. Add `JsonNotificationRepository.cs`:
   - Constructor should accept the path to `Notifications.json`.
   - Load and deserialize the JSON into a list of `Notification`.
   - Implement the methods from `INotificationRepository`.
3. Reuse patterns from `JsonTaskRepository`:
   - Use `System.Text.Json` with appropriate `JsonSerializerOptions`.
   - Use `IReadOnlyCollection<T>` where appropriate for return types.

Worth noting: for this training project, repositories may load data into memory once and serve read-only queries. You do not need to implement persistence of changes unless a later assignment asks for it explicitly.

---

### 7. Wire repositories into the Website DI container

Once the implementations are ready, make them available to the web layer.

1. Open `TaskMaster.Website/Program.cs`.
2. Find where `ITaskRepository` is registered.
3. Register `IEmployeeRepository` and `INotificationRepository` in a similar way:
   - Resolve `IHostEnvironment`.
   - Build the path to the `DataStore` folder.
   - Build the full paths to `Employees.json` and `Notifications.json`.
   - Construct `JsonEmployeeRepository` and `JsonNotificationRepository` with those paths.
4. Rebuild the solution to confirm there are no DI-related compile-time errors.

Later assignments (Profile page and Notification Center) will rely on these registrations, so take a moment to double-check the paths.

---

### 8. Sanity checks and small experiments

Once everything compiles:

1. Temporarily inject `IEmployeeRepository` into a simple test controller or page model and log:

   ```csharp
   var employees = _employeeRepository.GetAll();
   ```

2. Run the site and confirm that you can see the expected number of employees.
3. Repeat for `INotificationRepository` and confirm that:
   - You can retrieve notifications for a known employee id from `Users.json`.

You may remove or comment out this experimental code once you are confident that repositories behave as expected.

---

### 9. Deliverables

To consider this assignment complete, you should have:

- `Employee` and `Notification` domain models in `TaskMaster.Core/Domain`.
- `IEmployeeRepository` and `INotificationRepository` interfaces in `TaskMaster.Core/Abstractions`.
- `JsonEmployeeRepository` and `JsonNotificationRepository` classes in `TaskMaster.Data/Repositories`.
- DI registrations in `Program.cs` so the repositories can be injected where needed.
- A short written note (for yourself) summarizing:
  - How the JSON data files map to the C# models.
  - How repositories hide file system details behind clean interfaces.

These pieces will be used directly in the Profile, Admin Dashboard, and Notification Center view assignments.

