using INT0010._4PS.Services.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.CodeBase
{
    public class VendorCodeBase
    {
        public Vendors GetVendorList(CommonParameters common, DateTime? changedAfter)
        {

            Vendors response = new Vendors();


            //  Hämta connection string för databasanrop
            string connectionString = common._4PSSQLConnection;

         
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                DataSet dsReturn = new DataSet();
                SqlCommand sqlCommand = new SqlCommand();

                // DONE: Code received from Assemblin contains SQL Injection vulnerability! Use params to fix this.
                // DONE: SQL Injection vulnerability below!

                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";

                string strFields = "  v.[No_] AS [VendorNo]" +
                                   ", v.[Name] AS [VendorName]" +
                                   ", v.[Address] AS [Address]" +
                                   ", v.[Address 2] AS [Address2]" +
                                   ", v.[Post Code] AS [PostCode]" +
                                   ", v.[City]" +
                                   ", v.[Country_Region Code] AS [CountryCode]" +
                                   ", v.[COC Registration No_] AS [OrgNo]" +
                                   ", v.[VAT Registration No_] AS [VATRegNo]" +
                                   ", v.[Payment Terms Code] AS [PaymentTermsCode]" +
                                   ", IsNull(pt.[Description], '') AS [PaymentTerm]" +
                                   ", v.[Modified by] AS ModifiedBy" +
                                   ", CONVERT( varchar(10), v.[Last Date Modified], 120) AS [LastDateModified]" +
                                   //                           ", Right(CONVERT(varchar(19), c.[Time Last Modified], 120), 8) AS[LastTimeModified]" +     // Finns inte för leverantör i 4PS
                                   ", v.Blocked ";

                strSQLCommand += String.Format("SELECT {0} FROM [dbo].[{1}$Vendor] v ", strFields, common.Company);
                strSQLCommand += String.Format("LEFT OUTER JOIN [dbo].[{0}$Payment Terms] pt ON pt.[Code] = v.[Payment Terms Code] ", common.Company);
                //            strSQLCommand += String.Format("WHERE CONVERT( varchar(10), v.[Last Date Modified], 120) + ' ' + Right(CONVERT( varchar(19), c.[Time Last Modified], 120), 8) > '{0}'", strChangedAfter);

                if (changedAfter != null)
                {
                    // TODO: Check Local / Universal time!
                    string strChangedAfter = String.Format("{0}", changedAfter?.ToUniversalTime().ToShortDateString());
                    strSQLCommand += String.Format("WHERE CONVERT( varchar(10), v.[Last Date Modified], 120) > @ChangedAfter");
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
                    Vendor c = new Vendor()
                    {
                        Domain = common.Domain,
                        VendorNo = CommonHelper.GetStringValueFromObject(dr["VendorNo"], ""),
                        VendorName = CommonHelper.GetStringValueFromObject(dr["VendorName"], ""),
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
                        // LastTimeModified = CommonHelper.GetStringValueFromObject(dr["LastTimeModified"], ""),    // Finns inte i 4PS för leverantör
                        Blocked = CommonHelper.GetIntValueFromObject(dr["Blocked"], 0) == 1,
                        BlockedSpecified = true
                    };

                    response.VendorListResponse.Add(c);
                }


            }

          
            return response;
        }
    }
}
