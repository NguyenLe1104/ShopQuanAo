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
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        int ID;
        SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connections"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTen.Text = "";
                lblChatlieu.Text = "";
                lblGia.Text = "";
                lblMota.Text = "";
                if (Request.QueryString["ID"] != null)
                {
                    var ma = Request.QueryString["ID"].ToString();
                    if (int.TryParse(ma, out ID))
                    {
                        getQuanAo(ID);
                    }
                }
            }
        }
        private void getQuanAo(int ID)
        {
            try
            {
                myCon.Open();
                using (SqlCommand myCmd = new SqlCommand("[dbo].[getQuanAo]", myCon))
                {
                    myCmd.Connection = myCon;
                    myCmd.CommandType = CommandType.StoredProcedure;
                    myCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                    SqlDataReader myDr = myCmd.ExecuteReader();
                    if (myDr.HasRows)
                    {
                        while (myDr.Read())
                        {
                            lblTen.Text = myDr.GetValue(1).ToString();
                            lblChatlieu.Text = myDr.GetValue(2).ToString();
                            lblGia.Text = myDr.GetValue(3).ToString();
                            lblMota.Text = myDr.GetValue(4).ToString();
                            Image1.ImageUrl = "~/Assets/Images/" + myDr.GetValue(5).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myCon.Close();
            }
        }

        protected void DathangBtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int productID = Convert.ToInt32(Request.QueryString["ID"]);
                string productName = lblTen.Text;
                string productCL = lblChatlieu.Text;
                decimal productPrice = Convert.ToDecimal(lblGia.Text);
                int quantity;

                // Kiểm tra xem người dùng đã nhập số lượng chưa
                if (!int.TryParse(TbSoluong.Text, out quantity) || quantity <= 0)
                {
                    // Nếu số lượng không hợp lệ, hiển thị thông báo
                    ErrorMessage.InnerHtml = "Vui lòng nhập số lượng sản phẩm.";
                    return;
                }
                else
                {
                    ErrorMessage.InnerHtml = ""; // Xóa thông báo nếu số lượng hợp lệ
                }

                string Note = lblMota.Text;
                string productImage = Image1.ImageUrl; // Lấy đường dẫn ảnh sản phẩm

                // Kiểm tra sản phẩm đã tồn tại trong giỏ hàng chưa
                bool existsInCart = false;
                foreach (DataRow row in DBClass.tbGioHang.Rows)
                {
                    if (Convert.ToInt32(row["Mahang"]) == productID)
                    {
                        existsInCart = true;
                        // Cập nhật số lượng
                        row["Soluong"] = Convert.ToInt32(row["Soluong"]) + quantity;
                        break;
                    }
                }

                // Nếu sản phẩm chưa tồn tại trong giỏ hàng, thêm mới
                if (!existsInCart)
                {
                    DataRow newRow = DBClass.tbGioHang.NewRow();
                    newRow["Anh"] = productImage;
                     // Thêm đường dẫn ảnh sản phẩm vào giỏ hàng
                    newRow["Mahang"] = productID;
                    newRow["Tenhang"] = productName;
                    newRow["Machatlieu"] = productCL;
                    newRow["Dongia"] = productPrice;
                    newRow["Soluong"] = quantity;
                    newRow["Ghichu"] = Note;

                    DBClass.tbGioHang.Rows.Add(newRow);
                }

                // Cập nhật giỏ hàng trong Session
                Session["GioHang"] = DBClass.tbGioHang;

                // Chuyển hướng đến trang giỏ hàng
                Response.Redirect("GioHang.aspx");
            }
        }


        protected void CloseBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuanAo.aspx");
        }
    }
}