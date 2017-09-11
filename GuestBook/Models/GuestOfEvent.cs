using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestBook.Models
{
    public class GuestOfEvent
    {
        public int Id { get; set; }

        [Required]
        public Event Event { get; set; }

        [Required]
        public Guest Guest { get; set; }
    }
}