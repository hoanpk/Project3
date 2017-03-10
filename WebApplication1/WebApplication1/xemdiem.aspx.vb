Imports System.Data
Public Class xemdiem
    Inherits System.Web.UI.Page
    Dim ReConnect = New connect
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userName As String = Session("UserName").ToString
        Dim passWord As String = Session("PassWord").ToString
        GridView1.DataSource = ReConnect.ShowScore(userName, passWord)
        GridView1.DataBind()
        Dim CaseAuthor As String = ReConnect.CheckAuthor(userName.ToLower, passWord.ToLower)
        Dim nameAuthor As String = ReConnect.CheckAuthorName(userName.ToLower, passWord.ToLower)
        Select Case CaseAuthor
            Case "1"
                Button2.Enabled = True
            Case Else
                Button2.Enabled = False
        End Select
        'Dim dt = Me.GridView1.DataSource
        'dt.Rows.RemoveAt(12)

    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("home.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim userName As String = Session("UserName").ToString
        Dim passWord As String = Session("PassWord").ToString
        Dim CaseAuthor As String = ReConnect.CheckAuthor(userName.ToLower, passWord.ToLower)
        Dim nameAuthor As String = ReConnect.CheckAuthorName(userName.ToLower, passWord.ToLower)
        Select Case CaseAuthor
            Case "1"
                MsgBox("Ban dang dang nhap voi quyen " + nameAuthor)

                Response.Redirect("suadiem.aspx")
            Case "2"
                MsgBox("Ban dang dang nhap voi quyen " + nameAuthor)
                MsgBox("ban khong co quyen sua diem")
                Response.Redirect("xemdiem.aspx")
            Case "3"
                MsgBox("Ban dang dang nhap voi quyen " + nameAuthor)
                MsgBox("ban khong co quyen sua diem")
                Response.Redirect("xemdiem.aspx")
            Case Else
                ' Response.Redirect("home.aspx")
        End Select
    End Sub


    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim dt As DataTable = GridView1.DataSource

        'GridView1.DeleteRow(e.RowIndex)
        Dim TemVar = e.RowIndex
        Dim SelectedRow = dt.Rows.Item(e.RowIndex)
        Dim a = SelectedRow.Item(1)
        Dim b = SelectedRow.Item(0)
        ReConnect.DeleteData(a, b)
        dt.Rows.RemoveAt(e.RowIndex)
        GridView1.DataBind()
    End Sub
End Class