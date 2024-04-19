using Microsoft.AspNetCore.Mvc;
using Tutorial5.Models;
using Tutorial5.Models.DTOs;

namespace Tutorial5.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> getAnimals([FromQuery] string orderBy = "name");
    void AddAnimal(AddAnimal animal);
    int DeleteAnimal(int idAnimal);
    int UpdateAnimal(Animal animal);
}