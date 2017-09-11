using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GuestBook.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d+$")]
        public string Code { get; set; }

        public string Information { get; set; }

        public PaymentType PaymentType { get; set; }

        [Required]
        public GuestType GuestType { get; set; }

        [Range(1, 1000)]
        public int? NumberGuests { get; set; }
    }


}