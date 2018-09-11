using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caching
{
    class MemoryCashService : ICashProductService
    {
        private IProductService _productService;
        private MemoryCachProvider _memoryCachProvider;
        public MemoryCashService()
        {
            _productService = new Service();
            _memoryCachProvider = new MemoryCachProvider();
        }
        public Product GetProductById(int id)
        {
            Product product = (Product)_memoryCachProvider.GetItem(Convert.ToString(id));
            if (product != null)
            {
                Console.Write("FROM CACHE : ");
                return product;
            }
            product = _productService.GetProductById(id);
            _memoryCachProvider.AddItem(Convert.ToString(product.Id), product);
            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _productService.GetProducts();

            return products;
        }
    }
}
