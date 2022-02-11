using Application.Domain.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly IWebApiExecutor _webApiExecutor;

        public OrganisationRepository(IWebApiExecutor webApiExecutor)
        {
            _webApiExecutor = webApiExecutor;
        }

        public async Task<IEnumerable<Organisation>> GetAsync(string uri)
        {
            return await _webApiExecutor.InvokeGetAsync<IEnumerable<Organisation>>(uri);
        }
    }
}
