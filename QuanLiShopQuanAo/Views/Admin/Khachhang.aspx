<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Khachhang.aspx.cs" Inherits="QuanLiShopQuanAo.Views.Admin.Khachhang" ValidateRequest="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                 <h3 class="text-center">Quản Lý Nhân Viên
                 </h3>   </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">Mã Khách Hàng</label>
                    <input type="text"  placeholder="Mã" autocomplete="off"  class="form-control" runat="server" id="MaKh"/>
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">Tên Khách Hàng</label>
                    <input type="text"  placeholder="Tên" autocomplete="off"  class="form-control" runat="server" id="TenKh"/>
                </div>
                 <div class="mb-3">
                    <label for="" class="form-label text-success">SĐT Khách Hàng</label>
                    <input type="text"  placeholder="SĐT Khách" autocomplete="off" class="form-control" runat="server" id="SĐTKh"/>
                </div>
                 <div class="mb-3">
        <label for="" class="form-label text-success">Địa Chỉ Khách Hàng</label>
            <input type="text"  placeholder="Địa chỉ khách hàng" autocomplete="off" class="form-control" runat="server" id="DiachiKh"/>
                </div>
              
               <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                    <div class="col d-grid">
                        <asp:Button Text="Update" runat="server" ID="UpdateBtn" class="btn-warning btn-block btn" OnClick="UpdateBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button Text="Save" runat="server" ID="SaveBtn" class="btn-success btn-block btn" OnClick="SaveBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button Text="Delete" runat="server" ID="DeleteBtn" class="btn-danger btn-block btn" OnClick="DeleteBtn_Click" />
                    </div>
                </div>

            </div>
            <div class="col-md-8">
                <asp:GridView ID="KhachHangList" runat="server" Width="849px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" AutoGenerateSelectButton="True" OnSelectedIndexChanged="KhachHangList_SelectedIndexChanged1">
                  <Columns>
                    <asp:BoundField DataField="Makhach" HeaderText="Mã Khách Hàng" />
                    <asp:BoundField DataField="Tenkhach" HeaderText="Tên Khách Hàng" />
                    <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" />
                    <asp:BoundField DataField="Dienthoai" HeaderText="Điện thoại" />
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
