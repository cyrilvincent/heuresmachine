<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HmiCustomer.aspx.vb" Inherits="HeuresMachineWEB.HmiCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 547px">
    <form id="form1" runat="server">
        <div>
            <div style="height: 536px; width: 582px; margin-left: 320px; background-color: #C0C0C0;">
                <img alt="" aria-checked="undefined" aria-grabbed="undefined" aria-hidden="False" dir="ltr" src="Ressources/Logo_der_Covestro_AG.ico" style="height: 122px; width: 122px; margin-left: 0px" /><br />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TxtName" runat="server" Height="16px" style="margin-left: 17px" Width="415px"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TxtCity" runat="server" Height="16px" style="margin-left: 2px" Width="168px"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Country"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TxtCountry" runat="server" Height="16px" style="margin-left: 6px" Width="168px"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Area"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="CmbArea" runat="server" Height="19px" style="margin-left: 6px" Width="141px">
                    <asp:ListItem>EMEA</asp:ListItem>
                    <asp:ListItem>LATAM</asp:ListItem>
                    <asp:ListItem>NAFTA</asp:ListItem>
                    <asp:ListItem>APAC</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="BtnCancel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#990033" Text="Cancel" Width="84px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnSave" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#009933" Text="Save" Width="84px" />
            </div>
        </div>
    </form>
</body>
</html>
