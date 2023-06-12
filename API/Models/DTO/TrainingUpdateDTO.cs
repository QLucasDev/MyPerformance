using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DTO
{
    public class TrainingUpdateDTO
    {
        public long Id { get; set; }
        public DayOfWeek DayOfWeek {get; set; }
        public virtual ICollection<Exercise> Exercices {get; set; }
        public DateTime UpdatedAt { get; set; }

        public TrainingUpdateDTO()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}