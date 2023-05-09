using Entitites.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework.Configurations
{
    public class CategoryMapping: IEntityTypeConfiguration<City>
    {
       
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CityID);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
    

        }
    }
}
