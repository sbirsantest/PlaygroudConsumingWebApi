using Application.Domain.Models.Administration;
using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConsoleClient
{
    public class WebApiClient
    {
        private readonly IOrganisationRepository _organisationRepository;

        public WebApiClient(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
        }

        public async Task<IEnumerable<Organisation>> GetOrganisationsAsync()
        {
            return await _organisationRepository.GetAsync("organisations");
        }
    }
}
