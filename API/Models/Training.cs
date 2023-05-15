using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Training
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek {get; set;}
        public List<Exercise> Exercices {get; set;}
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}