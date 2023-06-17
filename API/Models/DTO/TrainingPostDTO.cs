using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DTO
{
    public class TrainingPostDTO
    {
        public DayOfWeek DayOfWeek {get; set; }
        public virtual ICollection<Exercise> Exercices {get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; } 

        public TrainingPostDTO()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}