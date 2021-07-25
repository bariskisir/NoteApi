using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoteApi.Models.Response;
using NoteApi.Services;
using System;
namespace NoteApi.Controllers
{
    [Authorize]
    [Route("api/note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<NoteController> _logger;
        private readonly INoteService _noteService;
        public NoteController
        (
            IConfiguration configuration,
            ILogger<NoteController> logger,
            INoteService noteService
        )
        {
            _configuration = configuration;
            _logger = logger;
            _noteService = noteService;
        }
        [HttpPost]
        [Route("add-note")]
        public ActionResult<BaseResponse> AddNote(string text)
        {
            _logger.LogInformation("AddNote method called with {@text}", text);
            try
            {
                var response = new BaseResponse();
                var userId = int.Parse(User.Identity.Name);
                var result = _noteService.AddNote(userId, text);
                response.Success = result;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception on AddNote");
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("get-notes")]
        public ActionResult<GetNotesResponse> GetNotes()
        {
            _logger.LogInformation("GetNotes method called");
            try
            {
                var response = new GetNotesResponse();
                var userId = int.Parse(User.Identity.Name);
                var notes = _noteService.GetNotes(userId);
                response.Success = true;
                response.Notes = notes;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception on GetNotes");
                return StatusCode(500);
            }
        }
    }
}
