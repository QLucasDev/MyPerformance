using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataBase;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(MyContext _myContext) : base(_myContext)
        {
            
        }

        public async Task<IEnumerable<Exercise>> GetExercises(){

                return await FindAll().ToListAsync();            
        }

        public async Task<Exercise> GetExerciseById(int id){
            return await FindByCondition(exercise => exercise.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public void CreateExercise(Exercise exercise){
            Create(exercise);
        }

        public void UpdateExercise(Exercise exercise){
            Update(exercise);
        }

        public void DeleteExercise(Exercise exercise){
            Delete(exercise);
        }
    }
}