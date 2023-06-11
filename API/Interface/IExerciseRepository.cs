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
        Task<Exercise> GetExerciseById(int id);
        void CreateExercise(Exercise exercise);
        void UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);

    }
}