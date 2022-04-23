using FormSender.Microservice.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<MessageForm> GetByIdAsync(Guid id) =>
            await _context.MessageForms.FindAsync(id);

        public async Task<IEnumerable<MessageForm>> GetAllAsync() =>
            await _context.MessageForms.ToArrayAsync();

        public void DeleteById(Guid id) =>
            throw new NotImplementedException();

        public Task UpdateAsync(MessageForm form) =>
            throw new NotImplementedException();
    }
}
