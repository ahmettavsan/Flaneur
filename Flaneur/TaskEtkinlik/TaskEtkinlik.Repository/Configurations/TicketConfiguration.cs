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
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.HasOne(x => x.Event).WithMany(x => x.Ticket).HasForeignKey(x => x.EventId);
        }
    }
}
