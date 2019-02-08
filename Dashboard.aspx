<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" MasterPageFile="~/DarkMaster.Master" Inherits="TheFutureDoctor.Login" %>

<asp:Content ID="ContentPlaceHolder1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <link rel="stylesheet" type="text/css" href="DashboardCSS.css" />
    <div class="navbar verticalCenter" align="right">
            <img src="Images/logo2.png" class="logo"/>
            <a href="" class="active">Dashboard</a>
            <a href="ViewPrescriptions.aspx">Prescriptions</a>
            <a href="ViewPhysicians.aspx">Doctors</a>
            <a href="ViewPatients.aspx">Patients</a>
            <a href="Home.html">Logout</a>
            <a class="callButton callBtnAdv verticalCenter" href="">Call Us Today</a>
            <a class="consultButton consultBtnAdv verticalCenter" href="">Free Consultation</a>
        </div>
    <div class="mainBack">
        <div class="welcomeDiv roundBorders">
            <div class="clockDiv">
                <iframe src="http://free.timeanddate.com/clock/i6lx9lsv/n4561/fn6/fs16/fcfff/tct/pct/ftb/pa8/tt0/tw1/th1/ta1/tb4" frameborder="0" width="100%" height="100%" allowTransparency="true"></iframe>
            </div>
            <asp:Label ID="lblWelcome" runat="server" Text="Welcome" CssClass="welcomeMsg"></asp:Label>
            <div id="cont_4218ecce3bb6b06f69973c0f8000b7e5" class="weatherDiv">
                <script type="text/javascript" async src="https://www.theweather.com/wid_loader/4218ecce3bb6b06f69973c0f8000b7e5"></script>
            </div>
        </div>
        <div class="titleDiv">
            XYZ Health | Dashboard
        </div>        
        <div class="customerInfoDiv roundBorders">
            <div class="infoHeader">
                Personal Information
            </div>
            <table class="customerInfoTable">
                <tr>
                    <td>Patient ID</td>
                    <td>Name</td>
                    <td>Gender</td>
                    <td>Address</td>
                    <td>Options</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div class="contactDiv roundBorders">
            <a id="foxyform_embed_link_942456" href=""></a>
            <script type="text/javascript">
                (function(d, t){
                    var g = d.createElement(t),
                    s = d.getElementsByTagName(t)[0];
                    g.src = "http://www.foxyform.com/js.php?id=942456&sec_hash=864e9a6dc65&width=350px";
                    s.parentNode.insertBefore(g, s);
                }(document, "script"));
            </script>
        </div>
        <div class="calendarDiv roundBorders">
            <iframe src="https://calendar.google.com/calendar/embed?height=600&amp;wkst=1&amp;bgcolor=%23FFFFFF&amp;src=pmh6tsa8snfv8mc2783nuvml10%40group.calendar.google.com&amp;color=%23B1440E&amp;ctz=America%2FNew_York" style="border-width:0" width="100%" height="100%" margin-top:"7%" frameborder="0" scrolling="yes"></iframe>
        </div>
        <div class="presInfoDiv roundBorders">
            <div class="infoHeader">
                Prescriptions
            </div>
            <table class="presInfoTable">
                <tr>
                    <td>Patient ID</td>
                    <td>Patient's Name</td>
                    <td>Doctor ID</td>
                    <td>Doctor's Name</td>
                    <td>Refill Amount</td>
                    <td>Options</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div class="callDiv roundBorders">

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
</asp:Content>

