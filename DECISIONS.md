# Architecture Decision Index

Detailed decisions live in `docs/decisions/`. A decision is not automatically final merely because it appears in this index; check its status.

| ID | Decision | Status |
|---|---|---|
| ADR-0001 | .NET 10 LTS baseline | Accepted, verify SDK and package compatibility |
| ADR-0002 | Monorepo for the learning project | Accepted |
| ADR-0003 | Two independently deployable processes initially | Accepted |
| ADR-0004 | Service-owned data; no cross-service DB access | Accepted |
| ADR-0005 | RabbitMQ for asynchronous work | Accepted |
| ADR-0006 | Transactional Outbox and idempotent consumer | Accepted as target design |
| ADR-0007 | OpenTelemetry with Prometheus/Grafana/Tempo/Loki | Accepted as target design; versions/config to verify |
| ADR-0008 | Docker Compose before Kubernetes | Accepted |
| ADR-0009 | Internal docs Azerbaijani; public docs/code English | Accepted |
| ADR-0010 | Keep initial processing deterministic and simulated | Accepted for first vertical slice |

## Decision process
Material decisions use the ADR template in `docs/decisions/ADR_TEMPLATE.md`. A decision should explain context, constraints, alternatives, chosen option, consequences, and validation plan. Update the status when a proposal is accepted, superseded, or deprecated.
