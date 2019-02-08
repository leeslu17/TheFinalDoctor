Public Class frmUpdateRecordPrescription
    Private drMsgReader As DialogResult
    Private FormDesigns As New FormDesigns()
    Private Sub frmUpdateRecordPrescription_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DBConnection As New DBConnection
        Dim ds As New DataSet
        Dim strPhysician As String = "PHYSICIAN_ID"
        Dim strPatient As String = "PATIENT_ID"
        txtRecordID.Text = frmUpdateRecord.cboRecordID.SelectedItem
        ds = DBConnection.FillUpdateForms(txtRecordID.Text, "CHECKPRESCRIPTION", "@PRESCRIPTION_ID")
        DBConnection.UpdatePhysicianDGV()
        DBConnection.UpdatePatientDGV()
        DBConnection.PopulateUpdatePrescriptionCBO(strPhysician, cboPhysician)
        DBConnection.PopulateUpdatePrescriptionCBO2(strPatient, cboPatient)
        FormDesigns.BtnSmoother(btnUpdate)
        FormDesigns.BtnSmoother(btnBack)
        FormDesigns.BtnSmoother(btnCancel)
        With Me
            .txtMedName.Text = ds.Tables(0).Rows(0)("MEDICATION_NAME").ToString
            .txtRefillAmt.Text = ds.Tables(0).Rows(0)("REFILL_AMT").ToString
            .txtDosage.Text = ds.Tables(0).Rows(0)("DOSAGE").ToString
            .txtIntakeMethod.Text = ds.Tables(0).Rows(0)("INTAKE_METHOD").ToString
            .txtFrequency.Text = ds.Tables(0).Rows(0)("FREQUENCY").ToString
            .cboPhysician.Text = ds.Tables(0).Rows(0)("PHYSICIAN_ID").ToString
            .cboPatient.Text = ds.Tables(0).Rows(0)("PATIENT_ID").ToString
        End With


    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        drMsgReader = MessageBox.Show("Are you sure you want to return to the record selection? All data will be lost.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (drMsgReader = DialogResult.Yes) Then
            frmAddRecord.Close()
            frmAddRecord.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim DBConnection As New DBConnection
        Dim textBoxes = Me.Controls.OfType(Of TextBox)
        Try
            For Each txtbx In textBoxes
                If String.IsNullOrEmpty(txtbx.Text) Then
                    txtbx.Text = "N/A"
                End If
            Next txtbx
            DBConnection.CheckUpdateNulls(txtMedName, "Medication Name")
            DBConnection.CheckUpdateNulls(txtRefillAmt, "Refill Amount")
            DBConnection.CheckUpdateNulls(txtDosage, "Dosage")
            DBConnection.CheckUpdateNulls(txtIntakeMethod, "Intake Method")
            DBConnection.CheckUpdateNulls(txtFrequency, "Frequency")
            If (DBConnection.Reply = "Fail") Then
                Exit Sub
            End If
            DBConnection.UpdatePrescription(txtRecordID.Text, txtMedName.Text, txtRefillAmt.Text, txtDosage.Text, txtIntakeMethod.Text, txtFrequency.Text, cboPhysician.SelectedItem, cboPatient.SelectedItem)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        drMsgReader = MessageBox.Show("Are you sure you want to close the window? All data will be lost.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (drMsgReader = DialogResult.Yes) Then
            frmMain.grpDesign.Visible = True
            frmUpdateRecord.Close()
            Me.Close()
        End If
    End Sub

    Private Sub txtRefillAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefillAmt.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class