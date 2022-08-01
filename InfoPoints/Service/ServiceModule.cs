using Domain;
using Microsoft.Extensions.DependencyInjection;
using DAL.Interfaces;
using DAL.Repositories;
using Service.Implements;
using Service.Interfaces;

namespace Service
{
    public class ServiceModule : IServiceModule
    {
        public void Registry(IServiceCollection services)
        {
            services.AddTransient<IPointRepo, PointRepo>();

            services.AddTransient<INoteRepo, NoteRepo>();

            services.AddTransient<IPointService, PointService>();

            services.AddTransient<INoteService, NoteService>();
        }
    }
}
