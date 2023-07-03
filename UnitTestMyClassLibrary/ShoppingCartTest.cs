using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassLibrary;
using System;
using System.Collections.Generic;

namespace UnitTestMyClassLibrary
{
    [TestClass]
    public class ShoppingCartTest
    {


        [TestMethod]
        public void TestAddToCart()
        {
            
            ShoppingCart cart1 = new ShoppingCart();
            ShoppingCart cart2 = new ShoppingCart();
        

            // Test if AddToCart works correctly multiple 
            Product product1 = new Product("1", "Product 1", "Desc 1", 13.99, 1 , Product.Category.Appliance);
            Product product2 = new Product("2", "Product 2", "Desc 2", 11.99 , 2 , Product.Category.Electronics);

            bool added1 = cart1.AddToCart(product1);
            bool added2 = cart1.AddToCart(product2);

            Assert.IsTrue(added1);
            Assert.IsTrue(added2);

            // checks to see if the added product is the previous
            Product product3 = new Product("3", "Product 3", "This is a description for Product 3", 19.99, 10, Product.Category.Toys);
            cart1.AddToCart(product3);

            Assert.AreNotEqual(product2, product3);


            // Test if AddtoCard recognizes a null product
            Product productnull = null;    
            
            bool addnull = cart2.AddToCart(productnull);

            Assert.IsFalse(addnull);
            

        }

        [TestMethod]

        public void TestCartItemCount()
        {
            ShoppingCart cart1 = new ShoppingCart();
            ShoppingCart cart2 = new ShoppingCart();
            ShoppingCart cart3 = new ShoppingCart();

            // tests if counts corrent number of products
            Product product1 = new Product("35", "Product 1", "Desc 1", 11.99, 5 , Product.Category.Furniture);

            bool added1 = cart1.AddToCart(product1);

            Assert.IsTrue(added1);
            Assert.AreEqual(1, cart1.CartItemCount());
            Assert.AreNotEqual(0, cart1.CartItemCount());



            // tests if counts corrent number of products with multiple products
            Product product3 = new Product("35", "Product 3", "Desc 3", 11.99, 7, Product.Category.Furniture);
            Product product4 = new Product("3", "Product 4", "Desc 4", 1.99, 7, Product.Category.Food);
            bool added3 = cart2.AddToCart(product3);
            bool added4 = cart2.AddToCart(product4);
            Assert.IsTrue(added3);
            Assert.IsTrue(added4);
            Assert.AreEqual(2, cart2.CartItemCount());
            Assert.AreNotEqual(1, cart2.CartItemCount());


            // tests to see if counts a null product 
            Product productnull = null;

            bool addnull = cart2.AddToCart(productnull);

            Assert.IsFalse(addnull);
            Assert.AreEqual(0, cart3.CartItemCount());
            Assert.AreNotEqual(1, cart3.CartItemCount());


        }

        [TestMethod]

        public void TestEmptyCart()
        {

            // tests to see if the EmptyCart deletes a product
            ShoppingCart cart1 = new ShoppingCart();
            Product product1 = new Product("35", "Product 1", "Desc 1", 11.99, 5, Product.Category.Furniture);
            Product product2 = new Product("424", "Product 2", "desc 2", 13.43, 3, Product.Category.Drink);

            cart1.AddToCart(product1);
            cart1.AddToCart(product2);

            cart1.EmptyCart();

            Assert.AreEqual(0, cart1.CartItemCount());
            Assert.AreNotEqual(2, cart1.CartItemCount());

        }

        [TestMethod]
        public void TestFindCartItemsByCategory()
        {
            
            ShoppingCart cart = new ShoppingCart();
            Product product1 = new Product("1", "Product 1", "Desc 1", 13.99, 1, Product.Category.Clothing);
            Product product2 = new Product("2", "Product 2", "Desc 2", 11.99, 1, Product.Category.Electronics);
            Product product3 = new Product("3", "Product 3", "Desc 3", 15.99, 1, Product.Category.Clothing);
            Product product4 = new Product("4", "Product 4", "Desc 4", 9.99, 1, Product.Category.Electronics);
            Product product5 = new Product("424", "Product 5", "Desc 5", 13.43, 3, Product.Category.Drink);
            Product product6 = new Product("6", "Product 6", "Desc 6", 8.99, 6, Product.Category.Electronics);

            cart.AddToCart(product1);
            cart.AddToCart(product2);
            cart.AddToCart(product3);
            cart.AddToCart(product4);
            cart.AddToCart(product5);
            cart.AddToCart(product6);

            // Tests to see if Find by Category counts the correct amounts of diffrent Categories
            // Also Tests whether the product category of the indexed item in the electronics or Clothes list is equal to the Product.Category. enum value.
            List<Product> clothes = cart.FindCartItemsByCategory(Product.Category.Clothing);
            List<Product> electronics = cart.FindCartItemsByCategory(Product.Category.Electronics);
            List<Product> drink = cart.FindCartItemsByCategory(Product.Category.Drink);


            Assert.AreEqual(2, clothes.Count);
            Assert.AreEqual(clothes[0].ProductCategory, Product.Category.Clothing);
            Assert.AreEqual(clothes[1].ProductCategory, Product.Category.Clothing);

            Assert.AreEqual(3, electronics.Count);
            Assert.AreEqual(electronics[0].ProductCategory, Product.Category.Electronics);
            Assert.AreEqual(electronics[1].ProductCategory, Product.Category.Electronics);
            Assert.AreEqual(electronics[2].ProductCategory, Product.Category.Electronics);

            Assert.AreEqual(1, drink.Count);
            Assert.AreNotEqual(0, drink.Count);
        }

        [TestMethod]
        public void TestGetCartItems()
        {
            
            ShoppingCart cart = new ShoppingCart();
            Product product1 = new Product("1", "Product 1", "Desc 1", 11.99, 2, Product.Category.Furniture);
            Product product2 = new Product("2", "Product 2", "desc 2", 13.43, 3, Product.Category.Drink);

            cart.AddToCart(product1);
            cart.AddToCart(product2);

          //Tests the GetCartItems method by adding them to cart and retrive a list of the cart items and 
          // check they are not null , has two products and has the same items that was added to cart
            List<Product> items = cart.GetCartItems();

       
            Assert.IsNotNull(items);
            Assert.AreEqual(items.Count, 2);


            Product item1 = items[0];
            Assert.AreEqual(item1.ProductID, product1.ProductID);
            Assert.AreEqual(item1.Title, product1.Title);
            Assert.AreEqual(item1.Description, product1.Description);
            Assert.AreEqual(item1.Price, product1.Price);
            Assert.AreEqual(item1.Quantity, product1.Quantity);
            Assert.AreEqual(item1.ProductCategory, product1.ProductCategory);

            Product item2 = items[1];
            Assert.AreEqual(item2.ProductID, product2.ProductID);
            Assert.AreEqual(item2.Title, product2.Title);
            Assert.AreEqual(item2.Description, product2.Description);
            Assert.AreEqual(item2.Price, product2.Price);
            Assert.AreEqual(item2.Quantity, product2.Quantity);
            Assert.AreEqual(item2.ProductCategory, product2.ProductCategory);
        }

        [TestMethod]
        public void TestTotalCost()
        {
            //tests total cost of multiple products and adds up all the prices based on the quanity 
            ShoppingCart cart = new ShoppingCart();
            Product product1 = new Product("35", "Product 1", "Desc 1", 6.00, 5, Product.Category.Furniture);
            Product product2 = new Product("424", "Product 2", "desc 2", 10.00, 3, Product.Category.Drink);

            cart.AddToCart(product1);
            cart.AddToCart(product2);
           
            double totalCost = cart.TotalCost();
        
            Assert.AreEqual(60, totalCost);

            // tests the same but for only one product
            ShoppingCart cart1 = new ShoppingCart();
            Product product3 = new Product("35", "Product 3", "Desc 3", 12.00, 2, Product.Category.Electronics);
            cart1.AddToCart(product3);

            double totalCost1 = cart1.TotalCost();

            Assert.AreEqual(24, totalCost1);


           //tests the shoping car total cost when it is empty 
            ShoppingCart cart3 = new ShoppingCart();

            try
            {
                double totalCost2= cart3.TotalCost();

          
            }
            catch (InvalidOperationException exception)
            {
                Assert.AreEqual("This operation cannot be performed on an empty cart!", exception.Message);
            }
        }

        [TestMethod]
        public void TestUpdateCartItemQaunitiy()
        {
            //tests updating the qauntity by calling the method and using the new quantity to caluclate total cost of the price. 
            // if it passes with the correct changed price then the method works.
            // Also tests if the entered new qauntity is changed correctly 
            ShoppingCart cart = new ShoppingCart();
            Product product1 = new Product("35", "Product 1", "Desc 1", 12.00, 5, Product.Category.Furniture);

            cart.AddToCart(product1);

            bool updatecart = cart.UpdateCartItemQuantity("35", 3);
            double totalCost = cart.TotalCost();

            Assert.IsTrue(updatecart);
            Assert.AreEqual(36, totalCost);


            //Tests to see if a cart can have either 0 or a negtive number and makes sure the quanity does not change if so
            ShoppingCart cart2 = new ShoppingCart();
            Product product2 = new Product("22", "Product 2", "Description 2", 10, 4, Product.Category.Electronics);
            cart2.AddToCart(product2);

            bool update1 = cart.UpdateCartItemQuantity("22", 0);
            bool update2 = cart.UpdateCartItemQuantity("22", -1);

            Assert.IsFalse(update1);
            Assert.IsFalse(update2);
            Assert.AreEqual(4, product2.Quantity);




        }

        [TestMethod]
        public void TestRemoveFromCart()
        {
            ShoppingCart cart = new ShoppingCart();
            Product product1 = new Product("1", "Product 1", "Desc 1", 10.00, 1, Product.Category.Appliance);
            cart.AddToCart(product1);

            
            Product removedProduct = cart.RemoveFromCart(product1);

            Assert.IsNotNull(removedProduct);
            Assert.AreEqual(removedProduct.ProductID, product1.ProductID);
        }




    }
}
