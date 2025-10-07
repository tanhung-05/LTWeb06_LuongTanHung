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
    public class HoaDonService
    {
        static string connectStr = ConfigurationManager.ConnectionStrings["QLSP"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectStr);

        public List<HoaDon> GetHoaDonByUser(string id)
        {
            string select = "Select * from tbl_HoaDon where MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(select, conn);
            cmd.Parameters.AddWithValue("@MaKH", id);
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            db.Fill(dt);
            List<HoaDon> hdList = new List<HoaDon>();
            foreach (DataRow dr in dt.Rows)
            {
                HoaDon hd = new HoaDon();
                hd.MaHoaDon = dr["MaHoaDon"].ToString();
                hd.MaKH = dr["MaKH"].ToString();
                hd.NgayTao = DateTime.Parse(dr["NgayTao"].ToString());
                hdList.Add(hd);
            }

            return hdList;
        }

        public List<CTHoaDon> GetCTHoaDonByHoaDon(string id)
        {
            string select = "Select * from tbl_ChiTiet where MaHD = @MaHD";
            SqlCommand cmd = new SqlCommand(select, conn);
            cmd.Parameters.AddWithValue("@MaHD", id);
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            db.Fill(dt);
            List<CTHoaDon> cthdList = new List<CTHoaDon>();
            foreach (DataRow dr in dt.Rows)
            {
                CTHoaDon ct = new CTHoaDon();
                ct.MaHD = dr["MaHD"].ToString();
                ct.MaSP = dr["MaSP"].ToString();
                ct.SoLuong = int.Parse(dr["SoLuong"].ToString());
                cthdList.Add(ct);
            }

            return cthdList;
        }
    }
}