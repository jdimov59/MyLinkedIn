using System.ComponentModel.DataAnnotations;

namespace MyLinkedIn.DataModels
{
    public class UserLanguage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
