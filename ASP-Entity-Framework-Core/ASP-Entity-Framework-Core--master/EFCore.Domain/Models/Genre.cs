using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    [Table("tbl_Genre")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [MaxLength(100)]
        [Column("Name")]
        public string? GenreName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
