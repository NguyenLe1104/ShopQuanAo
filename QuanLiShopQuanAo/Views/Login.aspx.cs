using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace QuanLiShopQuanAo.Views
{
    public partial class Login : Page
    {
        private Models.DBClass myCon;

        protected void Page_Load(object sender, EventArgs e)
        {
            myCon = new Models.DBClass();
        }

        public static string Namenv = "";
        public static int User;

        protected void Dangnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Usermailname.Value) || string.IsNullOrWhiteSpace(Password.Value))
            {
                ErrMsg.Text = "Vui lòng nhập tên người dùng và mật khẩu!";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Connections"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                ErrMsg.Text = "kết nối đến cơ sở dữ liệu không hợp lệ!";
                return;
            }

            string qry = "SELECT * FROM Nguoidung WHERE Username=@Username AND Password=@Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(qry, connection);
                cmd.Parameters.AddWithValue("@Username", Usermailname.Value);
                cmd.Parameters.AddWithValue("@Password", Password.Value);

                try
                {
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        Session["Username"] = Usermailname.Value;
                        if (Usermailname.Value == "admin")
                        {
                            Response.Redirect("Admin/TrangChu.aspx");
                        }
                        else
                        {
                            Namenv = Usermailname.Value;
                            User = Convert.ToInt32(sdr["ID"]);
                            Response.Redirect("Banhang/QuanAo.aspx");
                        }
                    }
                    else
                    {
                        ErrMsg.Text = "Tài khoản hoặc mật khẩu không hợp lệ. Vui lòng thử lại!";
                    }
                }
                catch (Exception ex)
                {
                    ErrMsg.Text = "Đã xảy ra lỗi: " + ex.Message;
                }
            }
        }


        protected void Dangki_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dangki.aspx");
        }
    }
}
