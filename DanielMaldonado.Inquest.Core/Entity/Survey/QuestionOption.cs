﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Survey
{
    public class QuestionOption : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual QuestionType QuestionType { get; set; }
    }
}
