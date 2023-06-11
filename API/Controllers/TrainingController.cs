using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using API.Models;
using API.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {

        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public TrainingController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTraining()
        {
            try{
                var training = await _repository.Training.GetTraining();
                var trainingDTO = _mapper.Map<IEnumerable<TrainingDTO>>(training);
                return Ok(trainingDTO);
            }
            catch(Exception ex){
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "TraininById")]
        public async Task<IActionResult> GetTrainingById(int id)
        {
            try{
                var training = await _repository.Training.GetTrainingById(id);

                if(training is null){
                    return NotFound();
                }
                else{
                    var trainingDTO = _mapper.Map<TrainingDTO>(training);
                    return Ok(trainingDTO);
                }
            }
            catch(Exception ex){
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTraining([FromBody]TrainingPostDTO trainingPost)
        {
            try{
                if(trainingPost is null || !ModelState.IsValid){
                return BadRequest();
                }

                var training = _mapper.Map<Training>(trainingPost);

                _repository.Training.CreateTraining(training);
                await _repository.Save();

                return CreatedAtRoute("TrainingById", training.Id, training);
            }
            catch(Exception ex){
                return StatusCode(500, ex.Message);
            }            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraining(int id, [FromBody]TrainingUpdateDTO trainingUpdate)
        {
            try{
                if(trainingUpdate is null || !ModelState.IsValid){
                    return BadRequest();
                }

                var training = await _repository.Training.GetTrainingById(id);
                if(training is null){
                    return NotFound();
                }

                _mapper.Map(trainingUpdate, training);

                _repository.Training.UpdateTraining(training);
                await _repository.Save();

                return NoContent();
            }
            catch(Exception ex){
                return StatusCode(500, ex.Message);
            }   
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            try{
                var training = await _repository.Training.GetTrainingById(id);
                if(training is null){
                    return NotFound();
                }

                _repository.Training.DeleteTraining(training);
                await _repository.Save();

                return NoContent();
            }
            catch(Exception ex){
                return StatusCode(500, ex.Message);
            }
        }
    }
}