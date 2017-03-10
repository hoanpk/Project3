<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="xemdiem.aspx.vb" Inherits="WebApplication1.xemdiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="delete" />
            </Columns>
        </asp:GridView>
    
        <asp:Button ID="Button1" runat="server" Text="Exit" />
    
    </div>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Edit" />
        </p>
        <asp:Button ID="Button3" runat="server" Text="Add new" />
    </form>
</body>
</html>
