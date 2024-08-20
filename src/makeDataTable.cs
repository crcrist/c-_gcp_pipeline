using System.Data;
using Google.Cloud.BigQuery.V2;


public class BigQueryDataTableCreator : IDataTableCreator
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
		column.ColumnName = "avg_income";
		table.Columns.Add(column);
		
		// Index value for each row added
		int i = 0;

		foreach (var row in query)
		{
			DataRow dataRow = table.NewRow();
			dataRow["id"] = i;
			dataRow["avg_income"] = row["avg_income"];
			table.Rows.Add(dataRow);
			i++;
		}


		return table;

	}
	
}
