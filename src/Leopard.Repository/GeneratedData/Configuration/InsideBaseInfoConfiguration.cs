// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // InsideBaseInfo
    public partial class InsideBaseInfoConfiguration : IEntityTypeConfiguration<InsideBaseInfo>
    {
        public void Configure(EntityTypeBuilder<InsideBaseInfo> builder)
        {
            builder.ToTable("InsideBaseInfo", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_InsideBaseInfo").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Type).HasColumnName(@"Type").HasColumnType("int").IsRequired();
            builder.Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Parent).WithMany(b => b.InsideBaseInfoes).HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InsideBaseInfo_InsideBaseInfo");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<InsideBaseInfo> builder);
    }

}
// </auto-generated>
