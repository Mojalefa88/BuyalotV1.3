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

            categories.Add(new ProductCategory { prodCategoryID = 1, categoryName = "Tumelo" });
            //categories.Add(new ProductCategory { prodCategoryID = pr});
            return categories;
        }

    }
}