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
        Dim sqlQuery As String = String.Format("select * from dbo.account where user_name = '{0}' and user_password = '{1}'", user, pass)
        Dim dTable As DataTable = getDataTable(sqlQuery)
        Return dTable.Rows.Count > 0
    End Function

    Public Function CheckAuthor(user As String, pass As String) As String
        Dim auThor As String = String.Format("select role_id from dbo.account where user_name = '{0}' and user_password = '{1}'", user, pass)
        Dim dTable As DataTable = getDataTable(auThor)

        Dim result As String = dTable.Rows.Item(0).Item("role_id")

        Return result


    End Function
    Public Function CheckAuthorName(user As String, pass As String) As String
        Dim AuThorName As String = String.Format("select role_name from dbo.account inner join dbo.role on QLSV.dbo.account.role_id=QLSV.dbo.role.role_id where user_name = '{0}' and user_password = '{1}'", user, pass)
        'select name from QLSV.dbo.role inner join QLSV.dbo.account on QLSV.dbo.account.role_id=QLSV.dbo.role.ID
        Dim dTable As DataTable = getDataTable(AuThorName)
        Dim result As String = dTable.Rows.Item(0).Item("role_name")
        Return result
    End Function
    Public Function ShowScore(user As String, pass As String) As DataTable
        Dim Author As String = CheckAuthor(user, pass)
        Dim dTable As DataTable
        Select Case Author
            Case "1"
                Dim GetScore As String = String.Format("select account.user_id,account.user_name,subject_name,user_score from dbo.account inner join dbo.user_subject_score on account.user_id = user_subject_score.user_id inner join dbo.subjects on subjects.subject_id = user_subject_score.subject_id")
                dTable = getDataTable(GetScore)
                Return dTable
            Case "2"
                Dim GetScore As String = String.Format("select account.user_id,account.user_name,subject_name,user_score from dbo.account inner join dbo.user_subject_score on account.user_id = user_subject_score.user_id inner join dbo.subjects on subjects.subject_id = user_subject_score.subject_id where user_name = '{0}' and user_password = '{1}'", user, pass)
                dTable = getDataTable(GetScore)
                Return dTable
        End Select
        Return dTable
    End Function
End Class
