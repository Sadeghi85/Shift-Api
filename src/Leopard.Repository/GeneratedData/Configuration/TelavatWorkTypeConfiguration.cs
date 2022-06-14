// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // TelavatWorkTypes
    public partial class TelavatWorkTypeConfiguration : IEntityTypeConfiguration<TelavatWorkType>
    {
        public void Configure(EntityTypeBuilder<TelavatWorkType> builder)
        {
            builder.ToTable("TelavatWorkTypes", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatWorkTypes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PortalId).HasColumnName(@"PortalID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Ordering).HasColumnName(@"Ordering").HasColumnType("int").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<TelavatWorkType> builder);
    }

}
// </auto-generated>