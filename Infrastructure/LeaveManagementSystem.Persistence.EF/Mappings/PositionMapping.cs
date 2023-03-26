using LeaveManagementSystem.Domain.Models.Departments;
using LeaveManagementSystem.Domain.Models.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Persistence.EF.Mappings
{
    public class PositionMapping : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Title).IsRequired();
            builder.Property(d => d.DepartmentName).IsRequired();
            builder.Property(d => d.DepartmentId).IsRequired();
            builder.Property(d => d.IsDeleted).IsRequired();
            builder.Property(d => d.IsActive).IsRequired();
            builder.Property(d => d.CreateDateTime).IsRequired();
            builder.Property(d => d.LastEditDateTime);
            builder.Property(d => d.UserId).IsRequired();
        }
    }
}