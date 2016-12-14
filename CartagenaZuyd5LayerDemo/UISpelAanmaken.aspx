<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UISpelAanmaken.aspx.cs" Inherits="CartagenaZuyd5LayerDemo.UISpelAanmaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Spelnaam:
        <asp:TextBox ID="tbSpelnaam" runat="server"></asp:TextBox>
        <br />
        Aantal spelers:
        <asp:DropDownList ID="ddlAantalSpelers" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:CheckBox ID="cbGestart" runat="server" Text="Gestart" />
        <br />
        <br />
        <asp:Button ID="btAanmaken" runat="server" OnClick="btAanmaken_Click" Text="Aanmaken" />
        <br />
        <br />
        Spelnaam:
        <asp:Label ID="lblSpelnaam" runat="server" Text="Label"></asp:Label>
        <br />
        Aantal spelers: <asp:Label ID="lblAantalSpelers" runat="server" Text="Label"></asp:Label>
        <br />
        Gestart:
        <asp:Label ID="lblGestart" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
