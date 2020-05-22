using Microsoft.Extensions.DependencyInjection;

namespace BlazorHistory
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers blazor hisstory service to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorHistoryService(this IServiceCollection services)
        {
            return services.AddScoped<IBlazorHistoryService, BlazorHistoryService>();
        }
    }
}
