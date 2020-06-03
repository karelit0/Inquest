using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Entity.Location
{
    public class Province : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<City> CityList { get; set; }
    }
}
