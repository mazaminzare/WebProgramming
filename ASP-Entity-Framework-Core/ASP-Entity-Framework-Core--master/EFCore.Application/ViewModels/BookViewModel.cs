using EFCore.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  

namespace EFCore.Application.ViewModels
{
    public class BookViewModel
    {
        public Book? Book { get; set; }
        public IEnumerable<SelectListItem>? PublisherList { get; set; }
        public IEnumerable<SelectListItem>? CategoryList { get; set; }

    }
}
