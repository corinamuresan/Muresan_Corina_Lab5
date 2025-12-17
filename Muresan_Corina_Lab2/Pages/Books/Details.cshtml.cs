using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muresan_Corina_Lab2.Data;
using Muresan_Corina_Lab2.Models;

namespace Muresan_Corina_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Muresan_Corina_Lab2.Data.Muresan_Corina_Lab2Context _context;

        public DetailsModel(Muresan_Corina_Lab2.Data.Muresan_Corina_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book is not null)
            {
                Book = book;

                return Page();
            }

            return NotFound();
        }
    }
}
