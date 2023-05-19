using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion
            
            IDbConnection conn = new MySqlConnection(connString);
            
            
            DapperProductRepository productRepo = new DapperProductRepository(conn);
            

            var products = productRepo.GetAllProducts();
            PrintProduct(products);
            productRepo.CreateProduct("newstuff", 20,1);

            #region Department

            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            Console.WriteLine(" Hello user, here are the current departments:");
            Console.WriteLine(" Please press enter...");
            Console.ReadLine();
            var depos = repo.GetAllDepartment();
            PrintDepos(depos);
 
            Console.WriteLine("What is the name your new Department?");
            string userResponse = Console.ReadLine();
            
            if(userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new Department??");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
                PrintDepos(repo.GetAllDepartment());

            }
            Console.WriteLine("Have a great day!");
            #endregion
        }
        private static void PrintDepos(IEnumerable<Department> depos)
        {

            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentId} Name: {depo.Name}");
            }
        }

        private static void PrintProduct(IEnumerable<Product> products)
        {
            foreach (var prod in products)
            {
                Console.WriteLine($"Id: {prod.ProductID} Name: {prod.Name}");

            }
        }
    }
}
