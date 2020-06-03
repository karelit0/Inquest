using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Location;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class SurveyedMap : EntityBaseMap<Surveyed>
    {
        public SurveyedMap() : base("Surveyed")
        {
            this.HasRequired<BranchOffice>(p => p.BranchOffice);
            this.HasRequired<Survey>(p => p.Survey).WithMany();
            this.HasRequired<PersonSurveyed>(p => p.PersonSurveyed);

            this.HasMany<Answer>(p => p.AnswerList);
        }
    }
}
