using Application.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var webApiClient = ActivatorUtilities.CreateInstance<WebApiClient>(host.Services);

            #region Organisations
            var organisations = await webApiClient.GetOrganisationsAsync();
            foreach (var org in organisations)
            {
                Console.WriteLine(org.Name);
            }
            #endregion
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
          .ConfigureServices((context, services) =>
          {
              services.AddHttpClient();
              //services.AddTransient<IWebApiClient, WebApiClient>();
              services.AddScoped<IWebApiExecutor, WebApiExecutor>();
              services.AddScoped<IOrganisationRepository, OrganisationRepository>();
          });
    }
}
