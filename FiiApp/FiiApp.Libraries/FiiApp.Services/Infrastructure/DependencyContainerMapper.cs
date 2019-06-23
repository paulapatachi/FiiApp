using FiiApp.Data.Context;
using FiiApp.Data.Infrastructure;
using FiiApp.Services.FacultyServices;
using FiiApp.Services.MLServices;
using FiiApp.Services.SendGridEmailServices;
using FiiApp.Services.StudentServices;
using FiiApp.Services.StudentTestServices;
using FiiApp.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiiApp.Services.Infrastructure
{
    public class DependencyContainerMapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //database
            services.AddDbContext<FiiAppContext>(options =>
                options.UseSqlServer(configuration["FiiAppDatabaseConnectionString"]));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //register generic repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //register generic service
            services.AddScoped<IStudentTestService, StudentTestService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IMLService, MLService>();
        }
    }
}
