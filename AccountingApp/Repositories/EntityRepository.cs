using AccountingApp.Context;
using AccountingApp.Entities;
using AccountingApp.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.Repositories
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AccountingContext _accountingContext;
        private DbSet<TEntity> _entities;

        public IQueryable<TEntity> Table => Entities;

        protected DbSet<TEntity> Entities => _entities ?? (_entities = _accountingContext.Set<TEntity>());

        public EntityRepository(AccountingContext context)
        {
            _accountingContext = context;
        }
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
            _accountingContext.SaveChanges();
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
            _accountingContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _accountingContext.SaveChanges();
        }
    }
}
