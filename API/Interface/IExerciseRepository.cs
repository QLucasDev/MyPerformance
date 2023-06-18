using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interface
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        Task<IEnumerable<Exercise>> GetExercises();
        Task<IEnumerable<Exercise>> GetUserExercises(long id);
        Task<Exercise> GetExerciseById(long id);
        void CreateExercise(Exercise exercise);
        void UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);

    }
}