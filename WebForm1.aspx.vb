Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'lblPatient_ID = "Pat_ID"

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If txtPatID.Text.Length > 0 Then

            lblFname.Text = "Fname"
            lblMint.Text = "Mint"
            lblLname.Text = "Lname"
            lblGender.Text = "Gender"

            lblStreet.Text = "Street"
            lblCity.Text = "City"
            lblState.Text = "State"
            lblZip.Text = "Zip"

            lblHome.Text = "Home"
            lblCell.Text = "Cell"
            lblEmail1.Text = "Email1"
            lblEmail2.Text = "Email2"
            lblEmail3.Text = "Email3"

        End If

    End Sub
End Class