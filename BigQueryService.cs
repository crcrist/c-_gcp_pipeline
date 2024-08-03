using Google.Cloud.BigQuery.V2;

namespace BigQueryDemo
{
    public interface IBigQueryService
    {
        BigQueryResults ExecuteQuery(string sql);
    }

    public class BigQueryService : IBigQueryService
    {
        private readonly BigQueryClient _client;

        public BigQueryService(string projectId)
        {
            _client = BigQueryClient.Create(projectId);
        }

        public BigQueryResults ExecuteQuery(string sql)
        {
            return _client.ExecuteQuery(sql, parameters: null);
        }
    }
}
