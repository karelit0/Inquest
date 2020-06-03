using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Survey
{
    public class Answer : FullAuditedEntity<Guid>
    {
        public virtual Surveyed Surveyed { get; set; }
        public virtual Question Question { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }
        public virtual string FreeAnswer { get; set; }
    }
}
