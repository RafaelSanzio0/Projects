<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="TreeviewBD.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href=""
    <title></title>
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
     
        <asp:TreeView ID="arvore" runat="server" OnSelectedNodeChanged="arvore_SelectedNodeChanged">
        </asp:TreeView><br />

       <asp:Button ID="btn" runat="server" Text="exportar" OnClick="btn_Click"  />
        
    </form>

    <div id="text_btn" runat="server"></div>
    <div id="text_select" runat="server"></div>

    </div>


</body>
</html>
