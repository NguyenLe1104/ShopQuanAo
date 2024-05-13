<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dangki.aspx.cs" Inherits="QuanLiShopQuanAo.Views.Dangki" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng kí tài khoản</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/Lib/css/bootstrap-grid.css" rel="stylesheet" /> 
</head>
<body>
    <div class="container-fluid"> 
        <div class="row mt-5 mb-5"> </div>
        <div class="row">
            <div class="col-md-4"> </div>
            <div class="col-md-4">
                <form id="form1" runat="server">
                    <div>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-8">
                                <img src="../../Assets/Images/icons8-clothes-52.png" />
                            </div>
                        </div>
                    </div>
                    <div class="mt-3">
                        <label for="HovatenNb" class="form-label">Họ và tên</label>
                       <input type="text" placeholder="Họ và tên" autocomplete="off" class="form-control" id="HovatenNb" runat="server"/>
                    </div>
                    <div class="mt-3">
                        <label for="UnameNb" class="form-label">User Name</label>
                       <input type="text" placeholder="User Name" autocomplete="off" class="form-control" id="UnameNb" runat="server"/>
                    </div>
                    <div class="mt-3">
                        <label for="PasswordNb" class="form-label">Password</label>
                       <input type="password" placeholder="Password" autocomplete="off" class="form-control" id="PasswordNb" runat="server"/>
                    </div>
                    <div class="mt-3">
                        <label for="SdtNb" class="form-label">Số điện thoại</label>
                       <input type="text" placeholder="Số điện thoại" autocomplete="off" class="form-control" id="SdtNb" runat="server"/>
                    </div>
                    <div class="mt-3">
                        <label for="DiachiNb" class="form-label">Địa chỉ</label>
                       <input type="text" placeholder="Địa chỉ" autocomplete="off" class="form-control" id="DiachiNb" runat="server"/>
                    </div>
                    <div class="mt-3 d-grid">
                        <asp:Button Text="Đăng kí" runat="server" CssClass="btn-success btn" ID="Dangkibtn" OnClick="Dangki_Click" />
                        <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger text-center"> </asp:Label>                 
                    </div>
                     <div class="mt-3 d-grid">
                        <asp:Button Text="Đăng nhập" runat="server" CssClass="btn-success btn" ID="DangnhapBtn" OnClick="Dangnhap_Click" />
                    </div>
                </form>
            </div>
            <div class="col-md-4"> </div>
        </div>
    </div>
</body>
</html>
