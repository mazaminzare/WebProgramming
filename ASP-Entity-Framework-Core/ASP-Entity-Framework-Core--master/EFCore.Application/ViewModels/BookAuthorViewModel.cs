using EFCore.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application.ViewModels
{
    public class BookAuthorViewModel
    {
        public BookAuthor BookAuthor { get; set; }
        public Book Book { get; set; }
        public IEnumerable<BookAuthor> BookAuthors { get; set; }
        public IEnumerable<SelectListItem> AuthorList{ get; set; }
    }
}
