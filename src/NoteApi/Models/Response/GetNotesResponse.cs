using NoteApi.Models.Db;
using System.Collections.Generic;

namespace NoteApi.Models.Response
{
    public class GetNotesResponse : BaseResponse
    {
        public List<Note> Notes { get; set; }
    }
}
