using System;
using System.Collections.Generic;
using Lab2;

namespace Assignment3
{
    public class Cart : Product
    {
        private int id;
        private string customer;
        private float grandTotal;
        private string city;
        private string country;
        private List<Product> listproduct;

        public Cart(int id, string customer, float grandTotal, string city, string country)
        {
            this.id = id;
            this.customer = customer;
            this.grandTotal = grandTotal;
            this.city = city;
            this.country = country;
            this.listproduct = new List<Product>();
        }

        public int FindProduct(Product product)
        {
            return this.listproduct.IndexOf(product);
        }

        public Boolean AddProduct(Product product)
        {
            if (FindProduct(product) > 0)
            {
                Console.WriteLine("the product is exist in the list");
                return false;
            }

            listproduct.Add(product);
            return true;
        }

        public Boolean RemoveProduct(Product product)
        {
            int foundPosition = FindProduct(product);
            if (foundPosition < 0)
            {
                Console.WriteLine("The product not found");
                return false;
            }

            this.listproduct.Remove(product);
            Console.WriteLine("Delete successfully");
            return true;
        }

        public int FindProduct(string name)
        {
            for (int i = 0; i < listproduct.Count; i++)
            {
                var product = listproduct[i];
                if (product.Name.Equals(name))
                {
                    return i;
                }
            }

            return -1;
        }

        public void PrintCart()
        {
            Console.WriteLine("customer : " + this.customer +
                              "\nCity: " + this.city +
                              "\nCountry: " + this.country);
            Console.WriteLine("your cart is : ");
            for (int i = 0; i < listproduct.Count; i++)
            {
                Console.WriteLine(listproduct[i].Id + ": " + listproduct[i].Name+" price "+ listproduct[i].Price+" Quantity "+ listproduct[i].Qty+" image"+ listproduct[i].Image);
            }
        }

        public Product QueryProduct(string name)
        {
            int position = FindProduct(name);
            if (position >= 0)
            {
                return this.listproduct[position];
            }

            return null;
        }

        public string QueryProduct(Product product)
        {
            if (FindProduct(product) >= 0)
            {
                return product.Name;
            }

            return null;
        }
    }
}