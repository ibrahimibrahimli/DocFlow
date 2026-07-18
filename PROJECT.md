# Project Charter — DocFlow

## 1. Purpose

DocFlow is a hands-on learning project and public portfolio artifact for understanding how to design, implement, test, operate, and explain a small distributed application.

The goal is not to maximize the number of services or tools. The goal is to demonstrate sound reasoning, working software, reproducible setup, meaningful tests, and evidence-based operational practices.

## 2. Product concept

A user submits a document for asynchronous processing and can inspect its status. The system accepts the request, stores the document, queues work, processes it, and records the outcome.

Initial processing may be simulated and deterministic. A real document-processing engine is a later optional extension, not a prerequisite for learning distributed systems.

## 3. Target learning outcomes

By completion, the author should be able to explain and demonstrate:

- Why service boundaries exist and what data each service owns.
- Synchronous HTTP versus asynchronous messaging.
- At-least-once message delivery, idempotent consumers, retry, and dead-letter handling.
- Transactional Outbox and the dual-write problem.
- Eventual consistency and failure modes across service boundaries.
- OpenTelemetry traces, metrics, and logs, including cross-service trace propagation.
- Prometheus queries, Grafana dashboards, and actionable alerts.
- Health checks, graceful shutdown, configuration, secret management, and container networking.
- Unit, integration, contract, and end-to-end testing.
- CI automation, dependency hygiene, and architecture decision records.

## 4. Scope

### In scope

- Document submission and status lookup.
- Document metadata and object storage.
- Asynchronous processing through RabbitMQ.
- Independent deployability of Document API and Processing Worker.
- Separate logical data ownership per service.
- Outbox publishing and idempotent consumption.
- Structured logs and correlated telemetry.
- Local development through Docker Compose.
- Automated tests and GitHub Actions CI.
- Operational runbooks and architecture documentation.

### Explicitly out of scope for the first release

- Kubernetes and multi-cluster orchestration.
- Multi-region deployment and high availability claims.
- Real billing, subscriptions, or payment handling.
- Complex user management, social features, and multi-tenant enterprise controls.
- A production-grade malware scanning pipeline.
- Real-time UI or frontend application.
- Premature caching with Redis.
- Multiple brokers or event-streaming platforms.
- Claiming exactly-once processing across distributed components.

These can be reconsidered only when a concrete learning objective or requirement justifies them.

## 5. Initial service responsibilities

### Document Service

- Accept and validate submission requests.
- Enforce upload limits and allowed content types.
- Store file bytes in object storage.
- Own document metadata and submission state.
- Persist an outbox record in the same database transaction as metadata.
- Expose document status and health endpoints.

### Processing Worker

- Consume `DocumentSubmitted` messages.
- Validate event schema and identity.
- Process work idempotently.
- Own processing records and processing outcome.
- Retry transient failures safely and route poison messages to a dead-letter queue.
- Emit telemetry and shut down gracefully.

The worker does not read or write the Document Service database. The API does not read or write the worker's database.

## 6. Quality goals

- A new contributor can follow the documented local setup.
- `dotnet build` and `dotnet test` succeed in CI.
- A submitted document can be traced through the asynchronous workflow.
- Duplicate delivery does not create duplicate processing effects.
- A failed dependency is diagnosable from logs, metrics, and traces.
- Configuration and secrets are handled explicitly.
- Important architectural choices include rationale and trade-offs.
- Implemented capabilities are clearly separated from planned work.

## 7. Constraints and assumptions

- Primary developer environment: Windows with Docker Desktop and PowerShell.
- Repository: GitHub monorepo.
- Documentation language: internal learning documentation in Azerbaijani; public README and code identifiers in English.
- Initial deployment target: local Docker Compose.
- .NET baseline: .NET 10 LTS, subject to SDK availability and compatibility verification at implementation time.

## 8. Definition of done

A milestone is done only when:
1. Acceptance criteria are met.
2. Relevant automated tests pass.
3. The application or infrastructure has been run, not merely compiled, where applicable.
4. Failure paths introduced by the milestone have been considered and tested.
5. Documentation and diagrams match the implementation.
6. `STATUS.md` and `LEARNING_LOG.md` are updated.
7. The change is committed with a meaningful message.

## 9. Non-goals

DocFlow is a learning and portfolio project, not a claim of enterprise production readiness. It must not expose credentials, real user documents, private infrastructure, or fabricated benchmark results.
