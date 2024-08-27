using System.ComponentModel.DataAnnotations;

namespace AishasLib.Models
{
    public class BookInfo
    {
        public String? BookTitle { get; set; }
        public String? AuthorFirstName { get; set; }
        public String? AuthorLastName { get; set; }
        public int? BookEdition { get; set; }
        public String? PublisherName { get; set; }
        public DateTime? PublishedDate { get; set; }

        //public String? ImagePath { get; set; } // images/filena.jpg
    }
}

