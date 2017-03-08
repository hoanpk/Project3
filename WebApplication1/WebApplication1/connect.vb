Imports System.Data.SqlClient
Imports System.Configuration
Public Class connect
    Private _Connectionstring As String = ConfigurationManager.ConnectionStrings("ConnStringQLSV").ConnectionString

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

            MsgBox("you have an error when try to read database")

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

    Public Function CheckAuthor(user As String, pass As String) As String
        Dim auThor As String = String.Format("select role_id from dbo.account where username = '{0}' and password = '{1}'", user, pass)
        Dim dTable As DataTable = getDataTable(auThor)

        Dim result As String = dTable.Rows.Item(0).Item("role_id")

        Return result


    End Function
    Public Function CheckAuthorName(user As String, pass As String) As String
        Dim AuThorName As String = String.Format("select name from dbo.account inner join dbo.role on QLSV.dbo.account.role_id=QLSV.dbo.role.ID where username = '{0}' and password = '{1}'", user, pass)
        'select name from QLSV.dbo.role inner join QLSV.dbo.account on QLSV.dbo.account.role_id=QLSV.dbo.role.ID
        Dim dTable As DataTable = getDataTable(AuThorName)
        Dim result As String = dTable.Rows.Item(0).Item("name")
        Return result
    End Function
End Class
