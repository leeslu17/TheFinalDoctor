Public Class AddPatient
    Inherits System.Web.UI.Page
    Public Reply As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlState.DataSource = StateManager.getStates()
        ddlState.DataTextField = "FullAndAbbrev"
        ddlState.DataValueField = "abbreviation"
        ddlState.Text = "PA"
        ddlState.DataBind()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim aAddRecordPatient As New DBConnection()
        Dim Reply, str, cutdown As String
        Dim textBoxes = Me.Controls.OfType(Of TextBox)
        Dim errCount As Integer = 0
        Try
            str = txtDOB.Text
            Try
                cutdown = txtPatID.Text.Substring(0, 1)
                If (txtPatID.Text.Trim().Length <> 5 And cutdown <> "P") Then
                    lblPatID.Text = "This field needs to be five characters long and begin with a 'P'. Example: P0001"
                    errCount += 1
                Else
                    lblPatID.Text = ""
                End If
            Catch ex As Exception
                lblPatID.Text = "This field needs to be five characters long and begin with a 'P'. Example: P0001"
                errCount += 1
            End Try
            If txtFName.Text = String.Empty Then
                lblFName.Text = "Please enter a first name."
                errCount += 1
            Else
                lblFName.Text = ""
            End If
            If txtLName.Text = String.Empty Then
                lblLName.Text = "Please enter a last name."
                errCount += 1
            Else
                lblLName.Text = ""
            End If
            Try
                If txtDOB.Text = String.Empty Then
                    lblDOB.Text = "Please enter a valid date in the format of 'mm/dd/yyyy'. Example:09/23/1998"
                    errCount += 1
                    Exit Try
                Else
                    If txtDOB.Text.Trim.Length <> 10 Then
                        lblDOB.Text = "Please enter a valid date in the format of 'mm/dd/yyyy'. Example:09/23/1998"
                        errCount += 1
                        Exit Try
                    Else
                        cutdown = str.Substring(0, 2)
                        If Integer.Parse(cutdown) > 12 Then
                            lblDOB.Text = "Please enter a valid date in the format of 'mm/dd/yyyy'. Example:09/23/1998"
                            errCount += 1
                            Exit Try
                        End If
                        cutdown = str.Substring(3, 2)
                        If Integer.Parse(cutdown) > 31 Then
                            lblDOB.Text = "Please enter a valid date in the format of 'mm/dd/yyyy'. Example:09/23/1998"
                            errCount += 1
                            Exit Try
                        End If
                        cutdown = str.Substring(6, 4)
                        If Integer.Parse(cutdown) < 1900 Then
                            lblDOB.Text = "Please enter a valid date in the format of 'mm/dd/yyyy'. Example:09/23/1998"
                            errCount += 1
                            Exit Try
                        End If
                    End If
                End If
                If txtDOB.Text <> String.Empty Then
                    lblDOB.Text = "mm/dd/yyyy"
                End If
            Catch ex As Exception

            End Try

            If errCount = 0 Then
                'Checks for empty textboxes
                Try
                    If (txtStreet.Text = "") Then
                        txtStreet.Text = "N/A"
                    End If
                    If (txtCity.Text = "") Then
                        txtCity.Text = "N/A"
                    End If
                    If (txtZIP.Text = "") Then
                        txtZIP.Text = "0"
                    End If
                    If (txtHomePhone.Text = "") Then
                        txtHomePhone.Text = "N/A"
                    End If
                    If (txtCellPhone.Text = "") Then
                        txtCellPhone.Text = "N/A"
                    End If
                    If (txtEmailI.Text = "") Then
                        txtEmailI.Text = "N/A"
                    End If
                    If (txtEmailII.Text = "") Then
                        txtEmailII.Text = "N/A"
                    End If
                    If (txtEmailIII.Text = "") Then
                        txtEmailIII.Text = "N/A"
                    End If
                Catch ex As Exception
                    Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
                End Try
                'Adds values to database
                Try
                    aAddRecordPatient.AddPatient(txtPatID.Text, txtFName.Text, txtMidInit.Text, txtLName.Text, ddlGender.Text, txtStreet.Text, txtCity.Text, ddlState.Text,
                                         txtZIP.Text, txtDOB.Text, txtHomePhone.Text, txtCellPhone.Text, txtEmailI.Text, txtEmailII.Text, txtEmailIII.Text)
                    Reply = "Success"
                Catch ex As Exception
                    Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
                    Reply = "Fail"
                End Try
                aAddRecordPatient.connString.Close()
                btnClose.Text = "REFRESH"
            End If
        Catch ex As Exception
            Dim script As String = "<script type='text/javascript'> alert('" + ex.Message + "');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", script)
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
End Class