using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping.Location
{
    public class BranchOfficeMap : EntityBaseMap<BranchOffice>
    {
        public BranchOfficeMap() : base("BranchOffice")
        {
            this.Property(p => p.Name);
            this.HasRequired(p => p.City);
        }
    }
}
