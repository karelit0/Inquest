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
    [AutoMap(typeof(City))]
    public class CityDto : FullAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual ICollection<BranchOfficeDto> BranchOfficeList { get; set; }
    }
}
