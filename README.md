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
- **Program.cs** - 
*Main application file.*
- **GoogleCredentialHelper.cs** 
BQ API Query logic. This is part of a proposal made by  [ccrist](https://github.com/crcrist) based on his experience with C#.
- **makeDataTable.cs**
Tabular Data constructor for itermediate storage.
- **c_sharp.csproj** 
project dependencies.


## FAQ 
**How do I set my application credentials in my environment?** 
- export GOOGLE_APPLICATION_CREDENTIALS='/path/to/your/client_secret.json'


## ToDo 
1. Establish mutually accessible service account in **GCP**.
2. ~~Create API call logic.~~
4. ~~Create Tabular Storage for Transformation~~
5. Develop transformation logic.
6. Create Postgres instance for landing.

## Relevant Documentation
- [gcloud CLI](https://cloud.google.com/sdk/docs/install)
- [GCP Service Accounts](https://cloud.google.com/iam/docs/service-account-overview)
- [GCP Billing Dashboard](https://console.cloud.google.com/billing)
- [C# BigQuery client Library](https://cloud.google.com/bigquery/docs/reference/libraries)
- [Google Cloud Free Tier Docs](https://cloud.google.com/free/docs/free-cloud-features)
- [DataTable class for Tabular Data](https://learn.microsoft.com/en-us/dotnet/api/system.data.datatable?view=net-8.0)


