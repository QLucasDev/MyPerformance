using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.DataBase
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<ExerciseRecord> ExerciseRecords { get; set; }
        public DbSet<TrainingRecord> TrainingRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){

            builder.Entity<Exercise>().HasKey(a => a.Id);
            builder.Entity<Exercise>().Property(a => a.Name).IsRequired();
            builder.Entity<Exercise>().Property(a => a.Series).IsRequired();
            builder.Entity<Exercise>().Property(a => a.Repetitions).IsRequired();
            builder.Entity<Exercise>().HasOne(a => a.training).WithMany(a => a.Exercices).HasForeignKey(a => a.TrainingId);
            builder.Entity<Exercise>().Ignore(a => a.training);
        
            builder.Entity<Training>().HasKey(a => a.Id);
            builder.Entity<Training>().Property(a => a.DayOfWeek).IsRequired();
            builder.Entity<Training>().Property(a => a.Exercices).IsRequired();
            builder.Entity<Training>().Ignore(a => a.Exercices);

            builder.Entity<Record>().HasKey(a => a.Id);
            builder.Entity<Record>().HasOne(a => a.TrainingRecord);

            builder.Entity<ExerciseRecord>().HasKey(a => a.Id);
            builder.Entity<ExerciseRecord>().Property(a => a.Name).IsRequired();
            builder.Entity<ExerciseRecord>().Property(a => a.Series).IsRequired();
            builder.Entity<ExerciseRecord>().Property(a => a.Repetitions).IsRequired();
            builder.Entity<ExerciseRecord>().HasOne(a => a.training).WithMany(a => a.Exercices).HasForeignKey(a => a.TrainingId);
            builder.Entity<ExerciseRecord>().Ignore(a => a.training);
        
            builder.Entity<TrainingRecord>().HasKey(a => a.Id);
            builder.Entity<TrainingRecord>().Property(a => a.DayOfWeek).IsRequired();
            builder.Entity<TrainingRecord>().Property(a => a.Exercices).IsRequired();
            builder.Entity<TrainingRecord>().Ignore(a => a.Exercices);
            
        }
    }
}