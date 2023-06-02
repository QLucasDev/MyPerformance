using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interface
{
    public interface IRepositoryWrapper
    {
        IExercise Exercise{ get;}
        ITraining Training{ get;}
        void Save();
    }
}