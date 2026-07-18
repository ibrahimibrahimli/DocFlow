# Event Contracts

**Status:** Draft; refine before implementing the publisher and consumer.

## `DocumentSubmitted` — version 1

Conceptual envelope:

```json
{
  "eventId": "stable-unique-id",
  "eventType": "docflow.document-submitted",
  "schemaVersion": 1,
  "occurredAtUtc": "2026-10-11T12:00:00Z",
  "traceParent": "optional-w3c-trace-context",
  "data": {
    "documentId": "stable-document-id",
    "objectKey": "opaque-object-key",
    "contentType": "application/pdf",
    "sizeBytes": 12345
  }
}
```

Values above are illustrative placeholders, not a final serialized contract.

## Rules
- `eventId` is stable across retries and duplicate publication.
- `schemaVersion` is explicit.
- `documentId` is an opaque identifier, not a filename.
- `objectKey` is internal and must not expose credentials.
- Do not put the document bytes in the message.
- Do not include secrets or unnecessary personal information.
- Consumer validates the event and handles unknown schema versions deliberately.
- Trace context propagation must use the agreed W3C Trace Context fields/headers rather than inventing an incompatible custom format.
- Contract changes require compatibility review and tests.
