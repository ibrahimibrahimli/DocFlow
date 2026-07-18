# Local Development Guide

**Status:** Planned; update commands only after they are verified against the actual repository.

## Prerequisites
- Windows 10/11 with PowerShell.
- Git.
- .NET 10 SDK.
- Docker Desktop running.
- Docker Compose v2 (`docker compose`).
- A GitHub account.

## Verify tools

Run in PowerShell:

```powershell
dotnet --list-sdks
dotnet --info
git --version
docker --version
docker compose version
```

If .NET 10 is missing, install it from the official .NET 10 download page. Do not assume the SDK version from the runtime alone.

## Clone repository

```powershell
git clone https://github.com/<YOUR-USERNAME>/DocFlow.git
Set-Location DocFlow
```

Replace `<YOUR-USERNAME>` with the repository owner.

## Expected workflow after M1 is implemented

```powershell
dotnet restore
dotnet build --no-restore
dotnet test --no-build
docker compose up --build
```

These commands are placeholders until the solution and Compose file exist. Follow the final root README and inspect the actual Compose configuration before starting services.

## Environment variables and secrets
- `.env` is local-only and must be ignored by Git.
- `.env.example` contains placeholder names and safe sample values only.
- Never paste real secrets into issues, logs, screenshots, or AI prompts.
- Rotate any credential accidentally committed; deleting it in a later commit does not remove it from Git history.

## Stopping and cleaning up
Once Compose is implemented:
- Stop services with `docker compose down`.
- Do not add `-v` unless you intentionally want to delete named volumes and local database/object-storage data.
- Use a documented reset command for destructive cleanup.

## Troubleshooting checklist
1. Confirm Docker Desktop is running.
2. Inspect `docker compose ps`.
3. Inspect logs with `docker compose logs <service-name>`.
4. Check host port conflicts.
5. Check container health and dependency readiness.
6. Verify environment variable names and connection strings.
7. Avoid fixing readiness failures by adding arbitrary sleeps; use health checks and dependency-aware startup.
