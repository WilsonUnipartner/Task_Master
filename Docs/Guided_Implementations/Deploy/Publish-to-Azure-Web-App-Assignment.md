# Guided Implementation: Publish Task Master to Azure Web App

## 1. Learning Objectives

By the end of this exercise you will be able to:

- Publish the Task Master website to your existing **Linux** Azure Web App using Visual Studio Code.
- Verify the deployed site in the browser.

This tutorial assumes the Azure Web App (Linux App Service) for Task Master already exists. The goal is to publish your application with a few clicks.

---

## 2. Prerequisites

- The Task Master solution builds and runs locally (you have completed the **Installing Core Dependencies** assignment or equivalent).
- An **Azure Web App for Linux** already created for Task Master (e.g. **taskMaster**).
- **Visual Studio Code** with the **Azure App Service** extension (or **Azure** extension pack) installed, and you are signed in with your work account.

---

## 3. Restore client-side libraries (so the site is well formatted)

The site uses Bootstrap and jQuery from `wwwroot/lib`. Restore them once before publishing (and after cloning):

1. In VS Code, open the **Command Palette** (`Ctrl+Shift+P`), run **Restore Client-Side Libraries** (or **LibMan: Restore**), and choose the **TaskMaster.Website** project when asked.

   If that command is not available, install the **Library Manager** extension, or from a terminal in the **TaskMaster.Website** folder run: `libman restore` (requires [LibMan CLI](https://www.nuget.org/packages/Microsoft.Web.LibraryManager.Cli/)).

2. Confirm that `TaskMaster.Website/wwwroot/lib/bootstrap` and `TaskMaster.Website/wwwroot/lib/jquery` contain the CSS and JS files (not only LICENSE files). Then the layout and login page will render with correct styling when you deploy.

---

## 4. Publish from Visual Studio Code

1. Open the Task Master **folder** in **Visual Studio Code** (the folder that contains the `TaskMaster` solution and `Docs`).

2. Sign in to Azure: click the **Azure** icon in the left sidebar (or press `Ctrl+Shift+A` and run **Azure: Sign In**). Sign in with your work account.

3. In the **Azure** sidebar, expand **App Services** and find your Web App (**taskMaster**). (If you don’t see it, check the correct subscription at the top of the Azure view.)

4. Right‑click **taskMaster** and choose **Deploy to Web App...** (or **Deploy to Web App**).

5. When prompted **Select the folder to deploy**, choose the **TaskMaster.Website** project folder (e.g. `TaskMaster/TaskMaster.Website`). Confirm if asked. VS Code will build and deploy the app; wait until the deployment finishes (notification or output panel).

6. When deployment succeeds, open your site at **https://taskMaster.azurewebsites.net** (or use **Browse Website** from the right‑click menu on the app in the sidebar).

---

## 5. Verify the Deployed Site

1. Open a browser and go to **https://taskMaster.azurewebsites.net** (or use **Browse Website** from the Azure sidebar).

2. Confirm that:
   - The Task Master layout and home page load.
   - Styles from Bootstrap and `main.css` are applied (no “not found” for CSS in the browser dev tools).
   - You can navigate to the login page and see the expected UI.

3. If something fails (for example 500 error or missing assets), check:
   - **Log stream** in the Azure Portal (App Service → **Monitoring** → **Log stream**).
   - **Advanced Tools (Kudu)** → **Debug console** to inspect the deployed files under `site/wwwroot`.

---

## 6. Extension Ideas

- Set up **Deployment Center** in the Azure Portal to deploy automatically from GitHub or Azure DevOps on each push.
- Use **staging slots** to test a deployment before swapping to production.
