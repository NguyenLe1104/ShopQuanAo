using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiShopQuanAo.Models
{

    public class DBClass
    {
        public static DataTable tbGioHang = new DataTable();
        private SqlConnection myCon;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;
        public DBClass()
        {
            ConStr = @"Data Source=LAPTOP-L79SRQNF\SQLEXPRESS;Initial Catalog=ShopQuanAo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            myCon = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = myCon;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }
        public int SetData(string Query, SqlParameter[] parameters)
        {
            int cnt = 0;
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            cmd.CommandText = Query;
            cmd.Parameters.AddRange(parameters); // Thêm các tham số vào câu lệnh SQL
            cnt = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear(); // Xóa các tham số sau khi thực thi câu lệnh
            myCon.Close();
            return cnt;
        }
        public object GetDataScalar(string Query, SqlParameter[] parameters)
        {
            object result = null;
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            cmd.CommandText = Query;
            cmd.Parameters.AddRange(parameters); // Thêm các tham số vào câu lệnh SQL
            result = cmd.ExecuteScalar();
            cmd.Parameters.Clear(); // Xóa các tham số sau khi thực thi câu lệnh
            myCon.Close();
            return result;
        }


    }
}