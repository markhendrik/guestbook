using System.ComponentModel.DataAnnotations;

namespace GuestBook.Models
{
    public class PaymentType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}