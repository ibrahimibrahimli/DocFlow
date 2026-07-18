# Runbook: <problem name>

- **Severity:** Info | Warning | Critical
- **Owner:** DocFlow maintainers
- **Last reviewed:** YYYY-MM-DD

## Symptoms
What the user or dashboard shows.

## Impact
Which workflow or component is affected?

## Diagnostics
1. Check relevant Grafana dashboard.
2. Inspect traces around the failure window.
3. Search structured logs by trace ID or safe business identifier.
4. Check container health and dependency logs.
5. Inspect queue depth, outbox age, retries, and DLQ where relevant.

## Mitigation
Safe, reversible actions first. Do not delete messages or volumes without understanding the impact.

## Recovery verification
Commands, tests, and dashboard signals that prove recovery.

## Root cause and follow-up
Record the actual cause, evidence, and prevention action after resolution.
