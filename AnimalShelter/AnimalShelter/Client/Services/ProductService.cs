using AnimalShelter.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AnimalShelter.Client.Services
{
    public class ProductService : IProductService
    {
        HttpClient httpClient;
        private List<Product> _products { get; set; } = new List<Product>();

        public ProductService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task AddProduct(Product newProduct)
        {
            try
            { 
            await httpClient.PostAsJsonAsync<Product>("api/product", newProduct);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task DeleteProduct(Product productToDelete)
        {
            try
            { 
            await httpClient.DeleteAsync($"api/product/{productToDelete.Id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            { 
            var result = await httpClient.GetFromJsonAsync<Product[]>("api/product");
            return result.ToList();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

            throw new InvalidOperationException("This code should not be reached!");
        }

        public async Task<Product> GetProduct(int id)
        {
            try
            {
            return await httpClient.GetFromJsonAsync<Product>($"api/product/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

            throw new InvalidOperationException("This code should not be reached!");
        }

        public async Task Update(Product product)
        {
            try
            { 
            await httpClient.PutAsJsonAsync<Product>($"api/product/{product.Id}", product);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
