using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyalotV1._3.Models
{
    public class Item
    {
        private Product prdcts = new Product();

       
        private int quantity;

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public Product Prdcts
        {
            get
            {
                return prdcts;
            }

            set
            {
                prdcts = value;
            }
        }

        public Item() { }

        public Item(Product product, int quantity)
        {
            this.Prdcts = product;
            this.Quantity = quantity;
        }
    }
}