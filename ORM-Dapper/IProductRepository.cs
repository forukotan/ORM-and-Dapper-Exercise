using System;
using System.Collections.Generic;

namespace ORM_Dapper
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(string productName, double price, int category);
        void UpdateProducts(string updatedName, int productID);
        void DeleteProduct(int productID);
    }
}
