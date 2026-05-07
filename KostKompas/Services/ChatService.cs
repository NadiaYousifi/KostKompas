using KostKompas.Models;

namespace KostKompas.Services
{
    public class ChatService
    {
        
            // Instance field
            private List<ChatMessage> messages; // En privat liste, hvor alle beskeder gemmes

        // Constructor
        public ChatService() // Når ChatService instantieres, oprettes en ny liste til at gemme beskeder
                             // Constructor kører automatisk, når ChatService oprettes
        {
            messages = new List<ChatMessage>(); // Her oprettes den tomme liste

            messages.Add(new ChatMessage // Her lægges en startbesked fra coach ind
            {
                    Id = 1, // Startbeskeden får id 1
                    SenderEmail = "coach@kostkompas.dk", // Afsenderen er coachen
                    Text = "Hej og velkommen til chatten 😊", // Teksten i beskeden
                    SentAt = DateTime.Now.AddMinutes(-10), // Beskeden sendes 10 minutter før nu, så den vises som en tidligere besked
                    IsFromUser = false // Beskeden er fra coachen, ikke brugeren
            });
            }

            // Methods
            public List<ChatMessage> GetMessages() // Denne metode returnerer alle beskeder sorteret efter tidspunktet, de blev sendt
            {
                return messages.OrderBy(m => m.SentAt).ToList(); // Beskederne sorteres i stigende rækkefølge baseret på SentAt, så de ældste beskeder kommer først
            }

            public void SendMessage(ChatMessage message) // Denne metode bruges til at sende en ny besked. Den tager en ChatMessage som parameter
            {
                message.Id = messages.Count + 1; // Id'et for den nye besked sættes til antallet af eksisterende beskeder plus 1, så hver besked får et unikt id
                message.SentAt = DateTime.Now; // SentAt sættes til det aktuelle tidspunkt, så beskeden vises som en ny besked

            messages.Add(message); // Den nye besked tilføjes til listen over beskeder
            }
         }
    }

