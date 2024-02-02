using Microsoft.EntityFrameworkCore;

namespace TripLog_App.Models.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected TripLogContext context { get; set; }
        private DbSet<T> dbSet { get; set; }
        public Repository(TripLogContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T>();
        }
        public IEnumerable<T> List(Queryoptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.ToList();
        }
       
        public T? Get(Queryoptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.FirstOrDefault();
        }
        
        public T? Get(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }

        public void Insert(T entity)
        {
            context.Add(entity);
        }

       
        public void Save()
        {
            context.SaveChanges();
        }

      
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        private IQueryable<T> BuildQuery(Queryoptions<T> options)
        {
            IQueryable<T> query = dbSet;

            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            if (options.HasOrderBy)
                query = query.OrderBy(options.OrderBy);
            return query;

        }
    }
}
