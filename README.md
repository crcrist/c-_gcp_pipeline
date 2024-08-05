# .NET BigQuery Data Pipeline 

 ## Overview
 Data Pipeline using **.NET**, BigQuery, and Postgres.

## Why does this exist?
This is a practice in **co-programming** and modern .NET ETL workflows. Our main objective is to utilize each other's strengths and gain a better understanding of the relationship between GCP and .NET.

## Project Tooling
| Cloud Storage | Local Storage | Development |
|---------------|---------------|-------------|
|   BigQuery    |   Postgres    |    .NET     |


## Files
- **Program.cs** - *Main application file.*
- **BigQueryService.cs** - BQ API Query logic. This is part of a proposal made by  [ccrist](https://github.com/crcrist) based on his experience with C#.
- **c_sharp.csproj** - project dependencies.

## ToDo 
1. Establish mutually accessible service account in **GCP**.
2. Create API call logic.
3. Develop transformation logic.
4. Create Postgres instance for landing.

## Relevant Documentation
- [gcloud CLI](https://cloud.google.com/sdk/docs/install)
- [GCP Service Accounts](https://cloud.google.com/iam/docs/service-account-overview)
- [GCP Billing Dashboard](https://console.cloud.google.com/billing)
- [C# BigQuery client Library](https://cloud.google.com/bigquery/docs/reference/libraries)
- [Google Cloud Free Tier Docs](https://cloud.google.com/free/docs/free-cloud-features)
- [DataTable class for Tabular Data](https://learn.microsoft.com/en-us/dotnet/api/system.data.datatable?view=net-8.0)


