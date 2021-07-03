<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SaisieHeures.aspx.vb" Inherits="HeuresMachineWEB.SaisieHeures" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 814px; width: 1279px">
    <form id="form1" runat="server">
        <div style="height: 740px; width: 1276px; background-color: #CCCCCC; font-size: large;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Ressources/Logo_der_Covestro_AG.ico" Width="132px" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Numero Serie:"></asp:Label>
            <asp:TextBox ID="TxtNumber" runat="server" style="margin-left: 32px" Width="154px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Indice:
            <asp:TextBox ID="TxtIndice" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descriptif:
            <asp:TextBox ID="TxtDescriptif" runat="server" style="margin-left: 13px" Width="438px" Height="69px"></asp:TextBox>
            <br />
            <br />
            <br />
            Client:
            <asp:TextBox ID="TxtClient" runat="server" style="margin-left: 19px" Width="363px"></asp:TextBox>
            <br />
            <br />
            Type Machine:
            <asp:DropDownList ID="CmbModeles" runat="server" Height="16px" Width="128px">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Label ID="Lbldate1" runat="server" Text="Date:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtDate1" runat="server" Visible="False"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblTemps1" runat="server" Text="Temps:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TxtTemps1" runat="server" Width="41px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblCwid1" runat="server" Text="Cwid:"></asp:Label>
&nbsp;<asp:DropDownList ID="CmbCwid1" runat="server" style="margin-left: 4px" AutoPostBack="True" Width="150px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblNom1" runat="server" Text="Nom:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TxtNom1" runat="server" Width="301px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblService1" runat="server" Text="Service"></asp:Label>
            :<asp:DropDownList ID="CmbService1" runat="server" style="margin-left: 4px">
                <asp:ListItem>Automatisme</asp:ListItem>
                <asp:ListItem>Electrique</asp:ListItem>
                <asp:ListItem>Mecanique</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Btnajout" runat="server" Text="Ajout" Width="51px" style="margin-left: 13px" Visible="False" />
            <br />
            <asp:Calendar ID="CldDate" runat="server" BackColor="#FFFFCC" ForeColor="#663399" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" Height="200px" ShowGridLines="True" style="margin-top: 11px" Width="254px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            <br />
            <asp:Button ID="BtnSave" runat="server" style="margin-left: 1187px; margin-bottom: 0px;" Text="Ajouter" Width="88px" />
            <br />
            <asp:Button ID="BtnModifier" runat="server" Text="Modifier" Width="104px" style="margin-left: 1px" Visible="False" />
            <br />
            <br />
            <asp:Button ID="BtnCancel" runat="server" Height="21px" style="margin-left: 1px" Text="Quitter" Width="108px" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
