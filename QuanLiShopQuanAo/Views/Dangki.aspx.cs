using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace QuanLiShopQuanAo.Views
{
    public partial class Dangki : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Dangki_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrEmpty(UnameNb.Value) || string.IsNullOrEmpty(PasswordNb.Value) || string.IsNullOrEmpty(HovatenNb.Value) || string.IsNullOrEmpty(DiachiNb.Value) || string.IsNullOrEmpty(SdtNb.Value))
            {
                ErrMsg.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            
            string connectionString = ConfigurationManager.ConnectionStrings["Connections"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                ErrMsg.Text = "Chuỗi kết nối đến cơ sở dữ liệu không hợp lệ!";
                return;
            }

            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                string qry = "INSERT INTO dbo.Nguoidung (Username, Password) VALUES (@Username, @Password);" +
                             "INSERT INTO dbo.Khach (Tenkhach, Diachi, Dienthoai) VALUES (@Tenkhach, @Diachi, @Dienthoai);";

                using (SqlCommand command = new SqlCommand(qry, myCon))
                {
                    command.Parameters.AddWithValue("@Username", UnameNb.Value);
                    command.Parameters.AddWithValue("@Password", PasswordNb.Value);
                    command.Parameters.AddWithValue("@Tenkhach", HovatenNb.Value);
                    command.Parameters.AddWithValue("@Diachi", DiachiNb.Value);
                    command.Parameters.AddWithValue("@Dienthoai", SdtNb.Value);

                    try
                    {
                        myCon.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ErrMsg.Text = "Đăng ký thành công!";
                        }
                        else
                        {
                            ErrMsg.Text = "Đăng ký thất bại!";
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrMsg.Text = "Đã xảy ra lỗi: " + ex.Message;
                    }
                }
            }
        }

        protected void Dangnhap_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
