using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjectDawAngular.Models;

[Route("api/[controller]")]
[ApiController]
public class StudentCoursesController : ControllerBase
{
    private readonly IStudentCourseRepository _studentCourseRepository;

    public StudentCoursesController(IStudentCourseRepository studentCourseRepository)
    {
        _studentCourseRepository = studentCourseRepository;
    }

    [HttpGet]
    public async Task<List<StudentCourse>> Get()
    {
        return await _studentCourseRepository.GetAll();
    }



    [HttpPost]
    public async Task<List<StudentCourse>> Add(StudentCourse studentCourse)
    {
        return await _studentCourseRepository.Add(studentCourse);
    }

}
