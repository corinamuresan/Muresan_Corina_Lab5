using Muresan_Corina_Lab2.Models;

namespace Muresan_Corina_Lab2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Book>? Books { get; set; }
    }
}

