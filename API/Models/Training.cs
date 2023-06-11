using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models
{
    public class Training
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek {get; set; }
        public virtual ICollection<Exercise> Exercices {get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}