<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="KR__Front.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            НАКЛАДНЫЕ<br />
            <asp:GridView ID="GridView1" runat="server" Width="342px">
            </asp:GridView>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Выберите поставщика: "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
&nbsp;<asp:Label ID="Label1" runat="server" Text="Введите сумму: "></asp:Label>
            <asp:TextBox ID="TextBox1" required min="1" TextMode="Number" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Введите дату: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" required TextMode="Date" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Добавить накладную" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
