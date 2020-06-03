using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Survey;
using DanielMaldonado.Inquest.EntityFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class AnswerMap : EntityBaseMap<Answer>
    {
        public AnswerMap() : base("Answer")
        {
            this.Property(p => p.FreeAnswer);

            this.HasRequired<Surveyed>(p => p.Surveyed);
            this.HasRequired<Question>(p => p.Question);
            this.HasRequired<QuestionType>(p => p.QuestionType);
            this.HasRequired<QuestionOption>(p => p.QuestionOption);
        }
    }
}
