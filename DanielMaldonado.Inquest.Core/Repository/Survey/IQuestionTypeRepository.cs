﻿using Abp.Domain.Repositories;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Repository.Survey
{
    public interface IQuestionTypeRepository : IRepository<QuestionType, Guid>
    {
    }
}
