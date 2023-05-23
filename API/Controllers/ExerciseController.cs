using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRespository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRespository = exerciseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> Get()
        {
            return await Task.FromResult(_exerciseRespository.GetExercises());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetWithId(int id){
            return await Task.FromResult(_exerciseRespository.GetExercises(id));
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> Post([FromBody] Exercise exercise)
        {
            _exerciseRespository.AddExercise(exercise);
            return await Task.FromResult(exercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Exercise>> Put(int id, [FromBody] Exercise exercise)
        {
            if(id != exercise.Id)
            {
                return BadRequest();
            }

            try {
                _exerciseRespository.UpdateExercise(exercise);
            }
            catch(DbUpdateConcurrencyException){

                if(!ExerciseExists(id))
                {
                    return NotFound();
                }
                else 
                {
                    throw;
                }
            }

            return await Task.FromResult(exercise);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Exercise>> Delete(int id)
        {
            Exercise exercise = _exerciseRespository.DeleteExercise(id);
            return await Task.FromResult(exercise);
        }

        [NonAction]
        private bool ExerciseExists(int id)
        {
            return _exerciseRespository.CheckExercise(id);
        }
    }
}