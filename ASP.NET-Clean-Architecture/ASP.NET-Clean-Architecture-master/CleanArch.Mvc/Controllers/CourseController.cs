﻿using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            CourseViewModel model= _courseService.GetCourses();
            return View(model);
        }

        public IActionResult ShowCourseInfo(int id) 
        {
            Course course = _courseService.GetCourseById(id);

            if (course==null) 
            {
                return NotFound();
            }
            return View(course);
        }
    }
}
