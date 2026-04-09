using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediAssist.Api.Data;
using MediAssist.Api.DTOS;
using MediAssist.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly MediAssistDbContext _db;
    private readonly ITokenService _tokenService;

    public AuthController(MediAssistDbContext db, ITokenService tokenService)
    {
        _db = db;
        _tokenService = tokenService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        // AnyAsync is better than FirstOrDefaultAsync + null check, because it can stop at the first match without fetching the entire user record.
        var exist = await _db.Users.AnyAsync(u => u.Email == dto.Email);
        if (exist)
            return BadRequest("Email already in use");

        var user = new User
        {
            Email = dto.Email,
            // BCrypt.HashPassword generates a salt internally and stores it
            // inside the hash string itself, so we don't need a separate salt column.
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = UserRole.Nurse
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return Ok(new { user.Id, user.Email });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _db.Users
        .FirstOrDefaultAsync(u => u.Email == dto.Email);
        // Return the same error for "user does not exist" and "wrong password".
        // If you distinguish between them, you are telling an attacker which
        // emails are registered, which is the first step in a targeted attack.
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized(new { error = "Invalid email or password." });
        var token = _tokenService.CreateToken(user);
        return Ok(new { token, user = new { user.Id, user.Email, user.Role } });
    }

    // mock endpoint to test JWT authentication. Remove before production.
    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        return Ok(new { userId, email, role });
    }
}