<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Nhanvien.aspx.cs" Inherits="QuanLiShopQuanAo.Views.Admin.Nhanvien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
      <div class="container-fluid">
        <div class="row">
            <div class="col">
                 <h3 class="text-center">Quan Li Shop Quan Ao</h3>   </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
        <label for="" class="form-label text-success">Ma Nhan Vien</label>
        <input type="text"  placeholder="Title" autocomplete="off" class="form-control" runat="server" id="Manhanvien"/>
                </div>
                <div class="mb-3">
        <label for="" class="form-label text-success">Ten Nhan Vien</label>
        <input type="text"  placeholder="Title" autocomplete="off" class="form-control" runat="server" id="Tennhanvien"/>
                </div>
                  <div class="mb-3">
        <label for="" class="form-label text-success">Gioi Tinh</label>
        <asp:DropDownList  runat="server" class="form-control" ID="Gioitinh">
                     <asp:ListItem>Nam</asp:ListItem>
                      <asp:ListItem>Nu</asp:ListItem>
        </asp:DropDownList>
                </div>
                
                   <div class="mb-3">
        <label for="" class="form-label text-success">Dia Chi</label>
                       <asp:DropDownList ID="Diachi" runat="server" class="form-control" >
                          <asp:ListItem>Thanh Khe</asp:ListItem>
                          <asp:ListItem>Hai Chau</asp:ListItem>
                          <asp:ListItem>Son Tra</asp:ListItem>
                          <asp:ListItem>Ngu Hanh Son</asp:ListItem>
                          <asp:ListItem>Hoa Vang</asp:ListItem>
                          <asp:ListItem>Hoa Khanh</asp:ListItem>
                       </asp:DropDownList>
                       </div>
                   <div class="mb-3">
        <label for="" class="form-label text-success">Dien Thoai</label>
        <input type="text"  placeholder="Title" autocomplete="off" class="form-control" runat="server" id="Dienthoai"/>
                </div>
                 <div class="mb-3">

        <label for="" class="form-label text-success">Ngay Sinh</label>
        <input type="text"  placeholder="Ngay sinh (dd/MM/yyyy)" autocomplete="off" class="form-control" runat="server" id="Ngaysinh"/>
                </div>
                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"> </asp:Label>
                    <div class="col d-grid"> <asp:Button Text="Update"  runat="server" ID="UpdateBtn" class="btn-warning btn-block btn" OnClick="UpdateBtn_Click" /></div>
                    <div class="col d-grid"> <asp:Button Text="Save"  runat="server" ID="SaveBtn" class="btn-success btn-block btn" OnClick="SaveBtn_Click" /></div>
                    <div class="col d-grid"> <asp:Button Text="Delete"  runat="server" ID="DeleteBtn" class="btn-danger btn-block btn" OnClick="DeleteBtn_Click" /></div>
                </div>
            </div>
            <div class="col-md-8">
                         <asp:GridView ID="NhanVienList" runat="server"  Width="849px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" AutoGenerateSelectButton="True" OnSelectedIndexChanged="NhanVienList_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Manhanvien" HeaderText="Mã nhân viên" />
                    <asp:BoundField DataField="Tennhanvien" HeaderText="Tên nhân viên" />
                    <asp:BoundField DataField="Gioitinh" HeaderText="Giới tính" />
                    <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" />
                    <asp:BoundField DataField="Dienthoai" HeaderText="Điện thoại" />
                    <asp:BoundField DataField="Ngaysinh" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}" /> 
                </Columns>
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="teal" Font-Bold="false" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>



