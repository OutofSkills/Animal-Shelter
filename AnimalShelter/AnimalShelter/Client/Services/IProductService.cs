using AnimalShelter.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Client.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task DeleteProduct(Product productToDelete);
        Task AddProduct(Product newProduct);
        Task Update(Product product);
    }
}
