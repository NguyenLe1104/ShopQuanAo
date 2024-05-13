using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiShopQuanAo.Views.Admin
{
    public partial class Chatlieu : Page
    {
        private Models.DBClass myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            myCon = new Models.DBClass();
            if (!IsPostBack)
            {
                ShowChatlieu();
            }
        }
        private void ShowChatlieu()
        {
            string Query = "SELECT * FROM dbo.Chatlieu";
            ChatlieuList.DataSource = myCon.GetData(Query);
            ChatlieuList.DataBind();
        }


        protected void saveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(MachatlieuN.Value) || string.IsNullOrEmpty(Tenchatlieu.Value))
                {
                    ErrMsg.Text = "Không có dữ liệu ";
                }
                else
                {
                    string Ma = MachatlieuN.Value;
                    string Ten = Tenchatlieu.Value;

                    string Query = "INSERT INTO dbo.Chatlieu VALUES (@Ma, @Ten)";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                                new SqlParameter("@Ma", Ma),
                                new SqlParameter("@Ten", Ten)
                    };

                    myCon.SetData(Query, parameters);
                    ShowChatlieu();
                    ErrMsg.Text = "Đã thêm thành công";
                    MachatlieuN.Value = "";
                    Tenchatlieu.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void ChatlieuList_SelectedIndexChanged1(object sender, EventArgs e)
        {

            MachatlieuN.Value = ChatlieuList.SelectedRow.Cells[1].Text;
            Tenchatlieu.Value = ChatlieuList.SelectedRow.Cells[2].Text;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MachatlieuN.Value) || string.IsNullOrEmpty(Tenchatlieu.Value))
                {
                    ErrMsg.Text = "Không có dữ liệu ";
                }
                else
                {
                    string Ma = MachatlieuN.Value;
                    string Ten = Tenchatlieu.Value;

                    string Query = "UPDATE dbo.Chatlieu SET Tenchatlieu = @Ten WHERE Machatlieu = @Ma";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                                new SqlParameter("@Ma", Ma),
                                new SqlParameter("@Ten", Ten)
                    };

                    myCon.SetData(Query, parameters);
                    ShowChatlieu();
                    ErrMsg.Text = "Đã cập nhật thành công";
                    MachatlieuN.Value = "";
                    Tenchatlieu.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MachatlieuN.Value))
                {
                    ErrMsg.Text = "Chọn một chất liệu muốn xóa ";
                }
                else
                {
                    string Ma = MachatlieuN.Value;

                    // Kiểm tra xem có bất kỳ bản ghi nào trong bảng "ChiTietHDBan" tham chiếu đến bản ghi bạn muốn xóa từ bảng "Hang" hay không
                    string checkChiTietHDBanQuery = "SELECT COUNT(*) FROM dbo.ChiTietHDBan WHERE Mahang IN (SELECT Mahang FROM dbo.Hang WHERE Machatlieu = @Ma)";
                    SqlParameter[] checkChiTietHDBanParameters = new SqlParameter[]
                    {
                new SqlParameter("@Ma", Ma),
                    };


                    // Nếu không có, tiến hành xóa các bản ghi trong bảng "ChiTietHDBan" tham chiếu đến bản ghi bạn muốn xóa từ bảng "Hang"
                    string deleteChiTietHDBanQuery = "DELETE FROM dbo.ChiTietHDBan WHERE Mahang IN (SELECT Mahang FROM dbo.Hang WHERE Machatlieu = @Ma)";
                    myCon.SetData(deleteChiTietHDBanQuery, checkChiTietHDBanParameters);

                    // Sau đó, xóa bản ghi trong bảng "Hang"
                    string deleteHangQuery = "DELETE FROM dbo.Hang WHERE Machatlieu = @Ma";
                    myCon.SetData(deleteHangQuery, checkChiTietHDBanParameters);

                    // Cuối cùng, xóa bản ghi trong bảng "Chatlieu"
                    string deleteChatlieuQuery = "DELETE FROM dbo.Chatlieu WHERE Machatlieu = @Ma";
                    myCon.SetData(deleteChatlieuQuery, checkChiTietHDBanParameters);

                    // Cập nhật lại danh sách chất liệu trong GridView
                    ShowChatlieu();

                    // Hiển thị thông báo xóa thành công
                    ErrMsg.Text = "Đã xóa chất liệu thành công";
                    MachatlieuN.Value = "";
                    Tenchatlieu.Value = "";
                }

            }
            catch (Exception Ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                ErrMsg.Text = Ex.Message;
            }
        }


    }
}

