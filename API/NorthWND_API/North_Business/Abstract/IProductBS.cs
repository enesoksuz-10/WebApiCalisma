using North_Model.Concreate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace North_Business.Abstract
{
    public interface IProductBS
    {
        List<Product> GetProducts(Expression<Func<Product, bool>> filter = null, params string[] includeList);
        Product GetProductById(int id, params string[] includeList);
        Product AddProduct(Product product);
    }
}
