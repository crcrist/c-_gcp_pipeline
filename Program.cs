using System;
using Google.Cloud.BigQuery.V2;
using System.Text.Json;

namespace GoogleCloudSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string projectId = GoogleCredentialsHelper.GetProjectId();
                Console.WriteLine($"Project ID: {projectId}");

                // Create BigQuery client and execute query
                var client = BigQueryClient.Create(projectId);
                string query = @"select * from `healthcare-111-391317.hc_db_prod_111.hc_decade_projections`";
                var result = client.ExecuteQuery(query, parameters: null);
                
                Console.WriteLine("\nQuery Results:\n------------");
                foreach (var row in result)
                {
                    Console.WriteLine($"{row["occupation_title"]}: {row["occupational_openings_2021_2031_annual_average"]}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
