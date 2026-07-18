# Security Baseline

This is a learning-project baseline, not a security certification or production threat-model sign-off.

## Assets to protect
- Uploaded files and metadata.
- Database and broker credentials.
- Object-storage access keys.
- Application configuration and telemetry.
- CI tokens and repository permissions.

## Threats to consider
- Oversized or malformed uploads.
- Misleading content type or extension.
- Path/key manipulation.
- Secrets committed to Git or printed in logs.
- Unauthenticated access to infrastructure dashboards or management ports.
- Poison messages and malformed event payloads.
- Dependency vulnerabilities.
- Excessive permissions between services.

## Minimum controls
- Enforce upload size and allowed content types; treat client-provided MIME type as untrusted.
- Generate opaque object keys; never concatenate an untrusted filename into a filesystem path.
- Keep credentials in ignored local environment files or a proper secret store; commit placeholders only.
- Use least-privilege credentials for each service and infrastructure component where practical.
- Publish only necessary ports to the developer host.
- Avoid logging file content, access tokens, connection strings, and secrets.
- Return safe API errors without stack traces.
- Validate message schema and reject unsupported versions safely.
- Pin dependencies and review security advisories.
- Restrict GitHub Actions permissions to the minimum required.
- Add authentication/authorization before exposing sensitive endpoints beyond local development.

## Upload-specific safeguards
- Maximum file size.
- Allow-list supported formats.
- Server-side validation beyond extension.
- Opaque object identifiers.
- Consider malware scanning and content-disarm techniques only if the project scope later requires them.
- Define cleanup/compensation when object storage succeeds but metadata persistence fails, or vice versa.

## Secret incident response
If a secret is committed:
1. Revoke or rotate it immediately.
2. Remove it from active configuration and repository content.
3. Assess logs and possible access.
4. Rewrite history if appropriate, understanding that clones/caches may retain the secret.
5. Record the incident and prevention action without copying the secret into the report.
