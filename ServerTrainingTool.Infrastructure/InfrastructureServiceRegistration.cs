using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerTrainingTool.Application.Contracts;
using ServerTrainingTool.Application.Contracts.Common;
using ServerTrainingTool.Application.Mappings;
using ServerTrainingTool.Infrastructure.Repositories;
using ServerTrainingTool.Infrastructure.Repositories.Common;
using ServerTrainingTool.Infrastructure.Service;

namespace ServerTrainingTool.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TrainingToolDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionTrainingToolSopran")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(IAsyncRepository<>), typeof(BaseAsyncRepository<>));

            services.AddTransient<ITabellaCorsiRepository, TabellaCorsiRepository>();

            services.AddMediatR();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
