using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
var app = builder.Build();

List<User> allUsers = [];
List<UserService> a = [];
app.MapGet("/users", () => allUsers);
app.MapGet("/users/{name}", (string name) => new User { Id = 0, Name = name });
app.MapGet("/users/{id:int}", (int id) => new User { Id = id, Name = "test" }); 
app.MapGet("/users/register", () => a);
app.MapPost("/users", (User user) => allUsers.Add(user));
app.MapPost("/users/register", (UserRegisterDTO user,
                                UserService us) => us.RegisterUser(user.Username, user.Password));

app.Run();

public record UserRegisterDTO(string Username, string Password);

public class User
{
    public int Id { get; set; } = Random.Shared.Next();
    public string? Name { get; set; } 
}