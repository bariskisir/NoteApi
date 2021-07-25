namespace NoteApi.Models.Response
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; }
        public long ExpireDate { get; set; }
    }
}
