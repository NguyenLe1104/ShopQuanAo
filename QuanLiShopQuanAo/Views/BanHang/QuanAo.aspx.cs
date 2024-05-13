using QuanLiShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiShopQuanAo.Views.BanHang
{
    public partial class QuanAo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GioHang"] != null)
                {
                    DBClass.tbGioHang = Session["GioHang"] as DataTable;
                }
                else
                {
                    DBClass.tbGioHang.Rows.Clear();
                    DBClass.tbGioHang.Columns.Clear();
                    DBClass.tbGioHang.Columns.Add("Mahang", typeof(int));
                    DBClass.tbGioHang.Columns.Add("Tenhang", typeof(string));
                    DBClass.tbGioHang.Columns.Add("Machatlieu", typeof(string));
                    DBClass.tbGioHang.Columns.Add("Dongia", typeof(decimal));
                    DBClass.tbGioHang.Columns.Add("SoLuong", typeof(int));
                    DBClass.tbGioHang.Columns.Add("Ghichu", typeof(string));
                    // Thêm cột "Anh" vào DataTable
                    DBClass.tbGioHang.Columns.Add("Anh", typeof(string)); // Đường dẫn ảnh sản phẩm
                    DBClass.tbGioHang.Columns.Add("TongTien", typeof(decimal), "SoLuong * Dongia");
                }

                lbGiohang.Text = "Giỏ hàng (" + DBClass.tbGioHang.Rows.Count + ")";
                // Gán giá trị mặc định cho trang đầu tiên
                if (Session["CurrentPage"] == null)
                {
                    Session["CurrentPage"] = 1;
                }
                // Gọi phương thức BindDataToRepeater để gán dữ liệu cho repeater
                BindDataToRepeater();
            }
        }

        protected void lbGiohang_Click(object sender, EventArgs e)
        {
            Response.Redirect("Giohang.aspx");
        }
        protected void BindDataToRepeater()
        {
            int currentPage = Convert.ToInt32(Session["CurrentPage"]);
            int itemsPerPage = 6;
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = startIndex + itemsPerPage;

            string connectionString = ConfigurationManager.ConnectionStrings["Connections"].ConnectionString;
            string query = $"SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY Mahang) AS RowNum FROM Hang) AS HangWithRowNum WHERE RowNum > {startIndex} AND RowNum <= {endIndex}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Xử lý exception nếu có
                }

                rptProducts.DataSource = dataTable;
                rptProducts.DataBind();
                if (dataTable.Rows.Count  < 1)
                {
                    // Giảm trang hiện tại và gọi lại BindDataToRepeater()
                    currentPage--;
                    Session["CurrentPage"] = currentPage;
                    BindDataToRepeater();
                }

                // Ẩn nút "Next" nếu không có đủ dữ liệu để điền vào một trang đầy đủ
                btnNextPage.Visible = dataTable.Rows.Count >= itemsPerPage && dataTable.Rows.Count > 0;
            }
        }

        private int GetCurrentPageNumber()
        {
            return (int)(Session["CurrentPage"] ?? 1);
        }
        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(Session["CurrentPage"]);
            currentPage++;
            Session["CurrentPage"] = currentPage;
            BindDataToRepeater();
        }

        protected void btnBackPage_Click(object sender, EventArgs e)
        {
             int currentPage = GetCurrentPageNumber();
            if (currentPage > 1)
            {
                currentPage--;
                Session["CurrentPage"] = currentPage;
                BindDataToRepeater();
            }
        }
    }
}

