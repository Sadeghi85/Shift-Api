// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMTV3_BroadcastTypes
    public partial class Samtv3BroadcastTypeConfiguration : IEntityTypeConfiguration<Samtv3BroadcastType>
    {
        public void Configure(EntityTypeBuilder<Samtv3BroadcastType> builder)
        {
            builder.ToTable("SAMTV3_BroadcastTypes", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMTV3_BroadcastTypes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(200)").IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.ItemOrder).HasColumnName(@"ItemOrder").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<Samtv3BroadcastType> builder);
    }

}
// </auto-generated>
