using AnimalShelter.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace AnimalShelter.Client.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;

        private List<Animal> _animals = new List<Animal>();

        public AnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddAnimal(Animal newAnimal)
        {
            try 
            { 
            await _httpClient.PostAsJsonAsync<Animal>("api/animal", newAnimal);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task AdoptAnimal(Animal animalToAdopt)
        {
            try 
            { 
            await _httpClient.DeleteAsync($"api/animal/{animalToAdopt.Id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task<List<Animal>> GetAllAnimals()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<Animal[]>("api/animal");
                return result.ToList();

            }catch(AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

            throw new InvalidOperationException("This code should not be reached!");
        }

        public async Task<Animal> GetAnimal(int id)
        {
            try
            { 
            return await _httpClient.GetFromJsonAsync<Animal>($"api/animal/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

            throw new InvalidOperationException("This code should not be reached!");
        }

        public async Task Update(Animal animal)
        {
            try
            { 
            await _httpClient.PutAsJsonAsync<Animal>($"api/animal/{animal.Id}", animal);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
