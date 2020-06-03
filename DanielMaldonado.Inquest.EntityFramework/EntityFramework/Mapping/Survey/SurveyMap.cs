using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class SurveyMap : EntityBaseMap<Survey>
    {
        public SurveyMap() : base("Survey")
        {
            this.Property(p => p.Name);

            this.HasMany<Question>(p => p.QuestionList);
        }
    }
}
