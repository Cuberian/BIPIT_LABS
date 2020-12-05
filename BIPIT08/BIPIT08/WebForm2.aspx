<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="BIPIT08.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ДОБАВИТЬ ПЕРЕВОЗКУ<br />
            <br />
            Клиент:&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Перевозка:&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Дата:&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" required TextMode="Date" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
