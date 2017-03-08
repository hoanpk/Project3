Public Class xemdiem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Dim ReConnect = New connect

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
End Class