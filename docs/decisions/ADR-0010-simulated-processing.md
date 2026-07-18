# ADR-0010: Begin with deterministic simulated processing

- **Status:** Accepted for the first vertical slice
- **Date:** 2026-10-11

## Context
A real PDF processing engine would introduce file-format edge cases and security concerns before the distributed workflow is understood.

## Decision
Initially implement a deterministic processing operation that validates the object exists and produces a predictable result. Keep the worker interface suitable for replacing the implementation later.

## Consequences
- Focus remains on delivery, persistence, idempotency, tracing, and failure recovery.
- Clearly label processing as simulated in the README and demo.
- Do not present the initial worker as a real document conversion or malware scanning system.
- A real processing engine can be added as a separate, tested milestone.
