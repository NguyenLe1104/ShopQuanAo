using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

namespace QuanLiShopQuanAo.Views.Admin
{
    public partial class Nhanvien : Page
    {
        private Models.DBClass myCon;

        protected void Page_Load(object sender, EventArgs e)
        {
            myCon = new Models.DBClass();
            if (!IsPostBack)
            {
                ShowNhanVien();
            }
        }

        private void ShowNhanVien()
        {
            string Query = "SELECT * FROM dbo.Nhanvien";
            NhanVienList.DataSource = myCon.GetData(Query);
            NhanVienList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Manhanvien.Value) || Gioitinh.SelectedIndex == -1 || Diachi.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Không có dữ liệu ";
                }
                else
                {
                    string Ma = Manhanvien.Value;
                    string Ten = Tennhanvien.Value;
                    string GioitinhNV = Gioitinh.SelectedValue;
                    string DiachiNV = Diachi.SelectedValue;
                    string DienthoaiNV = Dienthoai.Value;
                    string NgaysinhNV = Ngaysinh.Value;

                    DateTime ngaySinh;
                    if (DateTime.TryParseExact(NgaysinhNV, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                    {
                        string NgaysinhFormatted = ngaySinh.ToString("yyyy-MM-dd");

                        string Query = "INSERT INTO dbo.Nhanvien VALUES (@Ma, @Ten, @Gioitinh, @Diachi, @Dienthoai, @Ngaysinh)";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@Ma", Ma),
                    new SqlParameter("@Ten", Ten),
                    new SqlParameter("@Gioitinh", GioitinhNV),
                    new SqlParameter("@Diachi", DiachiNV),
                    new SqlParameter("@Dienthoai", DienthoaiNV),
                    new SqlParameter("@Ngaysinh", NgaysinhFormatted)
                        };

                        myCon.SetData(Query, parameters);
                        ShowNhanVien();
                        ErrMsg.Text = "Đã thêm thành công";
                        Manhanvien.Value = "";
                        Tennhanvien.Value = "";
                        Gioitinh.SelectedIndex = -1;
                        Diachi.SelectedIndex = -1;
                        Dienthoai.Value = "";
                        Ngaysinh.Value = "";

                    }
                    else
                    {
                        ErrMsg.Text = "Dữ liệu không hợp lệ. Vui lòng nhập theo dạng dd/MM/yyyy .";
                    }
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void NhanVienList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manhanvien.Value = NhanVienList.SelectedRow.Cells[1].Text;
            Tennhanvien.Value = NhanVienList.SelectedRow.Cells[2].Text;
            Gioitinh.SelectedValue = NhanVienList.SelectedRow.Cells[3].Text;
            Diachi.SelectedValue = NhanVienList.SelectedRow.Cells[4].Text;
            Dienthoai.Value = NhanVienList.SelectedRow.Cells[5].Text;
            Ngaysinh.Value = NhanVienList.SelectedRow.Cells[6].Text;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Manhanvien.Value) || Gioitinh.SelectedIndex == -1 || Diachi.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Không thấy dữ liệu ";
                }
                else
                {
                    string Ma = Manhanvien.Value;
                    string Ten = Tennhanvien.Value;
                    string GioitinhNV = Gioitinh.SelectedValue;
                    string DiachiNV = Diachi.SelectedValue;
                    string DienthoaiNV = Dienthoai.Value;
                    string NgaysinhNV = Ngaysinh.Value;

                    DateTime ngaySinh;
                    if (DateTime.TryParseExact(NgaysinhNV, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                    {
                        string NgaysinhFormatted = ngaySinh.ToString("yyyy-MM-dd");

                        string Query = "UPDATE dbo.Nhanvien SET Tennhanvien = @Ten, Gioitinh = @Gioitinh, Diachi = @Diachi, Dienthoai = @Dienthoai, Ngaysinh = @Ngaysinh WHERE Manhanvien = @Ma";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@Ma", Ma),
                    new SqlParameter("@Ten", Ten),
                    new SqlParameter("@Gioitinh", GioitinhNV),
                    new SqlParameter("@Diachi", DiachiNV),
                    new SqlParameter("@Dienthoai", DienthoaiNV),
                    new SqlParameter("@Ngaysinh", NgaysinhFormatted)
                        };

                        myCon.SetData(Query, parameters);
                        ShowNhanVien();
                        ErrMsg.Text = "Đã cập nhật thành công";
                        Manhanvien.Value = "";
                        Tennhanvien.Value = "";
                        Gioitinh.SelectedIndex = -1;
                        Diachi.SelectedIndex = -1;
                        Dienthoai.Value = "";
                        Ngaysinh.Value = "";
                    }
                    else
                    {
                        ErrMsg.Text = "Dữ liệu không hợp lệ. Vui lòng nhập theo dạng dd/MM/yyyy .";
                    }
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
                if (string.IsNullOrEmpty(Manhanvien.Value) || Gioitinh.SelectedIndex == -1 || Diachi.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Chọn một nhân viên";
                }
                else
                {
                    string Ma = Manhanvien.Value;

                    string deleteHDBanQuery = "DELETE FROM dbo.HDBan WHERE Manhanvien = @Ma";
                    SqlParameter[] deleteHDBanParameters = new SqlParameter[]
                    {
            new SqlParameter("@Ma", Ma),
                    };
                    myCon.SetData(deleteHDBanQuery, deleteHDBanParameters);

                    string Query = "DELETE FROM dbo.Nhanvien WHERE Manhanvien = @Ma";
                    SqlParameter[] Parameters = new SqlParameter[]
                    {
            new SqlParameter("@Ma", Ma),
                    };
                    myCon.SetData(Query, Parameters);

                    ShowNhanVien();
                    ErrMsg.Text = "Đã xóa thành công";
                    Manhanvien.Value = "";
                    Tennhanvien.Value = "";
                    Gioitinh.SelectedIndex = -1;
                    Diachi.SelectedIndex = -1;
                    Dienthoai.Value = "";
                    Ngaysinh.Value = "";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }

        }
    }
}


