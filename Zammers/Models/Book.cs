using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zammers.Models
{
    public partial class Book
    {//All database values used
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required(ErrorMessage ="PLease enter the book title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter an author name")]
        public string Author { get; set; }
        [Required(ErrorMessage ="Please enter a publisher")]
        public string Publisher { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required(ErrorMessage ="Please enter a category")]
        public string Category { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Please Enter a Price")]
        //Adds in error if price is negative or more than 2 decimal places
        public double Price { get; set; }
    }
}
