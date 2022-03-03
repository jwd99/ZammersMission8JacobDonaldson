using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zammers.Models
{
    public class checkoutInfo
    {//model for all of the checkout user information

        [Key]
        [BindNever]
        public int CheckoutId { get; set; }
        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }
        [Required(ErrorMessage ="Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter the an address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Required(ErrorMessage = "Please enter the a city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter the a state")]
        public string State { get; set; }
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Please enter the a country")]
        public string Country { get; set; }

        public string Notes { get; set; }


    }
}
