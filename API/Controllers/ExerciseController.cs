using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public ExerciseController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Exercise>> GetExercises()
        {
            var exercises = _repository.Exercise.FindAll();
            return Ok(exercises);
        }
    }
}