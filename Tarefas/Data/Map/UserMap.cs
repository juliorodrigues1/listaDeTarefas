using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Models;

namespace Tarefas.Data.Map;

public class UserMap : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(x => x.name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.email).IsRequired().HasMaxLength(150);
    }
}