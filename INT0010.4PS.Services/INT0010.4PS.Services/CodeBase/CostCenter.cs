using INT0010._4PS.Services.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.CodeBase
{
    public class CostCenterCodeBase
    {
        public CostCenters GetCostCenterList(CommonParameters common )
        {
           
            CostCenters response = new CostCenters();

            //  Hämta företag
           

            //  Hämta connection string för databasanrop
            string connectionString = common._4PSSQLConnection;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                DataSet dsReturn = new DataSet();
                SqlCommand sqlCommand = new SqlCommand();


                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";

                string strFields = @"  kst.Code 
                                   , kst.[Name] 
                                   , kst.[ORA CostCenterResponsible] 
                                   , kst.[Blocked]";

                strSQLCommand += $@"SELECT {strFields} FROM [dbo].[{common.Company}$Dimension Value] kst 
                                WHERE kst.[Dimension Code] = 'KOSTNADSSTÄLLE'
                                ORDER BY kst.Code";

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strSQLCommand;

                sqlConnection.Open();

                DataTable dt = new DataTable("ResultTable");
                SqlDataAdapter dtAd = new SqlDataAdapter(sqlCommand);
                dtAd.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    CostCenter cc = new CostCenter()
                    {
                        Domain = common.Domain,
                        Code = CommonHelper.GetStringValueFromObject(dr["Code"], ""),
                        Name = CommonHelper.GetStringValueFromObject(dr["Name"], ""),
                        CostCenterResponsible = CommonHelper.GetStringValueFromObject(dr["ORA CostCenterResponsible"], ""),
                        Blocked = CommonHelper.GetIntValueFromObject(dr["Blocked"], 0) == 1,
                        BlockedSpecified = true
                    };

                    response.CostCenterListResponse.Add(cc);
                }


            }

          
            return response;
        }
    }
}
