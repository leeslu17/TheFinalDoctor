Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports System.Security.Cryptography
Public Class DBConnection
    Public connString As New SqlClient.SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=10;integrated security=SSPI;")
    Public cmdString As New SqlClient.SqlCommand
    Public Reply As String
    Public aAdapter As New SqlClient.SqlDataAdapter
    Public aDataSet As New DataSet
    Public userPassword As String = ""
    Public hidePassword As String = ""
    Public strResult As String
    Public UserType As String
    Private key() As Byte = {}
    Private IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

    Public Function LoginCheck(username)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            Try
                If (username.Length <> 5) Or (username = "Username") Or (username = Nothing) Then
                    Return Reply = "Bad Login"
                    Exit Function
                End If
                UserType = username.Substring(0, 1)
                With cmdString
                    .Connection = connString
                    .CommandType = CommandType.StoredProcedure
                    .CommandTimeout = 900
                    Select Case UserType
                        Case ("P").ToUpper()
                            .CommandText = "CHECKPATIENTS"
                            .Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 5).Value = username
                        Case ("D").ToUpper()
                            .CommandText = "CHECKPHYSICIANS"
                            .Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = username
                        Case Else
                            Reply = "Bad Login"
                            Return Reply
                            Exit Function
                    End Select
                End With
            Catch ex As Exception
                Return Reply = "Login Error"
                Exit Function
            End Try
        Catch ex As Exception
            Return Reply = "No DB"
            Exit Function
        End Try
        Return Reply = ""
    End Function

    Public Function ViewPatients()
        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "VIEWPATIENTS"
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function ViewPhysicians()
        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "VIEWPHYSICIANS"
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function ViewPrescriptions()
        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "VIEWPRESCRIPTIONS"
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function GetPatientByID(patientID)
        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "CHECKPATIENTS"
            cmdString.Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 5).Value = patientID
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function GetPhysicianByID(physicianID)
        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "CHECKPHYSICIANS"
            cmdString.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Sub UpdatePatient(ByVal PATIENT_ID As String, ByVal FNAME As String, ByVal MIDINIT As String, ByVal LNAME As String, ByVal GENDER As String, ByVal STREET As String,
                          ByVal CITY As String, ByVal PATIENT_STATE As String, ByVal ZIP As Decimal, ByVal DOB As Date, ByVal HOME_PHONE As String, ByVal CELL_PHONE As String,
                          ByVal EMAIL_I As String, ByVal EMAIL_II As String, ByVal EMAIL_III As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "UPDATEPATIENT"
                .Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID)
                .Parameters.AddWithValue("@FNAME", FNAME)
                .Parameters.AddWithValue("@MIDINIT", MIDINIT)
                .Parameters.AddWithValue("@LNAME", LNAME)
                .Parameters.AddWithValue("@GENDER", GENDER)
                .Parameters.AddWithValue("@STREET", STREET)
                .Parameters.AddWithValue("@CITY", CITY)
                .Parameters.AddWithValue("@PATIENT_STATE", PATIENT_STATE)
                .Parameters.AddWithValue("@ZIP", ZIP)
                .Parameters.AddWithValue("@DOB", DOB)
                .Parameters.AddWithValue("@HOME_PHONE", HOME_PHONE)
                .Parameters.AddWithValue("@CELL_PHONE", CELL_PHONE)
                .Parameters.AddWithValue("@EMAIL_I", EMAIL_I)
                .Parameters.AddWithValue("@EMAIL_II", EMAIL_II)
                .Parameters.AddWithValue("@EMAIL_III", EMAIL_III)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
        End Try
        connString.Close()
    End Sub
    Public Sub DBConnection(ByVal ProcedureType As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = ProcedureType
            End With
        Catch ex As Exception
        End Try
    End Sub
    Public Sub AddPatient(ByVal PATIENT_ID As String, ByVal FNAME As String, ByVal MIDINIT As String, ByVal LNAME As String, ByVal GENDER As String, ByVal STREET As String,
                          ByVal CITY As String, ByVal PATIENT_STATE As String, ByVal ZIP As Decimal, ByVal DOB As Date, ByVal HOME_PHONE As String, ByVal CELL_PHONE As String,
                          ByVal EMAIL_I As String, ByVal EMAIL_II As String, ByVal EMAIL_III As String)
        Try
            Dim ProcedureType As String = "ADDPATIENT"
            DBConnection(ProcedureType)
            With cmdString
                .Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID)
                .Parameters.AddWithValue("@FNAME", FNAME)
                .Parameters.AddWithValue("@MIDINIT", MIDINIT)
                .Parameters.AddWithValue("@LNAME", LNAME)
                .Parameters.AddWithValue("@GENDER", GENDER)
                .Parameters.AddWithValue("@STREET", STREET)
                .Parameters.AddWithValue("@CITY", CITY)
                .Parameters.AddWithValue("@PATIENT_STATE", PATIENT_STATE)
                .Parameters.AddWithValue("@ZIP", ZIP)
                .Parameters.AddWithValue("@DOB", DOB)
                .Parameters.AddWithValue("@HOME_PHONE", HOME_PHONE)
                .Parameters.AddWithValue("@CELL_PHONE", CELL_PHONE)
                .Parameters.AddWithValue("@EMAIL_I", EMAIL_I)
                .Parameters.AddWithValue("@EMAIL_II", EMAIL_II)
                .Parameters.AddWithValue("@EMAIL_III", EMAIL_III)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
        End Try
        connString.Close()
    End Sub

    Public Function SearchPatients(ByVal PATIENT_ID As String, ByVal FNAME As String, ByVal LNAME As String, ByVal GENDER As String)
        Try
            'Dim dateDOB As Date = Date.Parse(DOB)
            Dim ProcedureType As String = "SEARCHPATIENTS"
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "SEARCHPATIENTS"
            End With
            'DBConnection(ProcedureType)
            With cmdString
                .Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID)
                .Parameters.AddWithValue("@FNAME", FNAME)
                .Parameters.AddWithValue("@LNAME", LNAME)
                .Parameters.AddWithValue("@GENDER", GENDER)
                '.ExecuteNonQuery()
            End With
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        End Try
        connString.Close()
    End Function

    Public Function SearchPrescriptions(ByVal PRESCRIPTION_ID As String, ByVal MEDICATION_NAME As String, ByVal PHYSICIAN_ID As String, ByVal PATIENT_ID As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "SEARCHPRESCRIPTIONS"
            End With
            'DBConnection(ProcedureType)
            With cmdString
                .Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID)
                .Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID)
                .Parameters.AddWithValue("@MEDICATION_NAME", MEDICATION_NAME)
                .Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID)
                '.ExecuteNonQuery()
            End With
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        End Try
        connString.Close()
    End Function

    Public Function SearchPhysicians(ByVal PHYSICIAN_ID As String, ByVal FNAME As String, ByVal LNAME As String, ByVal GENDER As String, ByVal OFFICE_PHONE As String, ByVal WORK_EMAIL As String, ByVal POSITION As String, ByVal SPECIALTY As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "SEARCHPHYSICIANS"
            End With
            'DBConnection(ProcedureType)
            With cmdString
                .Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID)
                .Parameters.AddWithValue("@FNAME", FNAME)
                .Parameters.AddWithValue("@LNAME", LNAME)
                .Parameters.AddWithValue("@GENDER", GENDER)
                .Parameters.AddWithValue("@OFFICE_PHONE", OFFICE_PHONE)
                .Parameters.AddWithValue("@WORK_EMAIL", WORK_EMAIL)
                .Parameters.AddWithValue("@POSITION", POSITION)
                .Parameters.AddWithValue("@SPECIALTY", SPECIALTY)
                '.ExecuteNonQuery()
            End With
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        End Try
        connString.Close()
    End Function

    Public Sub CheckEmptyTextBoxes(ByVal input As TextBox, ByVal output As String)
        Try
            If (String.IsNullOrEmpty(input.Text)) Then
                strResult = "Fail"
            Else
                strResult = "Success"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function Decrypt(ByVal stringToDecrypt As String, ByVal sEncryptionKey As String) As String
        Dim inputByteArray(stringToDecrypt.Length) As Byte
        Try

            key = System.Text.Encoding.UTF8.GetBytes(Left(sEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV),
                    CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function

    Public Function Encrypt(ByVal stringToEncrypt As String, ByVal SEncryptionKey As String) As String
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(SEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(
                    stringToEncrypt)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV),
                    CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function

    Public Sub DeleteProcedure(ByVal RECORD_ID As String, ByVal RecordType As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            Select Case RecordType
                Case "PATIENT"
                    With cmdString
                        .Connection = connString
                        .CommandType = CommandType.StoredProcedure
                        .CommandTimeout = 900
                        .CommandText = "DELETEPRESCRIPTIONBYPATIENT"
                        .Parameters.AddWithValue("@PATIENT_ID", RECORD_ID)
                        .ExecuteNonQuery()

                        .Parameters.Clear()
                        .Connection = connString
                        .CommandType = CommandType.StoredProcedure
                        .CommandTimeout = 900
                        .CommandText = "DELETEPATIENT"
                        .Parameters.AddWithValue("@PATIENT_ID", RECORD_ID)
                        .ExecuteNonQuery()
                    End With
                Case "PHYSICIAN"
                    With cmdString
                        .Connection = connString
                        .CommandType = CommandType.StoredProcedure
                        .CommandTimeout = 900
                        .CommandText = "DELETEPRESCRIPTIONBYPHYSICIAN"
                        .Parameters.AddWithValue("@PHYSICIAN_ID", RECORD_ID)
                        .ExecuteNonQuery()

                        .Parameters.Clear()
                        .Connection = connString
                        .CommandType = CommandType.StoredProcedure
                        .CommandTimeout = 900
                        .CommandText = "DELETEPHYSICIAN"
                        .Parameters.AddWithValue("@PHYSICIAN_ID", RECORD_ID)
                        .ExecuteNonQuery()
                    End With
                Case "PRESCRIPTION"
                    With cmdString
                        .Connection = connString
                        .CommandType = CommandType.StoredProcedure
                        .CommandTimeout = 900
                        .CommandText = "DELETEPRESCRIPTION"
                        .Parameters.AddWithValue("@PRESCRIPTION_ID", RECORD_ID)
                        .ExecuteNonQuery()
                    End With
            End Select

        Catch ex As Exception

        End Try
        connString.Close()
    End Sub





    'Uses the stored procedure ADDPHYSICIAN to add a physician record from frmAddRecordPhysician
    Public Sub AddPhysician(ByVal PHYSICIAN_ID As String, ByVal FNAME As String, ByVal MIDINIT As String, ByVal LNAME As String, ByVal GENDER As String, ByVal STREET As String,
                          ByVal CITY As String, ByVal PHYSICIAN_STATE As String, ByVal ZIP As Decimal, ByVal DOB As Date, ByVal OFFICE_PHONE As String, ByVal PERSONAL_PHONE As String,
                          ByVal WORK_EMAIL As String, ByVal EMAIL_I As String, ByVal EMAIL_II As String, ByVal POSITION As String, ByVal SPECIALTY As String, ByVal SALARY As Decimal)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "ADDPHYSICIAN"
                .Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID)
                .Parameters.AddWithValue("@FNAME", FNAME)
                .Parameters.AddWithValue("@MIDINIT", MIDINIT)
                .Parameters.AddWithValue("@LNAME", LNAME)
                .Parameters.AddWithValue("@GENDER", GENDER)
                .Parameters.AddWithValue("@STREET", STREET)
                .Parameters.AddWithValue("@CITY", CITY)
                .Parameters.AddWithValue("@PHYSICIAN_STATE", PHYSICIAN_STATE)
                .Parameters.AddWithValue("@ZIP", ZIP)
                .Parameters.AddWithValue("@DOB", DOB)
                .Parameters.AddWithValue("@OFFICE_PHONE", OFFICE_PHONE)
                .Parameters.AddWithValue("@PERSONAL_PHONE", PERSONAL_PHONE)
                .Parameters.AddWithValue("@WORK_EMAIL", WORK_EMAIL)
                .Parameters.AddWithValue("@EMAIL_I", EMAIL_I)
                .Parameters.AddWithValue("@EMAIL_II", EMAIL_II)
                .Parameters.AddWithValue("@POSITION", POSITION)
                .Parameters.AddWithValue("@SPECIALTY", SPECIALTY)
                .Parameters.AddWithValue("@SALARY", SALARY)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        End Try
        connString.Close()
    End Sub

    'Uses the stored procedure ADDPRESCRIPTION to add a prescription record from frmAddRecordPrescription
    Public Sub AddPrescription(ByVal PRESCRIPTION_ID As String, ByVal MEDICATION_NAME As String, ByVal REFILL_AMT As Decimal, ByVal DOSAGE As String,
                          ByVal INTAKE_METHOD As String, ByVal FREQUENCY As String, ByVal PHYSICIAN_ID As String, ByVal PATIENT_ID As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "ADDPRESCRIPTION"
                .Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID)
                .Parameters.AddWithValue("@MEDICATION_NAME", MEDICATION_NAME)
                .Parameters.AddWithValue("@REFILL_AMT", REFILL_AMT)
                .Parameters.AddWithValue("@DOSAGE", DOSAGE)
                .Parameters.AddWithValue("@INTAKE_METHOD", INTAKE_METHOD)
                .Parameters.AddWithValue("@FREQUENCY", FREQUENCY)
                .Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID)
                .Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
        End Try
        connString.Close()
    End Sub

    Public Sub UpdateRecord(ByVal StoredProcedure As String)
        cmdString.Parameters.Clear()
        connString.Open()
        With cmdString
            .Connection = connString
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 900
            .CommandText = StoredProcedure
        End With
        aAdapter.SelectCommand = cmdString
        aAdapter.Fill(aDataSet)
        'If aDataSet.Tables(0).Rows.Count > 0 Then
        'frmUpdateRecord.dgvRecordIDTest.DataSource = aDataSet.Tables(0)
        'End If
        connString.Close()
    End Sub

    'Fills the patient/doctor ID comboboxes on frmAddRecordPrescription
    Public Sub AddPartiesPrescription(ByVal Procedure As String, ByVal DGVOutput As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = Procedure
            End With
            aAdapter.SelectCommand = cmdString
            aAdapter.Fill(aDataSet)
            If (aDataSet.Tables(0).Rows.Count > 0) Then
                Select Case DGVOutput
                    Case "dgvRecordIDTest"
                        'frmAddRecordPrescription.dgvRecordIDTest.DataSource = aDataSet.Tables(0)
                    Case "dgvRecordIDTest2"
                        'frmAddRecordPrescription.dgvRecordIDTest2.DataSource = aDataSet.Tables(0)
                End Select

            End If
        Catch ex As Exception

        End Try

        connString.Close()
    End Sub


    Public Sub AddPrescription()
        cmdString.Parameters.Clear()
        connString.Open()
        With cmdString
            .Connection = connString
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 900
            .CommandText = "VIEWPRESCRIPTIONS"
        End With
        aAdapter.SelectCommand = cmdString
        aAdapter.Fill(aDataSet)
        If aDataSet.Tables(0).Rows.Count > 0 Then
            'frmRefills.dgvRecordIDTest.DataSource = aDataSet.Tables(0)
        End If
        connString.Close()
    End Sub
    'Public Sub UpdatePhysicianDGV()
    'Dim bAdapter As New SqlDataAdapter
    'Dim bDataSet As New DataSet
    'cmdString.Parameters.Clear()
    'connString.Open()
    'With cmdString
    '.Connection = connString
    '.CommandType = CommandType.StoredProcedure
    '.CommandTimeout = 900
    '.CommandText = "VIEWPHYSICIANS"
    'End With
    'bAdapter.SelectCommand = cmdString
    'bAdapter.Fill(bDataSet)
    'If bDataSet.Tables(0).Rows.Count > 0 Then
    'frmUpdateRecordPrescription.dgvRecordIDTest.DataSource = bDataSet.Tables(0)
    'End If
    'connString.Close()
    'End Sub

    'Public Sub UpdatePatientDGV()
    'Dim cAdapter As New SqlDataAdapter
    'Dim cDataSet As New DataSet
    '   cmdString.Parameters.Clear()
    '   connString.Open()
    'With cmdString
    '.Connection = connString
    '.CommandType = CommandType.StoredProcedure
    '.CommandTimeout = 900
    '.CommandText = "VIEWPATIENTS"
    'End With
    '   cAdapter.SelectCommand = cmdString
    '  cAdapter.Fill(cDataSet)
    'If cDataSet.Tables(0).Rows.Count > 0 Then
    '       frmUpdateRecordPrescription.dgvRecordIDTest2.DataSource = cDataSet.Tables(0)
    'End If
    '   connString.Close()
    'End Sub
    '****************************************************************************************
    '****************************************************************************************
    '****************************************************************************************

    '****************************************************************************************
    '************************************UPDATE PROCEDURES***********************************
    '****************************************************************************************

    'Fills in the textboxes on frmUpdateRecordPatient
    Public Function FillUpdateForms(ByVal Record_ID As String, ByVal StoredProcedure As String, ByVal DataBaseColumn As String) As DataSet
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = StoredProcedure
            cmdString.Parameters.AddWithValue(DataBaseColumn, Record_ID)
            aAdapter.SelectCommand = cmdString
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function ViewPrescription(ByVal PRESCRIPTION_ID As String) As DataSet
        Try
            connString.Open()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "CHECKPRESCRIPTION"
            cmdString.Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID)
            aAdapter.SelectCommand = cmdString
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        End Try
        connString.Close()
    End Function
    Public Sub CheckUpdateNulls(ByVal FormObject As TextBox, ByVal Output As String)
        If (FormObject.Text = "N/A") Then
            FormObject.Text = ""
            'Return that there are empty textboxes
            Reply = "Fail"
            Exit Sub
        End If
    End Sub

    Public Sub UpdatePhysician(ByVal PHYSICIAN_ID As String, ByVal FNAME As String, ByVal MIDINIT As String, ByVal LNAME As String, ByVal GENDER As String, ByVal STREET As String,
                          ByVal CITY As String, ByVal PHYSICIAN_STATE As String, ByVal ZIP As Decimal, ByVal DOB As Date, ByVal OFFICE_PHONE As String, ByVal PERSONAL_PHONE As String,
                          ByVal WORK_EMAIL As String, ByVal EMAIL_I As String, ByVal EMAIL_II As String, ByVal POSITION As String, ByVal SPECIALTY As String, ByVal SALARY As Decimal)
        Try
            cmdString.Parameters.Clear()
            connString.Open()

            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "UPDATEPHYSICIAN"
                .Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID)
                .Parameters.AddWithValue("@FNAME", FNAME)
                .Parameters.AddWithValue("@MIDINIT", MIDINIT)
                .Parameters.AddWithValue("@LNAME", LNAME)
                .Parameters.AddWithValue("@GENDER", GENDER)
                .Parameters.AddWithValue("@STREET", STREET)
                .Parameters.AddWithValue("@CITY", CITY)
                .Parameters.AddWithValue("@PHYSICIAN_STATE", PHYSICIAN_STATE)
                .Parameters.AddWithValue("@ZIP", ZIP)
                .Parameters.AddWithValue("@DOB", DOB)
                .Parameters.AddWithValue("@OFFICE_PHONE", OFFICE_PHONE)
                .Parameters.AddWithValue("@PERSONAL_PHONE", PERSONAL_PHONE)
                .Parameters.AddWithValue("@WORK_EMAIL", WORK_EMAIL)
                .Parameters.AddWithValue("@EMAIL_I", EMAIL_I)
                .Parameters.AddWithValue("@EMAIL_II", EMAIL_II)
                .Parameters.AddWithValue("@POSITION", POSITION)
                .Parameters.AddWithValue("@SPECIALTY", SPECIALTY)
                .Parameters.AddWithValue("@SALARY", SALARY)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        End Try
        connString.Close()
    End Sub

    Public Sub UpdatePrescription(ByVal PRESCRIPTION_ID As String, ByVal MEDICATION_NAME As String, ByVal REFILL_AMT As Decimal, ByVal DOSAGE As String, ByVal INTAKE_METHOD As String, ByVal FREQUENCY As String,
                          ByVal PHYSICIAN_ID As String, ByVal PATIENT_ID As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "UPDATEPRESCRIPTION"
                .Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID)
                .Parameters.AddWithValue("@MEDICATION_NAME", MEDICATION_NAME)
                .Parameters.AddWithValue("@REFILL_AMT", REFILL_AMT)
                .Parameters.AddWithValue("@DOSAGE", DOSAGE)
                .Parameters.AddWithValue("@INTAKE_METHOD", INTAKE_METHOD)
                .Parameters.AddWithValue("@FREQUENCY", FREQUENCY)
                .Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID)
                .Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
        End Try
        connString.Close()
    End Sub
    '****************************************************************************************
    '****************************************************************************************
    '****************************************************************************************
    Public Sub AddDropRefills(ByVal PRESCRIPTION_ID As String, ByVal REFILL_AMT As Decimal, ByVal StoredProcedure As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = StoredProcedure
                .Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID)
                .Parameters.AddWithValue("@REFILL_AMT", REFILL_AMT)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
        End Try
        connString.Close()
    End Sub
    '****************************************************************************************
    '****************************************************************************************
    '****************************************************************************************





    Public Sub ViewRecordID(ByVal StoredProcedure As String)
        cmdString.Parameters.Clear()
        connString.Open()
        With cmdString
            .Connection = connString
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 900
            .CommandText = StoredProcedure
        End With
        aAdapter.SelectCommand = cmdString
        aAdapter.Fill(aDataSet)
        If aDataSet.Tables(0).Rows.Count > 0 Then
            'frmViewRecordPrescription.dgvRecordIDTest.DataSource = aDataSet.Tables(0)
        End If
        connString.Close()
    End Sub


    Public Function ViewPrescription()
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "VIEWPRESCRIPTIONS"
            End With
            aAdapter.SelectCommand = cmdString
            aAdapter.Fill(aDataSet)
            If aDataSet.Tables(0).Rows.Count > 0 Then
                'frmViewRecordPrescription.dgvPrescription.DataSource = aDataSet.Tables(0)
                'frmViewRecordPrescription.dgvPrescription.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray
                'frmViewRecordPrescription.dgvPrescription.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                'frmViewRecordPrescription.dgvPrescription.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                'frmViewRecordPrescription.dgvPrescription.EnableHeadersVisualStyles = False
                'frmViewRecordPrescription.dgvPrescription.Visible = True
            End If

        Catch ex As Exception
        End Try
        Return aDataSet
        connString.Close()
    End Function

    Public Function GetPrescriptionByID(prescriptionID)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "CHECKPRESCRIPTION"
                .Parameters.AddWithValue("@PRESCRIPTION_ID", prescriptionID)
            End With
            aAdapter.SelectCommand = cmdString
            aAdapter.Fill(aDataSet)
            If aDataSet.Tables(0).Rows.Count > 0 Then
                'frmViewRecordPrescription.dgvPrescription.DataSource = aDataSet.Tables(0)
                'frmViewRecordPrescription.dgvPrescription.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray
                'frmViewRecordPrescription.dgvPrescription.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                'frmViewRecordPrescription.dgvPrescription.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                'frmViewRecordPrescription.dgvPrescription.EnableHeadersVisualStyles = False
                'frmViewRecordPrescription.dgvPrescription.Visible = True
            End If

        Catch ex As Exception
        End Try
        Return aDataSet
        connString.Close()
    End Function

    Public Sub ViewPrescriptionByPatient(ByVal PATIENT_ID As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "CHECKPRESCRIPTIONSBYPATIENT"
                .Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID)
            End With
            aAdapter.SelectCommand = cmdString
            aAdapter.Fill(aDataSet)
            If aDataSet.Tables(0).Rows.Count > 0 Then
                'frmViewRecordPrescription.dgvPrescription.DataSource = aDataSet.Tables(0)
                'frmViewRecordPrescription.dgvPrescription.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray
                'frmViewRecordPrescription.dgvPrescription.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                'frmViewRecordPrescription.dgvPrescription.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                'frmViewRecordPrescription.dgvPrescription.EnableHeadersVisualStyles = False
                'frmViewRecordPrescription.dgvPrescription.Visible = True
            End If
        Catch ex As Exception
        End Try
        connString.Close()
    End Sub

    Public Sub ViewPhysician(ByVal PHYSICIAN_ID As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "CHECKPHYSICIANS"
                .Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID)
            End With
            aAdapter.SelectCommand = cmdString
            aAdapter.Fill(aDataSet)
            If aDataSet.Tables(0).Rows.Count > 0 Then
                'frmViewRecordPhysician.dgvPhysician.DataSource = aDataSet.Tables(0)
                'frmViewRecordPhysician.dgvPhysician.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray
                'frmViewRecordPhysician.dgvPhysician.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                'frmViewRecordPhysician.dgvPhysician.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                'frmViewRecordPhysician.dgvPhysician.EnableHeadersVisualStyles = False
                'frmViewRecordPhysician.dgvPhysician.Visible = True
            End If
        Catch ex As Exception
        End Try
        connString.Close()
    End Sub

    Public Sub ViewPatient(ByVal PATIENT_ID As String)
        Try
            cmdString.Parameters.Clear()
            connString.Open()
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "CHECKPATIENTS"
                .Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID)
            End With
            aAdapter.SelectCommand = cmdString
            aAdapter.Fill(aDataSet)
            If aDataSet.Tables(0).Rows.Count > 0 Then
                'frmViewRecordPatient.dgvPatient.DataSource = aDataSet.Tables(0)
                'frmViewRecordPatient.dgvPatient.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray
                'frmViewRecordPatient.dgvPatient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                'frmViewRecordPatient.dgvPatient.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                'frmViewRecordPatient.dgvPatient.EnableHeadersVisualStyles = False
                'frmViewRecordPatient.dgvPatient.Visible = True
            End If
        Catch ex As Exception
        End Try
        connString.Close()
    End Sub
End Class
