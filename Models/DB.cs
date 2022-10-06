using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AuthenticationandAuthorization.Models;

namespace AuthenticationandAuthorization.Models
{
    public class DB
    {
        SqlConnection conn = new SqlConnection("Data Source=ADMIN-MACHINE-1;Initial Catalog=Authentication;Integrated Security=True");
        public int Login_checking(userlogin uslog)
        {
            SqlCommand com = new SqlCommand("Login", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Username", uslog.Username);
            com.Parameters.AddWithValue("@Password", uslog.Password);
            SqlParameter Ologin = new SqlParameter();
            Ologin.ParameterName = "@Isvalid";
            Ologin.SqlDbType = SqlDbType.Bit;
            Ologin.Direction = ParameterDirection.Output;
            com.Parameters.Add(Ologin);

            conn.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(Ologin.Value);
            conn.Close();
            return res;
        }
    }
}
