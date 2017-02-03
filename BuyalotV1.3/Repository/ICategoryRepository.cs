using System.Collections.Generic;
using BuyalotV1._3.Models;

namespace BuyalotV1._3.Repository
{
    public interface ICategoryRepository
    {
        List<ProductCategory> findAll();
        ProductCategory find(int id);
    }
}
