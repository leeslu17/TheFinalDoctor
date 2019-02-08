<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateRecordPrescription
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtRecordID = New System.Windows.Forms.TextBox()
        Me.lblRecordID = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtMedName = New System.Windows.Forms.TextBox()
        Me.txtRefillAmt = New System.Windows.Forms.TextBox()
        Me.txtDosage = New System.Windows.Forms.TextBox()
        Me.txtIntakeMethod = New System.Windows.Forms.TextBox()
        Me.txtFrequency = New System.Windows.Forms.TextBox()
        Me.cboPatient = New System.Windows.Forms.ComboBox()
        Me.cboPhysician = New System.Windows.Forms.ComboBox()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.lblFrequency = New System.Windows.Forms.Label()
        Me.lblIntakeMethod = New System.Windows.Forms.Label()
        Me.lblDosage = New System.Windows.Forms.Label()
        Me.lblMedName = New System.Windows.Forms.Label()
        Me.lblRXNum = New System.Windows.Forms.Label()
        Me.dgvRecordIDTest2 = New System.Windows.Forms.DataGridView()
        Me.dgvRecordIDTest = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvRecordIDTest2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRecordIDTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRecordID
        '
        Me.txtRecordID.Enabled = False
        Me.txtRecordID.Location = New System.Drawing.Point(220, 13)
        Me.txtRecordID.Name = "txtRecordID"
        Me.txtRecordID.Size = New System.Drawing.Size(117, 20)
        Me.txtRecordID.TabIndex = 2
        '
        'lblRecordID
        '
        Me.lblRecordID.AutoSize = True
        Me.lblRecordID.BackColor = System.Drawing.Color.Transparent
        Me.lblRecordID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordID.ForeColor = System.Drawing.Color.White
        Me.lblRecordID.Location = New System.Drawing.Point(120, 11)
        Me.lblRecordID.Name = "lblRecordID"
        Me.lblRecordID.Size = New System.Drawing.Size(94, 24)
        Me.lblRecordID.TabIndex = 1
        Me.lblRecordID.Text = "Record ID"
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.DarkBlue
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.White
        Me.btnBack.Location = New System.Drawing.Point(101, 240)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 28)
        Me.btnBack.TabIndex = 17
        Me.btnBack.Text = "Back"
        Me.ToolTip1.SetToolTip(Me.btnBack, "Back to record selection")
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.DarkBlue
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(262, 240)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Exit the update GUI")
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.DarkBlue
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(181, 240)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 28)
        Me.btnUpdate.TabIndex = 18
        Me.btnUpdate.Text = "Update"
        Me.ToolTip1.SetToolTip(Me.btnUpdate, "Update the record")
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'txtMedName
        '
        Me.txtMedName.Location = New System.Drawing.Point(220, 37)
        Me.txtMedName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMedName.Name = "txtMedName"
        Me.txtMedName.Size = New System.Drawing.Size(117, 20)
        Me.txtMedName.TabIndex = 4
        '
        'txtRefillAmt
        '
        Me.txtRefillAmt.Location = New System.Drawing.Point(220, 65)
        Me.txtRefillAmt.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRefillAmt.Name = "txtRefillAmt"
        Me.txtRefillAmt.Size = New System.Drawing.Size(117, 20)
        Me.txtRefillAmt.TabIndex = 6
        '
        'txtDosage
        '
        Me.txtDosage.Location = New System.Drawing.Point(220, 94)
        Me.txtDosage.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDosage.Name = "txtDosage"
        Me.txtDosage.Size = New System.Drawing.Size(117, 20)
        Me.txtDosage.TabIndex = 8
        '
        'txtIntakeMethod
        '
        Me.txtIntakeMethod.Location = New System.Drawing.Point(220, 122)
        Me.txtIntakeMethod.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIntakeMethod.Name = "txtIntakeMethod"
        Me.txtIntakeMethod.Size = New System.Drawing.Size(117, 20)
        Me.txtIntakeMethod.TabIndex = 10
        '
        'txtFrequency
        '
        Me.txtFrequency.Location = New System.Drawing.Point(220, 151)
        Me.txtFrequency.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFrequency.Name = "txtFrequency"
        Me.txtFrequency.Size = New System.Drawing.Size(117, 20)
        Me.txtFrequency.TabIndex = 12
        '
        'cboPatient
        '
        Me.cboPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatient.FormattingEnabled = True
        Me.cboPatient.Location = New System.Drawing.Point(220, 207)
        Me.cboPatient.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPatient.Name = "cboPatient"
        Me.cboPatient.Size = New System.Drawing.Size(117, 21)
        Me.cboPatient.TabIndex = 16
        '
        'cboPhysician
        '
        Me.cboPhysician.FormattingEnabled = True
        Me.cboPhysician.Location = New System.Drawing.Point(220, 179)
        Me.cboPhysician.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPhysician.Name = "cboPhysician"
        Me.cboPhysician.Size = New System.Drawing.Size(117, 21)
        Me.cboPhysician.TabIndex = 14
        '
        'lblPatient
        '
        Me.lblPatient.BackColor = System.Drawing.Color.Transparent
        Me.lblPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatient.ForeColor = System.Drawing.Color.White
        Me.lblPatient.Location = New System.Drawing.Point(12, 206)
        Me.lblPatient.Name = "lblPatient"
        Me.lblPatient.Size = New System.Drawing.Size(202, 21)
        Me.lblPatient.TabIndex = 15
        Me.lblPatient.Text = "*Patient ID:"
        Me.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDoc
        '
        Me.lblDoc.BackColor = System.Drawing.Color.Transparent
        Me.lblDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoc.ForeColor = System.Drawing.Color.White
        Me.lblDoc.Location = New System.Drawing.Point(12, 178)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(202, 21)
        Me.lblDoc.TabIndex = 13
        Me.lblDoc.Text = "*Prescribing Doctor ID:"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFrequency
        '
        Me.lblFrequency.BackColor = System.Drawing.Color.Transparent
        Me.lblFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrequency.ForeColor = System.Drawing.Color.White
        Me.lblFrequency.Location = New System.Drawing.Point(12, 149)
        Me.lblFrequency.Name = "lblFrequency"
        Me.lblFrequency.Size = New System.Drawing.Size(202, 21)
        Me.lblFrequency.TabIndex = 11
        Me.lblFrequency.Text = "*Frequency:"
        Me.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntakeMethod
        '
        Me.lblIntakeMethod.BackColor = System.Drawing.Color.Transparent
        Me.lblIntakeMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntakeMethod.ForeColor = System.Drawing.Color.White
        Me.lblIntakeMethod.Location = New System.Drawing.Point(12, 120)
        Me.lblIntakeMethod.Name = "lblIntakeMethod"
        Me.lblIntakeMethod.Size = New System.Drawing.Size(202, 21)
        Me.lblIntakeMethod.TabIndex = 9
        Me.lblIntakeMethod.Text = "*Intake Method:"
        Me.lblIntakeMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDosage
        '
        Me.lblDosage.BackColor = System.Drawing.Color.Transparent
        Me.lblDosage.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDosage.ForeColor = System.Drawing.Color.White
        Me.lblDosage.Location = New System.Drawing.Point(12, 92)
        Me.lblDosage.Name = "lblDosage"
        Me.lblDosage.Size = New System.Drawing.Size(202, 21)
        Me.lblDosage.TabIndex = 7
        Me.lblDosage.Text = "*Dosage:"
        Me.lblDosage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMedName
        '
        Me.lblMedName.BackColor = System.Drawing.Color.Transparent
        Me.lblMedName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedName.ForeColor = System.Drawing.Color.White
        Me.lblMedName.Location = New System.Drawing.Point(12, 35)
        Me.lblMedName.Name = "lblMedName"
        Me.lblMedName.Size = New System.Drawing.Size(202, 21)
        Me.lblMedName.TabIndex = 3
        Me.lblMedName.Text = "*Medication Name:"
        Me.lblMedName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRXNum
        '
        Me.lblRXNum.BackColor = System.Drawing.Color.Transparent
        Me.lblRXNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRXNum.ForeColor = System.Drawing.Color.White
        Me.lblRXNum.Location = New System.Drawing.Point(12, 63)
        Me.lblRXNum.Name = "lblRXNum"
        Me.lblRXNum.Size = New System.Drawing.Size(202, 21)
        Me.lblRXNum.TabIndex = 5
        Me.lblRXNum.Text = "*Refill Amount:"
        Me.lblRXNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvRecordIDTest2
        '
        Me.dgvRecordIDTest2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecordIDTest2.Location = New System.Drawing.Point(374, 248)
        Me.dgvRecordIDTest2.Name = "dgvRecordIDTest2"
        Me.dgvRecordIDTest2.Size = New System.Drawing.Size(22, 16)
        Me.dgvRecordIDTest2.TabIndex = 39
        Me.dgvRecordIDTest2.Visible = False
        '
        'dgvRecordIDTest
        '
        Me.dgvRecordIDTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecordIDTest.Location = New System.Drawing.Point(366, 235)
        Me.dgvRecordIDTest.Name = "dgvRecordIDTest"
        Me.dgvRecordIDTest.Size = New System.Drawing.Size(20, 12)
        Me.dgvRecordIDTest.TabIndex = 38
        Me.dgvRecordIDTest.Visible = False
        '
        'frmUpdateRecordPrescription
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkBlue
        Me.BackgroundImage = Global.frmMain.My.Resources.Resources.frmBack3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(352, 277)
        Me.Controls.Add(Me.dgvRecordIDTest2)
        Me.Controls.Add(Me.dgvRecordIDTest)
        Me.Controls.Add(Me.txtRecordID)
        Me.Controls.Add(Me.lblRecordID)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtMedName)
        Me.Controls.Add(Me.txtRefillAmt)
        Me.Controls.Add(Me.txtDosage)
        Me.Controls.Add(Me.txtIntakeMethod)
        Me.Controls.Add(Me.txtFrequency)
        Me.Controls.Add(Me.cboPatient)
        Me.Controls.Add(Me.cboPhysician)
        Me.Controls.Add(Me.lblPatient)
        Me.Controls.Add(Me.lblDoc)
        Me.Controls.Add(Me.lblFrequency)
        Me.Controls.Add(Me.lblIntakeMethod)
        Me.Controls.Add(Me.lblDosage)
        Me.Controls.Add(Me.lblMedName)
        Me.Controls.Add(Me.lblRXNum)
        Me.Name = "frmUpdateRecordPrescription"
        Me.Text = "Update Prescription"
        CType(Me.dgvRecordIDTest2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRecordIDTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtRecordID As TextBox
    Friend WithEvents lblRecordID As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtMedName As TextBox
    Friend WithEvents txtRefillAmt As TextBox
    Friend WithEvents txtDosage As TextBox
    Friend WithEvents txtIntakeMethod As TextBox
    Friend WithEvents txtFrequency As TextBox
    Friend WithEvents cboPatient As ComboBox
    Friend WithEvents cboPhysician As ComboBox
    Friend WithEvents lblPatient As Label
    Friend WithEvents lblDoc As Label
    Friend WithEvents lblFrequency As Label
    Friend WithEvents lblIntakeMethod As Label
    Friend WithEvents lblDosage As Label
    Friend WithEvents lblMedName As Label
    Friend WithEvents lblRXNum As Label
    Friend WithEvents dgvRecordIDTest2 As DataGridView
    Friend WithEvents dgvRecordIDTest As DataGridView
    Friend WithEvents ToolTip1 As ToolTip
End Class
