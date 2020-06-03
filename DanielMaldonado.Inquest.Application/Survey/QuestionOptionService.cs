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
    public class QuestionOptionService : InquestAppServiceBase, IQuestionOptionService
    {
        #region repositories
        private readonly IQuestionOptionRepository entityRepository;
        #endregion

        #region builders
        public QuestionOptionService(IQuestionOptionRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<QuestionOptionDto> Delete(QuestionOptionDto request)
        {
            var entity = AutoMapper.Mapper.Map<QuestionOption>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<QuestionOptionDto>(result);
        }

        public EntityPagedDto<QuestionOptionDto> GetEntityPaged(EntityPagedRequestDto<QuestionOptionDto> request)
        {
            var result = new EntityPagedDto<QuestionOptionDto>();
            result.Items = AutoMapper.Mapper.Map<IReadOnlyList<QuestionOptionDto>>(this.entityRepository.GetAll().ToList());

            return result;
        }

        public async Task<QuestionOptionDto> Insert(QuestionOptionDto request)
        {
            var entity = AutoMapper.Mapper.Map<QuestionOption>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<QuestionOptionDto>(result);
        }

        public async Task<QuestionOptionDto> Update(QuestionOptionDto request)
        {
            var entity = AutoMapper.Mapper.Map<QuestionOption>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<QuestionOptionDto>(result);
        }
        #endregion

    }
}
