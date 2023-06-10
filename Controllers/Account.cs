using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Backend.Dtos.User;

using Backend.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Authorization;


using System.Security.Claims;
using Practice.Contracts;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;


        public Account(IAuthManager authManager, UserManager<ApiUser> userManager, IMapper mapper)
        {
            _authManager = authManager;
            this._userManager = userManager;
            this._mapper = mapper;

        }
        [HttpGet]
        [Route("register")]
        public async Task<ActionResult<List<GetUserDto>>> GetRegisterUsers()
        {
            var record = await _userManager.Users.ToListAsync();
            if (record == null)
            {
                return BadRequest("Users not exists");
            }
            var users = _mapper.Map<List<GetUserDto>>(record);
            return Ok(users);
        }
        ///Get id of registered User <summary>
        /// Get id of registered User
        /// </summary>




        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            var errors = await _authManager.Register(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok();
        }



        //Post:Rgister:ADmin
        [HttpPost]
        [Route("registerAdmin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RegisterAdmin([FromBody] ApiUserDto apiUserDto)
        {
            var errors = await _authManager.RegisterAdmin(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok();
        }



        //Post:RegisterDealer
        [HttpPost]
        [Route("registerDealer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RegisterDealer([FromBody] ApiUserDto apiUserDto)
        {
            var errors = await _authManager.RegisterDealer(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok();
        }


        //Post;Login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            var authResponse = await _authManager.Login(loginUserDto);
            if (authResponse == null)
            {
                return Unauthorized();
            }
            Response.Headers.Add("Authorization", "Bearer " + authResponse.Token);
            Response.Headers.Add("FirstName", authResponse.FirstName);
            Response.Headers.Add("UserId", authResponse.UserId);
            return Ok(authResponse);
        }
        ///Indentity User
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administration")]

        public async Task<ActionResult<bool>> DeleteUser(string id)
        {
            if (_authManager == null)
            {
                return false;
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
            {
                return false;
            }
            await _userManager.DeleteAsync(user);
            return true;
        }

    }
}
