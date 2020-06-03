using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanielMaldonado.Inquest.Location.Dto;
using DanielMaldonado.Inquest.Utils.Pagination;
using DanielMaldonado.Inquest.Repository.Survey;
using DanielMaldonado.Inquest.Entity.Location;

namespace DanielMaldonado.Inquest.Location
{
    public class CityService : InquestAppServiceBase, ICityService
    {
        #region repositories
        private readonly ICityRepository entityRepository;
        #endregion

        #region builders
        public CityService(ICityRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<CityDto> Delete(CityDto request)
        {
            var entity = AutoMapper.Mapper.Map<City>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<CityDto>(result);
        }

        public EntityPagedDto<CityDto> GetEntityPaged(EntityPagedRequestDto<CityDto> request)
        {
            throw new NotImplementedException();
        }

        public async Task<CityDto> Insert(CityDto request)
        {
            var entity = AutoMapper.Mapper.Map<City>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<CityDto>(result);
        }

        public async Task<CityDto> Update(CityDto request)
        {
            var entity = AutoMapper.Mapper.Map<City>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<CityDto>(result);
        }
        #endregion

    }
}
