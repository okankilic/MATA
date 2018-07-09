using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public abstract class GenericRepository<TEntity, TView> 
        where TEntity: class 
        where TView: class
    {
        internal MataDBEntities dbContext;
        internal DbSet<TEntity> dbSetEntity;
        internal DbSet<TView> dbSetView;

        public GenericRepository(MataDBEntities dbContext)
        {
            this.dbContext = dbContext;

            dbSetEntity = this.dbContext.Set<TEntity>();
            dbSetView = this.dbContext.Set<TView>();
        }

        public virtual IQueryable<TView> Find(Expression<Func<TView, bool>> expression = null)
        {
            if(expression == null)
            {
                return dbSetView;
            }

            return dbSetView.Where(expression);
        }

        public virtual int GetCount()
        {
            return dbSetEntity.Count();
        }

        public virtual TEntity GetByID(int id)
        {
            var t = typeof(TEntity);

            var parameter = Expression.Parameter(t, "x");
            var property = Expression.Property(parameter, "ID");
            var constant = Expression.Constant(id);
            var body = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

            return dbSetEntity.Single(lambda);
        }

        public virtual TView GetViewByID(int id)
        {
            var t = typeof(TView);

            var parameter = Expression.Parameter(t, "x");
            var property = Expression.Property(parameter, "ID");
            var constant = Expression.Constant(id);
            var body = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<TView, bool>>(body, parameter);

            return dbSetView.Single(lambda);
        }

        public virtual void Create(TEntity entity)
        {
            dbSetEntity.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSetEntity.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            dbSetEntity.Remove(entity);
        }

        //private PropertyInfo GetKeyProperty(Type t)
        //{
        //    PropertyInfo keyProperty = null;

        //    foreach (var prop in typeof(TEntity).GetProperties())
        //    {
        //        foreach (var attr in prop.GetCustomAttributes(true))
        //        {
        //            if (attr is EdmScalarPropertyAttribute && ((EdmScalarPropertyAttribute)attr).EntityKeyProperty)
        //            {
        //                keyProperty = prop;
        //                break;
        //            }
        //        }
        //    }

        //    return keyProperty;
        //}
    }
}
