using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    public class Author
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }

        [NotMapped]
        public string FullName { get { return $"({FirstName} {LastName})"; } }



    }
}
