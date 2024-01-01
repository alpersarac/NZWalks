using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this._userManager = userManager;
            this._tokenRepository = tokenRepository;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.username,
                Email = registerRequestDTO.username
            };
            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDTO.password);
            if (identityResult.Succeeded)
            {
                if (registerRequestDTO.roles != null && registerRequestDTO.roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDTO.roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDTO.username);
            if (user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDTO.password);
                if (checkPasswordResult)
                {
                    //get roles
                    var roles = await _userManager.GetRolesAsync(user);
                    //Create Token
                    if (roles!=null)
                    {
                        var token = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var tokenResponse = new LoginResponseDTO
                        {
                            jwtToken = token
                        };
                        return Ok(tokenResponse);
                    }
                }
            }

            return BadRequest("Username or password incorrect");
        }
    }
}
