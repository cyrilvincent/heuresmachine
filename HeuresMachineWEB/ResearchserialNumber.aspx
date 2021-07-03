<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ResearchserialNumber.aspx.vb" Inherits="HeuresMachineWEB.ResearchserialNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 2945px; width: 1586px; font-size: large; background-color: #999999;">
            Numero serie:
            <asp:TextBox ID="TxtserialNumber" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Type Machine:
            <asp:TextBox ID="TxtMachine" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Client:
            <asp:TextBox ID="TxtCustomer" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnSearch" runat="server" Text="Rechercher" Width="85px" />
            <asp:Button ID="BtnPrev" runat="server" style="margin-left: 167px" Text="Ajouter Previsionnel" Width="129px" />
            <asp:Button ID="BtnSaisi" runat="server" Text="Saisir Heures" Width="115px" style="margin-left: 22px" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GrdPrev" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="ObjectDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="NumeroSerie" HeaderText="NumeroSerie" SortExpression="NumeroSerie" />
                    <asp:BoundField DataField="Indice" HeaderText="Indice" SortExpression="Indice" />
                    <asp:BoundField DataField="Descriptif" HeaderText="Descriptif" SortExpression="Descriptif" />
                    <asp:BoundField DataField="TempsBEM" HeaderText="Temps Prevu BEM" SortExpression="TempsBEM" />
                    <asp:BoundField DataField="TempsBEE" HeaderText="Temps Prevu BEE" SortExpression="TempsBEE" />
                    <asp:BoundField DataField="TempsBEA" HeaderText="Temps Prevu BEA" SortExpression="TempsBEA" />
                    <asp:BoundField DataField="TempsTotalBEM" HeaderText="Temps Total BEM" SortExpression="TempsTotalBEM" />
                    <asp:BoundField DataField="TempsTotalBEE" HeaderText="Temps Total BEE" SortExpression="TempsTotalBEE" />
                    <asp:BoundField DataField="TempsTotalBEA" HeaderText="Temps Total BEA" SortExpression="TempsTotalBEA" />
                    <asp:BoundField DataField="TempsRestantBEM" HeaderText="Temps Restant BEM" SortExpression="TempsRestantBEM" />
                    <asp:BoundField DataField="TempsRestantBEE" HeaderText="Temps Restant BEE" SortExpression="TempsRestantBEE" />
                    <asp:BoundField DataField="TempsRestantBEA" HeaderText="Temps Restant BEA" SortExpression="TempsRestantBEA" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="HeuresMachineWEB.Repositories.PrevionnelRepository"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
