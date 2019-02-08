Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication
    Public connString As New SqlClient.SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=30;integrated security=SSPI;")
    Public cmdString As New SqlClient.SqlCommand
    Public Reply As String
    Public aAdapter As New SqlClient.SqlDataAdapter
    Public aDataSet As New DataSet
    Public userPassword As String = ""
    Public hidePassword As String = ""
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub


End Class