using Npgsql;
using System.Data;

public class PostgresDatabaseService : IDatabaseService
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
    {
        //string connectionString = "Host=localhost;Port=5432;Database = postgres;User Id = postgres; Password = Brooke274442!;";
        
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
                    //sql here
                    cmd.CommandText = "INSERT INTO public.\"TEST\" (id, name, number, \"InsertTs\") VALUES (@val1, @val2, @val3, @val4);";

                    foreach (DataRow row in dataTable.Rows)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@val1", row["id"]);
                        cmd.Parameters.AddWithValue("@val2", row["name"]);
                        cmd.Parameters.AddWithValue("@val3", row["number"]);
                        cmd.Parameters.AddWithValue("@val4", DateTime.UtcNow);

                        cmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }
        }
    }

    public void RunTest()
    {
        DataTable dataTable = CreateMockDataTable();

        InsertDataIntoPostgres(dataTable);
    }

    private DataTable CreateMockDataTable()
    {
        DataTable dataTable = new DataTable();

        dataTable.Columns.Add("id", typeof(int));
        dataTable.Columns.Add("name", typeof(string));
        dataTable.Columns.Add("number", typeof(int));

        
        dataTable.Rows.Add(1, "Dis Guy", 123);
        dataTable.Rows.Add(2, "Albe Danged", 456);

        return dataTable;
    }
}

