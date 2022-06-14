// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMTV2_PlanTopics
    public partial class Samtv2PlanTopicConfiguration : IEntityTypeConfiguration<Samtv2PlanTopic>
    {
        public void Configure(EntityTypeBuilder<Samtv2PlanTopic> builder)
        {
            builder.ToTable("SAMTV2_PlanTopics", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMTV2_PlanTopics").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.ParentId).HasColumnName(@"ParentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Grade).HasColumnName(@"Grade").HasColumnType("int").IsRequired();
            builder.Property(x => x.OrderId).HasColumnName(@"OrderID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.TimeId).HasColumnName(@"TimeID").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreateBy).HasColumnName(@"CreateBy").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ModifyBy).HasColumnName(@"ModifyBy").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ModifyDate).HasColumnName(@"ModifyDate").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.FetchDate).HasColumnName(@"FetchDate").HasColumnType("datetime").IsRequired();

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<Samtv2PlanTopic> builder);
    }

}
// </auto-generated>