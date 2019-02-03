using Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace PortalTI
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (DataTable datatable = DataLayer.GetComputerUser(txtSearch.Text))
            {
                rptList.DataSource = datatable;
                rptList.DataBind();
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView; // ?
                
            
                HtmlInputCheckBox chkUser = e.Item.FindControl("chkUser") as HtmlInputCheckBox;
                HtmlTableCell tdLogin = e.Item.FindControl("tdLogin") as HtmlTableCell;
                HtmlTableCell tdNome = e.Item.FindControl("tdNome") as HtmlTableCell;
                HtmlTableCell tdStatus = e.Item.FindControl("tdStatus") as HtmlTableCell;
                HtmlTableCell tdDepartamento = e.Item.FindControl("tdDepartamento") as HtmlTableCell;
                HtmlTableCell tdEligible = e.Item.FindControl("tdEligible") as HtmlTableCell;
                HtmlTableCell tdTeste = e.Item.FindControl("tdTeste") as HtmlTableCell;

                string userLogon = drv["UserLogon"].ToString();

                tdLogin.InnerText = userLogon;
                tdNome.InnerText = drv["UserDisplayname"].ToString();
                bool isMigrated = (drv["MigrateDate"] != DBNull.Value); //check if column is difference null
               

                string readyToMigrate = string.Empty;

                using (DataTable datatable = DataLayer.GetUserDepartment(userLogon))
                {
                    if(datatable.Rows.Count > 0)
                    {
                        string department = datatable.Rows[0]["description"].ToString();
                        readyToMigrate = datatable.Rows[0]["ReadyToMigrate"].ToString();
                        string teste = datatable.Rows[0]["teste"].ToString();


                        tdDepartamento.InnerText = department;
                        tdTeste.InnerText = teste;
                    }
                }

                if (isMigrated)
                    tdStatus.InnerText = "Sim";
                else
                    tdStatus.InnerText = "Nao";

                if (readyToMigrate=="Y")
                    tdEligible.InnerText = "Sim";
                else
                    tdEligible.InnerText = "Nao";

                if (readyToMigrate == "N" && !isMigrated)
                    chkUser.Disabled = true;

            }
        }

        private void ShowAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "xxx", string.Format("alert('{0}')", message), true);
        }

        protected void btnMigrate_Click(object sender, EventArgs e)
        {
            string url = ConfigurationManager.AppSettings["WS.SSMP"] + txtSearch.Text;

            WebClient webClient = new WebClient();


            using (Stream stream = webClient.OpenRead(url))
            {
                StreamReader streamReader = new StreamReader(stream);

                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(streamReader.ReadToEnd());

                if (xmlDoc.SelectSingleNode("result/failed").InnerText == "True")
                    ShowAlert("Falha na migracao!");
                else
                    ShowAlert("Migracao iniciada. Protocolo : " + xmlDoc.SelectSingleNode("result/id").InnerText);
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}
