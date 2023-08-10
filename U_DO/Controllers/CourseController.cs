using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using U_DO.Data;
using U_DO.Data.DTO;
using U_DO.Models;

namespace U_DO.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private CourseContext _context;
    private IMapper _mapper;
    public CourseController(CourseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AddCourse([FromBody] CreateCourseDto courseDto)
    {

        // Add course
        Course course = _mapper.Map<Course>(courseDto);
        _context.Courses.Add(course);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
    }

    [HttpGet]
    public IEnumerable<ReadCourseDto> GetCourses([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        // Get tasks
        return _mapper.Map<List<ReadCourseDto>>(_context.Courses.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetCourse(int id)
    {
        // Get course by id
        var course = _context.Courses.FirstOrDefault(course => course.Id == id);

        if (course == null) return NotFound();


        var courseDto = _mapper.Map<ReadCourseDto>(course);

        return Ok(courseDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseDto courseDto)
    {
        // Update course
        var course = _context.Courses.FirstOrDefault(course => course.Id == id);

        if (course == null) return NotFound();

        _mapper.Map(courseDto, course);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateCoursePatch(int id, [FromBody] JsonPatchDocument<UpdateCourseDto> patchDoc)
    {
        // Update course
        var course = _context.Courses.FirstOrDefault(course => course.Id == id);
        if (course == null) return NotFound();

        var courseToPatch = _mapper.Map<UpdateCourseDto>(course);
        patchDoc.ApplyTo(courseToPatch, ModelState);

        if (!TryValidateModel(courseToPatch)) return ValidationProblem(ModelState);

        _mapper.Map(courseToPatch, course);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCourse(int id)
    {
        // Delete course
        var course = _context.Courses.FirstOrDefault(course => course.Id == id);

        if (course == null) return NotFound();

        _context.Courses.Remove(course);
        _context.SaveChanges();

        return NoContent();
    }
}
