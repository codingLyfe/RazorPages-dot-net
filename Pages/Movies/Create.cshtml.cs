using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        // initializes any state needed for the page
        public IActionResult OnGet()
        {
            return Page();
        }

        // BindProperty -- maps data from HTTP requests to action method parameters
        // whe the 'Create' form 'POST's the values are bound and given to the Movie Model
        [BindProperty]
        public Movie Movie { get; set; }

        /*
         * This is run when the 'Create' page posts data 
         * 
         * If there are any model errors, the form is redisplayed, along with any form data posted. 
         * If there are no errors, the data is save and the the browser is redirected to the 'Index' page
         */
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}