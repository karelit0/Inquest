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
    public class ProvinceService : InquestAppServiceBase, IProvinceService
    {
        #region repositories
        private readonly IProvinceRepository entityRepository;
        #endregion

        #region builders
        public ProvinceService(IProvinceRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<ProvinceDto> Delete(ProvinceDto request)
        {
            var entity = AutoMapper.Mapper.Map<Province>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<ProvinceDto>(result);
        }

        public EntityPagedDto<ProvinceDto> GetEntityPaged(EntityPagedRequestDto<ProvinceDto> request)
        {
            throw new NotImplementedException();
        }

        public async Task<ProvinceDto> Insert(ProvinceDto request)
        {
            var entity = AutoMapper.Mapper.Map<Province>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<ProvinceDto>(result);
        }

        public async Task<ProvinceDto> Update(ProvinceDto request)
        {
            var entity = AutoMapper.Mapper.Map<Province>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<ProvinceDto>(result);
        }
        #endregion

    }
}
