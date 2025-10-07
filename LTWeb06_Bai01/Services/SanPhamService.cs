using LTWeb06_Bai01.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LTWeb06_Bai01.Services
{
    public class SanPhamService
    {
        static string connectStr = ConfigurationManager.ConnectionStrings["QLSP"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectStr);

        public List<SanPham> GetSanPhamByLoai(string id)
        {
            string select = "Select * from tbl_SanPham where MaL = @MaL";
            SqlCommand cmd = new SqlCommand(select, conn);
            cmd.Parameters.AddWithValue("@MaL", id);
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            db.Fill(dt);
            List<SanPham> spList = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = dr["MaSanPham"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.MaL = dr["MaL"].ToString();
                sp.MaSX = dr["MaSX"].ToString();
                sp.Gia = decimal.Parse(dr["Gia"].ToString());
                sp.GhiChu = dr["GhiChu"].ToString();
                sp.Hinh = dr["Hinh"].ToString();
                spList.Add(sp);
            }

            return spList;
        }

        public SanPham GetSanPhamById(string id)
        {
            string select = "Select * from tbl_SanPham where MaSanPham = @MaSanPham";
            SqlCommand cmd = new SqlCommand(select, conn);
            cmd.Parameters.AddWithValue("@MaSanPham", id);
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            db.Fill(dt);
            DataRow dr = dt.Rows[0];
            SanPham sp = new SanPham();
            sp.MaSanPham = dr["MaSanPham"].ToString();
            sp.TenSP = dr["TenSP"].ToString();
            sp.MaL = dr["MaL"].ToString();
            sp.MaSX = dr["MaSX"].ToString();
            sp.Gia = decimal.Parse(dr["Gia"].ToString());
            sp.GhiChu = dr["GhiChu"].ToString();
            sp.Hinh = dr["Hinh"].ToString();

            return sp;
        }

        public List<SanPham> SearchSanPham(string maLoai, decimal? giaTu, decimal? giaDen)
        {
            List<SanPham> list = new List<SanPham>();

            using (SqlConnection conn = new SqlConnection(connectStr))
            {
                string sql = "SELECT * FROM tbl_SanPham WHERE 1=1";

                if (!string.IsNullOrEmpty(maLoai))
                    sql += " AND MaL = @MaL";

                if (giaTu.HasValue)
                    sql += " AND Gia >= @GiaTu";

                if (giaDen.HasValue)
                    sql += " AND Gia <= @GiaDen";

                SqlCommand cmd = new SqlCommand(sql, conn);

                if (!string.IsNullOrEmpty(maLoai))
                    cmd.Parameters.AddWithValue("@MaL", maLoai);

                if (giaTu.HasValue)
                    cmd.Parameters.AddWithValue("@GiaTu", giaTu.Value);

                if (giaDen.HasValue)
                    cmd.Parameters.AddWithValue("@GiaDen", giaDen.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    SanPham sp = new SanPham
                    {
                        MaSanPham = dr["MaSanPham"].ToString(),
                        TenSP = dr["TenSP"].ToString(),
                        MaL = dr["MaL"].ToString(),
                        MaSX = dr["MaSX"].ToString(),
                        Gia = dr["Gia"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Gia"]),
                        GhiChu = dr["GhiChu"].ToString(),
                        Hinh = dr["Hinh"].ToString()
                    };
                    list.Add(sp);
                }
            }

            return list;
        }
    }
 }