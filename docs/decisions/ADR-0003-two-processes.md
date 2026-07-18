# ADR-0003: Start with two independently deployable processes

- **Status:** Accepted
- **Date:** 2026-10-11

## Context
The learning objective explicitly includes service-to-service communication, messaging, observability, and distributed failure scenarios. A single process would not demonstrate these boundaries directly.

## Decision
Start with:
1. Document Service API.
2. Processing Worker.

They are separate deployable processes and communicate through RabbitMQ for asynchronous processing.

## Alternatives considered
- Modular monolith first: simpler operationally and a strong default for many products, but does not directly exercise the requested inter-process messaging and distributed tracing early.
- Many microservices immediately: increases cognitive and operational load without adding proportional learning value.
- Two processes: enough to teach messaging, retries, idempotency, trace propagation, and independent failure.

## Consequences
- Local development has more moving parts than a monolith.
- Each service needs clear responsibility, configuration, health checks, tests, and telemetry.
- The number of services must remain small until a concrete requirement justifies more.
- Shared libraries must not become a way to bypass service boundaries.
