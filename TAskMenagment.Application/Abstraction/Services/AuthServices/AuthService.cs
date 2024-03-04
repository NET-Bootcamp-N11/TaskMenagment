using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskMenagment.Domain.Entities.DataTransferObject;
using TaskMenagment.Domain.Entities.Model;
using TaskMenagment.Domain.Enums;
using TaskMenagment.Domain.Exeptions;

namespace TaskMenagment.Application.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(ProgrammerDTO programmer)
        {
            if (programmer == null)
            {
                throw new ProgrammerNotFoundExeption();
            }
            else if (IsProgrammerExist(programmer))
            {
                var permissionList = new List<int>();

                if (programmer.Field == Field.Teamlead)
                {
                    permissionList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12 };
                }
                else
                {
                    permissionList = new List<int> { 9,10,12 };
                }

                var permissionToJson = JsonSerializer.Serialize(permissionList);
                List<Claim> claims = new List<Claim>()
                {
                    new Claim("Field", programmer.Field.ToString()),
                    new Claim("FullName", programmer.FullName),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                    new Claim("Permissions", permissionToJson)
                };

                return await GenerateToken(claims);
            }
            return "Token UnAuthorised";
        }

        public async Task<string> GenerateToken(List<Claim> additionalClaims)
        {
            SymmetricSecurityKey? securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            SigningCredentials? credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            int expires = Convert.ToInt32(_configuration["JWT:ExpireDate"] ?? "10");

            List<Claim>? claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,

                expires: DateTime.UtcNow.AddMinutes(expires),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsProgrammerExist(ProgrammerDTO programmer)
        {
            var passw = "12";
            var username = "admin";
            if (programmer.Password == passw && programmer.Username == username) return true;
            return false;
        }
    }
}