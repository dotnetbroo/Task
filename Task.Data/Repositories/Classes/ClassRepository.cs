using Task.Data.DbContexts;
using Task.Data.IRepositories.Classes;
using Task.Domain.Entities;

namespace Task.Data.Repositories.Classes;

public class ClassRepository : Repository<Class>, IClassRepository
{
    public ClassRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
