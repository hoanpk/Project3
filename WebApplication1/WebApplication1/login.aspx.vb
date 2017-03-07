Imports System.Data.SqlClient
Public Class login

    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private _Connectionstring As String = ConfigurationSettings.AppSettings("ConnStringQLSV")
    Private conn As SqlConnection
    Private da As SqlDataAdapter
    Private Function getDataTable(sqlQuery As String) As DataTable
        Dim dTable As New DataTable
        conn = New SqlConnection(_Connectionstring)
        da = New SqlDataAdapter(sqlQuery, conn)
        Try
            conn.Open()
            da.Fill(dTable)
        Catch ex As Exception
            WriteLine(ex.Message, "Error")
            Throw ex
        Finally
            conn.Close()
        End Try
        Return dTable
    End Function
    Public Function CheckLogin(user As String, pass As String) As Boolean
        Dim sqlQuery As String = String.Format("select * from dbo.account where username = '{0}' and password = '{1}'", user, pass)
        Dim dTable As DataTable = getDataTable(sqlQuery)
        Return dTable.Rows.Count > 0
    End Function



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckLogin(Me.username.Text.ToLower, Me.password.Text.ToLower) Then
            WriteLine("dang nhap thanh cong")

        End If
    End Sub
End Class