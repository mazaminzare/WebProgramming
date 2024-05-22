using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    public class Fluent_Book
    {
    
        public int BookId { get; set; }
 
        public string Title { get; set; }
 
        public string ISBN { get; set; }
 
        public int Price { get; set; }
 
        public string PriceRange { get; set; }

 
        public int CategoryId { get; set; }
 


 
        public int BookDetailId { get; set; }

        public Fluent_BookDetail Fluent_BookDetail { get; set; }


        public int PublisherId { get; set; }
        public Fluent_Publisher Fluent_Publisher { get; set; }

        public ICollection<Fluent_BookAuthor> Fluent_BookAuthors { get; set; }


    }
}
