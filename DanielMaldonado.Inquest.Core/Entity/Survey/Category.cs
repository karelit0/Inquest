﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Survey
{
    public class Category : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Question> QuestionList { get; set; }
    }
}
