using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GuestBook.Models;

namespace GuestBook.ViewModels
{
    public class GuestFormViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Information { get; set; }

        public int PaymentTypeId { get; set; }

        public int GuestTypeId { get; set; }

        [Range(1, 1000)]
        public int? NumberGuests { get; set; }

        public IEnumerable<PaymentType> PaymentTypes { get; set; }


    }
}