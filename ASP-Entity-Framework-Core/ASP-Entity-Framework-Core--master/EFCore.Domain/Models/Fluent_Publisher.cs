using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    public class Fluent_Publisher
    {
 
        public int PublisherId { get; set; }
 
        public string Name { get; set; }
 
        public string Location { get; set; }

        public ICollection<Fluent_Book> Fluent_Books { get; set; }


    }
}
