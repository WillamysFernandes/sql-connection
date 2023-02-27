using System;
using System.Data.SqlClient;

namespace sqlConnection
{
    class Program
    {
        static void Main(string[] args)
        {
             
            var _connnection="Data Source=DESKTOP-8U0OIEV\\SQLEXPRESS1;Initial Catalog=projetinho;Integrated Security=True";
            //                             nome do servidor                     nome do banco  
            using (var con = new SqlConnection(_connnection))

            {
                con.Open();
                using(var command = new SqlCommand()){
                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT[nome] FROM [teste]";

                    var reader = command.ExecuteReader();
                    while (reader.Read())

                    {
                        Console.WriteLine($"{reader.GetString(0)}");    
                    }
                    

                }
                con.Close();
            }
        }
    }

}