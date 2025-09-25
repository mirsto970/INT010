using INT0010._4PS.Services.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.CodeBase
{
    public class LookupTableCodeBase
    {
      
        public LookupTable GetLookupTable(CommonParameters common,  TableType tableType)
        {
          
            LookupTable response = new LookupTable();

            //  Hämta företag
            string company = common.Domain;

            //  Hämta connection string för databasanrop
            string connectionString = common._4PSSQLConnection;

          
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                DataSet dsReturn = new DataSet();
                SqlCommand sqlCommand = new SqlCommand();


                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";
                strSQLCommand += GetSQLCommand(common,  tableType);

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strSQLCommand;

                sqlConnection.Open();

                DataTable dt = new DataTable("ResultTable");
                SqlDataAdapter dtAd = new SqlDataAdapter(sqlCommand);
                dtAd.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    LookupTableRow tr = Map(dr, common, tableType);
                    response.LookupTableResponse.Add(tr);
                }

               
            }

            

            return response;
        }



        private LookupTableRow Map(DataRow dr, CommonParameters common,  TableType tableType)
        {

            if (tableType == TableType.CustomerPriceList)
            {
                return new LookupTableRow()
                {
                    Domain = common.Domain,
                    Code = CommonHelper.GetStringValueFromObject(dr["Code"], ""),
                    Description = CommonHelper.GetStringValueFromObject(dr["Description"], ""),
                    ExtraInfo1 = CommonHelper.GetStringValueFromObject(dr["DisplayPriceList"], ""),
                    ExtraInfo2 = CommonHelper.GetStringValueFromObject(dr["ApplyMaterialSurcharge"], ""),
                    ExtraInfo3 = CommonHelper.GetStringValueFromObject(dr["NetPriceList"], ""),
                    ExtraInfo4 = CommonHelper.GetDecimalValueFromObject(dr["SurchargeIfMissingArticles"], 0).ToString(),

                };
            }

            else if (tableType == TableType.DiscountTermGroup)
            {
                return new LookupTableRow()
                {
                    Domain = common.Domain,
                    Code = CommonHelper.GetStringValueFromObject(dr["Code"], ""),
                    Description = CommonHelper.GetStringValueFromObject(dr["Description"], ""),
                    ExtraInfo1 = CommonHelper.GetStringValueFromObject(dr["Level"], ""),
                    ExtraInfo2 = CommonHelper.GetStringValueFromObject(dr["RowType"], ""),
                    ExtraInfo3 = CommonHelper.GetStringValueFromObject(dr["PriceListCode"], ""),
                };
            }
            else
            {
                return new LookupTableRow()
                {
                    Domain = common.Domain,
                    Code = CommonHelper.GetStringValueFromObject(dr["Code"], ""),
                    Description = CommonHelper.GetStringValueFromObject(dr["Description"], ""),

                };
            }


        }

        private string GetSQLCommand(CommonParameters common,  TableType tableType)
        {


            if (tableType == TableType.ObjectCode)
            {
                return $"SELECT[Line No_] AS [Code] , [Description] FROM dbo.[{common.Company}$ORA Job Segments Nordic] WHERE[Line Type] = 0";

            }
            else if (tableType == TableType.JobType)
            {
                return $"SELECT [Line No_] AS [Code], [Description] FROM dbo.[{common.Company}$ORA Job Segments Nordic] WHERE [Line Type] = 2";
            }
            else if (tableType == TableType.ReimbursementForm)
            {
                return $"SELECT [Line No_] AS [Code] , [Description] FROM dbo.[{common.Company}$ORA Job Segments Nordic] WHERE [Line Type] = 3";
            }
            else if (tableType == TableType.RowType)
            {
                return $"SELECT Code, [Description] FROM [dbo].[{common.Company}$Type]";
            }
            else if (tableType == TableType.Discipline)
            {
                return $"SELECT Code, [Description] FROM[dbo].[{common.Company}$Discipline]";
            }
            else if (tableType == TableType.ProjectType)
            {
                return $"SELECT Code, [Description] FROM[dbo].[{common.Company}$Project Type]";
            }
            else if (tableType == TableType.HandyManNoteType)
            {
                return $"SELECT Code, [Description] FROM [dbo].[{common.Company}$Standard Text] ";
            }
            else if (tableType == TableType.CustomerPriceList)
            {
                return $@"SELECT  
                  Code
	            , [Description] 
	            , CASE[Display Price List] WHEN 0 THEN 'false' ELSE 'true' END AS[DisplayPriceList]
                , CASE[Apply Material Surcharge] WHEN 0 THEN 'false' ELSE 'true' END AS[ApplyMaterialSurcharge]
                , CASE[Net Price List] WHEN 0 THEN 'false' ELSE 'true' END AS[NetPriceList]
                , [SurchargeIfMissingArticles]
                FROM [dbo].[{common.Company}$Customer Price List]";
            }
            else if (tableType == TableType.DiscountTermGroup)
            {
                return $@"SELECT  
	                CASE [Level] WHEN 0 THEN 'Company' WHEN 1 THEN 'Customer' WHEN 2 THEN 'Job' ELSE '' END AS [Level]
	                , Code
	                , [Description] 
	                , CASE [Type] WHEN 0 THEN 'Common' WHEN 1 THEN 'Purchase' WHEN 2 THEN 'Sales' END AS [RowType]
	                , [Price List Code] AS [PriceListCode]
                    FROM 
	                [dbo].[{common.Company}$Discount Term Group]
                    WHERE [Level] = 1 AND [Type] = 2";
            }
            else
                return null;
          


        }
    }
}
