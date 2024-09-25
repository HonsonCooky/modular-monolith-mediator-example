using MediatR;
using MMME.Common;

namespace MMME.Module1.Application;

public class ListUserRequest : IContract<List<Guid>?> {}

public class GetUserRequest(Guid userId) : IContract<MmmeUser?>
{
    public Guid UserId { get; } = userId;
}

public class UserManagement(IMediator mediator)
{
    public async Task<List<Guid>?> GetUserIdsWhere(Func<Guid, int, bool> whereOperation)
    {
        var guids = await mediator.Send(new ListUserRequest());
        return guids?.Where(whereOperation).ToList();
    }

    public async Task<MmmeUser?> GetUserWithId(Guid guid) => await mediator.Send(new GetUserRequest(guid));
}