<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ResearchUser.aspx.vb" Inherits="HeuresMachineWEB.ResearchUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 366px">
    <form id="form1" runat="server">
        <div style="height: 644px; background-color: #CCCCCC;">
        &nbsp;
            <br />
            Nom:
            <asp:TextBox ID="TxtName" runat="server" Width="161px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Acces:
            <asp:TextBox ID="TxtAcces" runat="server" Width="145px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="BtnSearch" runat="server" Text="Rechercher" Width="126px" />
            <br />
            <br />
            <asp:Button ID="BtnAddUser" runat="server" style="margin-left: 786px" Text="Ajouter Utilisateur" Width="126px" />
            <asp:GridView ID="GrdUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="ObjectDataSource1" style="margin-left: 96px" Width="650px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="Cwid" HeaderText="Cwid" SortExpression="Cwid" />
                    <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                    <asp:BoundField DataField="Acces" HeaderText="Acces" SortExpression="Acces" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="HeuresMachineWEB.Repositories.UtilisateursRepository"></asp:ObjectDataSource>
            <br />
            <br />
            <asp:Button ID="BtnCancel" runat="server" Text="Quitter" />
        </div>
    </form>
</body>
</html>
