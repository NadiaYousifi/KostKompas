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
        private ChatService _chatService;

        // Properties
        public List<ChatMessage> Messages { get; set; }

        [BindProperty]
        public string NewMessage { get; set; }

        // Constructor
        public IndexModel(ChatService chatService)
        {
            _chatService = chatService;
        }

        // Methods
        public void OnGet()
        {
            Messages = _chatService.GetMessages();
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(NewMessage))
            {
                ChatMessage message = new ChatMessage
                {
                    SenderEmail = User.Identity.Name,
                    Text = NewMessage,
                    IsFromUser = true
                };

                _chatService.SendMessage(message);
            }

            return RedirectToPage();
        }
    }
}


