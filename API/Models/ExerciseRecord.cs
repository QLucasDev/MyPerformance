using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ExerciseRecord
    {
        public long Id { get; set; }
        public long TrainingId { get; set; }
        public string Name { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public bool IsDone { get; set; }
        public TrainingRecord training { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
    }
}