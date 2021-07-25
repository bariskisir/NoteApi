using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteApi.Models.Request;
using NoteApi.Models.Response;
using NoteApi.Services;
using System;
namespace NoteApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        public AuthController
        (
            ILogger<AuthController> logger,
            IAuthService authService
        )
        {
            _logger = logger;
            _authService = authService;
        }
        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login(LoginRequest loginRequest)
        {
            _logger.LogInformation("Login method called with {@loginRequest}", loginRequest);
            try
            {
                var loginResponse = _authService.Login(loginRequest);
                return loginResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception on Login");
                return StatusCode(500);
            }
        }
        [HttpPost]
        [Route("register")]
        public ActionResult<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            _logger.LogInformation("Register method called with {@registerRequest}", registerRequest);
            try
            {
                var registerResponse = _authService.Register(registerRequest);
                return registerResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception on Register");
                return StatusCode(500);
            }
        }
    }
}
