using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<User> allUsers = [];
app.MapGet("/users", () => allUsers);
app.MapGet("/users/{name}", (string name) => new User { Id = 0, Name = name });
app.MapGet("/users/{id:int}", (int id) => new User { Id = id, Name = "test" }); 
app.MapPost("/users", (User user) => allUsers.Add(user));
app.Run();

public class User
{
    public int Id { get; set; } = Random.Shared.Next();
    public string? Name { get; set; } 
}