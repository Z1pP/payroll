
namespace Payroll.DataAccess.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime SendTime { get; set; }

        public ChatMessage()
        {
            
        }
        public ChatMessage(string name, string message)
        {
            UserName = name;
            Message = message;
            SendTime = DateTime.Now;
        }
    }
}
