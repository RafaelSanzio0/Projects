using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreeviewBD
{
	public partial class home : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                using (DataTable datatable = DataLayer.GetTreeviewCandidate())
                {
                    foreach (DataRow dataRow in datatable.Rows)
                    {
                         TreeNode parentNode = new TreeNode();
                         parentNode.ImageUrl = "~/imagens/pasta.png";                      
                         parentNode.Text = string.Format("{0} [{1}] [{2}] [{3}] [{4}] [{5}]", dataRow["DepartmentLevel1"], dataRow["CandidateCount"], dataRow["AppBlockCount"], dataRow["OtherBlockCount"], dataRow["MigratedCount"], dataRow["ElectedCount"]);
                         parentNode.Value = dataRow["DepartmentLevel1"].ToString() + "|1";
                         arvore.Nodes.Add(parentNode);
                    }

                }

            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode treeNode = arvore.SelectedNode;
                List<string> colunas = new List<string>();
                string textoRow = string.Empty;
                string msg = string.Empty;
                string[] value = treeNode.Value.Split('|'); //lista de 2 indices, department e level
                string departmenteLevel = value[0]; //indice 0 reponsavel pelo  tipo de node selecionado
                string nivel = value[1];
                msg = ("arquivo exportado");

                using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\Public\Documents\Presidencia.csv", true))
                {

                    if (treeNode != null)
                    {
                        if (nivel == "1")
                        {

                            using (DataTable dataTable = DataLayer.GetPresidencia(departmenteLevel))
                            {

                                foreach (DataColumn dataColumn in dataTable.Columns)
                                {
                                    colunas.Add(dataColumn.ColumnName);

                                    DataColumn lastItem = dataTable.Columns[8];

                                    if (dataColumn == lastItem)
                                    {
                                        streamWriter.Write(dataColumn.ColumnName);


                                    }
                                    else
                                    {
                                        streamWriter.Write(dataColumn.ColumnName + ";");

                                    }

                                }


                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    streamWriter.Write(textoRow + "\r\n");
                                    string lastItem = dataTable.Columns[8].ColumnName;

                                    foreach (string coluna in colunas)
                                    {

                                        if (lastItem == coluna)
                                        {
                                            streamWriter.Write(dataRow[coluna].ToString());

                                        }
                                        else
                                        {
                                            streamWriter.Write(dataRow[coluna].ToString() + ";");

                                        }


                                    }

                                }

                            }




                        }

                        if (nivel == "2")
                        {
                            string[] value2 = treeNode.Parent.Value.Split('|'); //lista de 2 indices, department e level
                            string presidencia = value2[0]; //indice 0 reponsavel pelo  tipo de node selecionado

                            using (DataTable dataTable = DataLayer.GetDiretoria(presidencia, departmenteLevel))
                            {

                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    foreach (DataColumn dataColumn in dataTable.Columns)
                                    {

                                        textoRow = string.Format("{0} [{1}] [{2}] [{3}] [{4}] [{5}] [{6}] [{7}]", dataRow["DepartmentLevel2"], dataRow["SamaccountName"], dataRow["EmployeeNumber"], dataRow["Displayname"], dataRow["Appblock"], dataRow["OtherBlock"], dataRow["migrated"], dataRow["Elected"]);
                                    }


                                    streamWriter.Write(textoRow + "\r\n");


                                }
                            }


                        }

                        if (nivel == "3")
                        {

                            using (DataTable dataTable = DataLayer.GetSuper(departmenteLevel, departmenteLevel, departmenteLevel))
                            {
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    foreach (DataColumn dataColumn in dataTable.Columns)
                                    {
                                        textoRow = string.Format("{0} [{1}] [{2}] [{3}] [{4}] [{5}] [{6}] [{7}]", dataRow["DepartmentLevel3"], dataRow["SamaccountName"], dataRow["EmployeeNumber"], dataRow["Displayname"], dataRow["Appblock"], dataRow["OtherBlock"], dataRow["migrated"], dataRow["Elected"]);
                                    }

                                    
                                        streamWriter.Write(textoRow + "\r\n");

                                    
                                }
                            }


                        }

                        if (nivel == "4")
                        {

                            using (DataTable dataTable = DataLayer.GetGerencia(departmenteLevel, departmenteLevel, departmenteLevel, departmenteLevel))
                            {
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    foreach (DataColumn dataColumn in dataTable.Columns)
                                    {
                                        textoRow = string.Format("{0} [{1}] [{2}] [{3}] [{4}] [{5}] [{6}] [{7}]", dataRow["DepartmentLevel4"], dataRow["SamaccountName"], dataRow["EmployeeNumber"], dataRow["Displayname"], dataRow["Appblock"], dataRow["OtherBlock"], dataRow["migrated"], dataRow["Elected"]);
                                    }

                                    
                                        streamWriter.Write(textoRow + "\r\n");

                                    
                                }
                            }

                        }


                    }


                        //else

                        //{
                        //    msg = ("nenhum node selecionado");
                        //}

                        ClientScript.RegisterStartupScript(this.GetType(), "xxx", string.Format("alert('{0}')", msg), true);

                    }
                }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void ExpandArvore(TreeNode parentNode)
        {
            try
            {

                string[] values = parentNode.Value.Split('|'); //lista de 2 indices, department e level
                string departmentLevel = values[0];
                string level = values[1];
                
                if(parentNode.ChildNodes.Count > 0)
                {
                    return;
                }
               

                if (level == "1")
                {
                    using (DataTable dataTable1 = DataLayer.GetTreeviewCandidateDP1(departmentLevel))
                    {
                        foreach (DataRow dataRow1 in dataTable1.Rows)
                        {
                            TreeNode t = new TreeNode();
                            t.ImageUrl = "~/imagens/pasta.png";
                            t.Text = string.Format("{0} [{1}] [{2}] [{3}] [{4}] [{5}]", dataRow1["DepartmentLevel2"], dataRow1["CandidateCount"], dataRow1["AppBlockCount"], dataRow1["OtherBlockCount"], dataRow1["MigratedCount"], dataRow1["ElectedCount"]);
                            t.Value = dataRow1["DepartmentLevel2"].ToString() + "|2";
                            parentNode.ChildNodes.Add(t);
                        }
                    }
                }

                if(level == "2")
                {
                    using (DataTable dataTable1 = DataLayer.GetTreeviewCandidateDP2(departmentLevel))
                    {
                        foreach (DataRow dataRow1 in dataTable1.Rows)
                        {
                            TreeNode t = new TreeNode();
                            t.ImageUrl = "~/imagens/user.png";
                            t.Text = string.Format("{0} [{1}] [{2}] [{3}] [{4}] [{5}]", dataRow1["DepartmentLevel3"], dataRow1["CandidateCount"], dataRow1["AppBlockCount"], dataRow1["OtherBlockCount"], dataRow1["MigratedCount"], dataRow1["ElectedCount"]); 
                            t.Value = dataRow1["DepartmentLevel3"].ToString() + "|3";
                            parentNode.ChildNodes.Add(t);
                        }
                    }
                }

                if (level == "3")
                {
                    using (DataTable dataTable1 = DataLayer.GetTreeviewCandidateDP3(departmentLevel))
                    {
                        foreach (DataRow dataRow1 in dataTable1.Rows)
                        {
                            TreeNode t = new TreeNode();
                            t.ImageUrl = "~/imagens/user.png";
                            t.Text = string.Format("{0} [{1}] [{2}] [{3}] [{4}] [{5}]", dataRow1["DepartmentLevel4"], dataRow1["CandidateCount"], dataRow1["AppBlockCount"], dataRow1["OtherBlockCount"], dataRow1["MigratedCount"], dataRow1["ElectedCount"]);
                            t.Value = dataRow1["DepartmentLevel4"].ToString() + "|4";
                            parentNode.ChildNodes.Add(t);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }


        protected void arvore_SelectedNodeChanged(object sender, EventArgs e)
        {
            ExpandArvore((sender as TreeView).SelectedNode); //chamada generica
        }

    }
}