using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        // GET: api/Student/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound("Student record not found");
            }
            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetStudent),
                new { id = student.Id },
                student
            );
        }

        // PUT: api/Student/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Student ID mismatch");
            }

            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound("Student record not found");
            }

            existingStudent.FullName = student.FullName;
            existingStudent.EnrollmentNo = student.EnrollmentNo;
            existingStudent.Email = student.Email;
            existingStudent.Department = student.Department;
            existingStudent.Semester = student.Semester;

            await _context.SaveChangesAsync();
            return Ok(existingStudent);
        }

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound("Student record not found");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok("Student deleted successfully");
        }
    }
}