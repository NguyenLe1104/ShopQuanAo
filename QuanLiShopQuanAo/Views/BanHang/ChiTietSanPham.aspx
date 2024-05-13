<%@ Page Title="" Language="C#" MasterPageFile="~/Views/BanHang/Nguoiban.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="QuanLiShopQuanAo.Views.BanHang.ChiTietSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Điều chỉnh kích thước và căn lề của các nhãn */
        .label-text {
            font-size: 20px; /* Kích thước chữ */
            font-weight: bold; /* In đậm chữ */
            text-align: right; /* Căn lề sang phải */
            margin-right: 10px; /* Khoảng cách từ nhãn đến nội dung */
        }

        /* Điều chỉnh kích thước của textbox */
        .form-control {
            width: 30%; /* Độ rộng tối đa */
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h3 class="text-center">Chi tiết quần áo</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <!-- Ảnh sản phẩm -->
                <asp:Image ID="Image1" runat="server" class="img-fluid" Height="500px" Width="500px"/>
            </div>
            <div class="col-md-6">
                <!-- Các nhãn (labels) -->
                <div class="mb-3">
                    <asp:Label Text="Tên quần áo:" runat="server" CssClass="label-text" />
                    <asp:Label ID="lblTen" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="mb-3">
                    <asp:Label Text="Chất liệu:" runat="server" CssClass="label-text" />   
                    <asp:Label ID="lblChatlieu" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="mb-3">
                    <asp:Label Text="Giá:" runat="server" CssClass="label-text" /> 
                    <asp:Label ID="lblGia" runat="server" Text="Label"></asp:Label>            
                </div>
                <div class="mb-3">
                    <asp:Label Text="Số lượng:" runat="server" CssClass="label-text" /> 
                    <asp:TextBox ID="TbSoluong" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label Text="Mô tả:" runat="server" CssClass="label-text" /> 
                    <asp:Label ID="lblMota" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="mb-3">
                    <span id="ErrorMessage" runat="server" style="color:red;font-size:30px;"></span>
                </div>
                <div class="col-md-8">
                    <!-- Nút "Đặt Hàng" và "Hủy" -->
                    <div class="mb-3 d-flex justify-content-between">
                        <asp:Button style="width:150px; height:50px; font-weight:400; font-size:20px;" class="btn btn-success" Text="Đặt Hàng" runat="server" OnClick="DathangBtn_Click" />
                        <asp:Button style="width:150px; height:50px; font-weight:400; font-size:20px;" class="btn btn-warning" Text="Hủy" runat="server" OnClick="CloseBtn_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
