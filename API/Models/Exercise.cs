using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Exercise
    {
        public long Id { get; set; }
        public long? TrainingId { get; set; }
        public string Name { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public virtual Training training { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}