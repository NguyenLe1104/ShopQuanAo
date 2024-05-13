
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiShopQuanAo.Views.Admin
{

    public partial class Khachhang : Page
    {
        private Models.DBClass myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            myCon = new Models.DBClass();
            if (!IsPostBack)
            {
                ShowKhachHang();
            }
        }
        private void ShowKhachHang()
        {
            string Query = "SELECT * FROM dbo.Khach";
            KhachHangList.DataSource = myCon.GetData(Query);
            KhachHangList.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TenKh.Value) || string.IsNullOrEmpty(DiachiKh.Value) || string.IsNullOrEmpty(SĐTKh.Value))
                {
                    ErrMsg.Text = "Vui lòng điền đầy đủ thông tin";
                }
                else
                {
                    string Ten = TenKh.Value;
                    string Diachi = DiachiKh.Value;
                    string Dienthoai = SĐTKh.Value;

                    string Query = "INSERT INTO dbo.Khach (Tenkhach, Diachi, Dienthoai) VALUES (@Ten, @Diachi, @Dienthoai)";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Ten", Ten),
                        new SqlParameter("@Diachi", Diachi),
                        new SqlParameter("@Dienthoai", Dienthoai),
                    };

                    myCon.SetData(Query, parameters);
                    ShowKhachHang();
                    ErrMsg.Text = "Đã thêm thành công";
                    MaKh.Value = "";
                    TenKh.Value = "";
                    DiachiKh.Value = "";
                    SĐTKh.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void KhachHangList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            MaKh.Value = KhachHangList.SelectedRow.Cells[1].Text;
            TenKh.Value = KhachHangList.SelectedRow.Cells[2].Text;
            DiachiKh.Value = KhachHangList.SelectedRow.Cells[3].Text;
            SĐTKh.Value = KhachHangList.SelectedRow.Cells[4].Text;
        }
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MaKh.Value))
                {
                    ErrMsg.Text = "Không thấy dữ liệu ";
                }
                else
                {
                    int Ma = int.Parse(MaKh.Value);
                    string Ten = TenKh.Value;
                    string Diachi = DiachiKh.Value;
                    string Dienthoai = SĐTKh.Value;


                    string Query = "UPDATE dbo.Khach SET Tenkhach = @Ten, Diachi = @Diachi, Dienthoai = @Dienthoai WHERE Makhach = @Ma";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                            new SqlParameter("@Ma", Ma),
                            new SqlParameter("@Ten", Ten),
                            new SqlParameter("@Diachi", Diachi),
                            new SqlParameter("@Dienthoai", Dienthoai),
                    };

                    myCon.SetData(Query, parameters);
                    ShowKhachHang();
                    ErrMsg.Text = "Đã cập nhật thành công";
                    MaKh.Value = "";
                    TenKh.Value = "";
                    DiachiKh.Value = "";
                    SĐTKh.Value = "";
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
                if (string.IsNullOrEmpty(MaKh.Value))
                {
                    ErrMsg.Text = "Chọn một nhân viên";
                }
                else
                {
                    int Ma = int.Parse(MaKh.Value);

                    // Xóa tất cả các hóa đơn liên quan đến khách hàng
                    string deleteHDBanQuery = "DELETE FROM dbo.HDBan WHERE Makhach = @Ma";
                    SqlParameter[] deleteHDBanParameters = new SqlParameter[]
                    {
                       new SqlParameter("@Ma", Ma),
                    };
                    myCon.SetData(deleteHDBanQuery, deleteHDBanParameters);

                    // Sau đó, xóa khách hàng
                    string Query = "DELETE FROM dbo.Khach WHERE Makhach = @Ma";
                    SqlParameter[] Parameters = new SqlParameter[]
                    {
                         new SqlParameter("@Ma", Ma),
                    };
                    myCon.SetData(Query, Parameters);

                    ShowKhachHang();
                    ErrMsg.Text = "Đã xóa thành công";
                    MaKh.Value = "";
                    TenKh.Value = "";
                    DiachiKh.Value = "";
                    SĐTKh.Value = "";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }

        }
    }
}
