using CoreCrud_5423.Models.Concrete;
using CoreCrud_5423.Models.Mappings.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.Mappings.Concrete
{
    public class MovieMap : BaseMap<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.HasOne(a => a.Director).WithMany(a => a.Movies).HasForeignKey(a => a.DirectorId);
            base.Configure(builder);
        }
    }
}
