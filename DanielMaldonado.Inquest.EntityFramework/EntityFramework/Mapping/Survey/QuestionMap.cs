using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class QuestionMap : EntityBaseMap<Question>
    {
        public QuestionMap() : base("Question")
        {
            this.Property(p => p.Name);
            this.Property(p => p.Note);
            this.Property(p => p.HasMultipleAnswer);

            this.HasRequired<Survey>(p => p.Survey);
            this.HasRequired<Category>(p => p.Category);
            this.HasRequired<QuestionType>(p => p.QuestionType);
        }
    }
}
