using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace QuanLiShopQuanAo.Views.Admin
{
    public partial class Clothes : System.Web.UI.Page
    {
        private Models.DBClass myCon;

        protected void Page_Load(object sender, EventArgs e)
        {
            myCon = new Models.DBClass();
            if (!IsPostBack)
            {
                ShowClothes();
            }
        }

        private void ShowClothes()
        {
            string query = "SELECT * FROM dbo.Hang";
            ClothesList.DataSource = myCon.GetData(query);
            ClothesList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MaQuanAoC.Value))
                {
                    ErrMsg.Text = "Không có dữ liệu";
                }
                else
                {
                    string Mahang = MaQuanAoC.Value;
                    string Manhom = MaNhomC.Value;
                    string Ten = TenQuanAoC.Value;
                    string Machatlieu = MaChatLieuC.Value;
                    string Soluong = SoluongC.Value;
                    string Dongianhap = GiaNhapC.Value;
                    string Dongiaban = GiaBanC.Value;
                    string Anh = HinhAnhC.Value;
                    string GhiChu = GhiChuC.Value;

                    string Query = "INSERT INTO dbo.Hang VALUES (@Mahang,@Manhom, @Ten, @Machatlieu, @Soluong,@Dongianhap,@Dongiaban,@Anh,@Ghichu)";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Mahang", Mahang),
                        new SqlParameter("@Manhom", Manhom),
                        new SqlParameter("@Ten", Ten),
                        new SqlParameter("@Machatlieu", Machatlieu),
                        new SqlParameter("@Soluong", Soluong),
                        new SqlParameter("@Dongianhap", Dongianhap),
                        new SqlParameter("@Dongiaban", Dongiaban),
                        new SqlParameter("@Anh", Anh),
                        new SqlParameter("@Ghichu", GhiChu),
                    };

                    myCon.SetData(Query, parameters);
                    ShowClothes();
                    ErrMsg.Text = "Đã thêm thành công";
                    MaQuanAoC.Value = "";
                    MaNhomC.Value = "";
                    TenQuanAoC.Value = "";
                    MaChatLieuC.Value = "";
                    SoluongC.Value = "";
                    GiaNhapC.Value = "";
                    GiaBanC.Value = "";
                    HinhAnhC.Value = "";
                    GhiChuC.Value = "";

                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MaQuanAoC.Value))
                {
                    ErrMsg.Text = "Không có dữ liệu";
                }
                else
                {
                    string Mahang = MaQuanAoC.Value;
                    string Manhom = MaNhomC.Value;
                    string Ten = TenQuanAoC.Value;
                    string Machatlieu = MaChatLieuC.Value;
                    string Soluong = SoluongC.Value;
                    string Dongianhap = GiaNhapC.Value;
                    string Dongiaban = GiaBanC.Value;
                    string Anh = HinhAnhC.Value;
                    string GhiChu = GhiChuC.Value;

                    string query = "UPDATE dbo.Hang SET Manhom = @Manhom, Tenhang = @Ten, Machatlieu = @Machatlieu, " +
                                   "Soluong = @Soluong, Dongianhap = @Dongianhap, Dongiaban = @Dongiaban, Anh = @Anh, Ghichu = @GhiChu " +
                                   "WHERE Mahang = @Mahang";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Mahang", Mahang),
                        new SqlParameter("@Manhom", Manhom),
                        new SqlParameter("@Ten", Ten),
                        new SqlParameter("@Machatlieu", Machatlieu),
                        new SqlParameter("@Soluong", Soluong),
                        new SqlParameter("@Dongianhap", Dongianhap),
                        new SqlParameter("@Dongiaban", Dongiaban),
                        new SqlParameter("@Anh", Anh),
                        new SqlParameter("@GhiChu", GhiChu),
                    };

                    myCon.SetData(query, parameters);
                    ShowClothes();
                    ErrMsg.Text = "Đã cập nhật thành công";
                    MaQuanAoC.Value = "";
                    MaNhomC.Value = "";
                    TenQuanAoC.Value = "";
                    MaChatLieuC.Value = "";
                    SoluongC.Value = "";
                    GiaNhapC.Value = "";
                    GiaBanC.Value = "";
                    HinhAnhC.Value = "";
                    GhiChuC.Value = "";

                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void ClothesList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow selectedRow = ClothesList.SelectedRow;
            if (selectedRow != null)
            {
                MaQuanAoC.Value = selectedRow.Cells[1].Text;
                MaNhomC.Value = selectedRow.Cells[2].Text;
                TenQuanAoC.Value = selectedRow.Cells[3].Text;
                MaChatLieuC.Value = selectedRow.Cells[4].Text;
                SoluongC.Value = selectedRow.Cells[5].Text;
                GiaNhapC.Value = selectedRow.Cells[6].Text;
                GiaBanC.Value = selectedRow.Cells[7].Text;
                GhiChuC.Value = selectedRow.Cells[9].Text;
            }
        }


        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MaQuanAoC.Value))
                {
                    ErrMsg.Text = "Chọn một quần áo muốn xóa ";
                }
                else
                {
                    string Mahang = MaQuanAoC.Value;

                    // Kiểm tra xem có bất kỳ bản ghi nào trong bảng "ChiTietHDBan" tham chiếu đến bản ghi bạn muốn xóa từ bảng "Hang" hay không
                    string checkChiTietHDBanQuery = "SELECT COUNT(*) FROM dbo.ChiTietHDBan WHERE Mahang IN (SELECT Mahang FROM dbo.Hang WHERE Mahang = @Mahang)";
                    SqlParameter[] checkChiTietHDBanParameters = new SqlParameter[]
                    {
                        new SqlParameter("@Mahang", Mahang),
                    };


                    // Nếu không có, tiến hành xóa các bản ghi trong bảng "ChiTietHDBan" tham chiếu đến bản ghi bạn muốn xóa từ bảng "Hang"
                    string deleteChiTietHDBanQuery = "DELETE FROM dbo.ChiTietHDBan WHERE Mahang IN (SELECT Mahang FROM dbo.Hang WHERE Mahang = @Mahang)";
                    myCon.SetData(deleteChiTietHDBanQuery, checkChiTietHDBanParameters);

                    // Sau đó, xóa bản ghi trong bảng "Hang"
                    string deleteHangQuery = "DELETE FROM dbo.Hang WHERE Mahang = @Mahang";
                    myCon.SetData(deleteHangQuery, checkChiTietHDBanParameters);

                    // Cuối cùng, xóa bản ghi trong bảng "Chatlieu"
                    string deleteChatlieuQuery = "DELETE FROM dbo.Chatlieu WHERE MaChatLieu = (SELECT Machatlieu FROM dbo.Hang WHERE Mahang = @Mahang)";
                    myCon.SetData(deleteChatlieuQuery, checkChiTietHDBanParameters);

                    // Cập nhật lại danh sách quần áo trong GridView
                    ShowClothes();

                    // Hiển thị thông báo xóa thành công
                    ErrMsg.Text = "Đã xóa quần áo thành công";
                    MaQuanAoC.Value = "";
                    MaNhomC.Value = "";
                    TenQuanAoC.Value = "";
                    MaChatLieuC.Value = "";
                    SoluongC.Value = "";
                    GiaNhapC.Value = "";
                    GiaBanC.Value = "";
                    HinhAnhC.Value = "";
                    GhiChuC.Value = "";
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
