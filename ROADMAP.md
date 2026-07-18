# DocFlow Roadmap

This roadmap is milestone-based, not a deadline promise. A milestone is complete only when its acceptance criteria are verified.

## M0 — Project governance and design
- [x] Create documentation baseline.
- [x] Define initial scope, principles, and service responsibilities.
- [x] Record initial architecture decisions.
- [ ] Verify documentation against final repository structure.
- [ ] Create GitHub repository and first documentation commit.

**Acceptance:** repository contains current project docs; scope, assumptions, and open decisions are explicit.

## M1 — Developer foundation
- [ ] Verify .NET 10 SDK, Git, Docker, and Docker Compose.
- [ ] Create solution and initial project structure.
- [ ] Add Document Service API and Processing Worker projects.
- [ ] Add unit-test projects.
- [ ] Add formatting/editor configuration and `.gitignore`.
- [ ] Add minimal health endpoints.
- [ ] Add Dockerfiles and a minimal Compose file.
- [ ] Add README setup instructions.
- [ ] Run build and tests locally.

**Acceptance:** fresh clone can be built and tested using documented commands; both processes start independently.

## M2 — Document submission vertical slice
- [ ] Define document state machine and validation rules.
- [ ] Add PostgreSQL and EF Core migrations.
- [ ] Add local MinIO object storage.
- [ ] Implement upload and metadata persistence.
- [ ] Implement status query and error contracts.
- [ ] Add unit and integration tests.
- [ ] Test oversized, invalid, and interrupted uploads.

**Acceptance:** a valid document is stored and queryable; invalid requests fail predictably; file/object cleanup limitations are documented.

## M3 — Reliable asynchronous processing
- [ ] Add RabbitMQ and versioned event contract.
- [ ] Implement transactional outbox.
- [ ] Implement publisher confirms and outbox recovery.
- [ ] Implement worker consumer and processing persistence.
- [ ] Implement idempotency/deduplication.
- [ ] Add bounded retry and dead-letter handling.
- [ ] Test duplicate delivery, worker crash, and broker interruption.

**Acceptance:** workflow completes asynchronously; repeated delivery does not duplicate business effects; poison messages are recoverable and diagnosable.

## M4 — Observability
- [ ] Add OpenTelemetry traces, metrics, and structured logs.
- [ ] Add Collector configuration.
- [ ] Add Prometheus, Grafana, Tempo, and Loki.
- [ ] Provision dashboards and data sources as code.
- [ ] Add trace propagation through RabbitMQ headers.
- [ ] Add useful service and business metrics.
- [ ] Add alert rules and runbooks.

**Acceptance:** one submission can be followed across API, outbox, broker, and worker; dashboards show latency, error rate, and processing backlog without high-cardinality labels.

## M5 — Testing and architecture quality
- [ ] Add database integration tests with disposable dependencies.
- [ ] Add messaging integration/contract tests.
- [ ] Add end-to-end workflow test.
- [ ] Add architecture boundary checks if they provide real value.
- [ ] Add deterministic failure-injection tests.
- [ ] Review cancellation, timeouts, shutdown, and retry behavior.

**Acceptance:** critical happy paths and failure paths are automated; test dependencies and local prerequisites are documented.

## M6 — CI and supply-chain hygiene
- [ ] Add GitHub Actions restore/build/test workflow.
- [ ] Add formatting verification.
- [ ] Build container images in CI.
- [ ] Enable dependency/security scanning appropriate to the repository.
- [ ] Ensure CI uses least-privilege permissions and no committed secrets.
- [ ] Document branch and pull-request checks.

**Acceptance:** a clean push or pull request runs repeatable checks and reports failures clearly.

## M7 — Portfolio finish
- [ ] Finalize architecture and sequence diagrams.
- [ ] Add sample dashboards and screenshots from actual runs.
- [ ] Add setup, troubleshooting, and recovery runbooks.
- [ ] Add design trade-offs and known limitations.
- [ ] Verify all README claims against code.
- [ ] Add release/tag and demo script.

**Acceptance:** a reviewer can clone, run, test, inspect telemetry, and understand the main design decisions without private assistance.

## Deferred unless justified
- Kubernetes, Helm, service mesh.
- Redis cache.
- gRPC between services.
- Authentication provider integration.
- Multi-tenancy and multi-region.
- High-availability deployment.
- Real PDF conversion or antivirus scanning.
