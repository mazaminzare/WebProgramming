using CleanArch.Data.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {private readonly UniversityDBContext _context;
        public CourseRepository(UniversityDBContext context)
        {
            _context = context;
        }

        public Course GetCourseById(int courseId)
        {
            return _context.Courses.Find(courseId);
        }

        public IEnumerable<Course> GetCoursess()
        {
           return _context.Courses;
        }
    }
}
