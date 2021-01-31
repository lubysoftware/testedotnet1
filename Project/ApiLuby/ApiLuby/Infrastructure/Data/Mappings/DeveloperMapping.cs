using ApiLuby.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiLuby.Infrastructure.Data.Mappings
{
    public class DeveloperMapping : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("TB_DEVELOPER");
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();
            //builder.HasOne(p => p.TotalHours).WithMany().HasForeignKey(foreignKeyExpression => foreignKeyExpression.TotalHours); //COLOQUEI ISSO NA ULTIMA AULA, ACREDITO QUE PRECISE COLOCAR AQUI N OBANCO QUE TEM O TOTAL HOURS DO BANCO, PRA MOSTRAR NO GET
           // builder.Property(p => p.TotalHours);
            builder.Property(p => p.Login);
            builder.Property(p => p.Password);
            builder.Property(p => p.Email);
            
        }
    }
}
