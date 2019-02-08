<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/DarkMaster.Master" CodeBehind="ViewPrescriptions.aspx.vb" Inherits="TheFutureDoctor.ViewPrescriptions" %>
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
            <a href="" class="active">Prescriptions</a>
            <a href="ViewPhysicians.aspx">Doctors</a>
            <a href="ViewPatients.aspx">Patients</a>
            <a href="Home.html">Logout</a>
            <a class="callButton callBtnAdv verticalCenter"href="">Call Us Today</a>
            <a class="consultButton consultBtnAdv verticalCenter"href="">Free Consultation</a>
        </div>
    <table class="auto-style1">
            <tr><td>&nbsp;</td><td>&nbsp;</td></tr>     
            <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
            <tr><td><asp:HyperLink ID="HyperLink1" onclick="NewPrescription" OnCommand="NewPrescription" CommandName="NewPrescription" runat="server" NavigateUrl="~/AddPrescription.aspx">Add a Record</asp:HyperLink></td>
                <td><asp:HyperLink ID="HyperLink2" onclick="SearchPrescriptions" OnCommand="SearchPrescriptions" CommandName="SearchPrescriptions" runat="server" NavigateUrl="~/SearchPrescription.aspx">Search Records</asp:HyperLink></td></tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="grdStudents" AutoGenerateColumns="False" CssClass="GridView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True" PageSize="10">
                        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="Go To First Page" LastPageText="Go To Last Page" Position="Top"  />
                        <Columns>
                            <asp:TemplateField HeaderText="Customer ID" >  
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cbSelectAll" runat="server"  /> &nbsp;
                                    <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="Delete_Click" CommandName="lbtnDelete" CommandArgument='<%#Eval("Prescription_ID") %>'>Delete</asp:LinkButton>
                                </HeaderTemplate>          
                                <ItemTemplate> 
                                    <asp:CheckBox ID="chkPreID" runat="server" AutoPostBack="false" /> 
                                    <asp:Label ID="hidPreID" runat="server" Text='<%#Eval("Prescription_ID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="PRESCRIPTION_ID" HeaderText="Prescription ID" SortExpression="PRESCRIPTION_ID" />
                            <asp:BoundField DataField="MEDICATION_NAME" HeaderText="Medication Name" SortExpression="MEDICATION_NAME" />
                            <asp:BoundField DataField="REFILL_AMT" HeaderText="Refill Amount" SortExpression="REFILL_AMT" />
                            <asp:BoundField HeaderText="Dosage" DataField="Dosage" SortExpression="DOSAGE" />
                            <asp:BoundField DataField="INTAKE_METHOD" HeaderText="Intake Method" SortExpression="INTAKE_METHOD" />
                            <asp:BoundField DataField="FREQUENCY" HeaderText="Frequency" SortExpression="FREQUENCY" />
                            <asp:BoundField DataField="PHYSICIAN_ID" HeaderText="Physician ID" SortExpression="PHYSICIAN_ID" />
                            <asp:BoundField HeaderText="PATIENT ID" DataField="Patient_ID" SortExpression="PATIENT_ID" />
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit" runat="server" OnCommand="lbtnEdit_Click" CommandName="lbtnEdit" CommandArgument='<% # Eval("Prescription_ID")%>'>Edit</asp:LinkButton>&nbsp;&nbsp;
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval("Prescription_ID")%>' OnCommand="Delete_Click" CommandName="btnDelete" ImageUrl="~/images/Delete.png" Height ="30"  Width ="30" CausesValidation="false"  />||
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval("Prescription_ID") %>' OnCommand="lbtnEdit_Click" CommandName="lbtnEdit" ImageUrl="~/images/Edit.jpg" Height ="30"  Width ="30" CausesValidation="false" />        
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
          
