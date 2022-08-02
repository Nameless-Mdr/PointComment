using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public interface IServiceModule
    {
        void Registry(IServiceCollection services);
    }
}