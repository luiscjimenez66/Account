using Account.DTO.Input;
using Account.DTO.Output;
using Account.Entities;
using Account.Interfaces.Business;
using Account.Interfaces.DataAccess;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Account.BusinessLayer
{
    public class SecurityBusiness : ISecurityBusiness
    {
        private readonly IUserDataAccess _userDA;
        private readonly AppSettings _appSettings;

        public SecurityBusiness(IUserDataAccess userDA, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _userDA = userDA;
        }

        public OutAuthenticateDTO Authenticate(InAuthenticateDTO userDTO)
        {
            var user = _userDA.LogIn(userDTO.Username, userDTO.Password).Result;

            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expireDate = DateTime.UtcNow.AddHours(2);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = expireDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            OutAuthenticateDTO userToken = new OutAuthenticateDTO()
            {
                Token = tokenHandler.WriteToken(token),
                ExpirationDate = expireDate
            };

            return userToken;
        }
    }
}
