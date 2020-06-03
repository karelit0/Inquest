using Abp.Domain.Repositories;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyEntity = DanielMaldonado.Inquest.Entity.Survey.Survey;

namespace DanielMaldonado.Inquest.Repository.Survey
{
    public interface ISurveyRepository : IRepository<SurveyEntity, Guid>
    {
    }
}
