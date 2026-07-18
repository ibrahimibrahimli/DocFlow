# Learning Log

Use this document to record concepts learned through implementation, not just definitions copied from documentation.

## 2026-10-11 — Project kickoff
### What we decided
- Establish project documentation before implementation.
- Use a monorepo for the first version.
- Start with two independently deployable processes: Document Service API and Processing Worker.
- Use Docker Compose locally before considering orchestration platforms.
- Keep service data ownership explicit.
- Plan observability from the beginning, but add components in understandable increments.

### Concepts to learn by doing
- Service boundary versus project/assembly boundary.
- Why a single database server can still host separate service-owned databases in local development.
- The dual-write problem and Transactional Outbox.
- At-least-once delivery and idempotent consumers.
- Distributed trace context propagation through a message broker.
- Metrics cardinality and the difference between logs, metrics, and traces.

### Questions not yet answered by implementation
- What exact document state machine should we use?
- How will the API present worker-owned processing status without querying the worker's database?
- What cleanup strategy handles a file upload succeeding while the database transaction fails?
- How should retries be delayed and bounded with the chosen RabbitMQ setup?

## Entry template
### YYYY-MM-DD — Topic
- **Problem:** 
- **What I expected:** 
- **What actually happened:** 
- **Root cause:** 
- **What I learned:** 
- **Evidence/tests:** 
- **Follow-up:** 
