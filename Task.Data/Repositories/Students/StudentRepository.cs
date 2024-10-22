using Task.Data.DbContexts;
using Task.Data.IRepositories.Students;
using Task.Domain.Entities;

namespace Task.Data.Repositories.Students;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
