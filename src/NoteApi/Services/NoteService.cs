using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoteApi.Models.Db;
using System.Collections.Generic;
using System.Linq;
namespace NoteApi.Services
{
    public class NoteService : INoteService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<NoteService> _logger;
        private readonly PostgreSqlContext _postgreSqlContext;
        public NoteService
        (
            IConfiguration configuration,
            ILogger<NoteService> logger,
            PostgreSqlContext postgreSqlContext
        )
        {
            _configuration = configuration;
            _logger = logger;
            _postgreSqlContext = postgreSqlContext;
        }
        public bool AddNote(int userId, string text)
        {
            var note = new Note()
            {
                UserId = userId,
                Text = text
            };
            _postgreSqlContext.Add(note);
            _postgreSqlContext.SaveChanges();
            return true;
        }
        public List<Note> GetNotes(int userId)
        {
            var userNotes = _postgreSqlContext.Notes.Where(x => x.UserId == userId).ToList();
            return userNotes;
        }
    }
}
