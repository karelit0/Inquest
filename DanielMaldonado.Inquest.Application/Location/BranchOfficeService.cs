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
    public class BranchOfficeService : InquestAppServiceBase, IBranchOfficeService
    {
        #region repositories
        private readonly IBranchOfficeRepository entityRepository;
        #endregion

        #region builders
        public BranchOfficeService(IBranchOfficeRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<BranchOfficeDto> Delete(BranchOfficeDto request)
        {
            var entity = AutoMapper.Mapper.Map<BranchOffice>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<BranchOfficeDto>(result);
        }

        public EntityPagedDto<BranchOfficeDto> GetEntityPaged(EntityPagedRequestDto<BranchOfficeDto> request)
        {
            var result = new EntityPagedDto<BranchOfficeDto>();
            result.Items = AutoMapper.Mapper.Map<IReadOnlyList<BranchOfficeDto>>(this.entityRepository.GetAll().ToList());

            return result;
        }

        public async Task<BranchOfficeDto> Insert(BranchOfficeDto request)
        {
            var entity = AutoMapper.Mapper.Map<BranchOffice>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<BranchOfficeDto>(result);
        }

        public async Task<BranchOfficeDto> Update(BranchOfficeDto request)
        {
            var entity = AutoMapper.Mapper.Map<BranchOffice>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<BranchOfficeDto>(result);
        }
        #endregion

    }
}
