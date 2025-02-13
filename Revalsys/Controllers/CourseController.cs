using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revalsys.Data;
using Revalsys.Entities;

namespace Revalsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Fetch all courses
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }

        // Create a new course
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            if (course == null)
                return BadRequest(new { Message = "Invalid course data" });

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Course created successfully", Course = course });
        }

    }
}
