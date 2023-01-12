using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.User;
using FiveMeals.WebAPI.ServiceJWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtService _jwtService;

        public UserController(
            UserManager<IdentityUser> userManager,
            JwtService jwtService
        )
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDTO>> PostUser(CreateUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = user.Username, Email = user.Email },
                user.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.Password = null;
            return Created("", user);
        }

        [HttpPost("Token")]
        public async Task<ActionResult<AuthenticationResponse>> CreateToken(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            //var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtService.CreateToken(user);

            return Ok(token);
        }

    }
}
