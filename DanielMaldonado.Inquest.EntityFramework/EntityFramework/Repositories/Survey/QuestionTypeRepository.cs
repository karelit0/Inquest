using Abp.Domain.Entities.Auditing;
using Abp.EntityFramework;
using DanielMaldonado.Inquest.Entity.Survey;
using DanielMaldonado.Inquest.EntityFramework.Repositories;
using DanielMaldonado.Inquest.Repository.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class QuestionTypeRepository : InquestRepositoryBase<QuestionType, Guid>, IQuestionTypeRepository
    {
        #region Builders
        public QuestionTypeRepository(IDbContextProvider<InquestDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        #endregion
    }
}
