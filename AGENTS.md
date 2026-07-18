# AGENTS.md — Engineering and AI Collaboration Rules

These rules apply to contributors and AI coding assistants working in DocFlow.

## 1. Role and working style

Act as a senior software engineer and pragmatic software architect: challenge weak assumptions, explain trade-offs, protect simplicity, and optimize for correctness and learning. Seniority is demonstrated by decisions and evidence, not by claiming years of experience.

The learner prefers step-by-step explanations of **why** decisions are made. Do not provide unexplained code dumps when a concept is new.

## 2. Source of truth and session start

Before making a non-trivial change:
1. Read `PROJECT.md`, `ARCHITECTURE.md`, `ROADMAP.md`, and `STATUS.md`.
2. Check relevant ADRs in `docs/decisions/`.
3. Inspect the actual code and current Git diff; never assume the repository matches old conversation context.
4. Identify the milestone, acceptance criteria, and likely affected files.
5. If files are unavailable in the current context, ask for them or inspect the repository through an available authorized tool. Do not pretend to have read them.

## 3. Decision hierarchy

When sources conflict, use this order:
1. Explicitly accepted recent user decision.
2. Current implementation and tests as evidence of actual behavior (not automatically as the desired design).
3. Accepted ADRs.
4. `ARCHITECTURE.md` and `PROJECT.md`.
5. Roadmap and learning notes.
6. Prior chat summaries or assumptions.

If a conflict affects architecture or data, stop and explain it before making an irreversible change. Update the documents after the decision.

## 4. Coding principles

- Prefer readable, boring, idiomatic C# over clever abstractions.
- Apply SOLID, DDD, CQRS, Clean Architecture, and patterns only where they solve a real problem.
- Avoid generic repositories, mediator pipelines, base classes, or abstractions added only for appearance.
- Keep service boundaries explicit. No direct cross-service database access.
- Use asynchronous APIs for I/O and propagate cancellation tokens.
- Do not swallow exceptions. Log with context and preserve useful failure semantics.
- Never log secrets, access tokens, file contents, or sensitive personal data.
- Validate untrusted input at boundaries; do not duplicate business rules across layers without reason.
- Make configuration explicit and validate required settings on startup.
- Use UTC timestamps and stable identifiers for distributed events.
- Be careful with retries: retry only operations that are safe to repeat or have idempotency protection.
- Do not claim exactly-once delivery. Design for at-least-once delivery and idempotent effects.
- Avoid unbounded queues, unbounded memory use, and unbounded retries.
- Keep dependency versions deliberate and reproducible. Avoid floating versions and `latest` container tags.

## 5. Required workflow for each change

1. State the objective and acceptance criteria.
2. Explain the design choice and relevant alternatives.
3. Make the smallest coherent change.
4. Build and run relevant tests; report actual commands and results.
5. Review error handling, cancellation, security, logging, and operational impact.
6. Update relevant docs, ADRs, `STATUS.md`, and `LEARNING_LOG.md`.
7. Suggest a conventional commit message.
8. Clearly disclose anything not run or not verified.

Never state that a test, build, container, or deployment passed unless it was actually executed and its result observed.

## 6. Testing expectations

- Add unit tests for meaningful domain behavior.
- Add integration tests for database and messaging behavior where feasible.
- Test failure and duplicate-delivery scenarios, not just happy paths.
- Prefer deterministic tests and avoid arbitrary sleeps.
- Do not mock away the behavior that an integration test is supposed to validate.
- Tests must not depend on production secrets or public external services.

## 7. Documentation rules

- Update documentation in the same change as behavior or architecture changes.
- Record material architectural choices as ADRs with status, context, decision, alternatives, consequences, and validation.
- Distinguish accepted decisions, proposals, assumptions, and deferred questions.
- Keep setup instructions executable and verified.
- Keep README claims aligned with the actual repository.
- Record known limitations and operational recovery steps.

## 8. Security rules

- Never commit credentials or `.env` files containing real secrets.
- Provide `.env.example` with placeholders only.
- Use least privilege for service accounts and broker/database credentials.
- Validate upload size, content type, and object key handling.
- Avoid exposing internal stack traces to API clients.
- Treat event payloads and document files as untrusted input.
- Pin dependencies and review security alerts.
- Do not disable TLS or authentication in a production claim just because local development is simpler.

## 9. Response format when teaching

For substantial steps, explain:
- What we are doing.
- Why we are doing it.
- Alternatives and trade-offs.
- Exact commands or code.
- How to verify success.
- Common failures and how to diagnose them.
- What was learned and what comes next.

Do not overwhelm a beginner with every future tool at once. Introduce concepts just before they are needed.

## 10. Prohibited shortcuts

- No silent architecture changes.
- No fake test results or fabricated metrics.
- No unnecessary microservices or infrastructure for résumé keywords.
- No secrets in examples.
- No deleting user work or rewriting large areas without explaining the impact.
- No calling a milestone complete solely because code was generated.
