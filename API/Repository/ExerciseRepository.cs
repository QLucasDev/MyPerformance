using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using API.Models;
using API.DataBase;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly MyContext _myContext;
        public ExerciseRepository(MyContext context)
        {
            _myContext = context;
        }

        public void AddExercise(Exercise exercise)
        {
            try {
                _myContext.Exercises.Add(exercise);
                _myContext.SaveChanges();
            }
            catch {
                throw new Exception("Não foi possivel adicionar exercicio");
            }
        }

        public Exercise DeleteExercise(int Id)
        {
            try {
                Exercise exercise = _myContext.Exercises.Find(Id);

                if(exercise != null)
                {
                    _myContext.Exercises.Remove(exercise);
                    _myContext.SaveChanges();
                    return exercise;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch {
                throw new Exception("Exercicio não encontrado");
            }
        }

        public List<Exercise> GetExercises()
        {
            try {
               return _myContext.Exercises.ToList();
            }
            catch {
                throw new Exception("Exercicios não encontrados");
            }
        }

        public Exercise GetExercises(int Id)
        {
            try {
                Exercise exercise = _myContext.Exercises.Find(Id);
                if(exercise != null)
                {
                    return exercise;
                }
                else 
                {
                    throw new ArgumentNullException();
                }
            }
            catch {
                throw new Exception("Exercicio não existe");
            }
        }

        public void UpdateExercise(Exercise exercise)
        {
            try {
                _myContext.Entry(exercise).State = EntityState.Modified;
                _myContext.SaveChanges();
            }
            catch {
                throw new ArgumentNullException();
            }
        }

        public bool CheckExercise(int id)
        {
            return _myContext.Exercises.Any(a => a.Id == id);
        }
    }
}