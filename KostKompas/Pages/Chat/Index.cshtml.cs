using KostKompas.Models;
using KostKompas.Services;
using KostKompas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Chat
{
    [Authorize]
    public class IndexModel : PageModel
    {
        // Instance field
        private ChatService _chatService; // ChatService-instanser bruges til at håndtere chatlogikken

        // Properties
        public List<ChatMessage> Messages { get; set; } // Messages-listen bruges til at vise chatbeskederne på siden

        [BindProperty]
        public string NewMessage { get; set; } // NewMessage bruges til at binde den nye besked, som brugeren indtaster, til modellen

        // Constructor
        public IndexModel(ChatService chatService) // Dependency Injection: ChatService-instanser injiceres i konstruktøren, så den kan bruges i metoderne
        {
            _chatService = chatService; // Gemmer den injicerede ChatService i en instansvariabel, så den kan bruges i OnGet og OnPost metoderne
        }

        // Methods
        public void OnGet() // OnGet-metoden kaldes, når siden indlæses. Den henter chatbeskederne for den nuværende bruger ved at kalde GetMessagesForUser-metoden på ChatService og gemmer dem i Messages-listen, som derefter kan vises på siden
        {
            Messages = _chatService.GetMessagesForUser(User.Identity.Name); // Henter chatbeskederne for den nuværende bruger ved at kalde GetMessagesForUser-metoden på ChatService,
        }

        // metode OnPost
        public IActionResult OnPost() // OnPost-metoden kaldes, når brugeren sender en ny besked. Den tjekker først, om den nye besked ikke er tom eller kun indeholder whitespace. Hvis det er tilfældet, oprettes en ny ChatMessage-objekt med oplysningerne om afsender, modtager, tekst og om det er fra brugeren. Derefter sendes beskeden ved at kalde SendMessage-metoden på ChatService. Til sidst omdirigeres brugeren tilbage til siden for at se den opdaterede chat
        {
            if (!string.IsNullOrWhiteSpace(NewMessage)) // Tjekker, om den nye besked ikke er tom eller kun indeholder whitespace. Hvis det er tilfældet, oprettes en ny ChatMessage-objekt med oplysningerne om afsender, modtager, tekst og om det er fra brugeren. Derefter sendes beskeden ved at kalde SendMessage-metoden på ChatService. Til sidst omdirigeres brugeren tilbage til siden for at se den opdaterede chat
            {
                ChatMessage message = new ChatMessage // Opretter en ny ChatMessage-objekt med oplysningerne om afsender, modtager, tekst og om det er fra brugeren. Derefter sendes beskeden ved at kalde SendMessage-metoden på ChatService. Til sidst omdirigeres brugeren tilbage til siden for at se den opdaterede chat
                {
                    SenderEmail = User.Identity.Name, // Sætter afsenderens email til den nuværende brugers email, som hentes fra User.Identity.Name
                    ReceiverEmail = "admin@gmail.com", // Sætter modtagerens email til "
                    Text = NewMessage, // Sætter tekstindholdet i beskeden til den nye besked, som brugeren har indtastet og som er bundet til NewMessage-egenskaben
                    IsFromUser = true // Sætter IsFromUser-egenskaben til true, hvilket indikerer, at beskeden er sendt af brugeren (i modsætning til en besked, der kunne være sendt af en administrator eller systemet)
                };

                _chatService.SendMessage(message); // Sender beskeden ved at kalde SendMessage-metoden på ChatService og passer den oprettede ChatMessage-objekt som argument. Dette vil håndtere logikken for at gemme beskeden og eventuelt sende den til modtageren
            }

            return RedirectToPage(); // Omdirigerer brugeren tilbage til den samme side (Index-siden) for at se den opdaterede chat, efter at beskeden er sendt. Dette sikrer, at siden genindlæses og viser den nye besked i chatten
        }


    }
}


