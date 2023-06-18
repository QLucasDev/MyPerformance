using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Exercise")]
    public class ExerciseController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;

        public ExerciseController(IRepositoryWrapper repository, IMapper mapper, IJwtProvider jwtProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
        }

        [HttpGet("All"), Authorize]
        public async Task<IActionResult> GetExercises()
        {
            try
            {
                var exercises = await _repository.Exercise.GetExercises();
                var exercisesDTO = _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);
                return Ok(exercisesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("User"), Authorize]
        public async Task<IActionResult> GetUserExercises()
        {
            try
            {
                string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                string userId = _jwtProvider.GetUserIdFromToken(token);

                var exercises = await _repository.Exercise.GetUserExercises(long.Parse(userId));
                var exercisesDTO = _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);
                return Ok(exercisesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "ExerciseById"), Authorize]
        public async Task<IActionResult> GetExerciseById(long id)
        {
            try
            {
                var exercise = await _repository.Exercise.GetExerciseById(id);
                if (exercise == null)
                {
                    return NotFound();
                }
                else
                {
                    var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
                    return Ok(exerciseDTO);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreateExercise([FromBody] ExercisePostDTO exercisePost)
        {
            try
            {
                if (exercisePost is null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var exercise = _mapper.Map<Exercise>(exercisePost);

                _repository.Exercise.CreateExercise(exercise);
                await _repository.Save();

                var createdExercise = _mapper.Map<ExerciseDTO>(exercise);

                return CreatedAtRoute("ExerciseById", exercise.Id, exercise);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateExecise(long id, [FromBody] ExerciseUpdateDTO exerciseUpdate)
        {
            try
            {
                if (exerciseUpdate is null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var exercise = await _repository.Exercise.GetExerciseById(id);
                if (exercise is null)
                {
                    return NotFound();
                }

                _mapper.Map(exerciseUpdate, exercise);

                _repository.Exercise.UpdateExercise(exercise);
                await _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> DeleteExercise(long id)
        {
            try
            {
                var exercise = await _repository.Exercise.GetExerciseById(id);
                if (exercise is null)
                {
                    return NotFound();
                }

                _repository.Exercise.DeleteExercise(exercise);
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