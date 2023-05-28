using Microsoft.AspNetCore.Mvc;
using Conduit.Api.Contracts.Users.Requests;
using Conduit.Api.Contracts.Users.Responses;

namespace Conduit.Api.Controllers;

public class UsersController : ApiControllerBase
{
    [HttpPost("login")]
    public Task<ActionResult<UserResponse>> Login([FromBody] LoginUserRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<ActionResult<UserResponse>> Register([FromBody] CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<ActionResult<UserResponse>> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public Task<ActionResult<UserResponse>> Update([FromBody] UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }
}
