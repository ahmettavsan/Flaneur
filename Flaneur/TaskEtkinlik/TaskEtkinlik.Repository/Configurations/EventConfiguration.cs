using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Repository.Configurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Events).HasForeignKey(x => x.CategoryId);
           
        }
    }
}
