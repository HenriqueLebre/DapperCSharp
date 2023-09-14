using System.Collections.Generic;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class RoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<Role> GetAll()
        => _connection.GetAll<Role>(); // Retornando com Expression Body
    public Role Get(int id)
        => _connection.Get<Role>(id); // Retornando com Expression Body
    public void Create(Role role)
        => _connection.Insert<Role>(role); // Retornando com Expression Body
}