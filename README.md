# DocFlow

**A production-minded microservices learning project built with .NET 10, RabbitMQ, PostgreSQL, OpenTelemetry, Prometheus, Grafana, and Docker.**

DocFlow is a document-submission and asynchronous-processing platform. It is designed to demonstrate engineering judgment—not just a collection of technologies—including service boundaries, reliable messaging, observability, failure handling, automated testing, security, and CI.

> **Project status:** Documentation baseline. Implementation has not started. Decisions marked *Proposed* or *Planned* must be validated as implementation progresses.

## Why this project exists

- Build and explain a small distributed system end to end.
- Practice production-minded engineering with a deliberately limited scope.
- Learn to observe, diagnose, and recover from failures.
- Maintain an auditable record of architecture decisions and trade-offs.
- Publish an honest, reproducible GitHub portfolio project.

## High-level flow

1. A client submits document metadata and a file.
2. **Document API** validates the request, stores the file in object storage, persists document metadata, and records an outbox event.
3. An outbox publisher delivers `DocumentSubmitted` to RabbitMQ.
4. **Processing Worker** consumes the event idempotently, processes the document, and persists its processing status.
5. OpenTelemetry emits traces, metrics, and structured logs. Prometheus stores metrics; Tempo stores traces; Loki stores logs; Grafana explores and visualizes telemetry.

The first implementation may use a deterministic, simulated processor rather than a real PDF conversion engine. This keeps the focus on distributed-systems fundamentals.

## Technology baseline

- .NET 10 LTS / ASP.NET Core
- C#
- PostgreSQL + EF Core
- RabbitMQ
- S3-compatible object storage (MinIO for local development)
- OpenTelemetry SDK and Collector
- Prometheus, Grafana, Tempo, Loki
- Docker Compose
- xUnit; integration tests with Testcontainers where practical
- GitHub Actions

Versions must be pinned and verified when implementation begins. Do not use `latest` image tags for reproducible development.

## Repository map

```text
.
├── AGENTS.md
├── PROJECT.md
├── ARCHITECTURE.md
├── ROADMAP.md
├── STATUS.md
├── LEARNING_LOG.md
├── DECISIONS.md
├── README.md
├── src/
│   ├── Services/
│   │   ├── DocumentService/
│   │   └── ProcessingWorker/
│   └── BuildingBlocks/
├── tests/
├── deploy/
│   ├── docker/
│   └── observability/
└── docs/
    ├── api/
    ├── runbooks/
    ├── standards/
    └── decisions/
```

## Quick start

Implementation is not yet present, so these commands will become available after the foundation milestone:

```bash
docker compose up --build
dotnet test
```

The authoritative setup steps will be maintained in [`docs/LOCAL_DEVELOPMENT.md`](docs/LOCAL_DEVELOPMENT.md).

## Engineering principles

- Start with the smallest system that demonstrates the required distributed-systems concepts.
- Each service owns its data; services do not query another service's database directly.
- Prefer asynchronous messaging for background work; use HTTP only where synchronous responses are needed.
- Assume messages can be delivered more than once.
- Make failures observable and test recovery paths.
- Keep secrets out of source control.
- Document meaningful decisions and update documentation with code.
- Avoid adding infrastructure unless it teaches or solves a concrete problem.

## Documentation index

- [Project charter](PROJECT.md)
- [Architecture](ARCHITECTURE.md)
- [Roadmap](ROADMAP.md)
- [Current status](STATUS.md)
- [AI and contributor rules](AGENTS.md)
- [Architecture decisions](DECISIONS.md)
- [Local development](docs/LOCAL_DEVELOPMENT.md)
- [Testing strategy](docs/TESTING.md)
- [Observability](docs/OBSERVABILITY.md)
- [Security baseline](docs/SECURITY.md)
- [Coding standards](docs/standards/CODING_STANDARDS.md)
- [Learning log](LEARNING_LOG.md)
- [Glossary](docs/GLOSSARY.md)

## Portfolio honesty

This repository must distinguish between **implemented**, **tested**, and **planned** capabilities. Do not claim production readiness, exactly-once delivery, high availability, or security certification without evidence. Screenshots and benchmark numbers must come from actual runs and include enough context to reproduce them.
