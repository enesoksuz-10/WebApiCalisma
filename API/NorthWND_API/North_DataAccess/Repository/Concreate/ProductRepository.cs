using Infrastructure.DataAccess.Concreate;
using North_DataAccess.Context;
using North_DataAccess.Repository.Abstract;
using North_Model.Concreate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace North_DataAccess.Repository.Concreate
{
    public class ProductRepository : GenericRepository<Product, NorthwndContext>, IProductRepository
    {
        public Product AddProduct(Product product)
        {
            return Insert(product);
        }

        public Product GetProductById(int id, params string[] includeList)
        {
            return Get(filter: x => x.ProductID == id, includeList:includeList);

        }

        public List<Product> GetProducts(Expression<Func<Product, bool>> filter = null, params string[] includeList)
        {
            return GetAll(filter: filter, includeList);
        }
    }
}
