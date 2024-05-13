using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace QuanLiShopQuanAo.Views.Admin
{
    public partial class BanHang : System.Web.UI.Page
    {
        private Models.DBClass myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            myCon = new Models.DBClass();
            if (!IsPostBack)
            {
                ShowBanHang();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("ID"),
                    new DataColumn("Clothes"),
                    new DataColumn("Chat Lieu"),
                    new DataColumn("So Luong"),
                    new DataColumn("Gia")
                }
                );
                ViewState["HoaDon"] = dt;
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            HoadonList.DataSource = ViewState["HoaDon"];
            HoadonList.DataBind();
        }
        private void ShowBanHang()
        {
            string Query = "SELECT * FROM dbo.Hang";
            BanHangList.DataSource = myCon.GetData(Query);
            BanHangList.DataBind();
        }
        protected void BanHangList_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}