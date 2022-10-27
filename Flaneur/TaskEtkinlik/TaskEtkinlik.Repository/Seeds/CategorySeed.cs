using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Models;

namespace TaskEtkinlik.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category { Id = 1, Name = "Tiyatro", IsDeleted = false },
                new Category { Id = 2, Name = "Sinema", IsDeleted = false },
                new Category { Id = 3, Name = "Müzik", IsDeleted = false },
                new Category { Id = 4, Name = "Spor", IsDeleted = false });
        }
    }
}
