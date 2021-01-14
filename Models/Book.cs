using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkBooksAPP.Models
{
    public class Book
    {   
        [Key]
        public int BookID { get; set; }

        [Display(Name="Book Name")]
        public string Name { get; set; }

        [Display(Name = "Book Count")]
        public int? Count { get; set; }

        [ForeignKey("Author")]
        [Display(Name="Author")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
    }
}