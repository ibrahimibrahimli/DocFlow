# Testing Strategy

## Test pyramid

### Unit tests
Fast tests for domain rules and deterministic logic. No real database, broker, or network. Examples:
- Document state transitions.
- Request validation rules.
- Idempotency decision logic.
- Retry classification logic where isolated.

### Integration tests
Validate real infrastructure boundaries using disposable dependencies (for example, Testcontainers where compatible):
- EF Core mappings and migrations against PostgreSQL.
- Outbox persistence and transaction behavior.
- RabbitMQ publish/consume behavior.
- Worker idempotency under redelivery.
- Object-storage interactions.

### Contract tests
Validate event schemas and compatibility expectations. Required fields, event type, schema version, IDs, and timestamp semantics must be explicit.

### End-to-end tests
Exercise the actual flow: submit document → event is published → worker processes → status/outcome becomes queryable. Avoid arbitrary sleeps; poll with bounded timeouts and useful diagnostics.

## Required failure scenarios
- Invalid content type and oversized upload.
- Object store unavailable.
- Database unavailable during submission.
- Broker unavailable while outbox contains pending rows.
- Publisher crashes after publish but before marking the outbox record dispatched.
- Worker receives the same event twice.
- Worker crashes after persistence but before acknowledgement.
- Poison message exhausts retries and reaches DLQ.
- Graceful shutdown with an in-flight message.
- Malformed or unsupported event schema.

## Test quality rules
- Deterministic inputs and isolated state.
- No real production credentials.
- No dependency on public services.
- Clear arrange/act/assert structure where it improves readability.
- Assert observable behavior, not private implementation details.
- Keep integration tests distinct from unit tests.
- Report what was actually run; don't infer passing tests from a successful build.

## CI gates (planned)
1. Restore.
2. Format verification.
3. Build in Release configuration.
4. Unit tests.
5. Integration tests where infrastructure is available.
6. Container build.
7. Dependency/security scanning.
