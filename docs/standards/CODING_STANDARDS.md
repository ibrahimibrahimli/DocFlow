# Coding Standards

## General
- Use English for code identifiers, comments that explain non-obvious technical constraints, API contracts, and public documentation.
- Use Azerbaijani for personal learning notes if that makes the concepts easier to retain.
- Prefer descriptive names and small methods with clear responsibilities.
- Avoid comments that merely repeat the code.
- Keep nullable reference types enabled.
- Use async APIs for I/O; pass `CancellationToken` through application boundaries.
- Use UTC for persisted timestamps and event timestamps.
- Do not use `DateTime.Now` for distributed event timestamps.

## API
- Validate inputs at the boundary.
- Use consistent `ProblemDetails` responses.
- Do not return internal exception messages or stack traces.
- Apply request size limits and explicit content-type rules to file uploads.
- Document status codes and error cases in OpenAPI.

## Persistence
- EF Core migrations are source-controlled.
- Never automatically drop or recreate databases as part of normal startup.
- Keep service-owned data boundaries explicit.
- Add indexes based on query needs and verify important query plans when performance matters.
- Use transactions for local atomic invariants; do not imply they span RabbitMQ or object storage.

## Messaging
- Integration events are contracts, not shared domain entities.
- Include event ID, event type, schema version, occurrence timestamp, and relevant trace context.
- Consumers must be idempotent.
- Bound retries and define DLQ handling.
- Acknowledge only after durable successful processing or a deliberate terminal-handling path.

## Observability
- Use structured logging.
- Include trace/span IDs when available.
- Never use unbounded identifiers as metric labels.
- Avoid duplicate instrumentation that creates duplicate metrics or spans.
- Health endpoints must distinguish liveness from dependency readiness.

## Dependencies and configuration
- Pin package and container image versions.
- Validate required configuration at startup.
- Keep secrets out of appsettings files committed to Git.
- Review package additions for maintenance, security, and licensing concerns.
