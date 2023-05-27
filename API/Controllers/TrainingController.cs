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
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingController(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> Get()
        {
            return await Task.FromResult(_trainingRepository.GetTraining());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetWithId(int id){
            return await Task.FromResult(_trainingRepository.GetTraining(id));
        }

        [HttpPost]
        public async Task<ActionResult<Training>> Post([FromBody] Training training)
        {
            _trainingRepository.AddTraining(training);
            return await Task.FromResult(training);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Training>> Put(int id, [FromBody] Training training)
        {
            if(id != training.Id)
            {
                return BadRequest();
            }

            try {
                _trainingRepository.UpdateTraining(training);
            }
            catch(DbUpdateConcurrencyException){

                if(!TrainingExists(id))
                {
                    return NotFound();
                }
                else 
                {
                    throw;
                }
            }

            return await Task.FromResult(training);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Training>> Delete(int id)
        {
            Training training = _trainingRepository.DeleteTraining(id);
            return await Task.FromResult(training);
        }

        [NonAction]
        private bool TrainingExists(int id)
        {
            return _trainingRepository.CheckTraining(id);
        }
    }
}