using MediatR;
using System.Data;

public class InsertDataCommand : IRequest
{
    public DataTable DataTable { get; }

    public InsertDataCommand(DataTable dataTable)
    {
        DataTable = dataTable;
    }
}
