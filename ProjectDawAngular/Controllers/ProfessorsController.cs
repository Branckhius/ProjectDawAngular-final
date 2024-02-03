using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjectDawAngular.Models;
namespace ProjectDawAngular.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorsController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public async Task<List<Professor>> Get()
        {
            return await _professorRepository.GetAll();
        }



        [HttpPost]
        public async Task<List<Professor>> Add(Professor professor)
        {
            return await _professorRepository.Add(professor);
        }

        [HttpDelete("{id}")]
        public async Task<List<Professor>> Delete(int id)
        {
            return await _professorRepository.Delete(id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Professor> professorPatch)
        {
            var professorToUpdate = await _professorRepository.GetById(id);

            if (professorToUpdate == null)
            {
                return NotFound();
            }

            if (professorPatch != null)
            {
                professorPatch.ApplyTo(professorToUpdate);

                if (!TryValidateModel(professorToUpdate))
                {
                    return BadRequest(ModelState);
                }

                await _professorRepository.Update(id, professorToUpdate);
                return Ok(await _professorRepository.GetAll());
            }
            else
            {
                return BadRequest("JsonPatchDocument is null");
            }
        }


    }
}