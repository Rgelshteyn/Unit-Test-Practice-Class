using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class ShoppingCart
    {
        Dictionary<String, Product> cartItems = new Dictionary<string, Product>();

        public bool AddToCart(Product theProduct)
        {
            int countBefore = cartItems.Count;

            if (theProduct == null)
                return false;

            Product copy = new Product(theProduct.ProductID, theProduct.Title, theProduct.Description, theProduct.Price, theProduct.Quantity, theProduct.ProductCategory);
            cartItems.Add(copy.ProductID, copy);
            
            if (cartItems.Count > countBefore)
                return true;

            return false;
        }

        public int CartItemCount()
        {
            return cartItems.Count;
        }

        public bool EmptyCart()
        {
            int countBefore = cartItems.Count;
            cartItems.Clear();

            if (cartItems.Count != 0)
                return false;

            return true;
        }

        public List<Product> FindCartItemsByCategory(Product.Category theCategory)
        {
            List<Product> products = new List<Product>();

            foreach (KeyValuePair<String, Product> item in cartItems)
            {
                Product cartItem = item.Value;

                if (cartItem.ProductCategory == theCategory)
                {
                    Product copy = new Product(cartItem.ProductID, cartItem.Title, cartItem.Description, cartItem.Price, cartItem.Quantity, cartItem.ProductCategory);
                    products.Add(copy);
                }
            }

            return products;
        }

        public List<Product> GetCartItems()
        {
            List<Product> products = new List<Product>();

            foreach (KeyValuePair<String, Product> item in cartItems)
            {
                Product cartItem = item.Value;
                Product copy = new Product(cartItem.ProductID, cartItem.Title, cartItem.Description, cartItem.Price, cartItem.Quantity, cartItem.ProductCategory);
                products.Add(copy);
            }

            return products;
        }

        public Product RemoveFromCart(Product theProduct)
        {
            if (theProduct == null)
                return null;

            return cartItems[theProduct.ProductID];
        }

        public double TotalCost()
        {
            double cost = 0;

            if (cartItems.Count == 0)
                throw new InvalidOperationException("This operation cannot be performed on an empty cart!");

            foreach (KeyValuePair<String, Product> item in cartItems)
            {
                Product cartItem = item.Value;
                cost = cost + cartItem.Price * cartItem.Quantity;
            }

            return cost;
        }

        public bool UpdateCartItemQuantity(String id, int quantity)
        {
            if (cartItems.ContainsKey(id) == false || quantity <= 0)
                return false;

            Product item = cartItems[id];
            item.Quantity = quantity;
            return true;
        }

        public bool Contains(Product product1)
        {
            throw new NotImplementedException();
        }
    }
}
