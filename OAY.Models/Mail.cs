
using System.ComponentModel;

namespace OAY.Models
{
    public class Mail
    {
        public int MailId { get; set; }
        [DisplayName("Din epost")]
        public string Fra { get; set; }
        public string Til { get; set; }
        public string Emne { get; set; }
        public string Melding { get; set; }
    }
}
