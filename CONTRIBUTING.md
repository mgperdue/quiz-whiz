# 📌 Git Branching Strategy for Quiz Whiz

## **🔹 Overview**
This repository follows a structured **Git branching strategy** to maintain **stability, organization, and efficient collaboration**. 

- The `main` branch is **always stable** and contains **production-ready code**.
- The `develop` branch is used for **active development** and contains the latest tested features.
- **Feature, bugfix, hotfix, and release branches** are used to manage changes efficiently.

---

## **🔹 Primary Branches**
| **Branch** | **Purpose** | **Naming Convention** |
|------------|------------|-----------------------|
| `main` | Always stable, production-ready code | `main` |
| `develop` | Latest working version of the app | `develop` |

---

## **🔹 Supporting Branches**
| **Branch Type** | **Purpose** | **Naming Convention** |
|----------------|------------|-----------------------|
| **Feature Branches** | For developing new features | `feature/<feature-name>` |
| **Bugfix Branches** | For fixing reported bugs | `bugfix/<issue-description>` |
| **Hotfix Branches** | Urgent fixes to `main` | `hotfix/<hotfix-description>` |
| **Release Branches** | Prepares `develop` for production | `release/<version-number>` |

---

## **🔹 How to Use the Branching Strategy**

### **1️⃣ Creating Initial Branches**
```bash
git checkout main
git checkout -b develop
git push origin develop
```

### **2️⃣ Creating a Feature Branch**
```bash
git checkout develop
git checkout -b feature/game-session
git push origin feature/game-session
```

### **3️⃣ Merging a Feature Branch into `develop`**
```bash
git checkout develop
git merge feature/game-session

# Delete the feature branch (optional)
git branch -d feature/game-session
git push origin --delete feature/game-session
```

### **4️⃣ Creating a Hotfix Branch (For Urgent Fixes in `main`)**
```bash
git checkout main
git checkout -b hotfix/login-bug

# Fix the bug, then merge into 'main' and 'develop'
git checkout main
git merge hotfix/login-bug
git checkout develop
git merge hotfix/login-bug

# Delete the hotfix branch
git branch -d hotfix/login-bug
git push origin --delete hotfix/login-bug
```

### **5️⃣ Creating a Release Branch**
```bash
git checkout develop
git checkout -b release/1.0
```

---

## **🔹 Verifying the Branching Strategy**
Run this command to check all local and remote branches:
```bash
git branch -a
```

Example output:
```
* develop
  main
  remotes/origin/develop
  remotes/origin/main
```

---

## **✅ Summary**
- **`main`** → Always stable, production-ready.
- **`develop`** → Contains the latest working version of the code.
- **`feature/*`** → Used for developing new features.
- **`bugfix/*`** → Used for fixing bugs reported in `develop`.
- **`hotfix/*`** → Used for urgent fixes in `main`.
- **`release/*`** → Used to finalize versions before deploying to `main`.

Following this strategy ensures **organized development, efficient collaboration, and stable releases**.

