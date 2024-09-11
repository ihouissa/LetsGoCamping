// UserService.cs
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using LetsGoCamping.Models; // Ensure this is present


public class UserService
{
    private readonly CampingDbContext _dbContext;

    // Constructor injection of DbContext
    public UserService(CampingDbContext dbContext)
    {
        _dbContext = dbContext; // Set the injected DbContext instance
    }

    // Method to register a new user
    public async Task<bool> RegisterUserAsync(string username, string email, string password)
    {
        // Check if the user already exists based on the username or email
        if (await _dbContext.Users.AnyAsync(u => u.Username == username || u.Email == email))
        {
            return false; // User already exists, registration fails
        }

        // Create a new user object with hashed password
        var newUser = new User
        {
            Username = username,
            Email = email,
            PasswordHash = HashPassword(password) // Store securely hashed password
        };

        // Add and save the new user to the database
        _dbContext.Users.Add(newUser);
        await _dbContext.SaveChangesAsync(); // Persist changes to the database
        return true; // Registration successful
    }

    // Method to handle user login
    public async Task<User> LoginUserAsync(string usernameOrEmail, string password)
    {
        // Find user by username or email
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);

        // Validate user exists and password matches
        if (user != null && VerifyPassword(password, user.PasswordHash))
        {
            return user; // Login successful, return the user
        }

        return null; // Login failed, user not found or incorrect password
    }

    // Utility to hash a plain-text password using SHA256
    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // Hash the password
            return Convert.ToBase64String(hashedBytes); // Convert hash to a string
        }
    }

    // Utility to verify that a password matches the stored hash
    private bool VerifyPassword(string password, string storedHash)
    {
        return HashPassword(password) == storedHash; // Re-hash and compare with stored hash
    }
}
