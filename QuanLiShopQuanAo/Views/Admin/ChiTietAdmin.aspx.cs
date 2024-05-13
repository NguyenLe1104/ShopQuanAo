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

namespace QuanLiShopQuanAo.Views.Admin
{
    public partial class ChiTietAdmin : System.Web.UI.Page
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
                using (SqlCommand myCmd = new SqlCommand("[dbo].[getQuanAo1]", myCon))
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
                            TbSoluong.Text = myDr.GetValue(6).ToString();
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

        protected void CloseBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrangChu.aspx");
        }
    }

}