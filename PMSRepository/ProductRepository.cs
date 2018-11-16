using PMSEntity;
using PMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return Context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
