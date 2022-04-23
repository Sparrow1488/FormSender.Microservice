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
            MessageForm result = default;
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
                                 })?.SingleOrDefaultAsync(x => x.Id == id);

            if(dbResult != null)
            {
                result = new MessageForm();
                result.Id = dbResult.Id;
                result.Content = dbResult.Content;
                result.CreatedAt = dbResult.CreatedAt;
                result.UpdatedAt = dbResult.UpdatedAt;

                if (result.Content != null)
                    result.Content.Documents = new List<WebDocument>() { dbResult.Document };
            }
            return result;
        }

        public async Task<IEnumerable<MessageForm>> GetAllAsync() =>
            await _context.MessageForms.ToArrayAsync();

        public void DeleteById(Guid id) =>
            throw new NotImplementedException();

        public Task UpdateAsync(MessageForm form) =>
            throw new NotImplementedException();

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
