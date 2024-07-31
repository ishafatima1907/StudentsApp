
using Microsoft.AspNetCore.Mvc;
using StudentsApp.Infrastructure.Interfaces;
using StudentsApp.Students.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDTO>> PostStudent(StudentDTO studentDto)
        {
            try
            {
                await _studentService.AddStudentAsync(studentDto);
                return CreatedAtAction(nameof(GetStudent), new { id = studentDto.Id }, studentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentDTO studentDto)
        {
            try
            {
                if (id != studentDto.Id)
                {
                    return BadRequest("Student ID mismatch");
                }

                await _studentService.UpdateStudentAsync(studentDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}