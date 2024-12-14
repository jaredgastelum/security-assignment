// Broken Endpoint
// This endpoint is vulnerable to SQL injection due to the use of string interpolation in the SQL query
[HttpGet("users")]
public IActionResult GetUsers(string name)
{
    var query = $"SELECT * FROM Users WHERE Name LIKE '%{name}%'";
    var users = _context.Users.FromSqlRaw(query).ToList();
    return Ok(users);
}



// Fixed Endpoint
// Use parameterized queries to prevent SQL injection
[HttpGet("users")]
public IActionResult GetUsers(string name)
{
    var users = _context.Users.Where(u => u.Name.Contains(name)).ToList();
    return Ok(users);
}
