using KostKompas.Models;
using KostKompas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Chat
{
    [Authorize(Roles = "admin")]
    public class AdminChatModel : PageModel
    {

        // instance fields 
        private ChatService _chatService;

        public List<ChatMessage> Messages { get; set; }

        // properteis 
        [BindProperty]
        public string ReplyMessage { get; set; }

        [BindProperty]
        public string ReceiverEmail { get; set; }

        // constructor 

        public AdminChatModel(ChatService chatService)
        {
            _chatService = chatService;
        }


        // metode OnGet - henter alle beskeder til admin og viser dem på siden
        public void OnGet()
        {
            Messages = _chatService.GetAllMessages();
        }

        // metode OnPost - sender en besked til en bruger

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(ReplyMessage))
            {
                ChatMessage message = new ChatMessage
                {
                    SenderEmail = User.Identity.Name,
                    ReceiverEmail = ReceiverEmail,
                    Text = ReplyMessage,
                    IsFromUser = false
                };

                _chatService.SendMessage(message);
            }

            return RedirectToPage();
        }
    }
}