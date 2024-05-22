using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    public class Fluent_BookAuthor
    {
 
        public int BookId { get; set; }
 
        public int AuthorId { get; set; }


        public Fluent_Book Fluent_Book { get; set; }
        public Fluent_Author Fluent_Author { get; set; }
    }
}
