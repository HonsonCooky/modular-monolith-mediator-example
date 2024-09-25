using MediatR;
using MMME.Common;
using MMME.Module1.Application;

namespace MMME.Module1.Infrastructure;

public static class InMemDbExample
{
    public static readonly List<MmmeUser> UserDb =
    [
        new(Guid.NewGuid(), "John Smith", MmmeUserType.Regular),
        new(Guid.NewGuid(), "Jane Johnson", MmmeUserType.Premium),
        new(Guid.NewGuid(), "Emily Davis", MmmeUserType.Curious),
        new(Guid.NewGuid(), "Two And A Half Devs", MmmeUserType.Enterprise),
    ];
}

public class ListUsersHandler : IContractHandler<ListUserRequest, List<Guid>?>
{
    public Task<List<Guid>?> Handle(ListUserRequest request, CancellationToken cancellationToken)
    {
        var res = InMemDbExample.UserDb.Select(u => u.Id).ToList();
        return Task.FromResult(res.Count > 0 ? res : null);
    }
}

public class GetUserHandler : IContractHandler<GetUserRequest, MmmeUser?>
{
    public Task<MmmeUser?> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(InMemDbExample.UserDb.Find(u => u.Id.Equals(request.UserId)));
    }
}