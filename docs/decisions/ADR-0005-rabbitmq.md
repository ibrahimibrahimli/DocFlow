# ADR-0005: Use RabbitMQ for asynchronous work

- **Status:** Accepted
- **Date:** 2026-10-11

## Context
Document processing should not hold an HTTP request open while the work runs. The project needs to demonstrate asynchronous communication, delivery semantics, retries, and dead-letter handling.

## Decision
Use RabbitMQ as the initial message broker and publish versioned integration events.

## Alternatives considered
- Synchronous HTTP: easier to trace initially, but couples availability and latency and is not suitable for long-running work.
- Kafka: useful for durable event streams and replay at scale, but adds concepts and operational weight beyond this project's initial needs.
- RabbitMQ: fits task/message routing and consumer acknowledgements for this workflow.

## Consequences
- Broker topology, durability, publisher confirms, acknowledgements, retry policy, and DLQ policy must be configured deliberately.
- Delivery is treated as at least once.
- The system must not claim exactly-once end-to-end processing.
- The choice can be revisited if replayable event streams become a real requirement.
