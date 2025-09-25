using INT0010._4PS.Services.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.CodeBase
{
    public class CustomerCodeBase
    {
        public Customers GetCustomerList(CommonParameters common, DateTime? changedAfter)
        {
           
            Customers response = new Customers();

            //  Hämta företag
          

            //  Hämta connection string för databasanrop
            string connectionString = common._4PSSQLConnection;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                DataSet dsReturn = new DataSet();
                SqlCommand sqlCommand = new SqlCommand();

                // DONE: Code received from Assemblin contains SQL Injection vulnerability! Use params to fix this.
                // DONE: SQL Injection vulnerability below!

                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";

                string strFields = "  c.[No_] AS[CustomerNo]" +
                                   ", c.[Name] AS[CustomerName]" +
                                   ", c.[Address]" +
                                   ", c.[Address 2] AS[Address2]" +
                                   ", c.[Post Code] AS[PostCode]" +
                                   ", c.[City]" +
                                   ", c.[Country_Region Code] AS[CountryCode]" +
                                   ", c.[COC Registration No_] AS[OrgNo]" +
                                   ", c.[VAT Registration No_] AS[VATRegNo]" +
                                   ", c.[Payment Terms Code] AS[PaymentTermsCode]" +
                                   ", IsNull(pt.[Description], '') AS[PaymentTerm]" +
                                   ", c.[Modified by] AS ModifiedBy" +
                                   ", c.[$systemModifiedAt]" +
                                   ", CONVERT( varchar(10), c.[$systemModifiedAt], 120) AS[LastDateModified]" +
                                   ", Right(CONVERT(varchar(19), c.[$systemModifiedAt], 120), 8) AS[LastTimeModified]" +
                                   ", c.Blocked ";

                strSQLCommand += String.Format("SELECT {0} FROM [dbo].[{1}$Customer] c ", strFields, common.Company);
                strSQLCommand += String.Format("LEFT OUTER JOIN [dbo].[{0}$Payment Terms] pt ON pt.[Code] = c.[Payment Terms Code] ", common.Company);

                if (changedAfter != null)
                {
                    // TODO: Check Local / Universal time!
                    string strChangedAfter = String.Format("{0} {1}", changedAfter?.ToUniversalTime().ToShortDateString(), changedAfter?.ToUniversalTime().ToLongTimeString());
                    strSQLCommand += "WHERE CONVERT(varchar(10), c.[$systemModifiedAt], 120) + ' ' + RIGHT(CONVERT(varchar(19), c.[$systemModifiedAt], 120), 8) > @ChangedAfter";
                    sqlCommand.Parameters.AddWithValue("@ChangedAfter", strChangedAfter);
                }

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strSQLCommand;

                sqlConnection.Open();

                DataTable dt = new DataTable("ResultTable");
                SqlDataAdapter dtAd = new SqlDataAdapter(sqlCommand);
                dtAd.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    Customer c = new Customer()
                    {
                        Domain = common.Domain,
                        CustomerNo = CommonHelper.GetStringValueFromObject(dr["CustomerNo"], ""),
                        CustomerName = CommonHelper.GetStringValueFromObject(dr["CustomerName"], ""),
                        Address = CommonHelper.GetStringValueFromObject(dr["Address"], ""),
                        Address2 = CommonHelper.GetStringValueFromObject(dr["Address2"], ""),
                        PostCode = CommonHelper.GetStringValueFromObject(dr["PostCode"], ""),
                        City = CommonHelper.GetStringValueFromObject(dr["City"], ""),
                        CountryCode = CommonHelper.GetStringValueFromObject(dr["CountryCode"], ""),
                        OrgNo = CommonHelper.GetStringValueFromObject(dr["OrgNo"], ""),
                        VATRegNo = CommonHelper.GetStringValueFromObject(dr["VATRegNo"], ""),
                        PaymentTermsCode = CommonHelper.GetStringValueFromObject(dr["PaymentTermsCode"], ""),
                        PaymentTerm = CommonHelper.GetStringValueFromObject(dr["PaymentTerm"], ""),
                        ModifiedBy = CommonHelper.GetStringValueFromObject(dr["ModifiedBy"], ""),
                        LastDateModified = CommonHelper.GetStringValueFromObject(dr["LastDateModified"], ""),
                        LastTimeModified = CommonHelper.GetStringValueFromObject(dr["LastTimeModified"], ""),
                        Blocked = CommonHelper.GetIntValueFromObject(dr["Blocked"], 0) == 1,
                        BlockedSpecified = true
                    };

                    response.CustomerListResponse.Add(c);
                }

            }

           
            return response;
        }
    }
}
