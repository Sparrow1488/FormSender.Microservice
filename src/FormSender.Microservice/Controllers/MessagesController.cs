using AutoMapper;
using FormSender.Microservice.Data;
using FormSender.Microservice.Entities;
using FormSender.Microservice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FormSender.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        public MessagesController(IMapper mapper, ApplicationDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        [HttpGet("GetFirstMessage")]
        public ActionResult<OperationResult<MessageFormViewModel>> GetFirstMessage()
        {
            var result = new OperationResult<MessageFormViewModel>();
            var messageForm = GetFirstFromDbTwoJoin();
            var viewModel = _mapper.Map<MessageFormViewModel>(messageForm);
            result.Body = viewModel;
            return Ok(result);
        }

        private MessageForm GetFirstFromDbTwoJoin()
        {
            var dbResult = (from form in _db.MessageForms
                           join content in _db.Content on form.Id equals content.Id
                           join document in _db.Documents on content.Id equals document.Id
                           select new
                           {
                               Id = form.Id,
                               Content = content,
                               Document = document,
                               CreatedAt = form.CreatedAt,
                               UpdatedAt = form.UpdatedAt
                           }).First();

            var messageForm = new MessageForm(id: dbResult.Id,
                                   content: dbResult.Content,
                                   createdAt: dbResult.CreatedAt,
                                   updatedAt: dbResult.UpdatedAt);
            messageForm.Content.Documents = new List<WebDocument>() { dbResult.Document };
            return messageForm;
        }
    }
}