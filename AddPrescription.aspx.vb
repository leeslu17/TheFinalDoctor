Imports System.Data.SqlClient

Public Class AddPrescription
    Inherits System.Web.UI.Page
    Public strValidation As String
    Public connString As New SqlClient.SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=10;integrated security=SSPI;")
    Public cmdString As New SqlClient.SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "VIEWPATIENTS"
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            DropDownList1.DataSource = cmdString.ExecuteReader()
            DropDownList1.DataValueField = "Patient_ID"
            DropDownList1.DataBind()
            DropDownList1.Items.Insert(0, New ListItem("--Select Patient ID--", "0"))
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try

        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "VIEWPHYSICIANS"
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            DropDownList2.DataSource = cmdString.ExecuteReader()
            DropDownList2.DataValueField = "Physician_ID"
            DropDownList2.DataBind()
            DropDownList2.Items.Insert(0, New ListItem("--Select Patient ID--", "0"))
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try



    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim cutdown As Char
        Dim errCount As Integer = 0
        Try
            Try
                cutdown = txtPrescriptionID.Text.Substring(0, 1)
                If (txtPrescriptionID.Text.Trim().Length <> 5 And cutdown <> "R") Then
                    lblPresID.Text = "This field needs to be five characters long and begin with a 'R'. Example: R0001"
                    errCount += 1
                Else
                    lblPresID.Text = ""
                End If
            Catch ex As Exception
                lblPresID.Text = "This field needs to be five characters long and begin with a 'R'. Example: R0001"
                errCount += 1
            End Try
            If txtMedicationName.Text = String.Empty Then
                lblMedName.Text = "Please enter a medication name."
                errCount += 1
            Else
                lblMedName.Text = ""
            End If
            If txtRefillAmount.Text = String.Empty Then
                lblRefillAmt.Text = "Please enter a refill amount."
                errCount += 1
            Else
                lblRefillAmt.Text = ""
            End If
            If txtDosage.Text = String.Empty Then
                lblDosage.Text = "Please enter a dosage."
                errCount += 1
            Else
                lblDosage.Text = ""
            End If
            If txtIntakeMethod.Text = String.Empty Then
                lblIntakeMethod.Text = "Please enter an intake method."
                errCount += 1
            Else
                lblIntakeMethod.Text = ""
            End If
            If txtFrequency.Text = String.Empty Then
                lblFrequency.Text = "Please enter a frequency."
                errCount += 1
            Else
                lblFrequency.Text = ""
            End If
            If DropDownList2.Text = String.Empty Then
                lblPhyID.Text = "Please enter a physician ID."
                errCount += 1
            Else
                lblPhyID.Text = ""
            End If
            If DropDownList1.Text = String.Empty Then
                lblPatID.Text = "Please enter a patient ID."
                errCount += 1
            Else
                lblPatID.Text = ""
            End If

            If errCount = 0 Then
                Dim DBConnection As New DBConnection
                DBConnection.AddPrescription(txtPrescriptionID.Text, txtMedicationName.Text, txtRefillAmount.Text, txtDosage.Text, txtIntakeMethod.Text, txtFrequency.Text, DropDownList2.Text, DropDownList2.Text)
                btnClose.Text = "Refresh"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Response.Redirect("ViewPrescriptions.aspx")
        Catch ex As Exception
            Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
        End Try
    End Sub
End Class