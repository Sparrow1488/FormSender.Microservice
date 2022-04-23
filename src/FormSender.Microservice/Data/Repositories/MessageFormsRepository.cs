using FormSender.Microservice.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormSender.Microservice.Data.Repositories
{
    public class MessageFormsRepository : IMessageFormsRepository
    {
        public MessageFormsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;
        
        public async Task InsertAsync(MessageForm form) =>
            await _context.AddAsync(form);

        public async Task<MessageForm> GetByIdAsync(Guid id)
        {
            var dbResult = await (from form in _context.MessageForms
                                 join content in _context.Content on form.Id equals content.Id
                                 join document in _context.Documents on content.Id equals document.Id
                                 select new
                                 {
                                     Id = form.Id,
                                     Content = content,
                                     Document = document,
                                     CreatedAt = form.CreatedAt,
                                     UpdatedAt = form.UpdatedAt
                                 }).FirstAsync(x => x.Id == id);
            var messageForm = new MessageForm(id: dbResult.Id,
                                   content: dbResult.Content,
                                   createdAt: dbResult.CreatedAt,
                                   updatedAt: dbResult.UpdatedAt);
            messageForm.Content.Documents = new List<WebDocument>() { dbResult.Document };
            return messageForm;
        }

        public async Task<IEnumerable<MessageForm>> GetAllAsync() =>
            await _context.MessageForms.ToArrayAsync();

        public void DeleteById(Guid id) =>
            throw new NotImplementedException();

        public Task UpdateAsync(MessageForm form) =>
            throw new NotImplementedException();
    }
}
