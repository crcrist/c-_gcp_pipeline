using System;
using Google.Cloud.BigQuery.V2;
using System.Text.Json;


namespace GoogleCloudSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
			// Why is it such a pain to simply get a JSON value?!
			// Guess this is how I am doing it?
			// Also I think that ?? string.Empty will basically make an empty non obj if the value is null...
			string credentials = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS") ?? string.Empty;
			
			if(string.IsNullOrEmpty(credentials))
			{
				Console.WriteLine("Credential File was not found bruv");
				return;
			}
			

			string credentials_json = File.ReadAllText(credentials);
			JsonDocument json = JsonDocument.Parse(credentials_json);
			


			// Ok so for some reason you need to first check if the key exists...
			// Then return it. I am sure you can get around this but it seems like good practice I guess..
			// type is suffixed with '?' to allow null, I think that is how you do that...
			string? projectId;

			if(json.RootElement.TryGetProperty("project_id", out JsonElement value))
			{
				projectId = value.GetString();
			}
			else
			{
				projectId = null;
				Console.WriteLine("Key not found and you're dumb");
			}


			// If that works then we can move the above code to maybe another file and work on...
			// Implementing dependency injection pattern...
            var client = BigQueryClient.Create(projectId);
            string query = @"select * from `healthcare-111-391317.hc_db_prod_111.hc_decade_projections`";
            var result = client.ExecuteQuery(query, parameters: null);
            Console.Write("\nQuery Results:\n------------\n");
            foreach (var row in result)
            {
                Console.WriteLine($"{row["url"]}: {row["view_count"]} views");
            }
        }
    }
}

