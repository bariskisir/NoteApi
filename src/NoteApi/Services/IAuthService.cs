using NoteApi.Models.Request;
using NoteApi.Models.Response;
namespace NoteApi.Services
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest loginRequest);
        RegisterResponse Register(RegisterRequest registerRequest);
    }
}