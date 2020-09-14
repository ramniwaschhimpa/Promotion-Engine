using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System.Collections.Generic;
using PromotionEngine.Contract;
using PromotionEngine.Implementation;
namespace PromotionEngineTest
{
    [TestClass]
    public class PromotionTest
    {

        //As of now dependency is directly resolved, later on we can do it by using ninject or any other dependency resolver
         IProductService _productService = new ProductService();

         [TestMethod]
         public void ScenarioA()
         {
             List<Product> products = new List<Product>();

             string type = string.Empty;
             //Added product A 1 time
             type = "A";
             Product productA = new Product(type);
             products.Add(productA);

             //Added product B 1 time
             type = "B";
             Product productB = new Product(type);
             products.Add(productB);

             //Added product C 1 time
             type = "C";
             Product product = new Product(type);
             products.Add(product);

             int totalPrice = _productService.GetTotalPrice(products);
             Assert.AreEqual(totalPrice, 100);
         }

         [TestMethod]
         public void ScenarioB()
         {
             List<Product> products = new List<Product>();

             string type = string.Empty;
             //Added product A 5 time
             for (int i = 0; i < 5; i++)
             {
                 type = "A";
                 Product p = new Product(type);
                 products.Add(p);
             }

             //Added product B 5 time
             for (int i = 0; i < 5; i++)
             {
                 type = "B";
                 Product p = new Product(type);
                 products.Add(p);
             }

             //Added product C 1 time
             type = "C";
             Product product = new Product(type);
             products.Add(product);

             int totalPrice = _productService.GetTotalPrice(products);
             Assert.AreEqual(totalPrice, 370);
         }

        [TestMethod]
        public void ScenarioC()
        {
            List<Product> products = new List<Product>();

            string type = string.Empty;
            //Added product A 3 time
            for (int i = 0; i < 3; i++)
            {
                type = "A";
                Product p = new Product(type);
                products.Add(p);
            }

            //Added product B 5 time
            for (int i = 0; i < 5; i++)
            {
                type = "B";
                Product p = new Product(type);
                products.Add(p);
            }

            //Added product C 1 time
            type = "C";
            Product productC = new Product(type);
            products.Add(productC);

             //Added product D 1 time
            type = "D";
            Product productD = new Product(type);
            products.Add(productD);
            
            int totalPrice = _productService.GetTotalPrice(products);
            Assert.AreEqual(totalPrice, 280);
        }

    }
}
