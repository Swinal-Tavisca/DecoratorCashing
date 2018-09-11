using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caching
{
    class Service : IProductService
    {
        public Product GetProductById(int id)
        {
            IRepo productRepo = new sqlProduct();
            Console.Write("FROM REPOSITORY : ");
            return productRepo.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            IRepo productRepo = new sqlProduct();
            return productRepo.GetAllProducts();
        }
    }
}
