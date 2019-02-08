<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/DarkMaster.Master" CodeBehind="UpdatePrescription.aspx.vb" Inherits="TheFutureDoctor.UpdatePrescription" %>
<asp:Content ID="ContentPlaceHolder1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <table class="auto-style1" style="color:white; background-color:black">
        <tr>
            <td class="auto-style2">Physician ID:</td>
            <td>
                <asp:Label ID="lblPrescriptionID" runat="server" Text="Prescription ID"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Medication Name:</td>
            <td>
                <asp:TextBox ID="txtMedicationName" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Refill Amount:</td>
            <td>
                <asp:TextBox ID="txtRefillAmt" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Dosage:</td>
            <td>
                <asp:TextBox ID="txtDosage" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Intake Method:</td>
            <td>
                <asp:TextBox ID="txtIntakeMethod" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Frequency:</td>
            <td>
                <asp:TextBox ID="txtFrequency" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Physician ID:</td>
            <td>
                <asp:TextBox ID="txtPhysicianID" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Patient ID:</td>
            <td>
                <asp:TextBox ID="txtPatientID" style="width:90%;" runat="server"></asp:TextBox>
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

