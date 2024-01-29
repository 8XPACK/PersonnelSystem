using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ChildDepartments)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId);

            builder.Property(x => x.ParentId)
                .IsRequired(false);

        }
    }
}
