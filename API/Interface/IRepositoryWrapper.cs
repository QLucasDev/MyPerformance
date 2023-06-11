using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interface
{
    public interface IRepositoryWrapper
    {
        IExerciseRepository Exercise{ get;}
        ITrainingRepository Training{ get;}
        Task Save();
    }
}