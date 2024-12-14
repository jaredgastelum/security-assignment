// Broken Endpoint
// This endpoint allows any authenticated user to access the details of any other user 
// by simply providing the user's ID, violating the principle of least privilege
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public IActionResult GetUserDetails(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }
}


// Fixed Endpoint
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthorizationService _authorizationService;

    public UserController(IUserService userService, IAuthorizationService authorizationService)
    {
        _userService = userService;
        _authorizationService = authorizationService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserDetails(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, user, "UserDetailsPolicy");
        if (!authorizationResult.Succeeded)
            return Forbid();

        return Ok(user);
    }
}

// Custom Authorization Policy
public class UserDetailsAuthorizationHandler : AuthorizationHandler<UserDetailsRequirement, User>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserDetailsRequirement requirement, User resource)
    {
        if (context.User.Identity?.Name == resource.Username || context.User.IsInRole("Admin"))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

public class UserDetailsRequirement : IAuthorizationRequirement { }

// Register Policy
services.AddAuthorization(options =>
{
    options.AddPolicy("UserDetailsPolicy", policy =>
        policy.Requirements.Add(new UserDetailsRequirement()));
});

services.AddScoped<IAuthorizationHandler, UserDetailsAuthorizationHandler>();
