using System.Threading.Tasks;
using Abp.Application.Services;
using DanielMaldonado.Inquest.Roles.Dto;

namespace DanielMaldonado.Inquest.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
