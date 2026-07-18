# Observability Design

## Goals
- Explain what the system is doing.
- Detect that it is unhealthy.
- Locate where a distributed operation is slow or failing.
- Diagnose broker backlog, repeated failures, and downstream dependency outages.

## Signals

### Traces
Represent a request/workflow across service boundaries. Preserve W3C Trace Context across RabbitMQ message headers. A consumer span should link the processing work to the originating submission trace where supported.

### Metrics
Numeric time series used for trends, SLO-style views, and alerts. Use bounded labels only.

Candidate metrics:
- HTTP request count and duration by route template, method, and status class.
- Processing count and duration by outcome.
- Outbox pending count and oldest pending age.
- Consumer delivery/failure counts.
- Retry and dead-letter counts.
- Dependency health and connection failures.

Do not label metrics with document ID, filename, trace ID, user ID, or other unbounded values.

### Logs
Structured events with timestamp, severity, service, environment, trace ID, span ID, and a safe correlation/business identifier. Do not log file content, credentials, tokens, or sensitive payloads.

## Planned pipeline
- Applications instrument with OpenTelemetry SDK.
- OTLP data is sent to OpenTelemetry Collector.
- Metrics are exposed/exported for Prometheus scraping.
- Traces are sent to Tempo.
- Logs are sent to Loki through a supported OTLP ingestion configuration.
- Grafana is provisioned with data sources and dashboards.

The exact Collector receivers, processors, exporters, ports, and image versions must be validated together. Do not assume an exporter exists or behaves the same across versions.

## Dashboard panels
1. API request rate, error rate, and latency percentiles.
2. Processing throughput and duration.
3. Outbox pending count and oldest age.
4. RabbitMQ queue depth and unacknowledged messages.
5. Retry/DLQ rate.
6. Dependency availability.
7. Trace links from representative logs where supported.

## Alert principles
- Alert on user-visible impact or a condition that requires action.
- Each alert needs a runbook, a severity, and a useful message.
- Avoid alerting on every transient exception.
- Keep local demo thresholds clearly marked as examples, not production SLOs.

## Validation exercises
- Introduce controlled worker delay and find it in traces.
- Stop RabbitMQ and observe outbox growth.
- Send a poison event and observe retry/DLQ behavior.
- Generate a bounded load and inspect latency and throughput.
- Verify that labels remain low-cardinality.
