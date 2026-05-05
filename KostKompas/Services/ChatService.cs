using KostKompas.Models;

namespace KostKompas.Services
{
    public class ChatService
    {
        
            // Instance field
            private List<ChatMessage> messages;

            // Constructor
            public ChatService()
            {
                messages = new List<ChatMessage>();

                messages.Add(new ChatMessage
                {
                    Id = 1,
                    SenderEmail = "coach@kostkompas.dk",
                    Text = "Hej og velkommen til chatten 😊",
                    SentAt = DateTime.Now.AddMinutes(-10),
                    IsFromUser = false
                });
            }

            // Methods
            public List<ChatMessage> GetMessages()
            {
                return messages.OrderBy(m => m.SentAt).ToList();
            }

            public void SendMessage(ChatMessage message)
            {
                message.Id = messages.Count + 1;
                message.SentAt = DateTime.Now;

                messages.Add(message);
            }
        }
    }

