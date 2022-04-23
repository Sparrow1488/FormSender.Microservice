using FormSender.Microservice.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormSender.Microservice.Data.Repositories
{
    public interface IMessageFormsRepository
    {
        Task InsertAsync(MessageForm form);
        Task UpdateAsync(MessageForm form);
        Task<MessageForm> GetByIdAsync(Guid id);
        Task<IEnumerable<MessageForm>> GetAllAsync();
        void DeleteById(Guid id);
    }
}
