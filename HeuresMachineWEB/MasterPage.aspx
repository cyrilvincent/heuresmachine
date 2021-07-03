<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterPage.aspx.vb" Inherits="HeuresMachineWEB.MasterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="width: 680px; height: 156px">
    <form id="form1" runat="server">
        <div style="height: 162px">
            <h1 style="width: 661px; margin-left:15px; color: #808000;">HEURES MACHINE</h1>
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Previsionnel" Value="Previsionnel" NavigateUrl="~/ResearchserialNumber.aspx"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <br />
            <asp:Menu ID="Menu2" runat="server">
                <Items>
                    <asp:MenuItem Text="Saisie Heures" Value="Saisie Heures" NavigateUrl="~/ResearchTempsSaisi.aspx"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <br />
        </div>
    </form>
</body>
</html>
