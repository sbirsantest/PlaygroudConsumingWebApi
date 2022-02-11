using Application.Repository;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WebApiExecutor webApiExecutor = new("http://localhost:5000/api", new HttpClient());

            #region Organisations

            OrganisationRepository orgRepo = new(webApiExecutor);
            var organisations = await orgRepo.GetAsync("organisations");
            foreach (var org in organisations)
            {
                Console.WriteLine(org.Name);
            }

            #endregion

            Console.ReadKey();
        }
    }
}
