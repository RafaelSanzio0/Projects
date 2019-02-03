using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoRenato
{
    public partial class Commands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         public bool GetPing(string Address)

        {
            using (Ping ping = new Ping())
            {
                try
                {
                    PingReply reply = ping.Send(Address, 100); //Fornece informações sobre o status e os dados resultantes de uma operação
                    if (reply.Status == IPStatus.Success)//verificando o status da requisicao com o obj reply
                    {
                        // Console.WriteLine(String.Format("OK - IP Address: {0}", reply.Address));
                        td_ping.Style.Add("color", "green");
                        td_ping.InnerText = ("OK");
                        



                        return true;
                    }
                    else
                    {

                        //Console.WriteLine(String.Format("{0} - IP Address: {1}", reply.Status.ToString(), Address));
                        td_ping.Style.Add("color", "red");
                        td_ping.InnerText = ("Failed");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    td_ping.Style.Add("color", "red");
                    td_ping.InnerText = ("host not found");
                    return false;
                }
            }
        }

        public void DoConnectTelnet(string host, int port)
        {
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);

            try
            {
                IPAddress[] IPAddresses = Dns.GetHostAddresses(host);
                t.Connect(IPAddresses, port);
                td_telnet.Style.Add("color", "green");
                td_telnet.InnerText = ("OK");

            }
            catch (Exception)
            {
                td_telnet.Style.Add("color", "red");
                td_telnet.InnerText = ("Failed");
            }

        }

        public bool AcessPast(string host)
        {

            string path = "\\\\" + host + "\\admin$"; //caminho de acesso
            bool result;

            try
            {
                if (Directory.Exists(path))
                {
                    td_admin.Style.Add("color", "green");
                    td_admin.InnerText = ("OK");
                    result = true;
                    return result;
                }

                    td_admin.Style.Add("color", "red");
                    td_admin.InnerText = ("Failed");
                    result = false;
                    return result;

            }
            catch (Exception e)
            {
                td_admin.Style.Add("color", "red");
                td_admin.InnerText = ("Exeception Treated");
            }
            return false;

        }
   
        protected void Button1_Click(object sender, EventArgs e)
        {
            string host = txt_host.Text;
            
            try
            {

                int port = Convert.ToInt32(txt_port.Text);

                DoConnectTelnet(host, port);
               


            }
            catch (FormatException ex)
            {
                td_telnet.InnerText = ex.Message;
            }

            td_host.InnerText = host;
            GetPing(host);
            AcessPast(host);
  
        }
    }
}