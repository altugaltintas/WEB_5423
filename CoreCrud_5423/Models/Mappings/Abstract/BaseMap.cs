using CoreCrud_5423.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.Mappings.Abstract
{
    // IEntityTypeConfiguration   bu interface Mic.Efcore dan gelir. Biz ayrıyetten bir paket indirmedik zaten Mic.Efcore.Sql içine gömülü geldiği için direkt olarak bu paketi indirdik.

    // Abstract işaretlediğimiz BAsemap sınıfı içindeki CONFIGURE metodunu VIRTUAL işaretlediğimizde bu metot aynen kullanılablir yada kalıtım alan diğer sınıflar içeriğini istediği gibi kullanabilir.
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(a => a.ID);  // ID sistemin bildiği bir isim , söylemeseydik de aslında pk olduğun bilirdi ama yinede söyledik.
            builder.Property(a => a.IsActive).IsRequired();  // defaultta isrequired true kabul edilir. kolonun null geçilip geçilemeyeceğine karar veririz.true => gerekli boş bırakılmaz. false => gerekli değil , boş geçilebilir kolon.
            builder.Property(a => a.UpdatedDate).IsRequired(false);
            builder.Property(a => a.DeletedDate).IsRequired(false);
        }
    }
}
