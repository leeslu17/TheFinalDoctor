<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/DarkMaster.Master" CodeBehind="SearchPhysician.aspx.vb" Inherits="TheFutureDoctor.SearchPhysician" %>
<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolKit" TagPrefix="CC1" %>
<asp:Content ID="ContentPlaceHolder1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <script type="text/javascript"> 
function SelectAll(id)
{
            //get reference of GridView control
            var grid = document.getElementById("<%= grdStudents.ClientID %>");
            //variable to contain the cell of the grid
            var cell;
            
            if (grid.rows.length > 0)
            {
                //loop starts from 1. rows[0] points to the header.
                for (i=1; i<grid.rows.length; i++)
                {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];
                    //loop according to the number of childNodes in the cell
                    for (j=0; j<cell.childNodes.length; j++)
                    {           
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type =="checkbox")
                        {
                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }

</script>
    <link href="main.css" rel="stylesheet" />
    <link href="StyleSheet.css" rel="stylesheet" />
    <div class="navbar verticalCenter" align="right">
            <img src="Images/logo2.png" class="logo"/>
            <a href="Dashboard.aspx">Dashboard</a>
            <a href="ViewPrescriptions.aspx">Prescriptions</a>
            <a href="" class="active">Doctors</a>
            <a href="ViewPatients.aspx">Patients</a>
            <a href="Home.html">Logout</a>
            <a class="callButton callBtnAdv verticalCenter"href="">Call Us Today</a>
            <a class="consultButton consultBtnAdv verticalCenter"href="">Free Consultation</a>
        </div>

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <CC1:AutoCompleteExtender ID="aceFname" runat="server" ServiceMethod="GetCompletionFname" TargetControlID="txtFname" UseContextKey="True" CompletionInterval="1" EnableCaching="true" CompletionSetCount="12" MinimumPrefixLength="1" DelimiterCharacters=";, :"></CC1:AutoCompleteExtender>
        <CC1:AutoCompleteExtender ID="aceLname" runat="server" ServiceMethod="GetCompletionLname" TargetControlID="txtLname" UseContextKey="True" CompletionInterval="1" EnableCaching="true" CompletionSetCount="12" MinimumPrefixLength="1" DelimiterCharacters=";, :"></CC1:AutoCompleteExtender>
        <CC1:AutoCompleteExtender ID="aceMidInit" runat="server" ServiceMethod="GetCompletionMidInit" TargetControlID="txtMidInit" UseContextKey="True" CompletionInterval="1" EnableCaching="true" CompletionSetCount="12" MinimumPrefixLength="1" DelimiterCharacters=";, :"></CC1:AutoCompleteExtender>
        <CC1:AutoCompleteExtender ID="acePhysicianID" runat="server" ServiceMethod="GetCompletionPhysicianID" TargetControlID="txtPhysicianID" UseContextKey="True" CompletionInterval="1" EnableCaching="true" CompletionSetCount="12" MinimumPrefixLength="1" DelimiterCharacters=";, :"></CC1:AutoCompleteExtender>

    <table class="auto-style1">
        <tr><td class="searchPara"><asp:Label ID="lblPhysicianID" runat="server" Text="Physician ID:"></asp:Label><asp:TextBox ID="txtPhysicianID" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label><asp:TextBox ID="txtFName" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label><asp:TextBox ID="txtLName" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label><asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem>MALE</asp:ListItem>
                <asp:ListItem>FEMALE</asp:ListItem>
                <asp:ListItem>OTHER</asp:ListItem>
            </asp:DropDownList></td></tr>
        <tr><td class="searchPara"><asp:Label ID="lblOfficePhone" runat="server" Text="Office Phone:"></asp:Label><asp:TextBox ID="txtOfficePhone" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblWorkEmail" runat="server" Text="Work Email:"></asp:Label><asp:TextBox ID="txtWorkEmail" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblPosition" runat="server" Text="Position:"></asp:Label><asp:TextBox ID="txtPosition" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblSpecialty" runat="server" Text="Specialty:"></asp:Label><asp:TextBox ID="txtSpecialty" runat="server"></asp:TextBox></td>
        <tr><td><asp:Button ID="btnSearch" runat="server" Text="Search" /><asp:Button ID="btnClose" runat="server" Text="Close" /></td></tr>
        <tr>
            <td colspan="2">
                    <asp:GridView ID="grdStudents" AutoGenerateColumns="False" CssClass="GridView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True" PageSize="10">
                        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="Go To First Page" LastPageText="Go To Last Page" Position="Top"  />
                        <Columns>
                            <asp:TemplateField HeaderText="Customer ID" >  
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cbSelectAll" runat="server"  /> &nbsp;
                                    <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="Delete_Click" CommandName="lbtnDelete" CommandArgument='<%#Eval("Physician_ID") %>'>Delete</asp:LinkButton>
                                </HeaderTemplate>          
                                <ItemTemplate> 
                                    <asp:CheckBox ID="chkPhyID" runat="server" AutoPostBack="false" /> 
                                    <asp:Label ID="hidPhyID" runat="server" Text='<%#Eval("Physician_ID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="FNAME" HeaderText="First Name" SortExpression="FNAME" />
                            <asp:BoundField DataField="LNAME" HeaderText="Last Name" SortExpression="LNAME" />
                            <asp:BoundField HeaderText="Gender" DataField="Gender" SortExpression="GENDER" />
                            <asp:BoundField HeaderText="Office Phone" DataField="Office_Phone" SortExpression="Office_Phone" />
                            <asp:BoundField HeaderText="Work Email" DataField="Work_Email" SortExpression="Work_Email" />
                            <asp:BoundField HeaderText="Position" DataField="Position" SortExpression="Position" />
                            <asp:BoundField HeaderText="Specialty" DataField="Specialty" SortExpression="Specialty" />

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit" runat="server" OnCommand="lbtnEdit_Click" CommandName="lbtnEdit" CommandArgument='<% # Eval("Physician_ID")%>'>Edit</asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval("Physician_ID")%>' OnCommand="Delete_Click" CommandName="btnDelete" ImageUrl="~/images/Delete.png" Height ="30"  Width ="30" CausesValidation="false"  />||
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval("Physician_ID") %>' OnCommand="lbtnEdit_Click" CommandName="lbtnEdit" ImageUrl="~/images/Edit.jpg" Height ="30"  Width ="30" CausesValidation="false" />        
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />           
                            </asp:TemplateField>    
                        </Columns>   
                        <EmptyDataTemplate>
                            No Records Found Matching Your Search!
                        </EmptyDataTemplate>
                    </asp:GridView>                
                </td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
        .auto-style2 {
            width: 5%;
            height: 1%;
            text-align: right;
            color: white;
        }
    </style>
</asp:Content>

