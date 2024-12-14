// Broken Endpoint
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = new User 
        {
            Username = request.Username,
            Password = request.Password, // Storing plain text password
            Email = request.Email
        };
        
        await _userRepository.CreateUser(user);
        return Ok(new { Message = "User registered successfully" });
    }
}


// Fixed Endpoint
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (!IsPasswordComplex(request.Password))
        {
            return BadRequest("Password does not meet complexity requirements");
        }

        var hashedPassword = _passwordHasher.HashPassword(request.Password);
        var user = new User 
        {
            Username = request.Username,
            PasswordHash = hashedPassword,
            Email = request.Email
        };
        
        await _userRepository.CreateUser(user);
        return Ok(new { Message = "User registered successfully" });
    }
}
