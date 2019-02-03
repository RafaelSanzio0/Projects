<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PortalTI.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portal TI - Simplificação Active Directory
    </title>
    <link href="estilo.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr style="background-color:darkblue;height:50px"><td></td></tr>
            <tr>
                <td align="center">
                    <table cellspacing="0" cellpadding="0" width="1000">
                        <tr style="height:50px"><td></td></tr>
                        <tr>
                            <td>
                                Pesquisar:
                                <asp:TextBox ID="txtSearch" runat="server" Width="200" TextMode="MultiLine" Height="80" ></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnSearch" runat="server" Text="Pequisar" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr style="height:50px"><td></td></tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound" OnItemCommand="rptList_ItemCommand">
                                    <HeaderTemplate>
                                        <table cellspacing="1" cellpadding="0" width="1000">
                                            <tr style="height:10px"><td></td></tr>
                                            <asp:Button ID="btnMigrate" runat="server" Text="Migrar" OnClick="btnMigrate_Click" />
                                            <tr style="background-color:darkblue;height:2px"><td colspan="6"></td></tr>
                                            <tr style="height:20px"><td></td></tr>
                                            <tr style="background-color:lightblue">
                                                <td></td>
                                                <td>Login</td>
                                                <td>Nome</td>
                                                <td>Migrado</td>
                                                <td>Departamento</td>
                                                <td>Elegível</td>
                                                <td>teste</td>
                                            </tr>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr style="background-color:honeydew">
                                            <td align="center">
                                                <input type="checkbox" runat="server" id="chkUser" />
                                            </td>
                                            <td id="tdLogin" runat="server"></td>
                                            <td id="tdNome" runat="server"></td>
                                            <td id="tdStatus" runat="server"></td>
                                            <td id="tdDepartamento" runat="server"></td>
                                            <td id="tdEligible" runat="server"></td>
                                            <td id="tdTeste" runat="server"></td>
                                        </tr>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>           
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>


    </form>
</body>
</html>
