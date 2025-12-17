using System.ComponentModel.DataAnnotations.Schema;

namespace Muresan_Corina_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public ICollection<Book>? Books { get; set; }
    }
}
