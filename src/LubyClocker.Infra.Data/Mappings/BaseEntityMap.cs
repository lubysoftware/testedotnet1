using LubyClocker.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubyClocker.Infra.Data.Mappings
{
    public abstract class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder
                .Property(c => c.CreatedAt);
            
            ConfigureMap(builder);
        }

        protected abstract void ConfigureMap(EntityTypeBuilder<T> builder);
    }
}