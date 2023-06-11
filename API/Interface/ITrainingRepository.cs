using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interface
{
    public interface ITrainingRepository : IRepositoryBase<Training>
    {
        Task<IEnumerable<Training>> GetTraining();
        Task<Training> GetTrainingById(int id);
        void CreateTraining(Training training);
        void UpdateTraining(Training training);
        void DeleteTraining(Training training);
    }
}