<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VueExport.aspx.vb" Inherits="HeuresMachineWEB.VueExport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div style="height: 4223px; width: 2384px; background-color: #999999; font-size: large; margin-right: 168px;">
            <br />
            <asp:Image ID="Image1" runat="server" Height="107px" ImageUrl="~/Ressources/Logo_der_Covestro_AG.ico" style="margin-bottom: 0px" Width="98px" />
            <br />
            <br />
            <br />
            Numero de Serie:<asp:TextBox ID="txtSerialNumber" runat="server" style="margin-left: 11px"></asp:TextBox>
&nbsp;&nbsp; Indice:
            <asp:TextBox ID="txtIndice" runat="server" style="margin-left: 11px"></asp:TextBox>
&nbsp; Client:
            <asp:TextBox ID="txtCustomer" runat="server" style="margin-left: 11px"></asp:TextBox>
&nbsp; Type Machine:
            <asp:TextBox ID="txtMachine" runat="server" style="margin-left: 11px"></asp:TextBox>
&nbsp;Technicien:
            <asp:TextBox ID="txtnom" runat="server" style="margin-left: 11px"></asp:TextBox>
&nbsp; Service:<asp:TextBox ID="txtService" runat="server" style="margin-left: 19px" Width="100px"></asp:TextBox>
&nbsp;
            <br />
            Date(A partir de):
&nbsp;<asp:TextBox ID="Txtdate" runat="server"></asp:TextBox>
&nbsp; (ex: 12-Dec-20)<asp:Button ID="BtnSearch" runat="server" style="margin-left: 848px" Text="Rechercher" Width="97px" Height="26px" />
            <br />
            <br />
            <asp:Button ID="BtnSaisie" runat="server" style="margin-left: 3px" Text="SaisieHeures" Width="97px" />
            <br />
            <asp:GridView ID="GrdTime" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="ObjectDataSource1" style="margin-left: 116px" Width="979px">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="NumeroSerie" HeaderText="NumeroSerie" SortExpression="NumeroSerie" />
                    <asp:BoundField DataField="Indice" HeaderText="Indice" SortExpression="Indice" />
                    <asp:BoundField DataField="Descriptif" HeaderText="Descriptif" SortExpression="Descriptif" />
                    <asp:BoundField DataField="Date1" HeaderText="Date1" SortExpression="Date1" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Temps1" HeaderText="Temps1" SortExpression="Temps1" />
                    <asp:BoundField DataField="Cwid" HeaderText="Cwid" SortExpression="Cwid" />
                    <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                    <asp:BoundField DataField="Service" HeaderText="Service" SortExpression="Service" />
                    <asp:BoundField DataField="TYpeMachine.modele" HeaderText="Type de Machine" SortExpression="TYpeMachine" />
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="HeuresMachineWEB.Repositories.TempsRepository"></asp:ObjectDataSource>
        </div>
    </form>
   
</body>
</html>
