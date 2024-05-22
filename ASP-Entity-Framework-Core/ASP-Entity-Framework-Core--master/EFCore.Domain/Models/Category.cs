using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        public ICollection<Book>? Books { get; set; }


    }
}
