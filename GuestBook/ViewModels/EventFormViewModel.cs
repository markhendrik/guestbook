using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GuestBook.Models;

namespace GuestBook.ViewModels
{
    public class EventFormViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime DateBeg { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        public string Information { get; set; }

        public List<Guest> Guests { get; set; }

        public bool IsNewForm { get; set; }

        public int? Id { get; set; }
    }
}