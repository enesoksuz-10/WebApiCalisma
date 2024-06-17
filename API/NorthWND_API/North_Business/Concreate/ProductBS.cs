using North_Business.Abstract;
using North_DataAccess.Context;
using North_DataAccess.Repository.Abstract;
using North_DataAccess.Repository.Concreate;
using North_Model.Concreate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace North_Business.Concreate
{

    public class ProductBS : IProductBS
    {
        private IProductRepository _repo;
        public ProductBS(IProductRepository repo)
        {
            _repo = repo;
        }
        public Product AddProduct(Product product)
        {
           
            _repo.AddProduct(product);
            return product;
        }

        public Product GetProductById(int id, params string[] includeList)
        {
            
            return _repo.GetProductById(id, includeList);
        }

        public List<Product> GetProducts(Expression<Func<Product, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetProducts(filter:filter,includeList:includeList);
        }
    }
}
