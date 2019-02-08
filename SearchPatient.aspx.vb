

Imports System.Data.SqlClient

Public Class SearchPatient
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
            adataset = DBConnection.ViewPatients
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

    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            'Dim script As String = "<script type=""text/javascript"">window.open(""AddPatient.aspx"",""_self"")</script>"
            Response.Redirect("ViewPatients.aspx")
            'ClientScript.RegisterStartupScript(Me.GetType, "openWindow", script)
        Catch ex As Exception
            Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
        End Try
    End Sub

    Private Sub LoadData()
        Dim adataset As New DataSet
        With Me
            adataset = DBConnection.SearchPatients((ViewState("patientid")), (ViewState("fname")), (ViewState("lname")), (ViewState("gender")))
            .grdStudents.DataSource = adataset.Tables(0)
            If Cache("PatientData") Is Nothing Then
                Cache.Add("PatientData", New DataView(adataset.Tables(0)), Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
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

            source = Cache("PatientData")
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
        Dim patientid, fname, midinit, lname, gender As String
        Try
            With Me
                patientid = txtPatientID.Text.Trim()
                fname = txtFName.Text.Trim()
                midinit = txtMidInit.Text.Trim()
                lname = txtLName.Text.Trim()
                gender = ddlGender.Text
                ViewState("patientid") = patientid
                ViewState("fname") = fname
                ViewState("midinit") = midinit
                ViewState("lname") = lname
                ViewState("gender") = gender
                LoadData()
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    <System.Web.Services.WebMethodAttribute()>
    <System.Web.Script.Services.ScriptMethodAttribute()>
    Public Shared Function GetCompletionFname(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim cmdString As String = "select FNAME from PATIENT where fname LIKE '" &
            prefixText & "%'"

        conn = New SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=30;integrated security=SSPI;")
        cmd = New SqlCommand(cmdString, conn)
        conn.Open()

        Dim myReader As SqlDataReader
        Dim returnData As List(Of String) = New List(Of String)
        myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While myReader.Read()
            returnData.Add(myReader("fname").ToString())
        End While

        Return returnData.ToArray()

    End Function

    <System.Web.Services.WebMethodAttribute()>
    <System.Web.Script.Services.ScriptMethodAttribute()>
    Public Shared Function GetCompletionLname(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim cmdString As String = "select LNAME from PATIENT where lname LIKE '" &
            prefixText & "%'"

        conn = New SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=30;integrated security=SSPI;")
        cmd = New SqlCommand(cmdString, conn)
        conn.Open()

        Dim myReader As SqlDataReader
        Dim returnData As List(Of String) = New List(Of String)
        myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While myReader.Read()
            returnData.Add(myReader("lname").ToString())
        End While

        Return returnData.ToArray()

    End Function

    <System.Web.Services.WebMethodAttribute()>
    <System.Web.Script.Services.ScriptMethodAttribute()>
    Public Shared Function GetCompletionMidInt(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim cmdString As String = "select MIDINIT from PATIENT where midinit LIKE '" &
            prefixText & "%'"

        conn = New SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=30;integrated security=SSPI;")
        cmd = New SqlCommand(cmdString, conn)
        conn.Open()

        Dim myReader As SqlDataReader
        Dim returnData As List(Of String) = New List(Of String)
        myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While myReader.Read()
            returnData.Add(myReader("midinit").ToString())
        End While

        Return returnData.ToArray()

    End Function

    <System.Web.Services.WebMethodAttribute()>
    <System.Web.Script.Services.ScriptMethodAttribute()>
    Public Shared Function GetCompletionPatientID(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim cmdString As String = "select PATIENT_ID from PATIENT where patient_id LIKE '" &
            prefixText & "%'"

        conn = New SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=30;integrated security=SSPI;")
        cmd = New SqlCommand(cmdString, conn)
        conn.Open()

        Dim myReader As SqlDataReader
        Dim returnData As List(Of String) = New List(Of String)
        myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While myReader.Read()
            returnData.Add(myReader("patient_id").ToString())
        End While

        Return returnData.ToArray()

    End Function


End Class