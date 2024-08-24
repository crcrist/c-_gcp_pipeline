using System.Data;
using Google.Cloud.BigQuery.V2;


public class makeDataTable
{

	// Query results create a "BigQueryResults" object type and must 
	// be a public declaration to be used in main program
	public DataTable createTable(BigQueryResults query)
	{

		DataTable table = new DataTable();
		DataColumn column;
		
		column = new DataColumn();
		column.DataType = Type.GetType("System.Int32");
		column.ColumnName = "id";
		table.Columns.Add(column);

		column = new DataColumn();
		column.DataType = Type.GetType("System.Int32");
		column.ColumnName = "avg_employment";
		table.Columns.Add(column);
		
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "state";
		table.Columns.Add(column);

		// Index value for each row added
		int i = 0;

		foreach (var row in query)
		{
			DataRow dataRow = table.NewRow();
			dataRow["id"] = i;
			dataRow["state"] = row["state"];
			dataRow["avg_employment"] = row["avg_employment"];
			table.Rows.Add(dataRow);
			i++;
		}


		return table;

	}
	
}
