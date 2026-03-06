## Task Master – Git & GitHub Assignment

### 1. Goal of this assignment

By the end of this assignment you should be able to:

- **Clone** the Task Master repository to your local machine.
- **Create and switch branches** for your work.
- **Stage and commit** changes with clear messages.
- **Push** your work to GitHub and open a basic pull request.
- **Pull and merge** updates from the main branch.

The focus here is on building habits that you will use in every other assignment.

---

### 2. One-time setup

1. Install Git if it is not already installed:
   - Download from `https://git-scm.com/downloads` and follow the installer.
2. Configure your identity (run these commands once on your machine):

   ```bash
   git config --global user.name "Your Name"
   git config --global user.email "your.email@example.com"
   ```

3. If you have not done so already, create a **GitHub account** at `https://github.com`.

Worth noting: the email you configure in Git does not have to be the same as your personal email, but using a consistent address helps when attributing commits.

---

### 3. Cloning the Task Master repository

1. In a browser, navigate to the GitHub repository for Task Master.
2. Copy the **clone URL** (HTTPS is recommended).
3. In a terminal, choose a folder where you want to keep your projects and run:

   ```bash
   git clone <REPO_URL>
   cd <REPO_FOLDER>
   ```

4. Confirm that you can see the `TaskMaster` solution folder and `Docs` folder in your local clone.

From this point onward, all `dotnet` and `npm` commands should be run inside your local clone, not from a separate copy.

---

### 4. Creating a feature branch

For each assignment, you will work on a separate branch. This keeps `main` clean and makes code review easier.

1. Make sure you are on the `main` (or `master`) branch:

   ```bash
   git status
   git checkout main
   ```

2. Pull the latest changes:

   ```bash
   git pull
   ```

3. Create a new branch for your assignment, for example:

   ```bash
   git checkout -b feature/auth-login-assignment
   ```

4. Run `git branch` to verify that your new branch is active (marked with `*`).

Use descriptive branch names like:

- `feature/profile-page`
- `feature/admin-dashboard`
- `chore/update-docs`

---

### 5. Making changes and committing

1. Make a small, focused change (for example, edit a doc or add a method).
2. Check the status of your repository:

   ```bash
   git status
   ```

3. Stage the files you want to include in your commit:

   ```bash
   git add path/to/changed-file.cs
   ```

   or, to stage all tracked changes:

   ```bash
   git add .
   ```

4. Commit with a clear, present-tense message:

   ```bash
   git commit -m "Add Employee repository interface"
   ```

Worth noting: aim for small, logical commits. Each commit should represent one meaningful step, not an entire assignment in one go.

---

### 6. Pushing your branch and opening a pull request

1. Push your branch to GitHub for the first time:

   ```bash
   git push -u origin feature/auth-login-assignment
   ```

2. In GitHub, open the repository and you should see a prompt to open a **Pull Request** for your new branch.
3. Create a Pull Request:
   - Title: short and descriptive (for example, “Add login assignment doc”).
   - Description: briefly explain what you changed and why.
4. Assign reviewers according to your team’s practice (for exercises, you may simply review it yourself or with a mentor).

After the PR is reviewed, it can be merged into `main`.

---

### 7. Keeping your branch up to date

While you work, other changes may be merged into `main`. To reduce merge conflicts:

1. Switch to `main` and pull the latest changes:

   ```bash
   git checkout main
   git pull
   ```

2. Switch back to your feature branch:

   ```bash
   git checkout feature/auth-login-assignment
   ```

3. Merge or rebase `main` into your branch (your team may prefer one approach; for now, merging is simpler):

   ```bash
   git merge main
   ```

4. Resolve any merge conflicts in your editor, test your changes, then commit the merge.

5. Push the updated branch:

   ```bash
   git push
   ```

---

### 8. Common commands reference

Keep this list handy while you practice:

- **Check current branch and status**

  ```bash
  git status
  git branch
  ```

- **Switch branches**

  ```bash
  git checkout main
  git checkout feature/your-branch
  ```

- **Create a new branch**

  ```bash
  git checkout -b feature/new-assignment
  ```

- **Stage and commit**

  ```bash
  git add .
  git commit -m "Describe the change"
  ```

- **Push**

  ```bash
  git push
  ```

- **Pull latest changes**

  ```bash
  git pull
  ```

---

### 9. Deliverables

To consider this assignment complete, you should have:

- A local clone of the Task Master repository.
- At least one feature branch created from `main`.
- One or more commits with clear messages on that branch.
- The branch pushed to GitHub and a Pull Request opened.
- A short written reflection (for yourself) answering:
  - What is the difference between `git add` and `git commit`?
  - When should you create a new branch?
  - How do you bring the latest `main` changes into your branch?

These Git/GitHub skills are expected in all subsequent assignments.

