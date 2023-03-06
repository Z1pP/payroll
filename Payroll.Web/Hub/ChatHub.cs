using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Payroll.Business.Services;
using Payroll.DataAccess.Interfaces;
using Payroll.DataAccess.Models;
using Payroll.DataAccess.Models.Employees;

namespace Payroll.Web.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly ChatService _chatService;
        private readonly EmployeeService _employeeService;

        public ChatHub(ChatService chatService, EmployeeService employeeService)
        {
            _chatService = chatService;
            _employeeService = employeeService;
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
