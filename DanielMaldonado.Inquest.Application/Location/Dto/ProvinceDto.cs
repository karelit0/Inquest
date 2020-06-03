using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Location.Dto
{
    [AutoMap(typeof(Province))]
    public class ProvinceDto : FullAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual ICollection<CityDto> CityList { get; set; }
    }
}
