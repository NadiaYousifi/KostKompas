namespace KostKompas.Models
{
    public class ChatMessage
    {
        // Properties
        public int Id { get; set; } // unikt nummer for beskeden
        public string SenderEmail { get; set; }  // Email på den person, der har sendt beskeden
        public string Text { get; set; } // Selve beskedens indhold
        public DateTime SentAt { get; set; } = DateTime.Now; //Tidspunktet beskeden blev sendt.
                                                             //Hvis man ikke selv sætter et tidspunkt, får den
                                                             //automatisk nuværende tidspunkt
        public bool IsFromUser { get; set; } // Bruges til at afgøre, om beskeden skal vises som brugerbesked
                                             // eller coachbesked
        public string ReceiverEmail { get; set; } // Email på den person, der modtager beskeden. Dette kan være nyttigt for at holde styr på, hvem beskeden er til, især i en chat med flere deltagere
    }
}