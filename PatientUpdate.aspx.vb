Imports System.Security.Cryptography
Public Class StudentEdit
    Inherits System.Web.UI.Page

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DBConnection As New DBConnection
        Dim ds As New DataSet
        Dim myedit As String
        Dim drData As New DoctorDataTier

        div2.Visible = False

        ds = drData.GetPrescriptionByID

        If txtPre_ID.Text.Length > 0 Then

            lblRefill.Text = ds.Tables(0).Rows(0)("Pre_ID").ToString()
            div2.Visible = True

        End If

    End Sub

    Protected Sub btnDecrease_Click(sender As Object, e As EventArgs) Handles btnDecrease.Click
        If txtInput.Text.Length > 0 And ((lblRefill.Text.Length) - (txtInput.Text.Length)) >= 0 Then
            DoctorDataTier.IncreasePre(txtInput.Text)
            lblReffill.Text += txtInput.Text
            txtInput.Text = ""
        End If
    End Sub

    Protected Sub btnIncrease_Click(sender As Object, e As EventArgs) Handles btnIncrease.Click
        If txtInput.Text.Length > 0 Then
            DoctorDataTier.DecreasePre(txtInput.Text)
            lblRefill.Text -= txtInput.Text
            txtInput.Text = ""
        End If
    End Sub
End Class