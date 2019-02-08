Public Class Login1
    Inherits System.Web.UI.Page

    Public cmdString As New SqlClient.SqlCommand
    Public Reply As String
    Public userPassword As String = ""
    Public hidePassword As String = ""

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String
        Dim DBConnection As DBConnection = New DBConnection()
        username = txtLogin.Text.Trim()
        DBConnection.LoginCheck(username)
        If DBConnection.Reply <> "" Then
            Select Case (DBConnection.Reply)
                Case "Bad Login"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "badLogin();", True)
                Case "Login Error"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "loginErr();", True)
                Case "No DB"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "noDB();", True)
            End Select
            Exit Sub
        Else
            'lblTest.Text = cmdString.ExecuteScalar()
            Session("username") = txtLogin.Text
            Response.Redirect("Dashboard.aspx", True)
        End If

    End Sub

End Class