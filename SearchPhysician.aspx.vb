Public Class SearchPhysician
    Inherits System.Web.UI.Page
    Public Property sortDir() As String
        Get
            Return CStr(ViewState("sortDir"))
        End Get
        Set(ByVal value As String)
            ViewState("sortDir") = value
        End Set
    End Property
    Public DBConnection As New DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadAllData()
    End Sub

    Private Sub LoadAllData()
        With Me
            Dim adataset As New DataSet
            adataset = DBConnection.ViewPhysicians
            .grdStudents.DataSource = adataset.Tables(0)
            .grdStudents.DataBind()
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
                    chk = CType(row.FindControl("chkPhyID"), CheckBox)
                    If chk.Checked = True Then
                        lbl = CType(row.Controls(0).FindControl("hidPhyID"), Label)
                        stu_ID = lbl.Text.ToString
                        aDatatier.DeleteProcedure(stu_ID, "PHYSICIAN")
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

    Public Sub lbtnEdit_Click(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim recordToBeEdited As String
        Dim DBConnection As New DBConnection
        Try
            recordToBeEdited = Trim(e.CommandArgument)
            Dim sb As New StringBuilder
            sb.Append("<script language='javascript'>")
            sb.Append("window.open('UpdatePhysician.aspx?ID=" + DBConnection.Encrypt(recordToBeEdited, "12345678") + "&type=Edit" + "'  , 'student',") 'StudentDataTier.Encrypt(recordToBeEdited, "12345678")
            sb.Append("'width=525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(GetType(Page), "PopupScript", sb.ToString())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            'Dim script As String = "<script type=""text/javascript"">window.open(""AddPatient.aspx"",""_self"")</script>"
            Response.Redirect("ViewPhysicians.aspx")
            'ClientScript.RegisterStartupScript(Me.GetType, "openWindow", script)
        Catch ex As Exception
            Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
        End Try
    End Sub

    Private Sub LoadData()
        Dim adataset As New DataSet
        With Me
            adataset = DBConnection.SearchPhysicians(ViewState("physicianid"), ViewState("fname"), ViewState("lname"), ViewState("gender"), ViewState("officephone"), ViewState("workemail"), ViewState("position"), ViewState("specialty"))
            .grdStudents.DataSource = adataset.Tables(0)
            If Cache("PhysicianData") Is Nothing Then
                Cache.Add("PhysicianData", New DataView(adataset.Tables(0)), Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            End If
            .grdStudents.DataBind()
        End With
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
            source = Cache("PhysicianData")
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

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim physicianid, fname, lname, gender, officePhone, workEmail, position, specialty As String
        Try
            With Me
                physicianid = txtPhysicianID.Text.Trim()
                fname = txtFName.Text.Trim()
                lname = txtLName.Text.Trim()
                gender = ddlGender.Text
                officePhone = txtOfficePhone.Text.Trim()
                workEmail = txtWorkEmail.Text.Trim()
                position = txtPosition.Text.Trim()
                specialty = txtSpecialty.Text.Trim()
                ViewState("physicianid") = physicianid
                ViewState("fname") = fname
                ViewState("lname") = lname
                ViewState("gender") = gender
                ViewState("officephone") = officePhone
                ViewState("workemail") = workEmail
                ViewState("position") = position
                ViewState("specialty") = specialty
                LoadData()
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

End Class