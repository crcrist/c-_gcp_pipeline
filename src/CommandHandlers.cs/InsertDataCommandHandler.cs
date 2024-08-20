using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class InsertDataCommandHandler : IRequestHandler<InsertDataCommand>
{
    private readonly IDatabaseService _databaseService;

    public InsertDataCommandHandler(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public Task<Unit> Handle(InsertDataCommand request, CancellationToken cancellationToken)
    {
        _databaseService.InsertData(request.DataTable);
        return Task.FromResult(Unit.Value);
    }
}
