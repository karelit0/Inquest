using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace DanielMaldonado.Inquest.Utils.Pagination
{
    public class EntityPagedDto<TEntityDto> : IPagedResult<TEntityDto>, IPagedResultRequest
    {
        public IReadOnlyList<TEntityDto> Items { get; set; }
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public int TotalCount { get; set; }
    }
}
