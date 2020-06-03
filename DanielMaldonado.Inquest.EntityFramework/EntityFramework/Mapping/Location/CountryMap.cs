using Abp.Domain.Entities.Auditing;
using DanielMaldonado.Inquest.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.EntityFramework.Mapping.Location
{
    public class CountryMap : EntityBaseMap<Country>
    {
        public CountryMap() : base("Country")
        {
            this.Property(p => p.Name);

            this.HasMany<Province>(p => p.ProvinceList);
        }
    }
}
