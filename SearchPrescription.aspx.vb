Imports System.Data.SqlClient

Public Class SearchPrescription
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
            adataset = DBConnection.ViewPrescriptions
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
                    chk = CType(row.FindControl("chkPreID"), CheckBox)
                    If chk.Checked = True Then
                        lbl = CType(row.Controls(0).FindControl("hidPreID"), Label)
                        stu_ID = lbl.Text.ToString
                        aDatatier.DeleteProcedure(stu_ID, "PRESCRIPTION")
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
            sb.Append("window.open('UpdatePrescription.aspx?ID=" + DBConnection.Encrypt(recordToBeEdited, "12345678") + "&type=Edit" + "'  , 'student',") 'StudentDataTier.Encrypt(recordToBeEdited, "12345678")
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
            Response.Redirect("ViewPrescriptions.aspx")
            'ClientScript.RegisterStartupScript(Me.GetType, "openWindow", script)
        Catch ex As Exception
            Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
        End Try
    End Sub

    Private Sub LoadData()
        Dim adataset As New DataSet
        With Me
            adataset = DBConnection.SearchPrescriptions(ViewState("prescriptionid"), ViewState("medicationname"), ViewState("physicianid"), ViewState("patientid"))
            .grdStudents.DataSource = adataset.Tables(0)
            If Cache("PrescriptionData") Is Nothing Then
                Cache.Add("PrescriptionData", New DataView(adataset.Tables(0)), Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            End If
            .grdStudents.DataBind()
        End With
    End Sub

    Private Sub grdStudents_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdStudents.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then
            CType(e.Row.FindControl("cbSelectAll"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll('" + CType(e.Row.FindControl("cbSelectAll"), CheckBox).ClientID + "')")
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
            source = Cache("PrescriptionData")
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
        Dim prescriptionid, medicationname, physicianid, patientid As String
        Try
            With Me
                prescriptionid = txtPrescriptionID.Text.Trim()
                medicationname = txtMedicationName.Text.Trim()
                physicianid = txtPhysicianID.Text.Trim()
                patientid = txtPatientID.Text.Trim()

                ViewState("physicianid") = physicianid
                ViewState("prescriptionid") = prescriptionid
                ViewState("medicationname") = medicationname
                ViewState("patientid") = patientid
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
        Dim cmdString As String = "select FNAME from PHYSICIAN where fname LIKE '" &
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
        Dim cmdString As String = "select LNAME from PHYSICIAN where lname LIKE '" &
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
        Dim cmdString As String = "select MIDINIT from PHYSICIAN where midinit LIKE '" &
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
        Dim cmdString As String = "select PHYSICIAN_ID from PHYSICIAN where physician_id LIKE '" &
            prefixText & "%'"

        conn = New SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=30;integrated security=SSPI;")
        cmd = New SqlCommand(cmdString, conn)
        conn.Open()

        Dim myReader As SqlDataReader
        Dim returnData As List(Of String) = New List(Of String)
        myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While myReader.Read()
            returnData.Add(myReader("physician_id").ToString())
        End While

        Return returnData.ToArray()

    End Function

End Class