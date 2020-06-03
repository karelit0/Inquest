using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanielMaldonado.Inquest.Location.Dto;
using DanielMaldonado.Inquest.Utils.Pagination;
using DanielMaldonado.Inquest.Repository.Survey;
using DanielMaldonado.Inquest.Entity.Location;
using DanielMaldonado.Inquest.Entity.Survey;
using DanielMaldonado.Inquest.Location;

namespace DanielMaldonado.Inquest.Survey
{
    public class AnswerService : InquestAppServiceBase, IAnswerService
    {
        #region repositories
        private readonly IAnswerRepository entityRepository;
        #endregion

        #region builders
        public AnswerService(IAnswerRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<AnswerDto> Delete(AnswerDto request)
        {
            var entity = AutoMapper.Mapper.Map<Answer>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<AnswerDto>(result);
        }

        public EntityPagedDto<AnswerDto> GetEntityPaged(EntityPagedRequestDto<AnswerDto> request)
        {
            var result = new EntityPagedDto<AnswerDto>();
            result.Items = AutoMapper.Mapper.Map<IReadOnlyList<AnswerDto>>(this.entityRepository.GetAll().ToList());

            return result;
        }

        public async Task<AnswerDto> Insert(AnswerDto request)
        {
            var entity = AutoMapper.Mapper.Map<Answer>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<AnswerDto>(result);
        }

        public async Task<AnswerDto> Update(AnswerDto request)
        {
            var entity = AutoMapper.Mapper.Map<Answer>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<AnswerDto>(result);
        }
        #endregion

    }
}
