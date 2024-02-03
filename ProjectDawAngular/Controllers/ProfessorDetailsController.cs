using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjectDawAngular.Models;

[Route("api/[controller]")]
[ApiController]
public class ProfessorDetailsController : ControllerBase
{
    private readonly IProfessorDetailsRepository _professorDetailsRepository;

    public ProfessorDetailsController(IProfessorDetailsRepository professorDetailsRepository)
    {
        _professorDetailsRepository = professorDetailsRepository;
    }

    [HttpGet]
    public async Task<List<ProfessorDetails>> Get()
    {
        return await _professorDetailsRepository.GetAll();
    }

    [HttpGet("{professorId}")]
    public async Task<ProfessorDetails> GetById(int professorId)
    {
        return await _professorDetailsRepository.GetById(professorId);
    }

    [HttpPost]
    public async Task<List<ProfessorDetails>> Add(ProfessorDetails professorDetails)
    {
        return await _professorDetailsRepository.Add(professorDetails);
    }

    [HttpDelete("{professorId}")]
    public async Task<List<ProfessorDetails>> Delete(int professorId)
    {
        return await _professorDetailsRepository.Delete(professorId);
    }

    [HttpPatch("{professorId}")]
    public async Task<IActionResult> Patch(int professorId, [FromBody] JsonPatchDocument<ProfessorDetails> professorDetailsPatch)
    {
        var professorDetailsToUpdate = await _professorDetailsRepository.GetById(professorId);

        if (professorDetailsToUpdate == null)
        {
            return NotFound();
        }

        if (professorDetailsPatch != null)
        {
            professorDetailsPatch.ApplyTo(professorDetailsToUpdate, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) =>
            {
                ModelState.AddModelError(err.AffectedObject.ToString(), err.ErrorMessage);
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _professorDetailsRepository.Update(professorId, professorDetailsToUpdate);
            return Ok(await _professorDetailsRepository.GetAll());
        }
        else
        {
            return BadRequest("JsonPatchDocument is null");
        }
    }
}
