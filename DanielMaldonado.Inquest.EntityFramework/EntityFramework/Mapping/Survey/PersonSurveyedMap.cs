using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping
{
    public class PersonSurveyedMap : EntityBaseMap<PersonSurveyed>
    {
        public PersonSurveyedMap() : base("PersonSurveyed")
        {
            this.Property(p => p.Cedula);
            this.Property(p => p.Name);
            this.Property(p => p.Age);
            this.Property(p => p.Gender);
        }
    }
}
