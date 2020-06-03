using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Survey
{
    [AutoMap(typeof(Answer))]
    public class AnswerDto : FullAuditedEntityDto<Guid>
    {
        public virtual QuestionDto Question { get; set; }
        public virtual QuestionTypeDto QuestionType { get; set; }
        public virtual QuestionOptionDto QuestionOption { get; set; }
        public virtual string FreeAnswer { get; set; }
    }
}
