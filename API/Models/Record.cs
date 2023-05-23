using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Record
    {
        
        public int Id { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        public TrainingRecord TrainingRecord { get; set; }
    }
}