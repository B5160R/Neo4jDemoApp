using Microsoft.AspNetCore.Mvc;
using Neo4jDemoApp.Models;
using Neo4jDemoApp.Repository;

namespace Neo4jDemoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonRepository _personRepository;

    public PersonController(PersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] Person person)
    {
        await _personRepository.CreatePersonAsync(person);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetPersons()
    {
        var persons = await _personRepository.GetPersonsAsync();
        return Ok(persons);
    }
}
