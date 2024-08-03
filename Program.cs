// for data frame like stuff I should look into the DataTable class in System.Data namespace.
// importing packages is done by "using <package>"


using System;
using Google.Cloud.BigQuery.V2;

namespace BigQueryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = BigQueryClient.Create("projectId");
            var table = client.GetTable("bigquery-public-data", "samples", "shakespeare");
            var sql = $"SELECT corpus AS title, COUNT(word) AS unique_words FROM {table} GROUP BY title ORDER BY unique_words DESC LIMIT 10";

            var results = client.ExecuteQuery(sql, parameters: null);

            foreach (var row in results)
            {
                Console.WriteLine($"{row["title"]}: {row["unique_words"]}");
            }
        }
    }
}

