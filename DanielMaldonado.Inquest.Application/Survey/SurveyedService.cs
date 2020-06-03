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
    public class SurveyedService : InquestAppServiceBase, ISurveyedService
    {
        #region repositories
        private readonly ISurveyedRepository entityRepository;
        private readonly IPersonSurveyedRepository personSurveyedRepository;
        private readonly IAnswerRepository answerRepository;
        private readonly IBranchOfficeRepository branchOfficeRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IQuestionOptionRepository questionOptionRepository;
        private readonly IQuestionTypeRepository questionTypeRepository;
        #endregion

        #region builders
        public SurveyedService(ISurveyedRepository entityRepository, IPersonSurveyedRepository
            personSurveyedRepository, IAnswerRepository answerRepository, IBranchOfficeRepository branchOfficeRepository,
            IQuestionRepository questionRepository, IQuestionOptionRepository questionOptionRepository, IQuestionTypeRepository questionTypeRepository)
        {
            this.entityRepository = entityRepository;
            this.personSurveyedRepository = personSurveyedRepository;
            this.answerRepository = answerRepository;
            this.branchOfficeRepository = branchOfficeRepository;
            this.questionRepository = questionRepository;
            this.questionOptionRepository = questionOptionRepository;
            this.questionTypeRepository = questionTypeRepository;
        }
        #endregion

        #region public Functions
        public async Task<SurveyedDto> Delete(SurveyedDto request)
        {
            var entity = AutoMapper.Mapper.Map<Surveyed>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<SurveyedDto>(result);
        }

        public EntityPagedDto<SurveyedDto> GetEntityPaged(EntityPagedRequestDto<SurveyedDto> request)
        {
            var result = new EntityPagedDto<SurveyedDto>();
            result.Items = AutoMapper.Mapper.Map<IReadOnlyList<SurveyedDto>>(this.entityRepository.GetAll().ToList());

            return result;
        }

        public async Task<SurveyedDto> Insert(SurveyedDto request)
        {
            var entity = AutoMapper.Mapper.Map<Surveyed>(request);
            entity.AnswerList = null;
            entity.BranchOffice = branchOfficeRepository.Get(entity.BranchOffice.Id);

            entity.PersonSurveyed = await personSurveyedRepository.InsertAsync(entity.PersonSurveyed);
            entity = await entityRepository.InsertAsync(entity);
            entity.AnswerList = new List<Answer>();

            foreach (var answerDto in request.AnswerList)
            {
                var answer = AutoMapper.Mapper.Map<Answer>(answerDto);
                answer.Surveyed = entity;
                answer.Question = questionRepository.Get(answer.Question.Id);
                answer.QuestionOption = questionOptionRepository.Get(answer.QuestionOption.Id);
                answer.QuestionType = questionTypeRepository.Get(answer.QuestionType.Id);

                answer = await answerRepository.InsertAsync(answer);
                entity.AnswerList.Add(answer);
            }

            return AutoMapper.Mapper.Map<SurveyedDto>(entity);
        }
        public SurveyedDto InsertEntity(SurveyedDto request)
        {
            try
            {
                var entity = AutoMapper.Mapper.Map<Surveyed>(request);
                entity.AnswerList = null;
                entity.BranchOffice = branchOfficeRepository.Get(entity.BranchOffice.Id);

                entity.PersonSurveyed = personSurveyedRepository.Insert(entity.PersonSurveyed);
                entity = entityRepository.Insert(entity);
                entity.AnswerList = new List<Answer>();

                foreach (var answerDto in request.AnswerList)
                {
                    var answer = AutoMapper.Mapper.Map<Answer>(answerDto);
                    answer.Surveyed = entity;
                    answer.Question = questionRepository.Get(answer.Question.Id);
                    answer.QuestionOption = questionOptionRepository.Get(answer.QuestionOption.Id);
                    answer.QuestionType = questionTypeRepository.Get(answer.QuestionType.Id);

                    answer = answerRepository.Insert(answer);
                    entity.AnswerList.Add(answer);
                }

                return AutoMapper.Mapper.Map<SurveyedDto>(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<SurveyedDto> Update(SurveyedDto request)
        {
            var entity = AutoMapper.Mapper.Map<Surveyed>(request);
            request.IsDeleted = true;

            var result = await entityRepository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<SurveyedDto>(result);
        }
        #endregion

    }
}
