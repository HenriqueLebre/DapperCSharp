// pacotes utilizados Microsoft.Data.SqlCliente
// Dapper
// Dapper.Contrib

// See https://aka.ms/new-console-template for more information
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;
class program
{

    private const string CONNECION_STRING = @"Server=localhost;1433;Database=Blog;User ID=sa;Password=1q2w3e4r@";
    static void Main(string[] args)
    {
        
    }

    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(CONNECION_STRING))
        {
            var users = connection.GetAll<User>();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
    public static void ReadUser()
    {
        using (var connection = new SqlConnection(CONNECION_STRING))
        {
            var user = connection.Get<User>(1);
            Console.WriteLine(user.Name);
        }
    }
    public static void CreateUser()
    {

        var user = new User(){
            Bio="Dev",
            Email="dev@dev.com",
            Image="https://",
            Name="Dev development",
            PasswordHash="HASH",
            Slug="Devs"
        };

        using (var connection = new SqlConnection(CONNECION_STRING))
        {
            connection.Insert<User>(user);
            Console.WriteLine(user.Name);
        }
    }
    public static void UpdateUser()
    {

        var user = new User(){
            Id=1,
            Bio="Analista",
            Email="analista@dev.com",
            Image="https://",
            Name="Dev development",
            PasswordHash="HASH",
            Slug="Analista de sistema"
        };

        using (var connection = new SqlConnection(CONNECION_STRING))
        {
            connection.Update<User>(user);
            Console.WriteLine(user.Name);
        }
    }
    public static void DeleteUser()
    {
        using (var connection = new SqlConnection(CONNECION_STRING))
        {
            var user = connection.Get<User>(2);
            connection.Delete<User>(user);
            Console.WriteLine(user.Name);
        }
    }
}