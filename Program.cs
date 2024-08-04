// for data frame like stuff I should look into the DataTable class in System.Data namespace.
// importing packages is done by "using <package>"
// added this package for DI dotnet add package Microsoft.Extensions.DependencyInjection


using System;
using Microsoft.Extensions.DependencyInjection;

namespace BigQueryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IBigQueryService>(provider => new BigQueryService("projectId"))
                .BuildServiceProvider();

            // Get service
            var bigQueryService = serviceProvider.GetService<IBigQueryService>();

            // Define SQL query
            var sql = "SELECT corpus AS title, COUNT(word) AS unique_words FROM `bigquery-public-data.samples.shakespeare` GROUP BY title ORDER BY unique_words DESC LIMIT 10";

            // Execute query
            var results = bigQueryService.ExecuteQuery(sql);

            // Display results
            foreach (var row in results)
            {
                Console.WriteLine($"{row["title"]}: {row["unique_words"]}");
            }
        }
    }
}


