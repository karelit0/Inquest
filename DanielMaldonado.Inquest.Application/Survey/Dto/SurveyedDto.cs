using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Location.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Survey
{
    [AutoMap(typeof(Surveyed))]
    public class SurveyedDto : FullAuditedEntityDto<Guid>
    {
        public virtual BranchOfficeDto BranchOffice { get; set; }
        public virtual SurveyDto Survey { get; set; }
        public virtual PersonSurveyedDto PersonSurveyed { get; set; }

        public virtual ICollection<AnswerDto> AnswerList { get; set; }
    }
}
