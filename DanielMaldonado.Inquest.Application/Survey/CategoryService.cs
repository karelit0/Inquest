using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanielMaldonado.Inquest.Location.Dto;
using DanielMaldonado.Inquest.Utils.Pagination;
using DanielMaldonado.Inquest.Repository.Survey;
using DanielMaldonado.Inquest.Entity.Location;
using DanielMaldonado.Inquest.Location;
using DanielMaldonado.Inquest.Entity.Survey;

namespace DanielMaldonado.Inquest.Survey
{
    public class CategoryService : InquestAppServiceBase, ICategoryService
    {
        #region repositories
        private readonly ICategoryRepository entityRepository;
        #endregion

        #region builders
        public CategoryService(ICategoryRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<CategoryDto> Delete(CategoryDto request)
        {
            var entity = AutoMapper.Mapper.Map<Category>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<CategoryDto>(result);
        }

        public EntityPagedDto<CategoryDto> GetEntityPaged(EntityPagedRequestDto<CategoryDto> request)
        {
            var result = new EntityPagedDto<CategoryDto>();
            result.Items = AutoMapper.Mapper.Map<IReadOnlyList<CategoryDto>>(this.entityRepository.GetAll().ToList());

            return result;
        }

        public async Task<CategoryDto> Insert(CategoryDto request)
        {
            var entity = AutoMapper.Mapper.Map<Category>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<CategoryDto>(result);
        }

        public async Task<CategoryDto> Update(CategoryDto request)
        {
            var entity = AutoMapper.Mapper.Map<Category>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<CategoryDto>(result);
        }
        #endregion

    }
}
