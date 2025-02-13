using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revalsys.Data;
using Revalsys.Entites;
using Revalsys.Entities;
using Revalsys.Models;

[Route("api/[controller]")]
[ApiController]
public class LearnerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LearnerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetLearners()
    {
        var learners = await _context.Learners
            .Include(l => l.LearnerCourses)
            .ThenInclude(lc => lc.Course)
            .ToListAsync();

        return Ok(learners);
    }

    [HttpPost("SaveLearner")]
    public async Task<IActionResult> SaveLearner([FromBody] LearnerDto learnerDto)
    {
        if (await _context.Learners.AnyAsync(l => l.Mobile == learnerDto.Mobile))
            return BadRequest("Mobile number must be unique.");

        var learner = new Learner
        {
            FirstName = learnerDto.FirstName,
            LastName = learnerDto.LastName,
            Mobile = learnerDto.Mobile,
            Email = learnerDto.Email,
            DOB = learnerDto.DOB,
            Gender = learnerDto.Gender,
            ProfileImage = learnerDto.ProfileImage

        };

        _context.Learners.Add(learner);
        await _context.SaveChangesAsync();

        var learnerCourses = learnerDto.CourseIds.Select(courseId => new LearnerCourse
        {
            LearnerId = learner.Id,
            CourseId = courseId
        }).ToList();

        _context.LearnerCourse.AddRange(learnerCourses);
        await _context.SaveChangesAsync();
        return Ok(new { Message = "Learner created successfully.", Learner = learner });
    }

    // ✅ Update learner courses
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLearnerCourses(int id, [FromBody] List<int> courseIds)
    {
        var learner = await _context.Learners.Include(l => l.LearnerCourses).FirstOrDefaultAsync(l => l.Id == id);
        if (learner == null)
            return NotFound(new { Message = "Learner not found" });

        _context.LearnerCourse.RemoveRange(learner.LearnerCourses);

        foreach (var courseId in courseIds)
        {
            _context.LearnerCourse.Add(new LearnerCourse { LearnerId = id, CourseId = courseId });
        }

        await _context.SaveChangesAsync();
        return Ok(new { Message = "Learner courses updated successfully" });
    }
}
