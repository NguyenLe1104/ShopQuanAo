<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Clothes.aspx.cs" Inherits="QuanLiShopQuanAo.Views.Admin.Clothes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
   
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                 <h3 class="text-center">Quản lý quần áo</h3>   </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-10">
        <label for="" class="form-label text-success">Mã quần áo</label>
        <input type="text"  placeholder="Mã quần áo" id="MaQuanAoC" autocomplete="off" runat="server" class="form-control"/>
                </div>  
                <div class="mb-10">
        <label for="" class="form-label text-success">Mã nhóm</label>
        <input type="text"  placeholder="Nhóm quần áo" id="MaNhomC" autocomplete="off" runat="server"  class="form-control"/>
                </div>
                <div class="mb-10">
        <label for="" class="form-label text-success">Tên quần áo</label>
        <input type="text"  placeholder="Tên quần áo" autocomplete="off" id="TenQuanAoC" runat="server"  class="form-control"/>
                </div>
                  <div class="mb-10">
        <label for="" class="form-label text-success">Mã chất liệu</label>
        <input type="text"  placeholder="Mã chất liệu" autocomplete="off" id="MaChatLieuC" runat="server"  class="form-control"/>
                </div>
                  <div class="mb-10">
        <label for="" class="form-label text-success">Số lượng</label>
        <input type="text"  placeholder="Số lượng" autocomplete="off" id="SoluongC" runat="server"  class="form-control"/>
                </div>
                  <div class="mb-10">
        <label for="" class="form-label text-success">Giá nhập</label>
        <input type="text"  placeholder="Giá nhập" autocomplete="off" id="GiaNhapC" runat="server"  class="form-control"/>
                </div>
                  <div class="mb-10">
        <label for="" class="form-label text-success">Giá bán</label>
        <input type="text"  placeholder="Giá bán" autocomplete="off" id="GiaBanC" runat="server"  class="form-control"/>
                </div>
                   <div class="mb-10">
        <label for="" class="form-label text-success">Hình ảnh</label>
        <input type="text"  placeholder="Ảnh" autocomplete="off" id="HinhAnhC" runat="server"  class="form-control"/>
                </div>
                   <div class="mb-10">
        <label for="" class="form-label text-success">Ghi chú</label>
        <input type="text"  placeholder="Ghi chú" autocomplete="off" id="GhiChuC" runat="server"  class="form-control"/>
                </div>
                <div class="row">
                     <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"> </asp:Label>
                    <div class="col d-grid"> <asp:Button Text="Update" ID="UpdateBtn"  runat="server" class="btn-warning btn-block btn" OnClick="UpdateBtn_Click" /></div>
                    <div class="col d-grid"> <asp:Button Text="Save"  ID="SaveBtn" runat="server" class="btn-success btn-block btn" OnClick="SaveBtn_Click" /></div>
                    <div class="col d-grid"> <asp:Button Text="Delete" ID="DeleteBtn"  runat="server" class="btn-danger btn-block btn" OnClick="DeleteBtn_Click" /></div>
                </div>
            </div>
                    <div class="col-md-8">
                <asp:GridView ID="ClothesList" runat="server" Width="849px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ClothesList_SelectedIndexChanged1">
                <Columns>
        <asp:BoundField DataField="Mahang" HeaderText="Mã quần áo" />
        <asp:BoundField DataField="Manhom" HeaderText="Mã nhóm" />
        <asp:BoundField DataField="Tenhang" HeaderText="Tên quần áo" />
        <asp:BoundField DataField="Machatlieu" HeaderText="Mã chất liệu" />
        <asp:BoundField DataField="Soluong" HeaderText="Số lượng" />
        <asp:BoundField DataField="Dongianhap" HeaderText="Giá nhập" />
        <asp:BoundField DataField="Dongiaban" HeaderText="Giá bán" />
        <asp:BoundField DataField="Anh" HeaderText="Hình ảnh" />
        <asp:BoundField DataField="Ghichu" HeaderText="Ghi chú" />
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
