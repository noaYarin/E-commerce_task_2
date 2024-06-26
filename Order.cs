﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Order
    {
        private Product[] allProducts;
        private float totalPrice = 0;
        private User buyerDetails;

       

        public Order(Product[] products, int cart_size, User b)
        {
            SetCheckOut(cart_size, products);
            SetOrderPrice();
            buyerDetails = b;
        }

        private void SetCheckOut(int cart_size, Product[] cartProducts)
        {
            this.allProducts = new Product[cart_size];
            for(int i = 0; i < cart_size; i++)
            {
                bool hasSpecialBox = cartProducts[i] is ProductExtraFields productExtra ? productExtra.GetHasSpecialBox() : false;
                if (cartProducts[i] != null)
                {
                    this.allProducts[i] = new ProductExtraFields(cartProducts[i].Id, cartProducts[i].Name, cartProducts[i].Price, cartProducts[i].Category, hasSpecialBox);
                }
            }
        }


        private void SetOrderPrice()
        {
            float price = 0;
            foreach (ProductExtraFields product in allProducts)
            {
                if (product != null)
                {
                    if (product.GetHasSpecialBox())
                    {
                        price += product.GetExtraPrice();
                    }
                    price += product.Price;
                }
                else 
                    break;
            }
            totalPrice = price;
        }

        public void HistroyCart()
        {
            foreach (var item in allProducts)
            {
                if(item != null)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public string ToString()
        {
            string resProducts = "";
            foreach (Product product in allProducts)
            {
                if(product == null) 
                {
                    break;
                }
                resProducts += product.ToString();
            }
            return $"\t# total price: {totalPrice}\n {resProducts}\n ";
        }
    }
}
