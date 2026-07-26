using DocFlow.DocumentService.Application.Abstractions.Persistence;
using DocFlow.DocumentService.Infrastructure.Persistance.Repository;
using DocFlow.DocumentService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocFlow.DocumentService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services, IConfiguration cnfg)
        {
            var connectionString = cnfg.GetConnectionString("DocumentDatabase") 
                ?? throw new InvalidOperationException("Connection string 'DocumentDatabase' is not found.");
            services.AddDbContext<DocumentDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped<IDocumentRepository, DocumentRepository>();

            return services;
        }
    }
}
