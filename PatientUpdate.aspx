<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PatientUpdate.aspx.vb" Inherits="Chapter7and8.StudentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 101px;
        }
        .auto-style3 {
            width: 991px;
        }
        .auto-style4 {
            width: 101px;
            height: 26px;
        }
        .auto-style5 {
            width: 991px;
            height: 26px;
        }
        .auto-style6 {
            width: 101px;
            height: 25px;
        }
        .auto-style7 {
            width: 991px;
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">
           
            <table>
                <tr>
                    <td class="auto-style2">Prescription ID:</td> 
                    <td class="auto-style3"><asp:TextBox ID="txtPre_ID" runat="server"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <div id="div2">
            <table>
                <tr>
                    <td class="auto-style2">Current refills left:</td>
                    <td class="auto-style3"><asp:Label ID="lblRefills" runat="server" /></td>
                </tr>
                <tr>
                    <td class="auto-style2">Increase/Decrease</td>
                    <td class="auto-style3"><asp:TextBox ID="txtInput" runat="server"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <div id="div3">
            <asp:Button ID="btnIncrease" runat="server" Text="Increase" />
            <asp:Button ID="btnDecrease" runat="server" Text="Decrease" />
            <asp:Button ID="btnClose" runat="server" Text="Close" />
         &nbsp;&nbsp;&nbsp;
         </div>   
        
    </form>
</body>
</html>
