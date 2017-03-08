Imports System.Data.SqlClient
Imports System.Configuration
Public Class login

    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Dim newobj = New connect

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If newobj.CheckLogin(Me.username.Text.ToLower, Me.password.Text.ToLower) Then
            Session("UserName") = Me.username.Text
            Session("Password") = Me.password.Text
            Response.Redirect("home.aspx")
        Else
            MsgBox("Sai ten tai khoan hoac mat khau")
        End If
    End Sub
End Class