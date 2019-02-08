<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/DarkMaster.Master" CodeBehind="SearchPatient.aspx.vb" Inherits="TheFutureDoctor.SearchPatient" %>
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
            <a href="ViewPhysicians.aspx">Doctors</a>
            <a href="" class="active">Patients</a>
            <a href="Home.html">Logout</a>
            <a class="callButton callBtnAdv verticalCenter"href="">Call Us Today</a>
            <a class="consultButton consultBtnAdv verticalCenter"href="">Free Consultation</a>
        </div>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <CC1:AutoCompleteExtender ID="aceFname" runat="server" ServiceMethod="GetCompletionFname" TargetControlID="txtFname" UseContextKey="True" CompletionInterval="1" EnableCaching="true" CompletionSetCount="12" MinimumPrefixLength="1" DelimiterCharacters=";, :"></CC1:AutoCompleteExtender>
        <CC1:AutoCompleteExtender ID="aceLname" runat="server" ServiceMethod="GetCompletionLname" TargetControlID="txtLname" UseContextKey="True" CompletionInterval="1" EnableCaching="true" CompletionSetCount="12" MinimumPrefixLength="1" DelimiterCharacters=";, :"></CC1:AutoCompleteExtender>
        <CC1:AutoCompleteExtender ID="aceMidInit" runat="server" ServiceMethod="GetCompletionMidInit" TargetControlID="txtMidInit" UseContextKey="True" CompletionInterval="1" EnableCaching="true" CompletionSetCount="12" MinimumPrefixLength="1" DelimiterCharacters=";, :"></CC1:AutoCompleteExtender>
        <CC1:AutoCompleteExtender ID="acePatientID" runat="server" ServiceMethod="GetCompletionPatientID" TargetControlID="txtPatientID" UseContextKey="True" CompletionInterval="1" EnableCaching="true" CompletionSetCount="12" MinimumPrefixLength="1" DelimiterCharacters=";, :"></CC1:AutoCompleteExtender>


    <table class="auto-style1">
        <tr><td class="searchPara"><asp:Label ID="lblPatientID" runat="server" Text="Patient ID:"></asp:Label><asp:TextBox ID="txtPatientID" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label><asp:TextBox ID="txtFName" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblMidInit" runat="server" Text="Middle Initial:"></asp:Label><asp:TextBox ID="txtMidInit" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label><asp:TextBox ID="txtLName" runat="server"></asp:TextBox></td>
            <td class="searchPara"><asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label><asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem>MALE</asp:ListItem>
                <asp:ListItem>FEMALE</asp:ListItem>
                <asp:ListItem>OTHER</asp:ListItem>
                </asp:DropDownList></td>
        </tr>        
        <tr><td><asp:Button ID="btnSearch" runat="server" Text="Search" /><asp:Button ID="btnClose" runat="server" Text="Close" /></td></tr>
        <tr>
            <td colspan="2">
                    <asp:GridView ID="grdStudents" AutoGenerateColumns="False" CssClass="GridView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True" PageSize="10">
                        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="Go To First Page" LastPageText="Go To Last Page" Position="Top"  />
                        <Columns>
                            <asp:TemplateField HeaderText="Customer ID" >  
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cbSelectAll" runat="server"  /> &nbsp;
                                    <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="Delete_Click" CommandName="lbtnDelete" CommandArgument='<%#Eval("Patient_ID") %>'>Delete</asp:LinkButton>
                                </HeaderTemplate>          
                                <ItemTemplate> 
                                    <asp:CheckBox ID="chkPatID" runat="server" AutoPostBack="false" /> 
                                    <asp:Label ID="hidPatID" runat="server" Text='<%#Eval("Patient_ID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="FNAME" HeaderText="First Name" SortExpression="FNAME" />
                            <asp:BoundField DataField="MIDINIT" HeaderText="Middle Initial" SortExpression="MIDINIT" />
                            <asp:BoundField DataField="LNAME" HeaderText="Last Name" SortExpression="LNAME" />
                            <asp:BoundField HeaderText="GENDER" DataField="Gender" SortExpression="GENDER" />
                            <asp:BoundField DataField="STREET" HeaderText="Street" SortExpression="STREET" />
                            <asp:BoundField DataField="CITY" HeaderText="City" SortExpression="CITY" />
                            <asp:BoundField DataField="PATIENT_STATE" HeaderText="State" SortExpression="PATIENT_STATE" />
                            <asp:BoundField HeaderText="ZIP" DataField="ZIP" SortExpression="ZIP" />
                            <asp:BoundField HeaderText="Date of Birth" DataField="DOB" SortExpression="DOB" />
                            <asp:BoundField HeaderText="Home Phone" DataField="Home_Phone" SortExpression="Home_Phone" />
                            <asp:BoundField HeaderText="Cell Phone" DataField="Cell_Phone" SortExpression="Cell_Phone" />                           
                            <asp:BoundField HeaderText="Email" DataField="Email_I" SortExpression="Email_I" />
                            <asp:BoundField HeaderText="Email" DataField="Email_II" SortExpression="Email_II" />
                            <asp:BoundField HeaderText="Email" DataField="Email_III" SortExpression="Email_III" />

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit" runat="server" OnCommand="lbtnEdit_Click" CommandName="lbtnEdit" CommandArgument='<% # Eval("Patient_ID")%>'>Edit</asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval("Patient_ID")%>' OnCommand="Delete_Click" CommandName="btnDelete" ImageUrl="~/images/Delete.png" Height ="30"  Width ="30" CausesValidation="false"  />||
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval("Patient_ID") %>' OnCommand="lbtnEdit_Click" CommandName="lbtnEdit" ImageUrl="~/images/Edit.jpg" Height ="30"  Width ="30" CausesValidation="false" />        
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

