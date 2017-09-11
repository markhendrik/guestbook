using System.ComponentModel.DataAnnotations;
using GuestBook.Models;

namespace GuestBook.Dto
{
    public class NewGuestDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d+$")]
        public string Code { get; set; }

        public string Information { get; set; }

        [Required]
        public int? PaymentTypeId { get; set; }

        public int? GuestTypeId { get; set; }

        [Required]
        public int? NumberGuests { get; set; }
    }
}