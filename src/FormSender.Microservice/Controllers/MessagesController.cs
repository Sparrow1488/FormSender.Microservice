using AutoMapper;
using FormSender.Microservice.Data.Repositories;
using FormSender.Microservice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            // 3a765e39-2a9b-4476-a608-08da24fe72ab
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
    }
}