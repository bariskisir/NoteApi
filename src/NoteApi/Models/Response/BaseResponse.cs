using NoteApi.Models.Db;
using System.Collections.Generic;
namespace NoteApi.Models.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public List<string> MessageList { get; set; }

        public BaseResponse()
        {
            MessageList = new List<string>();
        }
    }
}
