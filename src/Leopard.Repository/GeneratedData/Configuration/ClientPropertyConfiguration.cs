// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // ClientProperties
    public partial class ClientPropertyConfiguration : IEntityTypeConfiguration<ClientProperty>
    {
        public void Configure(EntityTypeBuilder<ClientProperty> builder)
        {
            builder.ToTable("ClientProperties", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ClientProperties").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ClientId).HasColumnName(@"ClientId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Key).HasColumnName(@"Key").HasColumnType("nvarchar(250)").IsRequired().HasMaxLength(250);
            builder.Property(x => x.Value).HasColumnName(@"Value").HasColumnType("nvarchar(2000)").IsRequired().HasMaxLength(2000);

            // Foreign keys
            builder.HasOne(a => a.Client).WithMany(b => b.ClientProperties).HasForeignKey(c => c.ClientId).HasConstraintName("FK_ClientProperties_Clients_ClientId");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<ClientProperty> builder);
    }

}
// </auto-generated>