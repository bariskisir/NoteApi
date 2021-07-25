using NoteApi.Models.Db;
using System.Collections.Generic;
namespace NoteApi.Services
{
    public interface INoteService
    {
        bool AddNote(int userId, string text);
        List<Note> GetNotes(int userId);
    }
}