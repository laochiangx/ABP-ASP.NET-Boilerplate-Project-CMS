using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace JCMS.EntityFramework.Repositories
{
    public abstract class JCMSRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<JCMSDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected JCMSRepositoryBase(IDbContextProvider<JCMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class JCMSRepositoryBase<TEntity> : JCMSRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected JCMSRepositoryBase(IDbContextProvider<JCMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
