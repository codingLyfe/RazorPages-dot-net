using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            // sets _context to the database context (the data?)
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }

        // when a request is made returns a list of movies to the razor page
        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            // Use LINQ ot get list of all genres from Database
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            // query is created, has not yet run
            var movies = from m in _context.Movie select m;

            // if search string is given, search movie titles
            if (!String.IsNullOrEmpty(searchString))
            {
                // movies in query is modified to match search criteria
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            
            // if movieGenre parameter is given, search Movies by Genre
            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            // creats a new list of genres that contains only distinct genres (one of each)
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            // this calls the query to the database (ToListAsync())
            Movie = await movies.ToListAsync();
        }
    }
}
