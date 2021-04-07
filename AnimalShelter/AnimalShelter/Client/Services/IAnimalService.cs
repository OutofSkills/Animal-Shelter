using AnimalShelter.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Client.Services
{
    public interface IAnimalService
    {
        Task<List<Animal>> GetAllAnimals();
        Task<Animal> GetAnimal(int id);
        Task AdoptAnimal(Animal animalToAdopt);
        Task AddAnimal(Animal newAnimal);
        Task Update(Animal animal);
    }
}
