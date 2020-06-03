using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Utils.Pagination
{
    public interface IEntityPagedService<TEntityDto> : IApplicationService
    {
        EntityPagedDto<TEntityDto> GetEntityPaged(EntityPagedRequestDto<TEntityDto> request);
    }
}
