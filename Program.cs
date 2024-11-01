using Neo4j.Driver;
using Neo4jDemoApp.Repository;

var builder = WebApplication.CreateBuilder(args);

var neo4jSettings = builder.Configuration.GetSection("Neo4j");
var uri = neo4jSettings["Uri"];
var username = neo4jSettings["Username"];
var password = neo4jSettings["Password"];

builder.Services.AddSingleton<IDriver>(provider =>
    GraphDatabase.Driver(uri, AuthTokens.Basic(username, password)));

builder.Services.AddScoped<PersonRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();