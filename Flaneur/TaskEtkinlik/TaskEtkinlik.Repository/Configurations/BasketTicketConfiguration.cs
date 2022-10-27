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
    internal class BasketTicketConfiguration : IEntityTypeConfiguration<BasketTicket>
    {
        public void Configure(EntityTypeBuilder<BasketTicket> builder)
        {
            builder.HasKey(bt => new { bt.AppUserName, bt.EventId });
        }
    }
}
