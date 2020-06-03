using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanielMaldonado.Inquest.Utils.Enums.Dto;

namespace DanielMaldonado.Inquest.Utils.Enums
{
    public class EnumService : InquestAppServiceBase, IEnumService
    {
        private const string SystemName = "NissanSystem";
        public IList<EnumDto> GetEnumList(string request)
        {
            var result = new List<EnumDto>();
            var enumType = Type.GetType(string.Format("DanielMaldonado.Inquest.Enums.{0}, DanielMaldonado.Inquest.Core", request), false);

            if (enumType == null && enumType.IsEnum)
                return result;

            foreach (var enumName in Enum.GetNames(enumType))
            {
                var systemEnum = new EnumDto();

                systemEnum.KeyName = enumName;
                systemEnum.Value = Convert.ToUInt16(Enum.Parse(enumType, enumName));
                systemEnum.LocalizationValue = L(string.Format("{0}.{1}.{2}", SystemName, request, enumName));

                result.Add(systemEnum);
            }

            return result;
        }
    }
}
