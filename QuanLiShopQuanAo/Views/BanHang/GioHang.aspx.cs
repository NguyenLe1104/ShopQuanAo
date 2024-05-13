using QuanLiShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace QuanLiShopQuanAo.Views.BanHang
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hiển thị danh sách sản phẩm trong giỏ hàng
                GridView1.DataSource = DBClass.tbGioHang;
                GridView1.DataBind();
                // Tính tổng tiền và hiển thị
                Tinhtong();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Xóa sản phẩm khỏi giỏ hàng
            DBClass.tbGioHang.Rows[e.RowIndex].Delete();
            // Cập nhật lại giỏ hàng trong Session
            Session["GioHang"] = DBClass.tbGioHang;
            // Hiển thị lại giỏ hàng sau khi xóa
            GridView1.DataSource = DBClass.tbGioHang;
            GridView1.DataBind();
            // Tính tổng tiền và hiển thị
            Tinhtong();
        }
        private void Tinhtong()
        {
            decimal total = 0;
            foreach (DataRow row in DBClass.tbGioHang.Rows)
            {
                total += Convert.ToDecimal(row["TongTien"]);
            }
            Tongtien.Text ="Tổng cộng: " + total.ToString("### ### ###");
        }
        protected void btnDathang_Click(object sender, EventArgs e)
        {
            string username = (string)Session["Username"];
            if (string.IsNullOrEmpty(username) == true)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Viết tiếp chức năng TẠO ĐƠN HÀNG')", true);
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/BanHang/QuanAo.aspx");
        }

    }
}