using MediatR;

public class GetBigQueryResultsQuery : IRequest<BigQueryResults>
{
    public string Query { get; }

    public GetBigQueryResultsQuery(string query)
    {
        Query = query;
    }
}
