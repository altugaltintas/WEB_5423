using CoreCrud_5423.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.Mappings.Concrete
{
    public class MovieActorMap : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(a=> new {a.ActorId,a.MovieId});   // ikisi de primary key 

            builder.HasOne(a => a.Movie).WithMany(a => a.MovieActors).HasForeignKey(a => a.MovieId);

            builder.HasOne(a => a.Actor).WithMany(a => a.MovieActors).HasForeignKey(a => a.ActorId);

        }
    }
}
