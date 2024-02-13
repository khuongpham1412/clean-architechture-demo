using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Application.Contracts.Features.Auths;
using StorageSystem.Application.Models.Auth.Ins;
using StorageSystem.Persistence.Models;
using StorageSystem.WebAPI.ViewModel.AuthViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StorageSystem.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authServicel;
        public AuthController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, IAuthService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authServicel = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (model is null)
            {
                return BadRequest("Invalid client request");
            }

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var expiresAt = DateTime.UtcNow.AddMinutes(10);
                var accessToken = _authServicel.GenerateAccessToken(authClaims, expiresAt);
                var refreshToken = _authServicel.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User update failure." });
                }

                return Ok(new
                {
                    access_token = accessToken,
                    refresh_token = refreshToken,
                    expires_at = expiresAt
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] Credential1 model)
        {
            string accessToken = model.AccessToken;
            string refreshToken = model.RefreshToken;
            var principal = _authServicel.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest("Invalid client request");

            var expiresAt = DateTime.UtcNow.AddMinutes(10);
            var newAccessToken = _authServicel.GenerateAccessToken(principal.Claims, expiresAt);
            var newRefreshToken = _authServicel.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User update failure." });
            }
            return Ok(new
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        //[HttpPost, Authorize]
        //[Route("revoke")]
        //public IActionResult Revoke()
        //{
        //    var username = User.Identity.Name;
        //    var user = _userContext.LoginModels.SingleOrDefault(u => u.UserName == username);
        //    if (user == null) return BadRequest();
        //    user.RefreshToken = null;
        //    _userContext.SaveChanges();
        //    return NoContent();
        //}


        //[HttpPost]
        //public IActionResult Authenticate([FromBody] Credential credential)
        //{
        //    Console.WriteLine("vao");
        //    if(credential.UserName == "admin" && credential.Password == "admin123") {
        //        var claims = new List<Claim> {
        //            new Claim(ClaimTypes.Name, "admin"),
        //            new Claim(ClaimTypes.Email, "admin@gmail.com"),
        //            new Claim("Department", "HR"),
        //            new Claim("Admin", "true"),
        //            new Claim("Manager", "true"),
        //            new Claim("EmploymentDate", "2021-02-01")
        //        };

        //        var expiresAt = DateTime.UtcNow.AddMinutes(10);

        //        return Ok(new
        //        {
        //            access_token = CreateToken(claims, expiresAt),
        //            expires_at = expiresAt
        //        });
        //    }

        //    ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint.");
        //    return Unauthorized(ModelState);
        //}
    }

    public class Credential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Credential1
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
