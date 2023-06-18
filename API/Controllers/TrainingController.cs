using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using API.Models;
using API.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {

        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;

        public TrainingController(IRepositoryWrapper repository, IMapper mapper, IJwtProvider jwtProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllTraining()
        {
            try
            {
                var training = await _repository.Training.GetTraining();
                var trainingDTO = _mapper.Map<IEnumerable<TrainingDTO>>(training);
                return Ok(trainingDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetUserTraining()
        {
            try
            {
                string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                string userId = _jwtProvider.GetUserIdFromToken(token);

                var training = await _repository.Training.GetUserTraining(long.Parse(userId));
                var trainingDTO = _mapper.Map<IEnumerable<TrainingDTO>>(training);
                return Ok(trainingDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}", Name = "TraininById"), Authorize]
        public async Task<IActionResult> GetTrainingById(long id)
        {
            try
            {
                var training = await _repository.Training.GetTrainingById(id);

                if (training is null)
                {
                    return NotFound();
                }
                else
                {
                    var trainingDTO = _mapper.Map<TrainingDTO>(training);
                    return Ok(trainingDTO);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreateTraining([FromBody] TrainingPostDTO trainingPost)
        {
            try
            {
                if (trainingPost is null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var training = _mapper.Map<Training>(trainingPost);

                _repository.Training.CreateTraining(training);
                await _repository.Save();

                return CreatedAtRoute("TrainingById", training.Id, training);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateTraining(long id, [FromBody] TrainingUpdateDTO trainingUpdate)
        {
            try
            {
                if (trainingUpdate is null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var training = await _repository.Training.GetTrainingById(id);
                if (training is null)
                {
                    return NotFound();
                }

                _mapper.Map(trainingUpdate, training);

                _repository.Training.UpdateTraining(training);
                await _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> DeleteTraining(long id)
        {
            try
            {
                var training = await _repository.Training.GetTrainingById(id);
                if (training is null)
                {
                    return NotFound();
                }

                _repository.Training.DeleteTraining(training);
                await _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}