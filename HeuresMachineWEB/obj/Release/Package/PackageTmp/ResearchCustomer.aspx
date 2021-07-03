<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ResearchCustomer.aspx.vb" Inherits="HeuresMachineWEB.ResearchCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 919px">
    <form id="form1" runat="server">
        <div style="margin-left: 44px; width: 1035px; height: 920px; background-color: #C0C0C0;">
            <br />
            &nbsp;&nbsp;<br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Country"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <br />
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtCountry" runat="server" style="margin-left: 52px"></asp:TextBox>
            <asp:Button ID="BtnSearch" runat="server" style="margin-left: 36px" Text="Search" Width="75px" />
            <br />
            <asp:GridView ID="GrdClientList" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None" Height="661px" Width="847px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                    <asp:BoundField DataField="Ville" HeaderText="Ville" SortExpression="Ville" />
                    <asp:BoundField DataField="Pays" HeaderText="Pays" SortExpression="Pays" />
                    <asp:BoundField DataField="Zone" HeaderText="Zone" SortExpression="Zone" />
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
            <br />
&nbsp;<br />
            <br />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="HeuresMachineWEB.Repositories.ClientsRepository"></asp:ObjectDataSource>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
    </form>
</body>
</html>
