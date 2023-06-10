using Backend.Dtos.User;
using Microsoft.AspNetCore.Identity;


namespace Practice.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto);
        Task<IEnumerable<IdentityError>> RegisterAdmin(ApiUserDto apiUserDto);
        Task<IEnumerable<IdentityError>> RegisterDealer(ApiUserDto apiUserDto);
        Task<bool> DeleteUserAsync(string userId);
        Task<AuthResponseDto> Login(LoginUserDto loginApiDto);
    }
}
