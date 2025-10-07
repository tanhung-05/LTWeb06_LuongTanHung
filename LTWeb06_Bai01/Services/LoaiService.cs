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
    public class LoaiService
    {
        static string connectStr = ConfigurationManager.ConnectionStrings["QLSP"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectStr);

        public List<Loai> GetLoaiAll()
        {
            SqlDataAdapter db = new SqlDataAdapter("Select * from tbl_Loai" ,conn);
            DataTable dt = new DataTable();
            db.Fill(dt);
            List<Loai> loaiList = new List<Loai>();
            foreach(DataRow dr in dt.Rows)
            {
                Loai loai = new Loai();
                loai.MaLoai = dr["MaLoai"].ToString();
                loai.TenLoai = dr["TenLoai"].ToString();
                loaiList.Add(loai);
            }

            return loaiList;
        }
    }
}