using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class CategoryMap : EntityBaseMap<Category>
    {
        public CategoryMap() : base("Category")
        {
            this.Property(p => p.Name);
            this.HasMany<Question>(p => p.QuestionList);
        }
    }
}
