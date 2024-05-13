<%@ Page Title="" Language="C#" MasterPageFile="~/Views/BanHang/Nguoiban.Master" AutoEventWireup="true" CodeBehind="Lienhe.aspx.cs" Inherits="QuanLiShopQuanAo.Views.BanHang.Lienhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bổ sung các CSS hoặc JS cần thiết cho trang liên hệ -->
    <style>
     
        /* Định dạng CSS cho trang liên hệ */
        .contact-container {
            margin-top: 50px;
            text-align: center; /* Căn giữa nội dung */
        }
        .social-links {
            margin-top: 20px;
        }
        .social-links a {
            display: inline-block;
            margin: 0 10px; /* Khoảng cách giữa các liên kết */
        }
        .social-links a img {
            width: 50px; /* Kích thước của biểu tượng */
            height: 50px;
            border-radius: 50%; /* Đảm bảo biểu tượng là hình tròn */
            border: 2px solid #ccc; /* Viền xung quanh biểu tượng */
            padding: 5px; /* Khoảng cách giữa biểu tượng và viền */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container">
        <h1 class="contact-container" style="margin-bottom:50px;">Hãy liên hệ với chúng tôi qua</h1>
        <div>
            <ul>
                 <li>
                    <a href="https://www.google.com/maps/place/279+Tr%E1%BA%A7n+Cao+V%C3%A2n,+Xu%C3%A2n+H%C3%A0,+Q.+Thanh+Kh%C3%AA,+%C4%90%C3%A0+N%E1%BA%B5ng+550000,+Vi%E1%BB%87t+Nam/@16.071013,108.1955071,17z/data=!3m1!4b1!4m6!3m5!1s0x31421853c3553345:0x24da16b2ae25fc07!8m2!3d16.071013!4d108.198082!16s%2Fg%2F11c5lg18gx?entry=ttu" style="text-decoration:none; font-size:20px;">
                        <img src="../../Assets/Images/Location.png" alt="Facebook" /> 
                        279 Trần Cao Vân Quận Thanh Khê Thành Phố Đà Nẵng
                    </a>
                </li>
                <li>
                    <a href="https://www.facebook.com/MCCB04" style="text-decoration:none; font-size:20px;">
                        <img src="../../Assets/Images/Facebook.jpg" alt="Facebook" /> 
                        https://www.facebook.com/MCCB04
                    </a>
                </li>
                <li>
                    <a href="https://mail.google.com/mail/u/0/?pli=1#inbox?compose=GTvVlcSKjgCQbTSWsZzhsdZXKMLHSkdQdLDGdpQRKlkCRRPXxpXhMCqxrGQdSwdDQFNRmnfswZRxB" style="text-decoration:none; font-size:20px;">
                        <img src="../../Assets/Images/Gmail.jpg" alt="Gmail" />
                        ngovanmanhcuong165@gmail.com
                    </a>
                </li>
                 <li>
                    <a href="#" style="text-decoration:none; font-size:20px;">
                        <img src="../../Assets/Images/Dienthoai.jpg"  alt="Điện Thoại" />
                        0799302155
                    </a>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
