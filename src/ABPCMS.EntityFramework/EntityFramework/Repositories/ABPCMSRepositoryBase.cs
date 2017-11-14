using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ABPCMS.EntityFramework.Repositories
{
    public abstract class ABPCMSRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ABPCMSDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ABPCMSRepositoryBase(IDbContextProvider<ABPCMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ABPCMSRepositoryBase<TEntity> : ABPCMSRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ABPCMSRepositoryBase(IDbContextProvider<ABPCMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
