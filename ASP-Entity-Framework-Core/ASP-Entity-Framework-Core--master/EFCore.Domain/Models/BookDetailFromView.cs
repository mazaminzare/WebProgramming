﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.Models
{
    public class BookDetailFromView
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int  Price { get; set; }
    }
}
