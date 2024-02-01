namespace TripLog_App.Models.DataAccess
{
    public interface IRepository <T>
    {
        IEnumerable<T> List(Queryoptions<T> options);

        T? Get(int id);
        T? Get(Queryoptions<T> options);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        void Save();
    }
}
