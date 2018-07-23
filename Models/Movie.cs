using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesMovie.Models
{
    public class Movie
    {
        /*
         *  Validation is delcared ONCE in the Model Class and enforced everywhere! 
         *  
         *  Enforced Server and Client side via JS and jQuery
         *  Validated servers side if user has JS disabled
         */

        public int ID { get; set; }

        // validation for Title length (Required)
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        // specifies what to display for the name field
        [Display(Name = "Release Date")]
        // specifies the type of the data (Date) so the time information stored in the field isn't displayed
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        // must start with one or more capital letters and follow with zero or more letters, single or double quotes, whitespace characters, or dashes.
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        // schema that allows Entity Framework Core (EFC) to correctly map 'Price' to currency in DB
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // must start with one or more capital letters and follow with zero or more letters, numbers, single or double quotes, whitespace characters, or dashes.
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}
