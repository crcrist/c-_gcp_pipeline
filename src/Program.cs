using Google.Cloud.BigQuery.V2;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using dotenv.net;

namespace GoogleCloudSamples
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Set up dependency injection
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var mediator = serviceProvider.GetRequiredService<IMediator>();

            // Load environment variables
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../.env" }));

            try
            {
                // Send query to get BigQuery results
                var query = new GetBigQueryResultsQuery(@"select avg(avg_annual_wage) as avg_income from `healthcare-111-391317.hc_db_prod_111.hc_emp_history`");
                var result = await mediator.Send(query);

                // Create DataTable from BigQuery results
                var dataTableCreator = serviceProvider.GetRequiredService<IDataTableCreator>();
                var dataTable = dataTableCreator.CreateDataTable(result);

                // Send command to insert data into PostgreSQL
                var command = new InsertDataCommand(dataTable);
                await mediator.Send(command);

                Console.WriteLine("Data Inserted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Register MediatR
            services.AddMediatR(typeof(Program).Assembly);

            // Register other services
            services.AddSingleton<IDatabaseService, PostgresDatabaseService>();
            services.AddSingleton<IDataTableCreator, BigQueryDataTableCreator>();
            services.AddSingleton<IGoogleCredentialService, GoogleCredentialService>();
        }
    }
}
