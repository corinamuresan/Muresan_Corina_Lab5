using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muresan_Corina_Lab2.Data;
using Muresan_Corina_Lab2.Models;
using Muresan_Corina_Lab2.Models.ViewModels;
namespace Muresan_Corina_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Muresan_Corina_Lab2.Data.Muresan_Corina_Lab2Context _context;

        public IndexModel(Muresan_Corina_Lab2.Data.Muresan_Corina_Lab2Context context)
        {
            _context = context;
        }
        public CategoryIndexData CategoryData { get; set; } = new CategoryIndexData();
        public int CategoryID { get; set; }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;

                var selectedCategory = CategoryData.Categories
                    .Single(c => c.ID == id.Value);

                CategoryData.Books = selectedCategory.BookCategories
                    .Select(bc => bc.Book)
                    .Where(b => b != null)
                    .Distinct()
                    .ToList();
            }
        }

    }
}
