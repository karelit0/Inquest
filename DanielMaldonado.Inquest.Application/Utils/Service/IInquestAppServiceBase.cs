using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Utils.Service
{
    public interface IInquestAppServiceBase<TEntityDto> : IApplicationService
    {
        Task<TEntityDto> Insert(TEntityDto request);
        Task<TEntityDto> Update(TEntityDto request);
        Task<TEntityDto> Delete(TEntityDto request);
    }
}
