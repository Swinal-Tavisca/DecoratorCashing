using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caching
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new MemoryCashService();
            List<Product> products = productService.GetProducts();

            Console.Write("ENTER ID : ");
            int id = int.Parse(Console.ReadLine());
            
            Product product = productService.GetProductById(id);

            Console.WriteLine(product.Id);
            Console.WriteLine("(ENTER WITHIN 30sec TO GET FROM CACHE)");
            Console.Write("ENTER ID : ");
            id = int.Parse(Console.ReadLine());
            product = productService.GetProductById(id);
            Console.WriteLine(product.Id);
            Console.ReadKey();

        }
    }
}
