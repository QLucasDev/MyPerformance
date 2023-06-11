using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DTO
{
    public class ExerciseUpdateDTO
    {
        public int? TrainingId { get; set; }
        public string Name { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public DateTime UpdatedAt { get; private set; }

        public ExerciseUpdateDTO()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}