using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping.Location
{
    public class CityMap : EntityBaseMap<City>
    {
        public CityMap() : base("City")
        {
            this.Property(p => p.Name);

            this.HasRequired<Province>(p => p.Province);

            this.HasMany<BranchOffice>(p => p.BranchOfficeList);
        }
    }
}
