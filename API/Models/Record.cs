using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Record
    {
        
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        public TrainingRecord TrainingRecord { get; set; }
        public User User { get; set; }
    }
}