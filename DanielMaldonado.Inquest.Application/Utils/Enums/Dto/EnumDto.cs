using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielMaldonado.Inquest.Utils.Enums.Dto
{
    public class EnumDto
    {
        public virtual string KeyName { get; set; }
        public virtual string LocalizationValue { get; set; }
        public virtual UInt16 Value { get; set; }
    }
}
