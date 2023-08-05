using CoreCrud_5423.Models.Concrete;
using CoreCrud_5423.Models.Mappings.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options): base(options) { }

        public DbSet<Movie>  Movies { get; set; }

        public DbSet<Director>  Directors { get; set; }

        public DbSet<Actor>  Actors { get; set; }

        public DbSet<MovieActor>  MovieActors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DirectorMap());
            modelBuilder.ApplyConfiguration(new MovieActorMap());
            modelBuilder.ApplyConfiguration(new MovieMap());

            base.OnModelCreating(modelBuilder);
        }





    }
}
