using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<T> where T : class // passando uma classe generica
{
    private readonly SqlConnection _connection;

    public Repository(SqlConnection connection)
        => _connection = connection;

    public IEnumerable<T> GetAll()
        => _connection.GetAll<T>(); // Retornando com Expression Body

    public T Get(int id)
        => _connection.Get<T>(id);
        
    public void Create(T model)
        => _connection.Insert<T>(model);

    public void Update(T model)
         => _connection.Update<T>(model);

    public void Delete(T model)
         => _connection.Delete<T>(model);

    public void Delete(int id)
    {
        var model = _connection.Get<T>(id);
        _connection.Delete<T>(model);
    }
}