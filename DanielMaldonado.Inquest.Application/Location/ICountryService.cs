using DanielMaldonado.Inquest.Entity.Location;
using DanielMaldonado.Inquest.Location.Dto;
using DanielMaldonado.Inquest.Utils.Pagination;
using DanielMaldonado.Inquest.Utils.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Location
{
    public interface ICountryService : IInquestAppServiceBase<CountryDto>, IEntityPagedService<CountryDto>
    {
    }
}
