using MediatR;
using Google.Cloud.BigQuery.V2;
using System.Threading;
using System.Threading.Tasks;

public class GetBigQueryResultsQueryHandler : IRequestHandler<GetBigQueryResultsQuery, BigQueryResults>
{
    private readonly IGoogleCredentialService _credentialService;

    public GetBigQueryResultsQueryHandler(IGoogleCredentialService credentialService)
    {
        _credentialService = credentialService;
    }

    public Task<BigQueryResults> Handle(GetBigQueryResultsQuery request, CancellationToken cancellationToken)
    {
        string projectId = _credentialService.GetProjectId();
        var client = BigQueryClient.Create(projectId);
        var result = client.ExecuteQuery(request.Query, parameters: null);

        return Task.FromResult(result);
    }
}
