using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NoteApi.Helpers;
using NoteApi.Models.Db;
using NoteApi.Models.Request;
using NoteApi.Models.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace NoteApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        private readonly PostgreSqlContext _postgreSqlContext;
        public AuthService
        (
            IConfiguration configuration,
            PostgreSqlContext postgreSqlContext,
            ILogger<AuthService> logger
        )
        {
            _configuration = configuration;
            _postgreSqlContext = postgreSqlContext;
            _logger = logger;
        }
        public LoginResponse Login(LoginRequest loginRequest)
        {
            var loginResponse = new LoginResponse();
            var existingUser = _postgreSqlContext.Users.SingleOrDefault(x => x.Email == loginRequest.Email);
            if (existingUser != null)
            {
                var isPasswordVerified = CryptoHelper.VerifyPassword(loginRequest.Password, existingUser.Salt, existingUser.Password);
                if (isPasswordVerified)
                {
                    var claimList = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, existingUser.Id.ToString()),
                            new Claim(ClaimTypes.Email, existingUser.Email),
                            new Claim(ClaimTypes.Role, existingUser.Role)
                        };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:SecretKey").Value));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expireDate = DateTime.UtcNow.AddDays(1);
                    var timeStamp = DateHelper.GetTimeStamp(expireDate);
                    var token = new JwtSecurityToken(
                        claims: claimList,
                        notBefore: DateTime.UtcNow,
                        expires: expireDate,
                        signingCredentials: creds);
                    loginResponse.Success = true;
                    loginResponse.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    loginResponse.ExpireDate = timeStamp;
                }
                else
                {
                    loginResponse.MessageList.Add("Password is wrong");
                }
            }
            else
            {
                loginResponse.MessageList.Add("Email is wrong");
            }
            return loginResponse;
        }
        public RegisterResponse Register(RegisterRequest registerRequest)
        {
            var registerResponse = new RegisterResponse();
            if (!_postgreSqlContext.Users.Any(x => x.Email == registerRequest.Email))
            {
                var email = registerRequest.Email;
                var salt = CryptoHelper.GenerateSalt();
                var password = registerRequest.Password;
                var hashedPassword = CryptoHelper.HashMultiple(password, salt);
                var user = new User
                {
                    Email = email,
                    Salt = salt,
                    Password = hashedPassword,
                    Role = "USER"
                };
                _postgreSqlContext.Users.Add(user);
                _postgreSqlContext.SaveChanges();
                registerResponse.Success = true;
            }
            else
            {
                registerResponse.MessageList.Add("Email is already in use");
            }
            return registerResponse;
        }
    }
}
