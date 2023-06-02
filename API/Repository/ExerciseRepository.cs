using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataBase;
using API.Interface;
using API.Models;

namespace API.Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExercise
    {
        public ExerciseRepository(MyContext _myContext) : base(_myContext)
        {
        }
    }
}