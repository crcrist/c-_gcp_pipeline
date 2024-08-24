using Npgsql;
using System.Data;


public class DBConnectTest
{
    

	private string GetConnectionString()
    {
        string conectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

        if (string.IsNullOrEmpty(conectionString) )
        {
            throw new InvalidOperationException("Connection string not found. Please set the POSTGRES_CONNECTION_STRING environment variable.\");");
        }

        return conectionString;
    }



    public void InsertDataIntoPostgres(DataTable dataTable)
    { // Call this method in program.cs...
	  // Instantiate DBConnectTest first.
        
        string connectionString = GetConnectionString();
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    

					// Explicit INSERT statement...
					// At some point it would be good to have this as an env variable so explicit...
					// Assets are not named.
                    cmd.CommandText = "INSERT INTO thrasher.\"public\".\"dotnet\" (id, state, avg_employment) VALUES (@val1, @val2, @val3);";


                    foreach (DataRow row in dataTable.Rows)
                    { // This should match the schema of the data in BQ.
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@val1", row["id"]);
                        cmd.Parameters.AddWithValue("@val2", row["state"]);
                        cmd.Parameters.AddWithValue("@val3", row["avg_employment"]);

                        cmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }
        }
    }

}
