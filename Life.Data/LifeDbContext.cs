using Life.Core.Domain.Exercise;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Data
{
    public class LifeDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseInfo> ExercisesInfo { get; set; }

        public LifeDbContext(DbContextOptions<LifeDbContext> options) : base(options)
        {
        }
    }
}

