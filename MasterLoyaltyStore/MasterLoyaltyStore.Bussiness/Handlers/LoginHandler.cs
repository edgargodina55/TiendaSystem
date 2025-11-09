using MasterLoyaltyStore.API.Dtos.Login;
using MasterLoyaltyStore.Bussiness.Exceptions;
using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Handlers;

public class LoginHandler : ILoginHandler
{
    private readonly IUserRepository _userRepository;
    private readonly Utils _utils;

    public LoginHandler(IUserRepository userRepository,Utils utils)
    {
        _userRepository = userRepository;
        _utils = utils;
    }
    
    
    public Task<User> CreateDefaultUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterUser(string firstName, string lastName, string email, string password, int userTypeId)
    {
        throw new NotImplementedException();
    }

    public async Task<LoginResponse> Authenticate(string username, string password)
    {
        if( string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            throw new ArgumentNullException("El usuario y la contrasena es requerido");
        
        var user = await _userRepository.ExistsUser(username);
        
        if( user == null)
            throw new NotFoundException("Usuario no encontrado");

        var hashedPassword = _utils.EncryptSHA256(password);
        user.PasswordHash = hashedPassword;
        return new LoginResponse
        {
            Token = "",
            User = new User()
        };
    }
}