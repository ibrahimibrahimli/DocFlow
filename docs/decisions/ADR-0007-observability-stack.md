# ADR-0007: Standardize telemetry on OpenTelemetry and dedicated backends

- **Status:** Accepted as target design; exact versions and pipeline pending validation
- **Date:** 2026-10-11

## Context
The project must teach distributed tracing, metrics, structured logs, dashboards, and diagnosis across service boundaries without tightly coupling application code to a vendor.

## Decision
Instrument applications with OpenTelemetry and send OTLP telemetry to an OpenTelemetry Collector. Use Prometheus for metrics, Tempo for traces, Loki for logs, and Grafana as the query/visualization layer.

## Alternatives considered
- Vendor-specific SDKs: may offer useful features but create stronger vendor coupling.
- Logs only: insufficient to explain latency and causality across asynchronous boundaries.
- OpenTelemetry with separate backends: clear responsibilities and a useful learning surface.

## Consequences
- The Collector configuration and exporter compatibility must be validated against pinned versions.
- Trace context must be propagated through RabbitMQ headers.
- Metric labels must avoid high cardinality.
- Local observability has meaningful resource cost; add components in stages.
