using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace DanielMaldonado.Inquest.Utils.Pagination
{
    public class EntityPagedRequestDto<TEntityDto> : ILimitedResultRequest, IPagedResultRequest
    {
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public KinareApp.NetFramework.Entities.Sorter Sorter { get; set; }
        public IList<KinareApp.NetFramework.Entities.Filter> FilterList { get; set; }

    }
}
