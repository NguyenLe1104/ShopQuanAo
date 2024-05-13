<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BanHang.aspx.cs" Inherits="QuanLiShopQuanAo.Views.Admin.BanHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <h3 class="text-center" style="color: teal;">Chi tiết quần áo</h3>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Mã quần áo</label>
                            <input type="text" placeholder="Mã quần áo" autocomplete="off" class="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Mã Nhóm</label>
                            <input type="text" placeholder="Mã nhóm" autocomplete="off" class="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Tên Quần Áo</label>
                            <input type="text" placeholder="Tên quần áo" autocomplete="off" class="form-control" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Mã Chất Liệu</label>
                            <input type="text" placeholder="Mã chất liệu" autocomplete="off" class="form-control" id="Machatlieu" runat="server" />
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Số Lượng</label>
                            <input type="text" placeholder="Số lượng" autocomplete="off" class="form-control" id="Soluong" runat="server" />
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Giá Bán</label>
                            <input type="text" placeholder="Giá bán" autocomplete="off" class="form-control" id="Dongiaban" runat="server" />
                        </div>
                    </div>
                </div>

                <h4 class="text-center" style="color: teal; margin-top: 20px;">Chi Tiết Quần Áo</h4>
                <div class="col">
                    <asp:GridView ID="BanHangList" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BanHangList_SelectedIndexChanged1">
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

            <div class="col-md-5">
                <h4 class="text-center" style="color: crimson;">Hóa Đơn</h4>
                <div class="col">
                    <asp:GridView ID="HoadonList" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BanHangList_SelectedIndexChanged1">
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
                    <div class="d-grid mt-3">
                        <asp:Button Text="Print" ID="PrintBtn" runat="server" class="btn-warning btn-block btn" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

