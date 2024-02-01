using System.Linq.Expressions;

namespace TripLog_App.Models.DataAccess
{
    public class Queryoptions<T>
    {
        public Expression<Func<T,object>>OrderBy { get; set; }
        public Expression<Func<T,bool>>Where{ get; set; }
        private string[] includes = Array.Empty<string>();  

        public string Includes { set => includes =
                value.Replace(" ", "").Split(',');
        }
        public string[] GetIncludes() => includes;
        public bool HasWhere => Where != null!;
        public bool HasOrderby => OrderBy != null;
    }
}
