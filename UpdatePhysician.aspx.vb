Public Class UpdatePhysician
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myid, myedit As String
        Dim gender, state As String
        Dim DBConnection As New DBConnection
        myedit = ""

        Page.ClientScript.RegisterClientScriptInclude("Test", "MyScript.js")

        If Not IsPostBack Then
            Dim strCrypt As String
            strCrypt = Request.QueryString("ID").Trim
            myid = DBConnection.Decrypt(strCrypt.Replace(" ", "+"), "12345678")
            If Not IsNothing(Request.QueryString("type")) And (Request.QueryString("type") <> String.Empty) Then
                myedit = Request.QueryString("type").Trim
            End If
            Dim ds As New DataSet

            ds = DBConnection.GetPhysicianByID(myid)
            If myedit.ToUpper = "EDIT" Then
                With Me
                    .lblPhysicianID.Text = ds.Tables(0).Rows(0)("Physician_ID").ToString()
                    .txtFName.Text = ds.Tables(0).Rows(0)("fname").ToString()
                    .txtMidInit.Text = ds.Tables(0).Rows(0)("midinit").ToString()
                    .txtLName.Text = ds.Tables(0).Rows(0)("lname").ToString()
                    .txtDOB.Text = ds.Tables(0).Rows(0)("DOB").ToString()

                    .txtStreet.Text = ds.Tables(0).Rows(0)("street").ToString()
                    .txtCity.Text = ds.Tables(0).Rows(0)("city").ToString()
                    .txtZIP.Text = ds.Tables(0).Rows(0)("zip").ToString()
                    .txtOfficePhone.Text = ds.Tables(0).Rows(0)("Office_Phone").ToString()
                    .txtPersonalPhone.Text = ds.Tables(0).Rows(0)("Personal_Phone").ToString()
                    .txtEmailI.Text = ds.Tables(0).Rows(0)("Email_I").ToString()
                    .txtEmailII.Text = ds.Tables(0).Rows(0)("Email_II").ToString()
                    .txtWorkEmail.Text = ds.Tables(0).Rows(0)("Work_Email").ToString()

                    .txtPosition.Text = ds.Tables(0).Rows(0)("Position").ToString()
                    .txtSpecialty.Text = ds.Tables(0).Rows(0)("Specialty").ToString()
                    .txtSalary.Text = ds.Tables(0).Rows(0)("Salary").ToString()

                    gender = ds.Tables(0).Rows(0)("GENDER").ToString()
                    .ddlGender.Text = gender
                    state = ds.Tables(0).Rows(0)("Physician_State").ToString()
                    .ddlState.Text = state
                End With
                ddlState.DataSource = StateManager.getStates()
                ddlState.DataTextField = "FullAndAbbrev"
                ddlState.DataValueField = "abbreviation"
                If state = "NA" Or state = "N/A" Then
                    ddlState.Text = "PA"
                Else
                    ddlState.SelectedValue = state
                End If
                ddlState.DataBind()
            Else
                With Me
                    .lblPhysicianID.Text = ds.Tables(0).Rows(0)("Student_ID").ToString()
                    .txtFName.Text = ds.Tables(0).Rows(0)("fname").ToString()
                    .txtFName.Enabled = False

                    gender = ds.Tables(0).Rows(0)("gender_desc").ToString()
                    .ddlGender.SelectedItem.Text = gender
                    .ddlGender.Enabled = False
                End With
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim DBConnection As New DBConnection
        Dim textBoxes = Me.Controls.OfType(Of TextBox)
        Try

            'Checks for empty textboxes
            Try
                For Each txtbx In textBoxes
                    If String.IsNullOrEmpty(txtbx.Text) Then
                        txtbx.Text = "N/A"
                    End If
                Next txtbx
                If (txtZIP.Text = "N/A") Then
                    txtZIP.Text = "00000"
                End If
            Catch ex As Exception

            End Try
            DBConnection.UpdatePhysician(lblPhysicianID.Text, txtFName.Text, txtMidInit.Text, txtLName.Text, ddlGender.Text, txtStreet.Text, txtCity.Text, ddlState.Text, txtZIP.Text, txtDOB.Text, txtOfficePhone.Text, txtPersonalPhone.Text, txtWorkEmail.Text, txtEmailI.Text, txtEmailII.Text, txtPosition.Text, txtSpecialty.Text, txtSalary.Text)
        Catch ex As Exception

        End Try

        btnClose.Text = "REFRESH"
    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            If btnClose.Text.ToUpper = "REFRESH" Then
                Dim cb As New StringBuilder
                cb.Append("opener.location.href='ViewPhysicians.aspx';")
                cb.Append("var ie7 = (document.all && !window.opera && window.XMLHttpRequest)? true:false;")
                cb.Append("if(ie7)")
                cb.Append("{")
                cb.Append("window.open('','_parent','');")
                cb.Append("window.close();")
                cb.Append("}")
                cb.Append("else")
                cb.Append("{")
                cb.Append("this.focus();")
                cb.Append("self.opener=this;")
                cb.Append("self.close();")
                cb.Append("}")
                ClientScript.RegisterClientScriptBlock(GetType(Page), "CloseReloadScript", cb.ToString(), True)
            ElseIf btnClose.Text.ToUpper = "CLOSE" Then
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "closeform", "CloseMe()", True)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class