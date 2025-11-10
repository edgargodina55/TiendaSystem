using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using MasterLoyaltyStore.Bussiness.Services.Interface;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Handlers;

public class UserHandler : IUserHandler
{
    
    private readonly IUserRepository _userRepository;
    private readonly IUserCreationService _userCreationService;
    private readonly Utils _utils;

    public UserHandler(IUserRepository userRepository,Utils utils,IUserCreationService userCreationService)
    {
        _userRepository = userRepository;
        _utils = utils;
        _userCreationService = userCreationService;
    }
    
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<User?> GetUserById(int id)
    {
        return  await _userRepository.GetByIdAsync(id);   
    }

    public async Task<User> CreateUserAsync(User newUser, CancellationToken cancellationToken = default)
    {
        if( newUser == null )
            throw new ArgumentNullException(nameof(newUser));

        var user = await _userRepository.ExistsUser(newUser.Email);
        if( user != null)
            throw new Exception("El usuario ya existe");

        var hashedPassword = _utils.EncryptSHA256(newUser.PasswordHash);
        newUser.PasswordHash = hashedPassword;
        
        var userCreated = _userCreationService.CreateUser(newUser.Email,newUser.PasswordHash,newUser.Address,newUser.FirstName,newUser.LastName,newUser.UserTypeId);
        await _userRepository.AddAsync(userCreated,cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);
        return newUser;   
    }

    public Task<User> UpdateUserAsync(User updatedUser,CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User> DeleteUserAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id);
        _userRepository.Delete(user);
        await _userRepository.SaveChangesAsync();
        return user;       
    }
    
}