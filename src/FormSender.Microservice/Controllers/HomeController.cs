﻿using AutoMapper;
using FormSender.Microservice.Data;
using FormSender.Microservice.Entities;
using FormSender.Microservice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace FormSender.Microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public HomeController(IMapper mapper, ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _mapper = mapper;
            _db = db;
            _logger = logger;
        }

        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        [HttpGet("")]
        [HttpGet("{page}")]
        public IActionResult Index(int page)
        {
            _logger.LogInformation("Get page => " + page);
            var messageForm = GetFirstFromDb();
            var viewModel = _mapper.Map<MessageFormViewModel>(messageForm);
            return Ok(viewModel);
        }

        private MessageForm GetFirstFromDb()
        {
            var form = _db.MessageForms.First();
            var content = _db.Content.Where(c => c.Id == form.Id).First();
            var docs = _db.Documents.Where(d => d.Content.Id == content.Id).ToArray();
            form.Content = content;
            form.Content.Documents = docs;
            return form;
        }

        [HttpGet("Error")]
        public IActionResult Error()
        {
            return BadRequest(new { Message = "Some error" });
        }
    }
}