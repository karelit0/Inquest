using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class QuestionTypeMap : EntityBaseMap<QuestionType>
    {
        public QuestionTypeMap() : base("QuestionType")
        {
            this.Property(p => p.Name);

            this.HasMany<QuestionOption>(p => p.QuestionOptionList);
            this.HasMany<Question>(p => p.QuestionList);
        }
    }
}
