# Guided Implementation: Notification Center Page

## 1. Learning Objectives

By the end of this exercise you will be able to:

- Build a Notification Center page that lists user notifications.
- Use the `NotificationController` API to retrieve data.
- Provide basic interactions such as marking notifications as read.

---

## 2. Where to Work

- **Website views**: `TaskMaster/TaskMaster.Website/Pages/Notifications`
  - Create `Index.cshtml` and `Index.cshtml.cs` for the Notification Center.
- **API**: `TaskMaster.Website/Controllers/NotificationController.cs`
  - You will extend this controller to support listing and updating notifications.

---

## 3. Step 1 – Shape the Notification Data

1. Decide the minimal information you need for each notification:
   - Title.
   - Message.
   - Created date/time.
   - Type (info, warning, alert).
   - Read/unread flag.
2. Extend the existing `GET /api/notification` endpoint to return a list of notifications with this shape.
3. Use `DataStore/Notifications.json` as the source of truth, or seed sample notifications in memory.

Example JSON entry:

```json
{
  "id": 1,
  "title": "New Task Assigned",
  "message": "You have been assigned a new task.",
  "createdAt": "2026-03-01T09:05:00Z",
  "type": "info",
  "isRead": false
}
```

---

## 4. Step 2 – Create the Notification Center Page

1. Add `Pages/Notifications/Index.cshtml` and its page model.
2. In the page model, define a view model that matches the notification JSON.
3. In `OnGet`, load notifications by:
   - Calling the `NotificationController` through a service, or
   - Using `HttpClient` to call `/api/notification`.
4. Pass the notifications to the Razor Page.

---

## 5. Step 3 – Build the Layout

In `Notifications/Index.cshtml`:

1. Add a header with:
   - Title: “Notification Center”
   - Subtitle: “Stay updated on task changes and system alerts.”
2. Create a list or stacked card layout:
   - Each notification should show title, message, created time, and type.
   - Use subtle styling to distinguish unread items (e.g., bold title or accent bar).
3. Consider grouping:
   - Today.
   - Yesterday.
   - Earlier this week.

Worth noting: aim for a clean, readable layout similar in spirit to the mockup, even if not pixel-perfect.

---

## 6. Step 4 – Add Basic Interactions

1. For each notification, add a “Mark as read” link or button.
2. Wire this to a new API endpoint, for example:
   - `PUT /api/notification/{id}/read`
3. Initially, the implementation may:
   - Update in memory only, or
   - Update the JSON file carefully (if you are comfortable doing so).
4. After marking as read, refresh the list or update the UI with JavaScript so the item appears as read.

---

## 7. Step 5 – Wire Navigation

1. Update `_Layout.cshtml` so the “Notifications” entry in the top navigation points to the Notification Center page.
2. Run the site, open the Notification Center, and verify that:
   - Notifications load from the API.
   - Unread items are visually distinct.
   - “Mark as read” changes the appearance and behavior of an item.

---

## 8. Extension Ideas

Once the basics work:

- Add filters for All / Unread / Alerts.
- Display links from notifications to the related task or page.
- Add pagination or “Load more” behavior for long histories.

