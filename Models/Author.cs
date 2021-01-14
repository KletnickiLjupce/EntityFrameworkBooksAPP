using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFrameworkBooksAPP.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [Display(Name = "Author Name")]
        public string Name { get; set; }

        //[ForeignKey("Book")]
        //[Display(Name = "BookName")]
        //public int BookID { get; set; }

        public virtual ICollection<Book> Book { get; set; }

    }
}