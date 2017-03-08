Public Class home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Dim ReConnect = New connect
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userName As String = Session("UserName").ToString
        Dim passWord As String = Session("PassWord").ToString
        Dim nameAuthor As String = ReConnect.CheckAuthorName(userName.ToLower, passWord.ToLower)
        Dim CaseAuthor As String = ReConnect.CheckAuthor(userName.ToLower, passWord.ToLower)

        Select Case CaseAuthor
            Case "3"
                MsgBox("Ban dang dang nhap voi quyen " + nameAuthor)
                MsgBox("ban khong co quyen xem diem")
                Response.Redirect("home.aspx")
            Case Else
                Response.Redirect("xemdiem.aspx")
        End Select
    End Sub
End Class