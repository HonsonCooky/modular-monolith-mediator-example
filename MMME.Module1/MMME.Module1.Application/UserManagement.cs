using MediatR;
using MMME.Common;

namespace MMME.Module1.Application;

public class ListUserRequest : IRequest<List<Guid>?> {}

public class GetUserRequest(Guid userId) : IRequest<MmmeUser?>
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

    public async Task<MmmeUser?> GetUserWithId(Guid guid)
    {
        return await mediator.Send(new GetUserRequest(guid));
    }
}