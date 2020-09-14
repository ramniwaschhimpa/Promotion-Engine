using PromotionEngine.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Implementation
{
   public class ProductService : IProductService
    {
       /// <summary>
       /// Assign product price
       /// </summary>
       /// <param name="product"></param>
        public void GetPriceByType(Product product)
        {
            switch (product.Id)
            {
                case "A":
                    product.Price = 50m;
                    break;
                case "B":
                    product.Price = 30m;

                    break;
                case "C":
                    product.Price = 20m;
                    break;
                case "D":
                    product.Price = 15m;
                    break;
            }
        }
       /// <summary>
       /// Calculate total price with promotion
       /// </summary>
       /// <param name="products"></param>
       /// <returns></returns>

        public int GetTotalPrice(List<Product> products)
        {
            int counterOfA = 0;
            int counterOfB = 0;
            int counterOfC = 0;
            int counterOfD = 0;

            //Count independent product
            foreach (Product pr in products)
            {
                switch (pr.Id.ToUpper())
                {
                    case "A":
                        counterOfA += 1;
                        break;
                    case "B":
                        counterOfB += 1;
                        break;
                    case "C":
                        counterOfC += 1;
                        break;
                    case "D":
                        counterOfD += 1;
                        break;
                }
            }
           int totalPriceOfA = (counterOfA / 3) * Constants.PromotionValueOnA + (counterOfA % 3 * Constants.PriceOfA);
           int totalPriceOfB = (counterOfB / 2) * Constants.PromotionValueOnB + (counterOfB % 2 * Constants.PriceOfB);
           int totalPriceOfCD = 0;
           int totalPriceOfC = 0;
           int totalPriceOfD = 0;

            //Apply C+D promotion
           if (counterOfC != 0 && counterOfD != 0)
           {
               if (counterOfC > counterOfD && counterOfD > 0)
               {
                   totalPriceOfCD = (counterOfC / counterOfD * Constants.PromotionValueOnCD) * counterOfD;
                   totalPriceOfC = (counterOfC % counterOfD * Constants.PriceOfC);
               }
               else if (counterOfD > counterOfC && counterOfC > 0)
               {
                   totalPriceOfCD = (counterOfD / counterOfC * Constants.PromotionValueOnCD) * counterOfC;
                   totalPriceOfD = (counterOfD % counterOfC * Constants.PriceOfD);
               }
               else if (counterOfD == counterOfC && (counterOfC > 0 && counterOfD > 0))
               {
                   totalPriceOfCD = (counterOfD / counterOfC * Constants.PromotionValueOnCD);
               }
           }
           else
           {
               totalPriceOfC = (counterOfC * Constants.PriceOfC);
               totalPriceOfD = (counterOfD * Constants.PriceOfD);
           }

            //Return the total price with promotion
            return totalPriceOfA + totalPriceOfB + totalPriceOfC + totalPriceOfD + totalPriceOfCD;
        }
    }
}
