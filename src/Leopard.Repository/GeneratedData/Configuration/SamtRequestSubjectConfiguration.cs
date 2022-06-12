// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_RequestSubjects
    public partial class SamtRequestSubjectConfiguration : IEntityTypeConfiguration<SamtRequestSubject>
    {
        public void Configure(EntityTypeBuilder<SamtRequestSubject> builder)
        {
            builder.ToTable("SAMT_RequestSubjects", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatRequestSubjects").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.RequestId).HasColumnName(@"RequestID").HasColumnType("int").IsRequired();
            builder.Property(x => x.SubjectId).HasColumnName(@"SubjectID").HasColumnType("int").IsRequired();
            builder.Property(x => x.SubjectPercent).HasColumnName(@"SubjectPercent").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.SamtRequest).WithMany(b => b.SamtRequestSubjects).HasForeignKey(c => c.RequestId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TelavatRequestSubjects_SAMT_Requests");
            builder.HasOne(a => a.SamtSubject).WithMany(b => b.SamtRequestSubjects).HasForeignKey(c => c.SubjectId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TelavatRequestSubjects_TelavatSubjects");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtRequestSubject> builder);
    }

}
// </auto-generated>
