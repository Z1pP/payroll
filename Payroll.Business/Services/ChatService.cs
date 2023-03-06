using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;

namespace Payroll.Business.Services
{
    public class ChatService
    {
        private readonly IBaseRepository<ChatMessage> _chatRepository;

        public ChatService(IBaseRepository<ChatMessage> chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public List<ChatMessage> GetChatMessages()
        {
            return _chatRepository.GetAll().ToList();
        }

        public async Task SaveMessage(ChatMessage chatMessage)
        {
            await _chatRepository.Create(chatMessage);
        }
    }
}
