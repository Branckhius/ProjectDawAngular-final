using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ProjectDawAngular.Models;

namespace ProjectDawAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly Lab4Context _lab4Context;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IProfessorDetailsRepository _professorDetailsRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;

        public DatabaseController(
            Lab4Context lab4Context,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IDepartmentRepository departmentRepository,
            IProfessorRepository professorRepository,
            IProfessorDetailsRepository professorDetailsRepository,
            IStudentCourseRepository studentCourseRepository)
        {
            _lab4Context = lab4Context ?? throw new ArgumentNullException(nameof(lab4Context));
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _professorRepository = professorRepository ?? throw new ArgumentNullException(nameof(professorRepository));
            _professorDetailsRepository = professorDetailsRepository ?? throw new ArgumentNullException(nameof(professorDetailsRepository));
            _studentCourseRepository = studentCourseRepository ?? throw new ArgumentNullException(nameof(studentCourseRepository));
        }

        // Funcții pentru entitatea Student
        [HttpGet("Students")]
        public ActionResult<List<Student>> GetAllStudents()
        {
            var students = _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("Students/GroupBy")]
        public async Task<ActionResult> GroupStudentsByAge()
        {
            var groupedStudents = await _studentRepository.GroupBy();
            return Ok(groupedStudents);
        }


        [HttpGet("Students/Where")]
        public async Task<ActionResult<List<Student>>> GetStudentByAge(int age)
        {
            var students = await _studentRepository.Where(age);
            return Ok(students);
        }

        [HttpGet("Students/GetAllWithInclude")]
        public ActionResult<List<Student>> GetAllStudentsWithInclude()
        {
            var students = _studentRepository.GetAllWithInclude();
            return Ok(students);
        }

        [HttpGet("Students/GetAllWithJoin")]
        public ActionResult<List<dynamic>> GetAllStudentsWithJoin()
        {
            var students = _studentRepository.GetAllWithJoin();
            return Ok(students);
        }

        [HttpGet("Courses")]
        public ActionResult<List<Course>> GetAllCourses()
        {
            var courses = _courseRepository.GetAll();
            return Ok(courses);
        }


        [HttpGet("Departments")]
        public ActionResult<List<Department>> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return Ok(departments);
        }

        [HttpGet("Professors")]
        public ActionResult<List<Professor>> GetAllProfessors()
        {
            var professors = _professorRepository.GetAll();
            return Ok(professors);
        }

        [HttpGet("ProfessorDetails")]
        public ActionResult<List<ProfessorDetails>> GetAllProfessorDetails()
        {
            var professorDetails = _professorDetailsRepository.GetAll();
            return Ok(professorDetails);
        }

        [HttpGet("StudentCourses")]
        public ActionResult<List<StudentCourse>> GetAllStudentCourses()
        {
            var studentCourses = _studentCourseRepository.GetAll();
            return Ok(studentCourses);
        }


        // Alte funcții pentru entitatea StudentCourse
    }
}
