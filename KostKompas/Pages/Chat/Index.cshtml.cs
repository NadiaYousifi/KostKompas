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
        public void OnGet() // OnGet-metoden kaldes, når siden indlæses,
                            // og den henter de eksisterende chatbeskeder ved at kalde GetMessages-metoden på
                            // ChatService og gemmer dem i Messages-listen, som derefter kan vises på siden
        {
            Messages = _chatService.GetMessages(); // Henter chatbeskederne fra ChatService
                                                   // og gemmer dem i Messages-listen
        }

        public IActionResult OnPost() // OnPost-metoden kaldes, når brugeren sender en ny besked.
                                      // Den tjekker først, om den nye besked ikke er tom eller kun indeholder whitespace.
        {
            if (!string.IsNullOrWhiteSpace(NewMessage)) // Hvis den nye besked er gyldig (ikke tom eller kun whitespace),
                                                        // oprettes en ny ChatMessage-objekt med afsenderens email,
                                                        // beskedens tekst og en flag, der angiver, at beskeden kommer fra brugeren.
            {
                ChatMessage message = new ChatMessage // Opretter en ny ChatMessage-objekt
                {
                    SenderEmail = User.Identity.Name, // Sætter afsenderens email til den nuværende brugers email
                                                      // (hentet fra User.Identity.Name)

                    Text = NewMessage, // Sætter beskedens tekst til den nye besked, som brugeren har indtastet
                    IsFromUser = true // Sætter flaget IsFromUser til true, hvilket indikerer,
                                      // at beskeden kommer fra brugeren
                };

                _chatService.SendMessage(message); // Sender den nye besked ved at kalde SendMessage-metoden på ChatService,
                                                   // som håndterer logikken for at gemme og distribuere beskeden til andre brugere
            }

            return RedirectToPage(); // Efter at have sendt beskeden, omdirigeres brugeren tilbage til samme side (Index),
                                     // hvilket får siden til at genindlæses og vise den opdaterede liste af chatbeskeder,
                                     // inklusive den nye besked, der lige er sendt
        }
    }
}


