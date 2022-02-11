using Application.Domain.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IOrganisationRepository
    {
        Task<IEnumerable<Organisation>> GetAsync(string uri);
    }
}