using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Practice.Contracts;


using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Backend.Data;
using Backend.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace Practice.Repositories
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userMapper;
        private readonly IConfiguration _configuration;


        public AuthManager(IMapper mapper, UserManager<ApiUser> userMapper, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userMapper = userMapper;
            this._configuration = configuration;

        }

        public async Task<AuthResponseDto> Login(LoginUserDto loginApiDto)
        {

            var user = await _userMapper.FindByEmailAsync(loginApiDto.Email);
            bool IsValidate = await _userMapper.CheckPasswordAsync(user, loginApiDto.Password);
            if (user == null || IsValidate == false)
            {
                return null;
            }

            var token = await GenerateTokens(user);

            return new AuthResponseDto
            {
                FirstName = user.FirstName,
                UserId = user.Id,
                Token = token
            };

        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto)
        {
            var user = _mapper.Map<ApiUser>(apiUserDto);
            user.UserName = apiUserDto.Email;
            var result = await _userMapper.CreateAsync(user, apiUserDto.Password);
            if (result.Succeeded)
            {
                await _userMapper.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }
        public async Task<IEnumerable<IdentityError>> RegisterAdmin(ApiUserDto apiUserDto)
        {
            var user = _mapper.Map<ApiUser>(apiUserDto);
            user.UserName = apiUserDto.Email;
            var result = await _userMapper.CreateAsync(user, apiUserDto.Password);
            if (result.Succeeded)
            {
                await _userMapper.AddToRoleAsync(user, "Administration");
            }
            return result.Errors;
        }

        public async Task<IEnumerable<IdentityError>> RegisterDealer(ApiUserDto apiUserDto)
        {
            var user = _mapper.Map<ApiUser>(apiUserDto);
            user.UserName = apiUserDto.Email;
            var result = await _userMapper.CreateAsync(user, apiUserDto.Password);
            if (result.Succeeded)
            {
                await _userMapper.AddToRoleAsync(user, "Dealer");
            }
            return result.Errors;
        }
        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userMapper.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                return false;
            }

            if (user.UserName == "system" || user.UserName == "admin")
            {
                throw new Exception("You can not delete system or admin user");
                //throw new BadRequestException("You can not delete system or admin user");
            }
            var result = await _userMapper.DeleteAsync(user);
            return true;
        }

        private async Task<string> GenerateTokens(ApiUser apiUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credendials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userMapper.GetRolesAsync(apiUser);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userMapper.GetClaimsAsync(apiUser);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,apiUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,apiUser.Email),
                new Claim("uid",apiUser.Id),
            }
            .Union(userClaims).Union(roleClaims);
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credendials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}
