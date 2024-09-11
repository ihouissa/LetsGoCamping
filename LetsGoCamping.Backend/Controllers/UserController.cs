// UserController.cs
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    // Constructor injection of UserService
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // POST endpoint to register a new user
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        // Attempt to register the user
        bool result = await _userService.RegisterUserAsync(request.Username, request.Email, request.Password);

        // Check if registration was successful
        if (!result)
        {
            // Return a bad request response with an error message
            return BadRequest("User already exists with the given username or email.");
        }

        // Return a success response
        return Ok("User registered successfully.");
    }

    // POST endpoint to log in a user
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Attempt to log in the user
        var user = await _userService.LoginUserAsync(request.UsernameOrEmail, request.Password);

        // Check if login was successful
        if (user == null)
        {
            // Return unauthorized response with error message
            return Unauthorized("Invalid username, email, or password.");
        }

        // Return success response with user information (modify as needed for security)
        return Ok("User logged in successfully.");
    }
}

// DTOs for incoming request data
public class RegisterRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}


public class LoginRequest
{
    [Required]
    public string UsernameOrEmail { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}

