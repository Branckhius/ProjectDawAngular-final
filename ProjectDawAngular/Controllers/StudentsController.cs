using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjectDawAngular.Models;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<List<Student>> Get()
    {
        return await _studentRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Student> GetById(int id)
    {
        return await _studentRepository.GetById(id);
    }

    [HttpPost]
    public async Task<List<Student>> Add(Student student)
    {
        return await _studentRepository.Add(student);
    }

    [HttpDelete("{id}")]
    public async Task<List<Student>> Delete(int id)
    {
        return await _studentRepository.Delete(id);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Student> studentPatch)
    {
        var studentToUpdate = await _studentRepository.GetById(id);

        if (studentToUpdate == null)
        {
            return NotFound();
        }

        if (studentPatch != null)
        {
            studentPatch.ApplyTo(studentToUpdate, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) =>
            {
                ModelState.AddModelError(err.AffectedObject.ToString(), err.ErrorMessage);
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _studentRepository.Update(id, studentToUpdate);
            return Ok(await _studentRepository.GetAll());
        }
        else
        {
            return BadRequest("JsonPatchDocument is null");
        }
    }
}
