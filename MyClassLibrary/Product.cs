using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Product
    {
        public enum Category { Appliance, Clothing, Food, Furniture, Drink, Electronics, Other, Toys };

        private String productId;
        private String title;
        private String description;
        private double price;
        private int quantity;
        private Category category;

        public Product()
        {
            this.quantity = 1;
            this.category = Category.Other;
        }

        public Product(String id, String title, String description, double price, int quantity = 1, Category category = Category.Other)
        {
            this.ProductID = id;
            this.title = title;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
            this.category = category;
        }

        public String ProductID
        {
            get 
            { 
                return this.productId; 
            }
            set 
            { 
                this.productId = value; 
            }
        }
        public String Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public String Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public Category ProductCategory
        {
            get 
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }
    }
}
