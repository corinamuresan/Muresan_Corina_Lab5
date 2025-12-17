using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muresan_Corina_Lab2.Data;
using Muresan_Corina_Lab2.Models;

namespace Muresan_Corina_Lab2.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Muresan_Corina_Lab2.Data.Muresan_Corina_Lab2Context _context;

        public DetailsModel(Muresan_Corina_Lab2.Data.Muresan_Corina_Lab2Context context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (category is not null)
            {
                Category = category;

                return Page();
            }

            return NotFound();
        }
    }
}
