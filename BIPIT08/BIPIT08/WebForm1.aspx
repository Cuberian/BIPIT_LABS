<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BIPIT08.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ТАБЛИЦА ПЕРЕВОЗОК<br />
            <asp:GridView ID="GridView1" runat="server" Height="160px" Width="280px">
            </asp:GridView>
            <br />
            от
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;до&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Фильтрация" Width="191px" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Удалить выбранные элементы" Width="185px" />
        </div>
    </form>
</body>
</html>
