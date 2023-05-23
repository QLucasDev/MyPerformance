using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models
{
    public class TrainingRecord
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek {get; set; }
        public virtual ICollection<ExerciseRecord> Exercices {get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}