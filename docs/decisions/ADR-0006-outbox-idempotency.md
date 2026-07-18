# ADR-0006: Use Transactional Outbox and idempotent consumers

- **Status:** Accepted as target design; implementation and tests pending
- **Date:** 2026-10-11

## Context
Persisting document metadata and publishing a message are two separate operations. A crash between them can leave committed data without a message, or a published message with an unmarked outbox row.

## Decision
Persist metadata and an outbox event in one local database transaction. Publish outbox records asynchronously with publisher confirms. Design the consumer for duplicate delivery and persist its idempotency record alongside processing effects where possible.

## Alternatives considered
- Publish directly during the HTTP request: simple but vulnerable to the dual-write problem.
- Distributed transaction: adds complexity and is not the intended design.
- Outbox plus idempotency: robust local atomicity with explicit at-least-once behavior.

## Consequences
- The outbox publisher must handle crash/restart and stale rows.
- Duplicate publication remains possible.
- Consumers must be idempotent.
- Outbox age and pending count become important metrics.
- Tests must simulate publish/marking and consume/ack crash windows.
