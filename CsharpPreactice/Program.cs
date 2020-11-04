using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CsharpPreactice
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConnection = @"server = DESKTOP-7TC9CTO\SQLEXPRESS;database = CustomersInfo; Integrated Security=True";
            string strRequete = "SELECT CategoryID, CategoryName FROM Categories;";
            try
            {
                SqlConnection con = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(strRequete,con);
                con.Open();
                SqlDataReader oRead = command.ExecuteReader();
                Console.WriteLine("\t {0} \t {1}", oRead.GetName(0),oRead.GetName(1));
                Console.WriteLine();
                while (oRead.Read())
                {
                    Console.WriteLine("\t {0} \t {1}", oRead.GetInt32(0), oRead.GetString(1));
                }
                Console.ReadKey();
                oRead.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
