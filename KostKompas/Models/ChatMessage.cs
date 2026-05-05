namespace KostKompas.Models
{
    public class ChatMessage
    {
            // Properties
            public int Id { get; set; }
            public string SenderEmail { get; set; }
            public string Text { get; set; }
            public DateTime SentAt { get; set; } = DateTime.Now;
            public bool IsFromUser { get; set; }
        }
    }


