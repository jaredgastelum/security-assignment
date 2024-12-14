// Broken Endpoint
// The vulnerability here is using SHA256 which is:
// Too fast for password hashing
// Doesn't use salt to prevent rainbow table attacks
// Vulnerable to parallel cracking attempts
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        // Vulnerable: Using simple SHA256 hashing without salt
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            var hashedPassword = Convert.ToBase64String(hashedBytes);

            var user = new User 
            {
                Username = model.Username,
                PasswordHash = hashedPassword
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}



// Fixed Endpoint
[HttpPost("register")]
public async Task<IActionResult> Register(RegisterModel model)
{
    // Secure: Using ASP.NET Core Identity's password hasher
    var hasher = new PasswordHasher<User>();
    
    var user = new User 
    {
        Username = model.Username,
        PasswordHash = hasher.HashPassword(null, model.Password)
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return Ok();
}
