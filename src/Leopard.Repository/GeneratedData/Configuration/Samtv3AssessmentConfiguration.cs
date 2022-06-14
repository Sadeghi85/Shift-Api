// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMTV3_Assessment
    public partial class Samtv3AssessmentConfiguration : IEntityTypeConfiguration<Samtv3Assessment>
    {
        public void Configure(EntityTypeBuilder<Samtv3Assessment> builder)
        {
            builder.ToTable("SAMTV3_Assessment", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMTV3_Assessment").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.RequestId).HasColumnName(@"RequestId").HasColumnType("int").IsRequired();
            builder.Property(x => x.EpisodeCount).HasColumnName(@"EpisodeCount").HasColumnType("int").IsRequired();
            builder.Property(x => x.DateFrom).HasColumnName(@"DateFrom").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.DateTo).HasColumnName(@"DateTo").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.PlayTime).HasColumnName(@"PlayTime").HasColumnType("nvarchar(5)").IsRequired().HasMaxLength(5);
            builder.Property(x => x.EpisodeTime).HasColumnName(@"EpisodeTime").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProgramIntro).HasColumnName(@"ProgramIntro").HasColumnType("nvarchar(4000)").IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.Conclusion).HasColumnName(@"Conclusion").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreateDateTime).HasColumnName(@"CreateDateTime").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasColumnName(@"ModifiedBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).HasColumnName(@"LastModifiedDateTime").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.SamtRequest).WithMany(b => b.Samtv3Assessment).HasForeignKey(c => c.RequestId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SAMTV3_Assessment_SAMTV3_Assessment");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<Samtv3Assessment> builder);
    }

}
// </auto-generated>