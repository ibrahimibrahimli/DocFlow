# ADR-0008: Use Docker Compose before Kubernetes

- **Status:** Accepted
- **Date:** 2026-10-11

## Context
The project needs repeatable local dependencies and separate service processes, but Kubernetes would add a large orchestration learning curve before core application behavior is understood.

## Decision
Use Docker Compose for local development and demo deployment. Reconsider Kubernetes only after the application, health checks, configuration, and failure behavior are clear.

## Consequences
- Compose is the canonical local environment initially.
- Do not claim that Compose provides production-grade high availability.
- Containers and health checks should still follow good operational practices.
