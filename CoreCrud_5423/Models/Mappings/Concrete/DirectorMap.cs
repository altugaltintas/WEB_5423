using CoreCrud_5423.Models.Concrete;
using CoreCrud_5423.Models.Mappings.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.Mappings.Concrete
{
    public class DirectorMap : BaseMap<Director>
    {
        public override void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.Property(a=>a.FirtsName).IsRequired();
            // builder.Property(a => a.FirtsName).IsRequired().HasColumnName("AD").HasMaxLength(30);
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.BirthDate).IsRequired(true);
            base.Configure(builder);
        }
    }
}
