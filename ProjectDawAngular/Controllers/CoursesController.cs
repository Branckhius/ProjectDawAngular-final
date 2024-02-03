using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDawAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> Get()
        {
            return await _courseRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await _courseRepository.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPost]
        public async Task<ActionResult<List<Course>>> Add(Course course)
        {
            return await _courseRepository.Add(course);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Course>>> Delete(int id)
        {
            return await _courseRepository.Delete(id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Course> coursePatch)
        {
            var courseToUpdate = await _courseRepository.GetById(id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (coursePatch != null)
            {
                coursePatch.ApplyTo(courseToUpdate, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) =>
                {
                    ModelState.AddModelError(err.AffectedObject.ToString(), err.ErrorMessage);
                });

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _courseRepository.Update(id, courseToUpdate);
                return Ok(await _courseRepository.GetAll());
            }
            else
            {
                return BadRequest("JsonPatchDocument is null");
            }
        }

    }
}
