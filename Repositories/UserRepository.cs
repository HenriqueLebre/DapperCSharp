using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository
{

    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<User> GetAll()
        => _connection.GetAll<User>(); // Retornando com Expression Body
    public User Get(int id)
        => _connection.Get<User>(id); // Retornando com Expression Body
    public void Create(User user)
        => _connection.Insert<User>(user); // Retornando com Expression Body

}