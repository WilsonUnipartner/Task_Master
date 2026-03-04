# Guided Implementation: Status Distribution Chart with Chart.js

## 1. Learning Objectives

By the end of this exercise you will be able to:

- Install and manage a JavaScript library (Chart.js) using npm.
- Consume a JSON API from the backend (`/api/home`) using `fetch`.
- Transform API data into a dataset suitable for a doughnut chart.
- Integrate a Chart.js chart into the existing Task Master Home dashboard layout.

You will work **only in the Frontend project and the Home page view**, leaving the backend services and controllers in place.

---

## 2. Where to Work

- **Frontend**: `TaskMaster/TaskMaster.Frontend`
  - JavaScript entry: `src/index.js`
  - Styles: `src/styles.css` (already bundled into `wwwroot/css/main.css`)
- **Website**: `TaskMaster/TaskMaster.Website`
  - Home page markup: `Pages/Index.cshtml`
  - API endpoint (already created for you): `Controllers/HomeController.cs`
    - `GET /api/home` returns a `TaskDashboardViewModel` in JSON.

You do **not** need to change the controller or service for this assignment.

---

## 3. Step 1 – Install Chart.js in the Frontend Project

1. Open a terminal at:

   ```bash
   cd TaskMaster/TaskMaster.Frontend
   ```

2. Install Chart.js as a runtime dependency:

   ```bash
   npm install chart.js
   ```

3. Confirm that `package.json` now contains:

   - `"chart.js": "..."` under `dependencies` (or `devDependencies`).

> Worth noting: keep Chart.js in the **Frontend** project so that all UI libraries are managed by npm and bundled by Webpack.

---

## 4. Step 2 – Add a Canvas to the Home Page

Open `TaskMaster.Website/Pages/Index.cshtml` and locate the **Status Distribution** sidebar card.

Inside that card, add a `<canvas>` element with a stable `id`:

```html
<div class="tm-card">
    <h2>Status Distribution</h2>
    <p>Your workload balance this week.</p>
    <canvas id="statusChart"></canvas>
</div>
```

This canvas is where Chart.js will render the doughnut chart.

---

## 5. Step 3 – Fetch Dashboard Data from the API

In `TaskMaster.Frontend/src/index.js`:

1. Import Chart.js and register the pieces we need:

   ```js
   import { Chart, ArcElement, Tooltip, Legend } from "chart.js";
   Chart.register(ArcElement, Tooltip, Legend);
   ```

2. After your imports, add code that runs when the DOM is ready:

   - Find the `statusChart` canvas.
   - If it exists, call `/api/home`.
   - Build status counts from the JSON response.

   Pseudo‑implementation (you will write the real code):

   ```js
   async function initStatusChart() {
     const canvas = document.getElementById("statusChart");
     if (!canvas) return;

     const response = await fetch("/api/home");
     const dashboard = await response.json();

     // TODO: compute counts per status from dashboard.WeekTasks or another field.
     const counts = {
       backlog: 0,
       analyzing: 0,
       implementing: 0,
       review: 0,
       done: 0
     };

     // Create Chart.js doughnut chart here.
   }

   document.addEventListener("DOMContentLoaded", initStatusChart);
   ```

> Worth noting: you are intentionally consuming the **same API** that could also be used by a SPA or another client, reinforcing the idea of a clean separation between API and UI.

---

## 6. Step 4 – Build the Doughnut Chart

Inside `initStatusChart`, after computing the `counts`, create the chart:

```js
const ctx = canvas.getContext("2d");

new Chart(ctx, {
  type: "doughnut",
  data: {
    labels: ["Backlog", "Analyzing", "Implementing", "Review", "Done"],
    datasets: [
      {
        data: [
          counts.backlog,
          counts.analyzing,
          counts.implementing,
          counts.review,
          counts.done
        ],
        backgroundColor: [
          "#9ca3af", // Backlog
          "#3b82f6", // Analyzing
          "#f97316", // Implementing
          "#a855f7", // Review
          "#22c55e"  // Done
        ],
        borderWidth: 0
      }
    ]
  },
  options: {
    cutout: "70%",
    plugins: {
      legend: {
        display: false
      }
    }
  }
});
```

Style the surrounding card (title, legend text) in `styles.css` to match the mockup.

---

## 7. Step 5 – Build and Test

1. Rebuild the frontend bundle:

   ```bash
   cd TaskMaster/TaskMaster.Frontend
   npm run build
   ```

2. Ensure the .NET site is running:

   ```bash
   cd ../
   dotnet run --project TaskMaster.Website/TaskMaster.Website.csproj
   ```

3. Open `http://localhost:5110` in the browser.

4. Verify:

   - The **Status Distribution** card shows a Chart.js doughnut.
   - The console has no errors.
   - Changing task statuses in `DataStore/Tasks.json` changes the chart after rebuild/refresh.

---

## 8. Extension Ideas for Interns

After completing the basic chart:

- Add a legend under the chart that shows each status name with its color and numeric value.
- Add tooltips that show both count and percentage.
- Make the chart update automatically when `/api/home` returns new data without reloading the page (e.g., using a refresh button or timer).

