using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestBook.Dto
{
    public class NewEventDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime DateBeg { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        [Required]
        public string Address { get; set; }

        public string Information { get; set; }

        public int? NumberGuestsTotal { get; set; }

        public List<int> GuestsIds { get; set; }
    }
}