using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library
{
    public static class DataLayer
    {

        private static SqlConnection CreateConnection(string connKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connKey].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            return sqlConnection;
        }


        public static DataTable GetUserDepartment(string userLogin)
        {
            DataTable datatable = new DataTable();
            string command = string.Format("select * from SIMPLAD_DEPARTMENT t1 inner join SIMPLAD_DEPARTMENT_USER t2 on t1.DepartmentID = t2.DepartmentID where t2.UserID = '{0}' ", userLogin);

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(datatable);
                }
            }

            return datatable;
        }

        public static DataTable GetComputerUser(string userLogin)
        {
            DataTable datatable = new DataTable();
            string command = string.Format("select * from RUM_COMPUTER where UserLogon = '{0}'", userLogin);

            using (SqlConnection sqlConnection = CreateConnection("SELF_MIGRATE2"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(datatable);
                }
            }

            return datatable;
        }

        public static DataTable GetTreeviewCandidate()
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("select distinct DepartmentLevel1, COUNT(1) as CandidateCount, SUM(case when AppBlock = 'Y' then 1 else 0 end) as AppBlockCount, SUM(case when OtherBlock = 'Y' then 1 else 0 end) as OtherBlockCount, SUM(case when Migrated = 'Y' then 1 else 0 end) as MigratedCount, SUM(case when Elected = 'Y' then 1 else 0 end) as ElectedCount from CANDIDATE group by DepartmentLevel1");

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;       
        }

        public static DataTable GetTreeviewCandidateDP1(string departmentLevel1)
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("select distinct DepartmentLevel2, COUNT(1) as CandidateCount,  SUM(case when AppBlock = 'Y' then 1 else 0 end)as AppBlockCount, SUM(case when OtherBlock = 'Y' then 1 else 0 end)as OtherBlockCount, SUM(case when Migrated = 'Y' then 1 else 0 end)as MigratedCount, SUM(case when Elected = 'Y' then 1 else 0 end) as ElectedCount from  CANDIDATE  where DepartmentLevel1 = '{0}' group by DepartmentLevel2;", departmentLevel1);

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable GetTreeviewCandidateDP2(string departmentLevel2)
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("select distinct DepartmentLevel3, COUNT(1) as CandidateCount,  SUM(case when AppBlock = 'Y' then 1 else 0 end)as AppBlockCount, SUM(case when OtherBlock = 'Y' then 1 else 0 end)as OtherBlockCount, SUM(case when Migrated = 'Y' then 1 else 0 end)as MigratedCount, SUM(case when Elected = 'Y' then 1 else 0 end) as ElectedCount from  CANDIDATE  where DepartmentLevel2 = '{0}' group by DepartmentLevel3;", departmentLevel2);

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable GetTreeviewCandidateDP3(string departmentLevel3)
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("select distinct DepartmentLevel4, COUNT(1) as CandidateCount, SUM(case when AppBlock = 'Y' then 1 else 0 end) as AppBlockCount, SUM(case when OtherBlock = 'Y' then 1 else 0 end) as OtherBlockCount, SUM(case when Migrated = 'Y' then 1 else 0 end) as MigratedCount, SUM(case when Elected = 'Y' then 1 else 0 end) as ElectedCount from CANDIDATE  where DepartmentLevel3 = '{0}' group by DepartmentLevel4; ", departmentLevel3);

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        //-----------------------------------------------------------------------------------------

        public static DataTable GetPresidencia(string departmentLevel)
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("select DepartmentLevel1,SAMAccountName,EmployeeNumber,SAMAccountName,Displayname,AppBlock,OtherBlock,Migrated,Elected from CANDIDATE where DepartmentLevel1 = '{0}'", departmentLevel);


            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable GetDiretoria(string departmentLevel, string departmenteLevel2)
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("select DepartmentLevel2,SAMAccountName,EmployeeNumber,Displayname,AppBlock,OtherBlock,Migrated,Elected from CANDIDATE where DepartmentLevel1 = '{0}' and DepartmentLevel2 = '{1}'", departmentLevel,departmenteLevel2);

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable GetSuper(string departamentLevel, string departmentLevel2, string departmentLevel3)
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("select DepartmentLevel3,SAMAccountName,EmployeeNumber,Displayname,AppBlock,OtherBlock,Migrated,Elected from CANDIDATE where DepartmentLevel1 = '{0}' and DepartmentLevel2 = '{1}' and DepartmentLevel3 = '{2}'", departamentLevel,departmentLevel2,departmentLevel3);

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public static DataTable GetGerencia(string departamentLevel, string departmentLevel2, string departmenteLevel3, string departmenteLevel4)
        {
            DataTable dataTable = new DataTable();
            string command = string.Format("select DepartmentLevel4,SAMAccountName,EmployeeNumber,Displayname,AppBlock,OtherBlock,Migrated,Elected from CANDIDATE where DepartmentLevel1 = '{0}' and DepartmentLevel2 = '{1}' and DepartmentLevel3 = '{2}' and DepartmentLevel4 = '{3}'", departamentLevel, departmentLevel2, departmenteLevel3,departmenteLevel4);

            using (SqlConnection sqlConnection = CreateConnection("ITAU_SSMP"))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

    }
}