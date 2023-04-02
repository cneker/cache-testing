using System.Linq.Expressions;

namespace CacheTesting.Contracts;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
}
