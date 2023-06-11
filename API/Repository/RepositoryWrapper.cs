using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataBase;
using API.Interface;

namespace API.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MyContext _context;
        private ExerciseRepository _exercise;
        private TrainingRepository _training;

        public IExerciseRepository Exercise {
            get{
                if(_exercise == null)
                {
                  _exercise = new ExerciseRepository(_context);
                }
                return _exercise;
            }
        }

        public ITrainingRepository Training {
            get{
                if(_training == null)
                {
                    _training = new TrainingRepository(_context);
                }
                return _training;
            }
            
        }

        public RepositoryWrapper(MyContext myContext)
        {
            _context = myContext;
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}