Imports System.Data
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic
Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography

Public Class StudentDataTier
    Private key() As Byte = {}
    Private IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    Dim connString As New SqlClient.SqlConnection(ConnectionStrings("connstring").ConnectionString)
    Dim cmdstring As New SqlClient.SqlCommand

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

    Public Function GetAllStudents() As DataSet
        Try
            connString.Open()
            cmdstring.Parameters.Clear()
            cmdstring.Connection = connString
            cmdstring.CommandType = CommandType.StoredProcedure
            cmdstring.CommandTimeout = 1500
            cmdstring.CommandText = "GetAllStudents"
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdstring
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function AddStudent(ByVal studid As String, ByVal fname As String, ByVal lname As String, ByVal dob As String, ByVal gender_desc As String) As DataSet
        Try
            Dim dateDOB As Date = Date.Parse(dob)
            connString.Open()
            cmdstring.Parameters.Clear()
            cmdstring.Connection = connString
            cmdstring.CommandType = CommandType.StoredProcedure
            cmdstring.CommandTimeout = 1500
            cmdstring.CommandText = "AddStudent"
            With cmdstring
                .Parameters.Add("@stud_ID", SqlDbType.VarChar, 6).Value = studid
                .Parameters.Add("@fname", SqlDbType.VarChar, 6).Value = fname
                .Parameters.Add("@lname", SqlDbType.VarChar, 6).Value = lname
                .Parameters.Add("@dob", SqlDbType.DateTime, 20).Value = dateDOB
                .Parameters.Add("@gender_desc", SqlDbType.Char, 1).Value = gender_desc
            End With
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdstring
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function GetAllStudentsByID(ByVal studid As String) As DataSet
        Try
            connString.Open()
            cmdstring.Parameters.Clear()
            cmdstring.Connection = connString
            cmdstring.CommandType = CommandType.StoredProcedure
            cmdstring.CommandTimeout = 1500
            cmdstring.CommandText = "GetStudentsByID"
            cmdstring.Parameters.Add("@student_ID", SqlDbType.VarChar, 6).Value = studid
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdstring
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function DeleteStudents(ByVal studid As String) As DataSet
        Try
            connString.Open()
            cmdstring.Parameters.Clear()
            cmdstring.Connection = connString
            cmdstring.CommandType = CommandType.StoredProcedure
            cmdstring.CommandTimeout = 1500
            cmdstring.CommandText = "DELETESTUDENT"
            cmdstring.Parameters.Add("@student_ID", SqlDbType.VarChar, 6).Value = studid
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdstring
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function GetPreByID(ByVal Pre_ID As String) As DataSet
        Try
            connString.Open()
            cmdstring.Parameters.Clear()
            cmdstring.Connection = connString
            cmdstring.CommandType = CommandType.StoredProcedure
            cmdstring.CommandTimeout = 1500
            cmdstring.CommandText = "GetPreByID"
            cmdstring.Parameters.Add("@pre_ID", SqlDbType.VarChar, 6).Value = Pre_ID
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdstring
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function IncreasePre(ByVal Refill As String) As DataSet
        Try
            connString.Open()
            cmdstring.Parameters.Clear()
            cmdstring.Connection = connString
            cmdstring.CommandType = CommandType.StoredProcedure
            cmdstring.CommandTimeout = 1500
            cmdstring.CommandText = "EditPre"
            cmdstring.Parameters.Add("@Refill", SqlDbType.VarChar, 6).Value = Refill
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdstring
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()

        End Try
    End Function
    Public Function DecreasePre(ByVal Refill As String) As DataSet
        Try
            connString.Open()
            cmdstring.Parameters.Clear()
            cmdstring.Connection = connString
            cmdstring.CommandType = CommandType.StoredProcedure
            cmdstring.CommandTimeout = 1500
            cmdstring.CommandText = "EditPre"
            cmdstring.Parameters.Add("@Refill", SqlDbType.VarChar, 6).Value = Refill
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdstring
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()

        End Try
    End Function

End Class


