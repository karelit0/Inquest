using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanielMaldonado.Inquest.Utils.Enums.Dto;

namespace DanielMaldonado.Inquest.Utils.Enums
{
    public interface IEnumService : IApplicationService
    {
        IList<EnumDto> GetEnumList(string request);
    }
}
