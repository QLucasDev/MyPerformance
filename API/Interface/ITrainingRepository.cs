using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interface
{
    public interface ITrainingRepository
    {
        public List<Training> GetTraining();
        public Training GetTraining(int Id);
        public void AddTraining(Training training);
        public void UpdateTraining(Training training);
        public Training DeleteTraining(int Id);
        public bool CheckTraining(int id);

    }
}