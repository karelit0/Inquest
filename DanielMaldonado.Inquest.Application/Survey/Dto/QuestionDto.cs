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
    [AutoMap(typeof(Question))]
    public class QuestionDto : FullAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Note { get; set; }

        public virtual CategoryDto Category { get; set; }
        public virtual QuestionTypeDto QuestionType { get; set; }
    }
}
