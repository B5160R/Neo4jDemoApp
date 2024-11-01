using Neo4j.Driver;
using Neo4jDemoApp.Models;

namespace Neo4jDemoApp.Repository;

public class PersonRepository(IDriver _driver)
{
    public async Task CreatePersonAsync(Person person)
    {
        var query = "CREATE (p:Person {Name: $name, Age: $age})";

        using var session = _driver.AsyncSession();
        await session.RunAsync(query, new { name = person.Name, age = person.Age });
    }

    public async Task<List<Person>> GetPersonsAsync()
    {
        var persons = new List<Person>();
        var query = "MATCH (p:Person) RETURN p.Name AS Name, p.Age AS Age";

        using var session = _driver.AsyncSession();
        var result = await session.RunAsync(query);
        await result.ForEachAsync(x =>
        {
            persons.Add(new Person
            {
                Name = x["Name"].As<string>(),
                Age = x["Age"].As<int>()
            });
        });
        return persons;
    }
}
