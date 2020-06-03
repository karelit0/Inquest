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
    [AutoMap(typeof(PersonSurveyed))]
    public class PersonSurveyedDto : FullAuditedEntityDto<Guid>
    {
        public virtual string Cedula { get; set; }
        public virtual string Name { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Age { get; set; }
    }
}
