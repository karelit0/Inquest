using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping.Location
{
    public class ProvinceMap : EntityBaseMap<Province>
    {
        public ProvinceMap() : base("Province")
        {
            this.Property(p => p.Name);
            this.HasRequired<Country>(p => p.Country);

            this.HasMany<City>(p => p.CityList);
        }
    }
}
