using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestBook.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Name of event")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Beginning date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateBeg { get; set; }

        [Required]
        [Display(Name = "Ending date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateEnd { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Additional information")]
        public string Information { get; set; }

        [Display(Name = "Participants")]
        public int? NumberGuestsTotal { get; set; }
    }
}