using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Tutorial5.Models;
using Tutorial5.Models.DTOs;
using Tutorial5.Repositories;

namespace Tutorial5.Controllers;

[ApiController]
// [Route("api/animals")]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAnimalRepository _animalRepository;
    public AnimalsController(IConfiguration configuration, IAnimalRepository animalRepository)
    {
        _configuration = configuration;
        _animalRepository = animalRepository;
    }
    
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name")
    {
        
        //var animals = _animalRepository.GetAnimals();
           
        return Ok(_animalRepository.getAnimals(orderBy) );
    }


    [HttpPost]
    public IActionResult AddAnimal([FromBody]AddAnimal animal)
    {
       
        
        return Created("", null);
    }
    
    
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var affectedCount = _animalRepository.DeleteAnimal(id);
        return NoContent();
    }
    
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var affectedCount = _animalRepository.UpdateAnimal(animal);
        return NoContent();
    }
}