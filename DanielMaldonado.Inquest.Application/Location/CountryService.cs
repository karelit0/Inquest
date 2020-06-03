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
    public class CountryService : InquestAppServiceBase, ICountryService
    {
        #region repositories
        private readonly ICountryRepository entityRepository;
        #endregion

        #region builders
        public CountryService(ICountryRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<CountryDto> Delete(CountryDto request)
        {
            var entity = AutoMapper.Mapper.Map<Country>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<CountryDto>(result);
        }

        public EntityPagedDto<CountryDto> GetEntityPaged(EntityPagedRequestDto<CountryDto> request)
        {
            throw new NotImplementedException();
        }

        public async Task<CountryDto> Insert(CountryDto request)
        {
            var entity = AutoMapper.Mapper.Map<Country>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<CountryDto>(result);
        }

        public async Task<CountryDto> Update(CountryDto request)
        {
            var entity = AutoMapper.Mapper.Map<Country>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<CountryDto>(result);
        }
        #endregion

    }
}
