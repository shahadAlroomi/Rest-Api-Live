public class UserService(IUserRepository userRepository)
{
    public bool RegisterUser(string username, string password)
    {
        userRepository.AddUser(new User { Name = username });

        return true;
    }
}

public interface IUserRepository
{
    void AddUser(User user);
}

public class UserRepository : IUserRepository
{
    public void AddUser(User user)
    {
        // Implementation to add user to the data store
    }
    
}
