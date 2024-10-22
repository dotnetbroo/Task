using Task.Data.IRepositories;
using Task.Data.IRepositories.Classes;
using Task.Data.IRepositories.Students;
using Task.Data.Repositories;
using Task.Data.Repositories.Classes;
using Task.Data.Repositories.Students;
using Task.Service.Interfaces.Classes;
using Task.Service.Interfaces.Students;
using Task.Service.Services.Classes;
using Task.Service.Services.Students;

namespace Task.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IStudentService, StudentService>();
    }
}
