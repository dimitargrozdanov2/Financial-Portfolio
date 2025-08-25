using FinancialPortfolioSystem.Application;
using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.Identity;
using FinancialPortfolioSystem.Application.Features.Identity.Commands;
using FinancialPortfolioSystem.Application.Features.Identity.Commands.ChangePassword;
using FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static FinancialPortfolioSystem.Infrastructure.Identity.IdentityConstants.Role;

namespace FinancialPortfolioSystem.Infrastructure.Identity;

public class IdentityService : IIdentity
{
    private const string InvalidErrorMessage = "Invalid credentials.";

    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationSettings _applicationSettings;

    public IdentityService(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<ApplicationSettings> applicationSettings)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _applicationSettings = applicationSettings.Value;
    }

    public async Task<Result> Register(UserInputModel userInput)
    {
        var user = new User(userInput.Email);
        IdentityResult createResult = null;

        try
        {
            createResult = await _userManager.CreateAsync(user, userInput.Password);
            if (!createResult.Succeeded)
            {
                var errors = createResult.Errors.Select(e => e.Description);
                return Result.Failure(errors);
            }

            if (!await _roleManager.RoleExistsAsync(UserRole))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(UserRole));
                if (!roleResult.Succeeded)
                {
                    await _userManager.DeleteAsync(user);

                    var errors = roleResult.Errors.Select(e => e.Description);
                    return Result.Failure(errors);
                }
            }

            var roleAssignResult = await _userManager.AddToRoleAsync(user, UserRole);
            if (!roleAssignResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);

                var errors = roleAssignResult.Errors.Select(e => e.Description);
                return Result.Failure(errors);
            }

            return Result.Success;
        }
        catch (Exception ex)
        {
            if (createResult?.Succeeded == true)
            {
                await _userManager.DeleteAsync(user);
            }

            return Result.Failure(new[] { "Unexpected error: " + ex.Message });
        }
    }

    public async Task<Result<LoginOutputModel>> Login(UserInputModel userInput)
    {
        var user = await _userManager.FindByEmailAsync(userInput.Email);
        if (user == null)
        {
            return Result<LoginOutputModel>.Failure(new[] { InvalidErrorMessage });
        }

        var passwordValid = await _userManager.CheckPasswordAsync(user, userInput.Password);
        if (!passwordValid)
        {
            return Result<LoginOutputModel>.Failure(new[] { InvalidErrorMessage });
        }

        var roles = await _userManager.GetRolesAsync(user);

        var token = GenerateJwtToken(
            user.Id,
            user.Email,
            roles);

        return new LoginOutputModel(token);
    }

    private string GenerateJwtToken(string userId, string email, IList<string> userRoles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_applicationSettings.Secret);

        var claims = new List<Claim>()
        {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, email),
        };

       foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
       
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var encryptedToken = tokenHandler.WriteToken(token);

        return encryptedToken;
    }

    public async Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
    {
        var user = await _userManager.FindByIdAsync(changePasswordInput.UserId);

        if (user == null)
        {
            return InvalidErrorMessage;
        }

        var identityResult = await _userManager.ChangePasswordAsync(
            user,
            changePasswordInput.CurrentPassword,
            changePasswordInput.NewPassword);

        var errors = identityResult.Errors.Select(e => e.Description);

        return identityResult.Succeeded
            ? Result.Success
            : Result.Failure(errors);
    }
}
