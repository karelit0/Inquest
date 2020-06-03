using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public abstract class EntityBaseMap<TEntity> : EntityTypeConfiguration<TEntity>
         where TEntity : FullAuditedEntity<Guid>
    {
        public EntityBaseMap(string toTable)
        {
            this.ToTable(toTable);

            this.HasKey<Guid>(s => s.Id);

            this.Property(p => p.CreatorUserId).IsRequired();
            this.Property(p => p.CreationTime).IsRequired();
            this.Property(p => p.IsDeleted).IsRequired();

            this.Property(p => p.DeleterUserId).IsOptional();
            this.Property(p => p.DeletionTime).IsOptional();

            this.Property(p => p.LastModificationTime).IsOptional();
            this.Property(p => p.LastModifierUserId).IsOptional();
        }
    }
}
