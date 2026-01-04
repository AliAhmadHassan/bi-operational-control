# BI Operational Control

Operational control and BI analytics for a collections/call-center operation. This solution combines a near-real-time notification service with a BI data access layer that reads from a SQL Server data warehouse and SSAS cubes, plus integrations with dialer systems.

## What this project does

- Monitors agent status and pause events from a dialer queue (MSMQ).
- Applies operational rules (late login, extended pauses, early exit) and writes notifications to BI tables.
- Exposes data access for BI dashboards and reports over fact/dimension models (carteira, acordos, producao, discador).
- Consolidates data from SQL Server DW, SSAS OLAP cubes, and a PostgreSQL-backed dialer source.

## Architecture at a glance

- ServiceNotification (console service): event-driven worker that processes pause events and emits notifications.
- BLL/DAL/DTO layering: DTOs model facts/dimensions, DAL runs ADO.NET + AdomdClient queries, BLL applies business rules.
- Data warehouse + cube access: MDX queries against SSAS and stored procedures against SQL Server DW.
- Queue-driven workflow: MSMQ private queue decouples dialer events from operational rules.

## Tech stack

- .NET, Visual Studio solution format.
- SQL Server DW + SSAS OLAP (AdomdClient).
- PostgreSQL access via Npgsql.
- MSMQ for queueing and transactional reads.
- XML serialization for lightweight state persistence.

## Key workflows

1. Dialer publishes pause events to MSMQ (private queue).
2. ServiceNotification dequeues events, normalizes them with dimension lookups, and tracks per-agent state.
3. Rule engine evaluates tolerances (late login, mandatory pauses, time off-line).
4. Notifications are written to BI tables for supervisors and dashboards.

## Project structure

- `ServiceNotificacao/` - console worker that runs timers and processes queue events.
- `ServiceNotification.BLL/`, `ServiceNotification.DTO/` - pause analysis domain models and rules.
- `BusinessIntelligence.DAL/` - SSAS MDX queries and DW stored procedure access.
- `BusinessIntelligence.BLL/`, `BusinessIntelligence.DTO/` - BI domain models (facts/dims, carteira, acordo, producao).
- `BITotalIP.DAL/` - dialer integrations (SQL Server + PostgreSQL).
- `BITotalIP.BLL/`, `BITotalIP.DTO/` - dialer domain models and queue helpers.

## Notable implementation details

- Uses SSAS cubes for high-performance analytics (MDX via AdomdClient).
- Encapsulates data access with reusable helpers for SQL Server and PostgreSQL.
- MSMQ transactional consumption to reduce duplicate processing.
- Rule logic persisted across runs in `analisePausas.xml` for continuity within the day.

## Configuration

Settings and connection strings are defined in `ServiceNotificacao/App.config`. For public sharing, replace any real credentials with placeholders and configure them locally.

## Why this is valuable

This solution bridges BI analytics and operational control: it makes the data warehouse actionable by turning live dialer events into supervisor notifications, while still supporting deep historical analysis via dimensions, facts, and OLAP cubes.
