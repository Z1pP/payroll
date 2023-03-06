
using Microsoft.AspNetCore.SignalR;
using Payroll.Business.Services;
using Payroll.DataAccess.Models;

namespace Payroll.Web.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly ChatService _chatService;

        public ChatHub(ChatService chatService)
        {
            _chatService = chatService;
        }
        public async Task SendMessage(string user, string message)
        {
            ChatMessage chatMessage = new ChatMessage(user, message);
            await _chatService.SaveMessage(chatMessage);

            await Clients.All.SendAsync("ReceiveMessage",
                chatMessage.UserName, 
                chatMessage.Message, 
                chatMessage.SendTime.ToString("HH:mm"));
        }
        public override async Task OnConnectedAsync()
        {
            var chatHistory = _chatService.GetChatMessages();

            foreach (var message in chatHistory)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", 
                    message.UserName, 
                    message.Message,
                    message.SendTime.ToString("HH:mm"));
            }

            await base.OnConnectedAsync();
        }
    }
}
