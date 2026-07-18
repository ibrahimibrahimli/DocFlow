# ADR-0001: Use .NET 10 LTS as the target framework

- **Status:** Accepted; verify local SDK and package compatibility
- **Date:** 2026-10-11

## Context
The project is new and intended to remain maintainable through a learning period and portfolio review. It needs a supported .NET baseline.

## Decision
Target .NET 10 LTS. Verify the installed SDK, official support status, and compatibility of chosen packages and container images before implementation.

## Alternatives considered
- .NET 9: not preferred for a new project when the .NET 10 LTS baseline is available.
- An older LTS version: could be reasonable for an existing production environment but adds no benefit to this greenfield learning project.

## Consequences
- Use `net10.0` target frameworks.
- Pin package versions and avoid assuming all third-party packages support the chosen framework.
- Document the actual SDK version used in CI.
- A local SDK installation is a prerequisite.

## Validation plan
Run `dotnet --list-sdks`, inspect `dotnet --info`, restore, build, and test in CI.
