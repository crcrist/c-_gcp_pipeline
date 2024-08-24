using Google.Cloud.BigQuery.V2;
using System.Data;
using dotenv.net;



namespace GoogleCloudSamples
{
    public class Program
    {


        public static void Main(string[] args)
        {
            // this is grabbing the connection string from the .env file.. 
			// can probably be done better, but for now we have this.

            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../.env" }));
            
            try
            {
                string projectId = GoogleCredentialsHelper.GetProjectId();
                Console.WriteLine($"Project ID: {projectId}");


                // Create BigQuery client and execute query...
				// Asset names should be moved to environment variables eventually...
                var client = BigQueryClient.Create(projectId);
                string query = @"
							select state,
							avg(safe_cast(a.tot_emp as int64)) as avg_employment
							from `healthcare-111-391317.hc_db_prod_111.hc_emp_history_state` as a
							group by 1";

                BigQueryResults result = client.ExecuteQuery(query, parameters: null);
                
				
				// Query Data Above is stored in tabular storage for insertion to postgres... 
				makeDataTable addRows = new makeDataTable();
				DataTable df = addRows.createTable(result);

				foreach (DataRow row in df.Rows)
				{
					Console.WriteLine($"{row["id"]}, State {row["state"]}, Employment {row["avg_employment"]}");
				}
				
				

				// Here we handle the local CRUD operations...
				// For our Postgres instance.
				DBConnectTest insertData = new DBConnectTest();
				insertData.InsertDataIntoPostgres(df);

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            


            Console.WriteLine("Data Inserted Successfully");
        }
    }
}
