using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models
{
    public class Training
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DayOfWeek DayOfWeek {get; set; }
        public virtual ICollection<Exercise> Exercices {get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}