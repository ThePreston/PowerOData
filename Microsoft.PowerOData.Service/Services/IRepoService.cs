using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PowerOData.Service
{
    public interface IRepoService<T> where T : class
    {
        public Task<IList<T>> GetData();

        public IQueryable<T> GetDataAsQueryable();
    }
}