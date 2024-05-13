<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuanLiShopQuanAo.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/Lib/css/bootstrap-grid.css" rel="stylesheet" /> 
</head>
<body>
    <div class="container-fluid"> 
        <div class="row mt-5 mb-5">
          
        </div>
        <div class="row">
            <div class="col-md-4">
             
            </div>
              <div class="col-md-4">
                <form id="form1" runat="server">
                    <div>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-8">
                                &nbsp;</div>
                        </div>
                    </div>
                    <div class="mt-3">
                        <label for="" class="form-label">User Name </label>
                       <input type="text"  placeholder="Email của bạn" autocomplete="off" class="form-control" id="Usermailname" runat="server"/>
                    </div>
                    <div class="mt-3">
                        <label for="" class="form-label">Password</label>
                       <input type="password"  placeholder="Password" autocomplete="off" class="form-control" id="Password" runat="server"/>
                    </div>
                    <div class="mt-3 d-grid">
                        <asp:Button Text="Đăng Nhập"  runat="server" class="btn-success btn" ID="DangnhapBtn" OnClick="Dangnhap_Click" />
                        <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"> </asp:Label>
                    </div>
                      <div class="mt-3 d-grid">
                        <asp:Button Text="Đăng Kí" runat="server" class="btn-success btn" ID="Dangki" OnClick="Dangki_Click" />
                    </div>
                </form>
            </div>
            <div class="col-md-4">

            </div>
        </div>
    </div>
</body>
    </html>