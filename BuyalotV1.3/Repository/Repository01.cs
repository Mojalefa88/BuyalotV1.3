using BuyalotV1._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuyalotV1._3.Repository;
using System.Collections;

namespace BuyalotV1._3.Repository
{
    public class Repository01 
    {
        private ModelDbEntities modelDbEntities = new ModelDbEntities();
        public List<ProductCategory> GetCategories()
        {
            List<ProductCategory> categories = new List<ProductCategory>();

            categories.Add(new ProductCategory { prodCategoryID = 1, categoryName = "Computers" });
            categories.Add(new ProductCategory { prodCategoryID = 2, categoryName = "Laptops" });
            categories.Add(new ProductCategory { prodCategoryID = 3, categoryName = "Mobile Phones" });
            categories.Add(new ProductCategory { prodCategoryID = 4, categoryName = "Gadgets" });
            categories.Add(new ProductCategory { prodCategoryID = 5, categoryName = "TV & Audio" });
            return categories;
        }
        
    }
}