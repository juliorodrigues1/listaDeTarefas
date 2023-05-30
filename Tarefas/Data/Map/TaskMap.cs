using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Models;

namespace Tarefas.Data.Map;

public class TaskMap : IEntityTypeConfiguration<TaskModel>
{
    public void Configure(EntityTypeBuilder<TaskModel> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(x => x.name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.description).HasMaxLength(1000);
        builder.Property(x => x.status).IsRequired();
        builder.Property(x => x.userId);

        builder.HasOne(x => x.user);
    }
}