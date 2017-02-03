using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyalotV1._3.Models;

namespace BuyalotV1._3.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ModelDbEntities modelDbEntities = new ModelDbEntities();

        public ProductCategory find(int id)
        {
            return modelDbEntities.ProductCategories.Find(id);
        }

        public List<ProductCategory> findAll()
        {
            return modelDbEntities.ProductCategories.ToList();
        }
    }
}