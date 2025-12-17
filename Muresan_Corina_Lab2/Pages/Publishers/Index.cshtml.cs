using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muresan_Corina_Lab2.Models;
using Muresan_Corina_Lab2.Models.ViewModels;

namespace Muresan_Corina_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Muresan_Corina_Lab2.Data.Muresan_Corina_Lab2Context _context;

        public IndexModel(Muresan_Corina_Lab2.Data.Muresan_Corina_Lab2Context context)
        {
            _context = context;
        }

        public PublisherIndexData PublisherData { get; set; } = new PublisherIndexData();
 
        public int PublisherID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {

            PublisherData.Publishers = await _context.Publisher
                .Include(p => p.Books)
                    .ThenInclude(b => b.Author)
                .OrderBy(p => p.PublisherName)
                .ToListAsync();

            if (id != null)
            {
                PublisherID = id.Value;
                Publisher publisher = PublisherData.Publishers
                    .Single(p => p.ID == id.Value);

                PublisherData.Books = publisher.Books;
            }
        }
    }
}


