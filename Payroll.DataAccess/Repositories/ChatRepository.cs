using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.DataAccess.DataBase;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.DataAccess.Repositories
{
    public class ChatRepository : IBaseRepository<ChatMessage>
    {
        private readonly MyDbContext _dbContext;

        public ChatRepository()
        {
            
        }
        public ChatRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<ChatMessage> GetAll()
        {
            return _dbContext.ChatMessages;
        }

        public  Task Delete(ChatMessage entity)
        {
            throw new NotImplementedException();
        }

        public async Task Create(ChatMessage entity)
        {
           await _dbContext.ChatMessages.AddAsync(entity);
           await _dbContext.SaveChangesAsync();
        }

        public Task<ChatMessage> Update(ChatMessage entity)
        {
            throw new NotImplementedException();
        }
    }
}
