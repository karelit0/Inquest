using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace DanielMaldonado.Inquest.EntityFramework.Repositories
{
    public abstract class InquestRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<InquestDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected InquestRepositoryBase(IDbContextProvider<InquestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class InquestRepositoryBase<TEntity> : InquestRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected InquestRepositoryBase(IDbContextProvider<InquestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
