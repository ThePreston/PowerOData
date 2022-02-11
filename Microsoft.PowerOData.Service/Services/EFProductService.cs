using Microsoft.PowerOData.Service.EF;
using Microsoft.PowerOData.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PowerOData.Service
{
    public class EFProductService : IRepoService<ProductEntityModel>
    {
        public EFProductService(ProductContext context)
        {
            _context = context;
        }

        private readonly ProductContext _context;

        public async Task<IList<ProductEntityModel>> GetData()
        {
            return await new TaskFactory().StartNew(() => { return _context.product.ToList(); });
        }

        public IQueryable<ProductEntityModel> GetDataAsQueryable() => _context.product.AsQueryable();
        
    }
}