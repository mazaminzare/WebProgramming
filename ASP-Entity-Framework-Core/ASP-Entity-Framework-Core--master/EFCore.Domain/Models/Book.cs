using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string ISBN { get; set; }
        [Required]
        public int Price { get; set; }
        [NotMapped]
        public string PriceRange { get; set; }



        #region Navigation Property

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }



        [ForeignKey("BookDetail")]
        public int? BookDetailId { get; set; }
        public BookDetail BookDetail { get; set; }


        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
        #endregion
    }
}
