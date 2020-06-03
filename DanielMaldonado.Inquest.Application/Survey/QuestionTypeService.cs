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
    public class QuestionTypeService : InquestAppServiceBase, IQuestionTypeService
    {
        #region repositories
        private readonly IQuestionTypeRepository entityRepository;
        #endregion

        #region builders
        public QuestionTypeService(IQuestionTypeRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<QuestionTypeDto> Delete(QuestionTypeDto request)
        {
            var entity = AutoMapper.Mapper.Map<QuestionType>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<QuestionTypeDto>(result);
        }

        public EntityPagedDto<QuestionTypeDto> GetEntityPaged(EntityPagedRequestDto<QuestionTypeDto> request)
        {
            var result = new EntityPagedDto<QuestionTypeDto>();
            result.Items = AutoMapper.Mapper.Map<IReadOnlyList<QuestionTypeDto>>(this.entityRepository.GetAll().ToList());

            return result;
        }

        public async Task<QuestionTypeDto> Insert(QuestionTypeDto request)
        {
            var entity = AutoMapper.Mapper.Map<QuestionType>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<QuestionTypeDto>(result);
        }

        public async Task<QuestionTypeDto> Update(QuestionTypeDto request)
        {
            var entity = AutoMapper.Mapper.Map<QuestionType>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<QuestionTypeDto>(result);
        }
        #endregion

    }
}
