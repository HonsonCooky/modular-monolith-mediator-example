using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMME.Module1.Application;

namespace MMME.Module1.Presentation;

[Route("api/user")]
public class UserController(IMediator mediator) : ControllerBase
{
    private UserManagement usrMng = new(mediator);

    [HttpGet("list-all")]
    public async Task<string> ListAllUsers()
    {
        var users = await usrMng.GetUserIdsWhere((_,_) => true);
        return users == null ? "Error : Unable to find users" : JsonSerializer.Serialize(users);
    }

    [HttpGet("list-three")]
    public async Task<string> ListThreeUsers()
    {
        var users = await usrMng.GetUserIdsWhere((_, i) => i < 3);
        return users == null ? "Error : Unable to find users" : JsonSerializer.Serialize(users);
    }

    [HttpGet("get/{guid}")]
    public async Task<string> GetUser([FromRoute] Guid guid)
    {
        var user = await usrMng.GetUserWithId(guid);
        return user == null ? "Error: Unable to find user" : JsonSerializer.Serialize(user);
    }
}