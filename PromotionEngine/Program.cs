using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.Contract;
using PromotionEngine.Implementation;
namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService _productService = new ProductService();
            List<Product> products = new List<Product>();

            //Enter the total  number of items to be ordered
            Console.WriteLine("Total number of order:- ");
            int a = Convert.ToInt32(Console.ReadLine());

            //Items its A,B,C and D
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("enter the type of product:A,B,C or D");
                string type = Console.ReadLine();
                Product p = new Product(type);
                products.Add(p);
            }

            int totalPrice = _productService.GetTotalPrice(products);
            Console.WriteLine(totalPrice);
            Console.ReadLine();
        }
    }
}
