Public Class Test1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Info As ContentPlaceHolder
        Info = Master.FindControl("infoDiv")

    End Sub

End Class