using DanielMaldonado.Inquest.EntityFramework;
using EntityFramework.DynamicFilters;

namespace DanielMaldonado.Inquest.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly InquestDbContext _context;

        public InitialHostDbBuilder(InquestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
