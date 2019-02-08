Public Class ViewPatients
    Inherits System.Web.UI.Page
    Public Property sortDir() As String
        Get
            Return CStr(ViewState("sortDir"))
        End Get
        Set(ByVal value As String)
            ViewState("sortDir") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
        Else
            'LoadData()
        End If
    End Sub

    Private Sub LoadData()
        Dim DBConnection As New DBConnection
        With Me
            Dim adataset As New DataSet
            adataset = DBConnection.ViewPatients
            .grdStudents.DataSource = adataset.Tables(0)
            .grdStudents.DataBind()
            If Cache("PatientViewData") Is Nothing Then
                Cache.Add("PatientViewData", New DataView(adataset.Tables(0)), Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            End If

        End With
    End Sub


    Public Sub Delete_Click(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try
            Dim chk As CheckBox
            Dim lbl As Label
            Dim stu_ID As String
            Dim aDatatier As New DBConnection
            If grdStudents.Rows.Count > 0 Then
                For Each row As GridViewRow In grdStudents.Rows
                    chk = CType(row.FindControl("chkPatID"), CheckBox)
                    If chk.Checked = True Then
                        lbl = CType(row.Controls(0).FindControl("hidPatID"), Label)
                        stu_ID = lbl.Text.ToString
                        aDatatier.DeleteProcedure(stu_ID, "PATIENT")
                    End If
                Next
                LoadData()
                Dim cba As New StringBuilder
                cba.Append("location.Reload();")
                ClientScript.RegisterClientScriptBlock(GetType(Page), "CloseReloadScript", cba.ToString(), True)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub NewPatient()
        Dim DBConnection As New DBConnection
        Try
            Dim sb As New StringBuilder
            sb.Append("<script language='javascript'>")
            sb.Append("window.open('AddPatient.aspx),")
            sb.Append("'width=525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(GetType(Page), "PopupScript", sb.ToString())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub SearchPatient()
        Dim DBConnection As New DBConnection
        Try
            Dim sb As New StringBuilder
            sb.Append("<script language='javascript'>")
            sb.Append("window.open('SearchPatient.aspx),")
            sb.Append("'width=525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(GetType(Page), "PopupScript", sb.ToString())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub lbtnEdit_Click(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim recordToBeEdited As String
        Dim DBConnection As New DBConnection
        Try
            recordToBeEdited = Trim(e.CommandArgument)
            Dim sb As New StringBuilder
            sb.Append("<script language='javascript'>")
            sb.Append("window.open('UpdatePatient.aspx?ID=" + DBConnection.Encrypt(recordToBeEdited, "12345678") + "&type=Edit" + "'  , 'student',") 'StudentDataTier.Encrypt(recordToBeEdited, "12345678")
            sb.Append("'width=525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(GetType(Page), "PopupScript", sb.ToString())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub grdStudents_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdStudents.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then

            CType(e.Row.FindControl("cbSelectAll"), CheckBox).Attributes.Add("onclick",
            "javascript:SelectAll('" + CType(e.Row.FindControl("cbSelectAll"),
            CheckBox).ClientID + "')")

        End If

    End Sub
    Private Sub grdStudents_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdStudents.PageIndexChanging
        grdStudents.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Private Sub SortRecords(ByVal sortExpress As String)
        Dim oldExpression As String = grdStudents.SortExpression
        Dim newExpression As String = sortExpress
        Dim lastValue, theSortField As String
        Dim source As DataView
        Dim theDirection As String
        Dim wildChar As String
        Dim sortExpression As String

        theDirection = " "
        wildChar = "%"

        Try
            lastValue = CType(ViewState("sortValue"), String)
            sortExpression = sortExpress
            theSortField = CType(ViewState("sortField"), String)
            If Me.sortDir = "desc" Then
                Me.sortDir = "asc"
            Else
                Me.sortDir = "desc"
            End If

            source = Cache("PatientViewData")
            source.Sort = (" " + sortExpression + " " + Me.sortDir)

            grdStudents.DataSource = source
            grdStudents.DataBind()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub grdStudents_Sorting(sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdStudents.Sorting
        SortRecords(e.SortExpression)
    End Sub
End Class