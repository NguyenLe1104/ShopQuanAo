using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiShopQuanAo.Views.Admin
{
    public partial class Nguoidung : System.Web.UI.Page
    {
        private Models.DBClass myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            myCon = new Models.DBClass();
            if (!IsPostBack)
            {
                ShowNguoiDung();
            }
        }

        private void ShowNguoiDung()
        {
            string query = "SELECT * FROM dbo.Nguoidung";
            NguoiDungList.DataSource = myCon.GetData(query);
            NguoiDungList.DataBind();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Usernamend.Value) || string.IsNullOrEmpty(Passwordnd.Value))
                {
                    ErrMsg.Text = "Không có dữ liệu";
                }
                else
                {
                    string username = Usernamend.Value;
                    string pass = Passwordnd.Value;

                    // Kiểm tra xem username đã tồn tại trong cơ sở dữ liệu chưa
                    string checkQuery = "SELECT COUNT(*) FROM dbo.Nguoidung WHERE Username = @Username";
                    SqlParameter[] checkParameters = new SqlParameter[]
                    {
                new SqlParameter("@Username", username)
                    };

                    int existingUserCount = Convert.ToInt32(myCon.GetDataScalar(checkQuery, checkParameters));

                    if (existingUserCount > 0)
                    {
                        // Username đã tồn tại, hiển thị thông báo lỗi cho người dùng
                        ErrMsg.Text = "Tên người dùng đã tồn tại.";
                    }
                    else
                    {
                        // Username chưa tồn tại, tiếp tục thêm dữ liệu vào cơ sở dữ liệu
                        string insertQuery = "INSERT INTO dbo.Nguoidung (Username, Password) VALUES (@Username, @Password)";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", pass)
                        };

                        myCon.SetData(insertQuery, parameters);
                        ShowNguoiDung();
                        ErrMsg.Text = "Đã thêm thành công";
                        this.Usernamend.Value = "";
                        this.Passwordnd.Value = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }


        protected void NguoiDungList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Usernamend.Value = NguoiDungList.SelectedRow.Cells[1].Text;
            Passwordnd.Value = NguoiDungList.SelectedRow.Cells[2].Text;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Usernamend.Value) || string.IsNullOrEmpty(Passwordnd.Value))
                {
                    ErrMsg.Text = "Không có dữ liệu ";
                }
                else
                {
                    string username = Usernamend.Value;
                    string pass = Passwordnd.Value;

                    string query = "UPDATE dbo.Nguoidung SET   [Password] = @pass where Username = @username";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@username", username),
                new SqlParameter("@pass", pass)
                    };

                    myCon.SetData(query, parameters);
                    ShowNguoiDung();
                    ErrMsg.Text = "Đã cập nhật thành công";
                    Usernamend.Value = "";
                    Passwordnd.Value = "";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }



        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Usernamend.Value))
                {
                    ErrMsg.Text = "Chọn một người dùng muốn xóa ";
                }
                else
                {
                    string username = this.Usernamend.Value;

                    string deleteQuery = "DELETE FROM dbo.Nguoidung WHERE Username = @username";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@username", username)
                    };

                    myCon.SetData(deleteQuery, parameters);

                    ShowNguoiDung();

                    ErrMsg.Text = "Đã xóa người dùng thành công";
                    this.Usernamend.Value = "";
                    this.Passwordnd.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}