Public Class AddPhysician
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlState.DataSource = StateManager.getStates()
        ddlState.DataTextField = "FullAndAbbrev"
        ddlState.DataValueField = "abbreviation"
        ddlState.Text = "PA"
        ddlState.DataBind()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim DBConnection As New DBConnection()
        Dim Reply As String
        Dim textBoxes = Me.Controls.OfType(Of TextBox)
        'Checks for required input (FNAME, LNAME, GENDER, DOB)
        Try
            DBConnection.CheckEmptyTextBoxes(txtFName, "FNAME")
            DBConnection.CheckEmptyTextBoxes(txtLName, "LNAME")
            If ddlState.Text = "" Then
                ddlState.SelectedIndex = 0
            End If
            'Invalid Gender
            If (String.IsNullOrEmpty(ddlGender.Text)) Then
                Exit Sub
            End If
            If DBConnection.strResult = "Fail" Then
                Exit Sub
            End If
        Catch ex As Exception
            Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
        End Try
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
            Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
        End Try
        'Adds values to database
        Try
            DBConnection.AddPhysician(txtPhyID.Text, txtFName.Text, txtMidInit.Text, txtLName.Text, ddlGender.Text, txtStreet.Text, txtCity.Text, ddlState.Text,
                                         txtZIP.Text, Date.Parse(txtDOB.Text), txtOfficePhone.Text, txtPersonalPhone.Text, txtEmailI.Text, txtEmailII.Text, txtWorkEmail.Text, txtPosition.Text, txtSpecialty.Text, Decimal.Parse(txtSalary.Text))
            Reply = "Success"
        Catch ex As Exception
            Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
            Reply = "Fail"
        End Try
        DBConnection.connString.Close()
        btnClose.Text = "REFRESH"
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

End Class