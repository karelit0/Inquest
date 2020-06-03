using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class QuestionOptionMap : EntityBaseMap<QuestionOption>
    {
        public QuestionOptionMap() : base("QuestionOption")
        {
            this.Property(p => p.Name);
            this.Property(p => p.Value);

            this.HasRequired<QuestionType>(p => p.QuestionType);
        }
    }
}
