<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="BIPIT08.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        ТАБЛИЦА ПЕРЕВОЗОК</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" Width="358px" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-top: 19px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </p>
    <p>
        от:&nbsp;&nbsp; <asp:TextBox ID="TextBox1" TextMode="Date" runat="server"></asp:TextBox>
&nbsp;&nbsp; до:&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" TextMode="Date" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Отфоильровать по датам" OnClick="Button1_Click" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="Удалить выбранное" OnClick="Button2_Click" />
    </p>
</asp:Content>
