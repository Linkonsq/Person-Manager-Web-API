using PMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSInterface
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsByCategory(int categoryId);
    }
}
