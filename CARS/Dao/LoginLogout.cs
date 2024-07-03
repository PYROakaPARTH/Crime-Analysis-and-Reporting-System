using CARS.Exceptions;
using CARS.MainModule;
using CARS.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CARS.Dao.ICrimeAnalysisService;

namespace CARS.Dao
{
    public class LoginLogout
    {
        string ConString = PropertyUtil.getPropertyString();
        public void adminLogin(string username, string password)
        {
            string? getPassword = null;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT Password FROM adminLogin WHERE UserName ='{username}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        getPassword = reader["Password"].ToString();
                    }

                    if (getPassword == password)
                    {
                        Console.WriteLine("\nLogin successful!");
                        /*adminModule obj = new adminModule();
                        obj.adminMenu();*/

                        adminApp obj = new adminApp();
                        obj.adminOptions();
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect password!");
                    }
                }
                else
                {
                    Console.WriteLine();
                    throw new UserNameNotFoundException($"Username '{username}' not found!");
                }

                reader.Close();
            }
            catch (UserNameNotFoundException ex)
            {
                Console.WriteLine("UserNameNotFoundException caught: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }

        public void userLogin(string username, string password)
        {
            string? getPassword = null;
            SqlConnection con = new SqlConnection(ConString);
            string queryString = $"SELECT Password FROM userLogin WHERE UserName ='{username}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        getPassword = reader["Password"].ToString();
                    }

                    if (getPassword == password)
                    {
                        Console.WriteLine("\nLogin successful!");
                        /*adminModule obj = new adminModule();
                        obj.adminMenu();*/

                        userApp obj = new userApp();
                        obj.userOptions();
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect password!");
                    }
                }
                else
                {
                    Console.WriteLine();
                    throw new UserNameNotFoundException($"Username '{username}' not found!");
                }

                reader.Close();
            }
            catch (UserNameNotFoundException ex)
            {
                Console.WriteLine("UserNameNotFoundException caught: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }
    }
}
