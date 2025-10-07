using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LTWeb06_Bai01.Models;

namespace LTWeb06_Bai01.Services
{
    public class UserService
    {
        static string connect = ConfigurationManager.ConnectionStrings["QLSP"].ConnectionString;
        SqlConnection conn = new SqlConnection(connect);

        public List<User> GetAllUser(){
            SqlDataAdapter db = new SqlDataAdapter("Select * from tbl_KhachHang", conn);
            DataTable dt = new DataTable();
            db.Fill(dt);
            List<User> userList = new List<User>();
            foreach(DataRow dr in dt.Rows)
            {
                User user = new User();
                user.MaKhachHang = dr["MaKhachHang"].ToString();
                user.TenKhachHang = dr["TenKhachHang"].ToString();
                user.SoDienThoai = dr["SoDienThoai"].ToString();
                user.MatKhau = dr["MatKhau"].ToString();
                userList.Add(user);
            }

            return userList;
        }

        public User FindUserBySDT(string SDT)
        {
            string selectStr = "Select * from tbl_KhachHang where SoDienThoai = @SDT";
            SqlCommand cmd = new SqlCommand(selectStr, conn);
            cmd.Parameters.AddWithValue("@SDT", SDT);
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            db.Fill(dt);
            DataRow dr = dt.Rows[0];
            Console.WriteLine("Query trả về: " + dt.Rows.Count);
            User user = new User();
            user.MaKhachHang = dr["MaKhachHang"].ToString();
            user.TenKhachHang = dr["TenKhachHang"].ToString();
            user.SoDienThoai = dr["SoDienThoai"].ToString();
            user.MatKhau = dr["MatKhau"].ToString();

            return user;
        }
    }
}