using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IWebApiExecutor
    {
        Task<T> InvokeGetAsync<T>(string uri);
    }
}