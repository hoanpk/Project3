<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="username"></asp:Label>
        <asp:TextBox ID="username" runat="server" Height="16px" Width="206px"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
            <asp:TextBox ID="password" runat="server" TextMode="Password" Width="207px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="login" Width="75px" />
        </p>
    </form>
</body>
</html>
