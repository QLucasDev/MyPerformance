using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;


namespace API.Interface
{
    public interface IExerciseRepository
    {
        public List<Exercise> GetExercises();
        public Exercise GetExercises(int Id);
        public void AddExercise(Exercise exercise);
        public void UpdateExercise(Exercise exercise);
        public Exercise DeleteExercise(int Id);
        public bool CheckExercise(int id);
    }
}