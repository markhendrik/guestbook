using System.ComponentModel.DataAnnotations;

namespace GuestBook.Models
{
    public class GuestType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}