
using AutoMapper;
using Services.Managers.Implementations;
using Services.Managers.Interfaces;
using StudentsApp.Infrastructure.Implementation;
using StudentsApp.Infrastructure.Interfaces;
using StudentsApp.Infrastructure.Repositories;
using StudentsApp.Students.Interfaces;
using StudentsApp.Students.Services;



namespace StudentsApp.Infrastructure.Configuration
{
    public class ServiceModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            // Auto Mapper Configurations
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfiler());
            //});

            // IMapper mapper = mapperConfig.CreateMapper();
            // services.AddSingleton(mapper);

        } 
    }
}
