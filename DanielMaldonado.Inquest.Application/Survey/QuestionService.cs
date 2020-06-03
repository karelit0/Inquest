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
    public class QuestionService : InquestAppServiceBase, IQuestionService
    {
        #region repositories
        private readonly IQuestionRepository entityRepository;
        #endregion

        #region builders
        public QuestionService(IQuestionRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<QuestionDto> Delete(QuestionDto request)
        {
            var entity = AutoMapper.Mapper.Map<Question>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<QuestionDto>(result);
        }

        public EntityPagedDto<QuestionDto> GetEntityPaged(EntityPagedRequestDto<QuestionDto> request)
        {
            var result = new EntityPagedDto<QuestionDto>();
            result.Items = AutoMapper.Mapper.Map<IReadOnlyList<QuestionDto>>(this.entityRepository.GetAll().ToList());

            return result;
        }

        public async Task<QuestionDto> Insert(QuestionDto request)
        {
            var entity = AutoMapper.Mapper.Map<Question>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<QuestionDto>(result);
        }

        public async Task<QuestionDto> Update(QuestionDto request)
        {
            var entity = AutoMapper.Mapper.Map<Question>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<QuestionDto>(result);
        }
        #endregion

    }
}
