using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ExerciseRecord
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public string Name { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public bool IsDone { get; set; }
        public TrainingRecord training { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
    }
}