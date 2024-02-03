using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjectDawAngular.Models;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentsController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [HttpGet]
    public async Task<List<Department>> Get()
    {
        return await _departmentRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Department> GetById(int id)
    {
        return await _departmentRepository.GetById(id);
    }

    [HttpPost]
    public async Task<List<Department>> Add(Department department)
    {
        return await _departmentRepository.Add(department);
    }

    [HttpDelete("{id}")]
    public async Task<List<Department>> Delete(int id)
    {
        return await _departmentRepository.Delete(id);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Department> departmentPatch)
    {
        var departmentToUpdate = await _departmentRepository.GetById(id);

        if (departmentToUpdate == null)
        {
            return NotFound();
        }

        if (departmentPatch != null)
        {
            departmentPatch.ApplyTo(departmentToUpdate, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) =>
            {
                ModelState.AddModelError(err.AffectedObject.ToString(), err.ErrorMessage);
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _departmentRepository.Update(id, departmentToUpdate);
            return Ok(await _departmentRepository.GetAll());
        }
        else
        {
            return BadRequest("JsonPatchDocument is null");
        }
    }
}
