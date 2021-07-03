<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ResearchTempsSaisi.aspx.vb" Inherits="HeuresMachineWEB.ResearchTempsSaisi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 4220px; width: 1380px;">
    <form id="form1" runat="server">
        <div style="height: 4223px; width: 1585px; background-color: #999999; font-size: large;">
            <asp:Image ID="Image1" runat="server" Height="102px" ImageUrl="~/Ressources/Logo_der_Covestro_AG.ico" Width="95px" />
            <br />
            <br />
            Numero Serie:<asp:TextBox ID="txtSerialNumber" runat="server" style="margin-top: 0px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Indice:
            <asp:TextBox ID="TxtIndice" runat="server" style="margin-top: 0px"></asp:TextBox>
&nbsp;&nbsp; Type Machine:
            <asp:TextBox ID="TxtMachine" runat="server" style="margin-top: 0px"></asp:TextBox>
            <br />
            <br />
            Client:
            <asp:TextBox ID="TxtCustomer" runat="server" style="margin-top: 0px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nom:
            <asp:TextBox ID="TxtNom" runat="server" style="margin-top: 0px"></asp:TextBox>
&nbsp;&nbsp; Service:
            <asp:TextBox ID="TxtService" runat="server" style="margin-top: 0px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Btnsearch" runat="server" Text="recherche" Width="113px" />
            <asp:Button ID="BtnPrev" runat="server" PostBackUrl="~/ResearchserialNumber.aspx" style="margin-left: 135px" Text="Previsionnel" Width="107px" />
            <asp:Button ID="BtnAddUser" runat="server" style="margin-left: 62px" Text="Utilisateur" Width="117px" />
            <asp:Button ID="BtnVue" runat="server" Text="Vue Export" Width="101px" style="margin-left: 33px" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GrdTime" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="ObjectDataSource1" Width="1077px" BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" ForeColor="Black" BorderStyle="None" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="NumeroSerie" HeaderText="NumeroSerie" SortExpression="NumeroSerie" />
                    <asp:BoundField DataField="Indice" HeaderText="Indice" SortExpression="Indice" />
                    <asp:BoundField DataField="Descriptif" HeaderText="Descriptif" SortExpression="Descriptif" />
                    <asp:BoundField DataField="TYpeMachine.Modele" HeaderText="Type Machine" SortExpression="TYpeMachine" />
                    <asp:BoundField DataField="Date1" HeaderText="Date1" SortExpression="Date1" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Temps1" HeaderText="Temps1" SortExpression="Temps1" Visible="False" />
                    <asp:BoundField DataField="Cwid" HeaderText="Cwid" SortExpression="Cwid" Visible="False" />
                    <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" Visible="False" />
                    <asp:BoundField DataField="Service" HeaderText="Service" SortExpression="Service" Visible="False" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll1" TypeName="HeuresMachineWEB.Repositories.TempsRepository"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
