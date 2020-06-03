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
    [AutoMap(typeof(Survey))]
    public class SurveyDto : FullAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual ICollection<QuestionDto> QuestionList { get; set; }
    }
}
