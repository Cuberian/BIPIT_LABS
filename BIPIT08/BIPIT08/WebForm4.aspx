<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="BIPIT08.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        ДОБАВИТЬ ПЕРЕВОЗКУ</p>
    <form>
        <p>
            Клиент:&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            Перевозка:&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            Дата:&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" required TextMode="Date" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Добавить" Width="191px" OnClick="Button1_Click" />
    </form>
</asp:Content>
