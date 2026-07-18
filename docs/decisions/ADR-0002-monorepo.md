# ADR-0002: Keep the initial project in a monorepo

- **Status:** Accepted
- **Date:** 2026-10-11

## Context
This is a small learning project with two services, shared event contracts, integration tests, and local infrastructure. The learner benefits from one clone and a single coherent change history.

## Decision
Use one Git repository for both services, tests, infrastructure configuration, and documentation.

## Alternatives considered
- One repository per service: independent histories and access controls, but more setup and cross-repository coordination than the current project needs.
- Monorepo: simple local development and atomic changes, but requires CI paths and service ownership to remain clear.

## Consequences
- Services remain separately deployable despite sharing a repository.
- CI should eventually build/test affected components efficiently, but do not optimize path filtering prematurely.
- Keep shared code minimal; avoid creating a shared domain model that couples services.
- Repository structure does not determine runtime deployment boundaries.
