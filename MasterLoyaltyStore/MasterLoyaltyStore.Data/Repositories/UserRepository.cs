using MasterLoyaltyStore.Bussiness.Exceptions;
using MasterLoyaltyStore.Data.Context;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterLoyaltyStore.Data.Repositories;

public class UserRepository :GenericRepository<User>, IUserRepository
{
    public UserRepository(StoreDbContext context) : base(context)
    {
    }

    public async Task<User> ExistsUser(string username)
    {
        return await _dbSet.AsNoTracking()
            .Include(x => x.UserType)
            .FirstOrDefaultAsync(x => x.UserName.Equals(username) && x.Status);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _dbSet.AsNoTracking()
            .Include(x => x.UserType)
            .ToListAsync();   
    }

    public async Task<User> FindUserByCredentials(string username, string hashedPassword)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(hashedPassword))
            throw new ArgumentNullException("Credenciales invalidas");

        User? user = await _dbSet.AsNoTracking()
            .Include(x => x.UserType)
            .FirstOrDefaultAsync(u =>
                u.Status &&
                (u.Email == username || u.UserName == username) &&
                u.PasswordHash == hashedPassword);

        if (user == null)
            throw new ActionFailedException("Correo o Contrasena incorrecta");
        
        return user;
    }
}