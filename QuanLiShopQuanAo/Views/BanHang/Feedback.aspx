<%@ Page Title="" Language="C#" MasterPageFile="~/Views/BanHang/Nguoiban.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="QuanLiShopQuanAo.Views.BanHang.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bổ sung các CSS hoặc JS cần thiết cho trang liên hệ -->
    <style>
        /* Định dạng CSS cho trang liên hệ */
        .contact-container {
            margin-top: 50px;
        }
        .contact-form {
            max-width: 500px;
            margin: 0 auto;
        }
        .contact-form input[type="text"],
        .contact-form input[type="email"],
        .contact-form textarea {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .contact-form textarea {
            height: 150px;
        }
        .contact-form button {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
        }
        .contact-form button:hover {
            background-color: #0056b3;
        }
        .social-links {
            margin-top: 20px;
        }
        .social-links a {
            display: inline-block;
            margin-right: 10px;
        }
        .social-links a img {
            width: 40px;
            height: 40px;
            border-radius: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
   <div class="container contact-container">
    <h1 class="text-center">Đánh giá của khách hàng</h1>
    <div class="contact-form">
        <div id="contactForm">
            <div class="form-group">
                <label style="color:teal;" for="txtName">Tài Khoản</label>
                <input type="text" class="form-control" id="txtTK" name="txtTK" />
            </div>
            <div class="form-group">
                <label style="color:teal;" for="txtPhone">Số điện thoại:</label>
                <input type="tel" class="form-control" id="txtPhone" name="txtPhone" />
            </div>
            <div class="form-group">
                <label style="color:teal;" for="txtSubject">Tiêu đề:</label>
                <input type="text" class="form-control" id="txtTieude" name="txtTieude" />
            </div>
            <div class="form-group">
                <label style="color:teal;" for="txtMessage">Nội dung:</label>
                <textarea class="form-control" id="txtMessage" rows="5" name="txtMessage"></textarea>
            </div>
            <button type="button" class="btn btn-primary" onclick="onSubmit()">Gửi</button>
        </div>
    </div>
    <div class="social-links">
        <p>Hoặc bạn có thể liên hệ qua:
            <a href="https://www.facebook.com/MCCB04" style="text-decoration:none; height:30px;" target="_blank">
                <img src ="../../Assets/Images/Facebook.jpg"  alt="Facebook" />
                https://www.facebook.com/MCCB04
            </a>
        </p>
        <!-- Thay đổi URL của href bằng URL của trang Facebook cá nhân của bạn -->
    </div>
</div>

<script>
    function onSubmit() {
         alert("Cảm ơn bạn đã đánh giá!");
    }
</script>

</asp:Content>
