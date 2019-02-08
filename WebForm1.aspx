<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/DarkMaster.Master" CodeBehind="WebForm1.aspx.vb" Inherits="TheFutureDoctor.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="float:left;">
           
            <table class="auto-style1">
                <tr>
                    <td>Patient Info</td>
                </tr>
                <tr>
                    <td class="auto-style2">Patient ID:</td>
                    <td class="auto-style3"><asp:TextBox ID="txtPatID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">First Name:</td>
                    <td class="auto-style3"><asp:Label ID="lblFname" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">Middle Initial:</td>
                    <td class="auto-style3"><asp:Label ID="lblMint" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">Last Name:</td>
                    <td class="auto-style3"><asp:Label ID="lblLname" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">Gender:</td>
                    <td class="auto-style3"><asp:Label ID="lblGender" runat="server"></asp:Label></td>
                </tr>
            </table>
         </div>
         
    <div style="float:left;">

          <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Address Info</td> 
                </tr>
                <tr>
                    <td class="auto-style2">Street Address:</td>
                    <td class="auto-style3"><asp:Label ID="lblStreet" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">City:</td>
                    <td class="auto-style3"><asp:Label ID="lblCity" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">State:</td>
                    <td class="auto-style3"><asp:Label ID="lblState" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">Zip Code:</td>
                    <td class="auto-style3"><asp:Label ID="lblZip" runat="server" /></td>
                </tr>
            </table>

    </div>
        
    <div style="float:left;">

          <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Contact Info:</td>
                </tr>
                <tr>
                    <td class="auto-style2">Home Phone:</td>
                    <td class="auto-style3"><asp:Label ID="lblHome" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">Cell Phone:</td>
                    <td class="auto-style3"><asp:Label ID="lblCell" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">Email:</td>
                    <td class="auto-style3"><asp:Label ID="lblEmail1" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">Email (alt):</td>
                    <td class="auto-style3"><asp:Label ID="lblEmail2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style2">Email (alt):</td>
                    <td class="auto-style3"><asp:Label ID="lblEmail3" runat="server"></asp:Label></td>
                </tr>
            </table>

    </div>
    
    <div>
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
    </div> 

</asp:Content>
