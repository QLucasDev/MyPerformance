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
    public class TrainingRepository : RepositoryBase<Training>, ITrainingRepository
    {
        public TrainingRepository(MyContext _myContext) : base(_myContext)
        {
        }

        public async Task<IEnumerable<Training>> GetTraining()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Training>> GetUserTraining(long id)
        {
            return await FindByCondition(training => training.UserId.Equals(id)).ToListAsync();
        }

        public async Task<Training> GetTrainingById(long id)
        {
            return await FindByCondition(training => training.Id.Equals(id)).Include(x => x.Exercices).FirstOrDefaultAsync();
        }

        public void CreateTraining(Training training)
        {
            Create(training);
        }

        public void UpdateTraining(Training training)
        {
            Update(training);
        }

        public void DeleteTraining(Training training)
        {
            Delete(training);
        }
    }
}