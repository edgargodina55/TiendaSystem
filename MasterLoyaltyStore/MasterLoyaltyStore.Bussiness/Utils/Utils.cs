using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MasterLoyaltyStore.Entities.Enums;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.Extensions.Configuration;

public class Utils
{
    private readonly IConfiguration _config;
    
    
    public Utils(IConfiguration config)
    {
        _config = config;
    }
    
    public string EncryptSHA256(string plainText)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
       
    }

    public string GenerateToken(string user, string password,int userTypeId)
    {
        if( user == null ) throw new ArgumentNullException(nameof(user));
        if (string.IsNullOrEmpty(user)) throw new ArgumentException("User name cannot be null or empty.");
        if (userTypeId < 0 ) throw new ArgumentException("User role cannot be null.");

        string roleName = userTypeId == (int)UserTypeId.Admin ? "Administrator" : "Customer";
        //Create information of use to create Token
        // La colección userClaims permite empaquetar información clave del usuario en el JWT de una manera estándar y 
        //     fácil de interpretar. 
        //     Esto es fundamental para autenticar y autorizar solicitudes basadas en roles o identidad.
        var userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.ToString()),
            new Claim(ClaimTypes.Email, user!),
            new Claim( ClaimTypes.Role, roleName),
        };
        
        if ( userTypeId == (int) UserTypeId.Admin)
        {
            userClaims.Add(new Claim("Admin","true"));
        }
        if (userTypeId == (int) UserTypeId.Customer)
        {
            userClaims.Add(new Claim("Customer","true"));
        }
       
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:key"]!));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);
            //  Crete token detail
            var jwtConfiguration = new JwtSecurityToken(
                claims: userClaims,
                expires:DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
                );
            
            return new JwtSecurityTokenHandler().WriteToken(jwtConfiguration);
    }
}