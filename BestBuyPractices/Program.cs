using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);
            var otherRepo = new DapperProductRepository(conn);

            var products = otherRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.Write(product.CategoryID);
                Console.Write($" {product.Name}");
                Console.WriteLine($" {product.price}");
            }
            
            var departments = repo.GetAllDepartments();
            foreach (var dept in departments)
            {
                Console.Write(dept.Name);
                Console.WriteLine($" {dept.DepartmentID}");
            }
            Console.WriteLine("Type a new department name:");
            var newDepartment = Console.ReadLine();

            repo.InsertDepartment(newDepartment);                      

            foreach(var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }
        }
    }
}
