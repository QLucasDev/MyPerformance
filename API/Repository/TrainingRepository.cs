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
    public class TrainingRepository : ITrainingRepository
    {
        private readonly MyContext _myContext;
        public TrainingRepository(MyContext context)
        {
            _myContext = context;
        }

        public void AddTraining(Training training)
        {
            try {
                _myContext.Training.Add(training);
                _myContext.SaveChanges();
            }
            catch {
                throw new Exception("Não foi possivel adicionar traino");
            }
        }

        public Training DeleteTraining(int Id)
        {
            try {
                Training training = _myContext.Training.Find(Id);

                if(training != null)
                {
                    _myContext.Training.Remove(training);
                    _myContext.SaveChanges();
                    return training;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch {
                throw new Exception("Treino não encontrado");
            }
        }

        public List<Training> GetTraining()
        {
            try {
               return _myContext.Training.ToList();
            }
            catch {
                throw new Exception("Treino não encontrados");
            }
        }

        public Training GetTraining(int Id)
        {
            try {
                Training training = _myContext.Training.Find(Id);
                if(training != null)
                {
                    return training;
                }
                else 
                {
                    throw new ArgumentNullException();
                }
            }
            catch {
                throw new Exception("Treino não existe");
            }
        }

        public void UpdateTraining(Training training)
        {
            try {
                _myContext.Entry(training).State = EntityState.Modified;
                _myContext.SaveChanges();
            }
            catch {
                throw new ArgumentNullException();
            }
        }

        public bool CheckTraining(int id)
        {
            return _myContext.Training.Any(a => a.Id == id);
        }
    }
}