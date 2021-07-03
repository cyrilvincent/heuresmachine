<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Previsonnel.aspx.vb" Inherits="HeuresMachineWEB.Previsonnel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 537px;
            width: 1251px;
        }
    </style>
</head>
<body style="width: 1322px; height: 540px;">
    <form id="form1" runat="server" style="background-color: #999999; font-size: large">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Ressources/Logo_der_Covestro_AG.ico" Width="115px" />
        <br />
        Numero de Serie:<asp:TextBox ID="TxtNumber" runat="server" style="margin-left: 61px"></asp:TextBox>
    &nbsp; Indice:<asp:TextBox ID="TxtIndice" runat="server" style="margin-left: 33px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descriptif:
        <asp:TextBox ID="TxtDescriptif" runat="server" style="margin-left: 33px" Height="48px" Width="360px"></asp:TextBox>
        <br />
        <br />
        <br />
        Client:
        <asp:TextBox ID="TxtCustomer" runat="server" style="margin-left: 33px" Width="321px"></asp:TextBox>
        &nbsp;<asp:Button ID="BtnCustomer" runat="server" Text="Client" Width="69px" />
        <asp:Button ID="BtnAddCustomer" runat="server" Text="Ajouter" Width="70px" />
        <br />
        <br />
        <br />
        Type Machine:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="CmbModele" runat="server" Height="16px" Width="153px">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        Temps Prévu BEM(en heures) :
        <asp:TextBox ID="TxtBEM" runat="server" Width="76px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Temps Prévu BEE(en heures):
        <asp:TextBox ID="TxtBEE" runat="server" Width="76px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Temps Prévu BEA(en heures):&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtBEA" runat="server" Width="76px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="BtnAdd" runat="server" Text="Sauvegarder" Width="129px" style="margin-left: 6px" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="Btncancel" runat="server" Text="Quitter" Width="94px" style="margin-left: 5px" />
    </form>
</body>
</html>
