<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="TheFutureDoctor.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <title></title>
    <script lang="javascript" type="text/javascript">
        function badLogin() {
            alert("Invalid login credentials.");
            return false;
        }
        function loginErr() {
            alert("Login failed. Please try again.")
            return false;
        }
        function noDB() {
            alert("Connection error. Database not found.");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="backgroundImg backgroundImgAdv">
            <div class="navbar verticalCenter" align="right">
                <img src="Images/logo2.png" class="logo"/>
                <a href="Home.html">Home</a>
                <a href="">Company</a>
                <a href="">Contact</a>
                <a href="Login.aspx" class="active">Login</a>
                <a class="callButton callBtnAdv verticalCenter"href="">Call Us Today</a>
                <a class="consultButton consultBtnAdv verticalCenter"href="">Free Consultation</a>
            </div>  
            <div class="back">
                <div class="loginBox">
                    <div class="title2">Welcome</div>
                    <asp:TextBox ID="txtLogin" runat="server" CssClass="textBox2" placeholder="Username"></asp:TextBox>
                    <br /><br />                   
                    <asp:Button ID="btnLogin" runat="server" CssClass="loginButton" Text="Login" />                   
                </div>
                <asp:Label ID="lblTest" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
            <div class="footer">&copy XYZ Corp. | (717)123-4567 | ABC Avenue, Littleville, PA | XYZCorp@gmail.com</div>
        </div>
    </form>
</body>
</html>