Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblWelcome.Text = "Welcome Back to XYZ Health " + (Session("username"))
    End Sub

End Class