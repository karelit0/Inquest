using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Survey
{
    public class Surveyed : FullAuditedEntity<Guid>
    {
        public virtual BranchOffice BranchOffice { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual PersonSurveyed PersonSurveyed { get; set; }

        public virtual ICollection<Answer> AnswerList { get; set; }
    }
}
