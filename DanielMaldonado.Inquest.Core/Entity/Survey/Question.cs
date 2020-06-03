using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Survey
{
    public class Question : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Note { get; set; }
        public virtual bool HasMultipleAnswer { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual Category Category { get; set; }
        public virtual QuestionType QuestionType { get; set; }
    }
}
