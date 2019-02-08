<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/DarkMaster.Master" CodeBehind="UpdatePatient.aspx.vb" Inherits="TheFutureDoctor.UpdatePatient" %>
<asp:Content ID="ContentPlaceHolder1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <table class="auto-style1" style="color:white; background-color:black">
        <tr>
            <td class="auto-style2">Patient ID:</td>
            <td>
                <asp:Label ID="lblPatientID" runat="server" Text="Patient's ID"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">First Name:</td>
            <td>
                <asp:TextBox ID="txtFName" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Middle Initial:</td>
            <td>
                <asp:TextBox ID="txtMidInit" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Last Name:</td>
            <td>
                <asp:TextBox ID="txtLName" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Gender:</td>
            <td>
                <asp:DropDownList ID="ddlGender" style="width:90%;" runat="server">
                    <asp:ListItem>MALE</asp:ListItem>
                    <asp:ListItem>FEMALE</asp:ListItem>
                    <asp:ListItem>OTHER</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Date of Birth</td>
            <td>
                <asp:TextBox ID="txtDOB" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Street:</td>
            <td>
                <asp:TextBox ID="txtStreet" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">City:</td>
            <td>
                <asp:TextBox ID="txtCity" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">State:</td>
            <td>
                <asp:DropDownList ID="ddlState" style="width:90%;" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Zip:</td>
            <td>
                <asp:TextBox ID="txtZIP" style="width:90%;" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td class="auto-style2">Home Phone:</td>
            <td>
                <asp:TextBox ID="txtHomePhone" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Cell Phone</td>
            <td>
                <asp:TextBox ID="txtCellPhone" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmailI" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmailII" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmailIII" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>               
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update Record" />
                <asp:Button ID="btnClose" runat="server" Text="Close"/>
            </td>
        </tr>
        
    </table>
    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 39%;
            height: 90%;
        }
        .auto-style2 {
            width: 120px;
            text-align: right;
        }
    </style>
</asp:Content>

