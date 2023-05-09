using Entitites.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitites.Concreate;

namespace DataAccess.Concreate.EntityFramework.Configurations
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.EvenetID);
            builder.Property(e=>e.Name).HasMaxLength(50);
            
            builder.HasOne<City>(c=>c.City).WithMany(e=>e.Events).HasForeignKey(fk=>fk.CityID).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Category>(c => c.Category).WithMany(e => e.Events).HasForeignKey(fk => fk.CategoryID).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(t=>t.Tickets).WithOne(e => e.Event).HasForeignKey(fk => fk.EventID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(u => u.User).WithMany(e => e.Events).HasForeignKey(fk => fk.Id).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
