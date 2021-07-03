<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddUser.aspx.vb" Inherits="HeuresMachineWEB.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 575px; width: 646px">
    <form id="form1" runat="server">
        <div style="height: 576px; background-color: #999999; font-size: x-large; text-decoration: underline;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Ressources/Logo_der_Covestro_AG.ico" Width="139px" />
            <br />
            <br />
            Nom:&nbsp;
            <asp:TextBox ID="TxtNom" runat="server" Width="341px" style="margin-left: 10px"></asp:TextBox>
            <br />
            <br />
            <br />
            Cwid:
            <asp:TextBox ID="TxtCwid" runat="server" Width="85px" style="margin-left: 12px"></asp:TextBox>
            <br />
            <br />
            <br />
            Mot de Passe:
            <asp:TextBox ID="txtpassword" runat="server" Width="156px" style="margin-left: 12px"></asp:TextBox>
            <br />
            <br />
            <br />
            Acces:
            <asp:DropDownList ID="CmbAcces" runat="server" style="margin-left: 6px">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Gestionnaire</asp:ListItem>
                <asp:ListItem>Technicien</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="BtnSave" runat="server" style="margin-left: 552px" Text="Sauvegarder" Width="91px" BorderStyle="Double" />
            <br />
            <asp:Button ID="BtnCancel" runat="server" style="margin-left: 570px; margin-top: 19px" Text="Quitter" BorderStyle="Double" />
        </div>
    </form>
</body>
</html>
