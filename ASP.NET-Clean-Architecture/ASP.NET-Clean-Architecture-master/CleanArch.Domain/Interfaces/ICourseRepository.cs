﻿using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCoursess();   
        Course GetCourseById(int courseId);
    }
}
