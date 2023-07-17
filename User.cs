using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Net;

namespace lesson11
{
    public static class User
    {
        public static string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=9511;Database=funcs";

        static public void Add()
        {
            try
            {
                // userId,  lastname,  password
                Console.WriteLine("[First Name] [Password]");
                string[] newClientInfo = Console.ReadLine().Split();
                var newClient = new UserProp( newClientInfo[0], newClientInfo[1]);
                using (var con = new NpgsqlConnection(connectionString))
                {
                    var sqlQuery = "INSERT INTO public.\"User\" (username, password) VALUES(@username, @password)";
                    con.Execute(sqlQuery, newClient);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong!!");
            }
        }

        static public void DeleteAll()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = "delete  from public.\"User\"";
                var s = connection.QueryFirstOrDefault(sqlQuery);
                if (s != null)
                {
                    Console.WriteLine("Not found to deleate");
                }
                else
                {
                    Console.WriteLine("Deleated");
                }
            }
        }

        static public void DeleteById(int userId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"delete  from public.\"User\" where userId = {userId}";
                var s = connection.QueryFirstOrDefault(sqlQuery);
                if (s != null)
                {
                    Console.WriteLine("Problem with ID");
                }
                else
                {
                    Console.WriteLine("Deleated");
                }
            }
        }

        static public void GetAll()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"select * from public.\"User\"";
                var s = connection.Query(sqlQuery);
                foreach (var item in s)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static public void GetById(int userId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"select * from public.\"User\" where userId = {userId}";
                var s = connection.Query(sqlQuery);
                foreach (var item in s)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}