Public Class UpdatePrescription
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myid, myedit As String
        Dim DBConnection As New DBConnection
        myedit = ""

        Page.ClientScript.RegisterClientScriptInclude("Test", "MyScript.js")

        If Not IsPostBack Then
            Dim strCrypt As String
            strCrypt = Request.QueryString("ID").Trim
            myid = DBConnection.Decrypt(strCrypt.Replace(" ", "+"), "12345678")
            If Not IsNothing(Request.QueryString("type")) And (Request.QueryString("type") <> String.Empty) Then
                myedit = Request.QueryString("type").Trim
            End If
            Dim ds As New DataSet

            ds = DBConnection.GetPrescriptionByID(myid)
            If myedit.ToUpper = "EDIT" Then
                With Me
                    .lblPrescriptionID.Text = ds.Tables(0).Rows(0)("Prescription_ID").ToString()
                    .txtMedicationName.Text = ds.Tables(0).Rows(0)("MEDICATION_NAME").ToString()
                    .txtRefillAmt.Text = ds.Tables(0).Rows(0)("REFILL_AMT").ToString()
                    .txtDosage.Text = ds.Tables(0).Rows(0)("DOSAGE").ToString()
                    .txtIntakeMethod.Text = ds.Tables(0).Rows(0)("INTAKE_METHOD").ToString()
                    .txtFrequency.Text = ds.Tables(0).Rows(0)("FREQUENCY").ToString()
                    .txtPhysicianID.Text = ds.Tables(0).Rows(0)("PHYSICIAN_ID").ToString()
                    .txtPatientID.Text = ds.Tables(0).Rows(0)("PATIENT_ID").ToString()
                End With
            Else
                With Me
                    .lblPrescriptionID.Text = ds.Tables(0).Rows(0)("Prescription_ID").ToString()
                    .txtMedicationName.Text = ds.Tables(0).Rows(0)("MEDICATION_NAME").ToString()
                    .txtRefillAmt.Text = ds.Tables(0).Rows(0)("REFILL_AMT").ToString()
                    .txtDosage.Text = ds.Tables(0).Rows(0)("DOSAGE").ToString()
                    .txtIntakeMethod.Text = ds.Tables(0).Rows(0)("INTAKE_METHOD").ToString()
                    .txtFrequency.Text = ds.Tables(0).Rows(0)("FREQUENCY").ToString()
                    .txtPhysicianID.Text = ds.Tables(0).Rows(0)("PHYSICIAN_ID").ToString()
                    .txtPatientID.Text = ds.Tables(0).Rows(0)("PATIENT_ID").ToString()
                End With
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim DBConnection As New DBConnection
        Dim textBoxes = Me.Controls.OfType(Of TextBox)
        Try

            'Checks for empty textboxes
            Try
                For Each txtbx In textBoxes
                    If String.IsNullOrEmpty(txtbx.Text) Then
                        txtbx.Text = "N/A"
                    End If
                Next txtbx
            Catch ex As Exception

            End Try
            DBConnection.UpdatePrescription(lblPrescriptionID.Text, txtMedicationName.Text, txtRefillAmt.Text, txtDosage.Text, txtIntakeMethod.Text, txtFrequency.Text, txtPhysicianID.Text, txtPatientID.Text)
        Catch ex As Exception

        End Try

        btnClose.Text = "REFRESH"
    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            If btnClose.Text.ToUpper = "REFRESH" Then
                Dim cb As New StringBuilder
                cb.Append("opener.location.href='ViewPrescriptions.aspx';")
                cb.Append("var ie7 = (document.all && !window.opera && window.XMLHttpRequest)? true:false;")
                cb.Append("if(ie7)")
                cb.Append("{")
                cb.Append("window.open('','_parent','');")
                cb.Append("window.close();")
                cb.Append("}")
                cb.Append("else")
                cb.Append("{")
                cb.Append("this.focus();")
                cb.Append("self.opener=this;")
                cb.Append("self.close();")
                cb.Append("}")
                ClientScript.RegisterClientScriptBlock(GetType(Page), "CloseReloadScript", cb.ToString(), True)
            ElseIf btnClose.Text.ToUpper = "CLOSE" Then
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "closeform", "CloseMe()", True)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class