# ADR-0004: Each service owns its data

- **Status:** Accepted
- **Date:** 2026-10-11

## Context
Independent deployability is weakened if services share tables or directly query each other's databases.

## Decision
Document Service owns document metadata and outbox records. Processing Worker owns processing records and idempotency state. A local PostgreSQL server may host separate logical databases for convenience, but service credentials and access boundaries should be distinct where practical.

## Alternatives considered
- Shared schema/tables: easy initially but couples releases and schema changes.
- Separate database servers from day one: stronger isolation but unnecessary resource overhead for local learning.
- Separate logical databases on one local server: ownership is clear while local setup remains manageable.

## Consequences
- Cross-service reads require an API, event, or deliberate read projection.
- Eventual consistency must be explained and tested.
- Local infrastructure is not a claim of production isolation.
