using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Location.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Location
{
    [AutoMap(typeof(Country))]
    public class CountryDto : FullAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual ICollection<ProvinceDto> ProvinceList { get; set; }
    }
}
