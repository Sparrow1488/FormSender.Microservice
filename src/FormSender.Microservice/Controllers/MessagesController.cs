using AutoMapper;
using FormSender.Microservice.Data.Repositories;
using FormSender.Microservice.Entities;
using FormSender.Microservice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormSender.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        public MessagesController(
            IMapper mapper, 
            IMessageFormsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        private readonly IMapper _mapper;
        private readonly IMessageFormsRepository _repository;

        [HttpGet("GetById/{id:Guid}")]
        public async Task<ActionResult<OperationResult<MessageFormViewModel>>> GetByIdAsync(Guid id)
        {
            var result = new OperationResult<MessageFormViewModel>();
            var messageForm = await _repository.GetByIdAsync(id);
            if (messageForm == null)
            {
                result.Ok = false;
                result.Errors.Add("Not found by " + id.ToString());
            }
            var viewModel = _mapper.Map<MessageFormViewModel>(messageForm);
            result.Body = viewModel;
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<OperationResult<IEnumerable<MessageFormViewModel>>>> GetAllAsync()
        {
            var result = new OperationResult<IEnumerable<MessageFormViewModel>>();
            var messageForms = await _repository.GetAllAsync();
            var viewModels = _mapper.Map<IEnumerable<MessageFormViewModel>>(messageForms);
            result.Body = viewModels;
            return Ok(result);
        }

        [HttpPost("CreateContent")]
        public ActionResult<OperationResult<MessageFormViewModel>> CreateContent([FromBody]CreateContentViewModel viewModel)
        {
            var result = new OperationResult<MessageFormViewModel>();
            if (ModelState.IsValid)
            {
                var formContent = _mapper.Map<Content>(viewModel);
                var form = _mapper.Map<MessageForm>(formContent);
                var formViewModel = _mapper.Map<MessageFormViewModel>(form);

                result.Messages.Add("Message form created success");
                result.Body = formViewModel;
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                result.Errors.AddRange(errors.Select(err => err.ErrorMessage));
                result.Ok = false;
            }
            
            return result;
        }
    }
}