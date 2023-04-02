using CacheTesting.Contracts;
using System.Linq.Expressions;

namespace CacheTesting.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly AppDbContext _appDbContext;

    public RepositoryBase(AppDbContext context)
    {
        _appDbContext = context;
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
        _appDbContext.Set<T>().Where(expression);
}
