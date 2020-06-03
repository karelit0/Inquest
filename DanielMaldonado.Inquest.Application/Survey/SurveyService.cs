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
using SurveyEntity = DanielMaldonado.Inquest.Entity.Survey.Survey;
using DanielMaldonado.Inquest.Entity.Survey;

namespace DanielMaldonado.Inquest.Survey
{
    public class SurveyService : InquestAppServiceBase, ISurveyService
    {
        #region repositories
        private readonly ISurveyRepository entityRepository;
        #endregion

        #region builders
        public SurveyService(ISurveyRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        #endregion

        #region public Functions
        public async Task<SurveyDto> Delete(SurveyDto request)
        {
            var entity = AutoMapper.Mapper.Map<SurveyEntity>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<SurveyDto>(result);
        }

        public EntityPagedDto<SurveyDto> GetEntityPaged(EntityPagedRequestDto<SurveyDto> request)
        {
            var result = new EntityPagedDto<SurveyDto>();
            result.Items = AutoMapper.Mapper.Map<IReadOnlyList<SurveyDto>>(this.entityRepository.GetAll().ToList());

            return result;
        }

        public async Task<SurveyDto> Insert(SurveyDto request)
        {
            var entity = AutoMapper.Mapper.Map<SurveyEntity>(request);

            var result = await entityRepository.InsertAsync(entity);

            return AutoMapper.Mapper.Map<SurveyDto>(result);
        }

        public async Task<SurveyDto> Update(SurveyDto request)
        {
            var entity = AutoMapper.Mapper.Map<SurveyEntity>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<SurveyDto>(result);
        }
        #endregion

    }
}
