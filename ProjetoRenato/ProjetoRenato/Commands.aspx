<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commands.aspx.cs" Inherits="ProjetoRenato.Commands" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="bootstrap/content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="css/estilos.css" />
    <title>Commands</title>
</head>


<body>

    <nav class="navbar navbar-default">
  <div class="container-fluid" style="background-color: orange;">
    <div class="navbar-header">
      
<a class="navbar-brand" href="#" style="padding: 4px;margin:auto" > <img src="imagens/itau.png" style="height:100%;width: auto;" title="mycompanylogo"></a>
    </div>


    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1" style="background-color: orange;">
      <ul class="nav navbar-nav">
        
      </ul>
    </div>
  </div>
</nav>

    <form id="form1" runat="server">

        <div class="container">
            <h4>Hostname:</h4>
            <asp:TextBox ID="txt_host" runat="server" CssClass="form-control"></asp:TextBox>
            <h4>Port:</h4>
            <asp:TextBox ID="txt_port" runat="server" CssClass="form-control"></asp:TextBox><br />

            <asp:Button ID="Button1" CssClass="btn-primary" runat="server" text="Search" OnClick="Button1_Click" /><br /><br /><br /><br /><br /><br />

            <table id="table" style="width:80%" border="1">
                  <tr id="tr_title">
                    <th id="th_host" runat="server">Host</th>
                    <th id="th_ping" runat="server">Ping</th>
                    <th id="th_admin" runat="server">Admin$</th> 
                    <th id="th_telnet" runat="server">Telnet</th>
                  </tr>
                  <tr>
                    <td id="td_host" runat="server"></td>
                    <td id="td_ping" runat="server"></td>
                    <td id="td_admin" runat="server"></td> 
                    <td id="td_telnet" runat="server"></td>
                  </tr>
             </table>

         </div>

    </form>
   
  </body>

</html>

