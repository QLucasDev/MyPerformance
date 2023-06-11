using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DTO
{
    public class TrainingDTO
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek {get; set; }
        public virtual ICollection<ExerciseDTO> Exercices {get; set; }
    }
}