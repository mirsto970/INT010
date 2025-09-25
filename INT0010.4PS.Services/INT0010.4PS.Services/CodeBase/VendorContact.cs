using INT0010._4PS.Services.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.CodeBase
{
    public class VendorContactCodeBase
    {
        public VendorContacts GetVendorContactList(CommonParameters common, DateTime? changedAfter)
        {

            VendorContacts response = new VendorContacts();

          
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
                                   ", cnt.[No_] AS ContactNo" +
                                   ", cnt.[First Name] AS FirstName" +
                                   ", cnt.[Surname] As Surname" +
                                   ", cnt.[Phone No_] AS PhoneNo" +
                                   ", cnt.[Mobile Phone No_] AS [MobilePhoneNo]" +
                                   ", cnt.[E-Mail] AS Email" +
                                   ", cnt.[Job Title] AS JobTitle" +
                                   ", cnt.[Modified by] AS ModifiedBy" +
                                   ", CONVERT (varchar(10), cnt.[Last Date Modified], 120) AS [LastDateModified]" +
                                   ", Right(CONVERT( varchar(19), cnt.[Last Time Modified], 120), 8) AS [LastTimeModified]" +
                                   ", cnt.Blocked ";

                strSQLCommand += String.Format("SELECT {0} FROM [dbo].[{1}$Vendor] v ", strFields, common.Company);
                strSQLCommand += String.Format("INNER JOIN [dbo].[{0}$Contact Business Relation] cbr ON cbr.[Link to Table] = 2 AND cbr.[No_] = v.[No_] ", common.Company);
                strSQLCommand += String.Format("INNER JOIN [dbo].[{0}$Contact] cnt ON cnt.[Type] = 1 AND cnt.[Company No_] = cbr.[Contact No_] ", common.Company);


                if (changedAfter != null)
                {
                    // TODO: Check Local / Universal time!
                    string strChangedAfter = String.Format("{0} {1}", changedAfter?.ToUniversalTime().ToShortDateString(), changedAfter?.ToUniversalTime().ToLongTimeString());

                    strSQLCommand += String.Format("WHERE CONVERT( varchar(10), cnt.[Last Date Modified], 120) + ' ' + Right(CONVERT( varchar(19), cnt.[Last Time Modified], 120), 8) > @ChangedAfter");

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

                    VendorContact vc = new VendorContact()
                    {
                        Domain = common.Domain,
                        VendorNo = CommonHelper.GetStringValueFromObject(dr["VendorNo"], ""),
                        VendorName = CommonHelper.GetStringValueFromObject(dr["VendorName"], ""),
                        ContactNo = CommonHelper.GetStringValueFromObject(dr["ContactNo"], ""),
                        FirstName = CommonHelper.GetStringValueFromObject(dr["FirstName"], ""),
                        Surname = CommonHelper.GetStringValueFromObject(dr["Surname"], ""),
                        PhoneNo = CommonHelper.GetStringValueFromObject(dr["PhoneNo"], ""),
                        MobilePhoneNo = CommonHelper.GetStringValueFromObject(dr["MobilePhoneNo"], ""),
                        Email = CommonHelper.GetStringValueFromObject(dr["Email"], ""),
                        JobTitle = CommonHelper.GetStringValueFromObject(dr["JobTitle"], ""),
                        ModifiedBy = CommonHelper.GetStringValueFromObject(dr["ModifiedBy"], ""),
                        LastDateModified = CommonHelper.GetStringValueFromObject(dr["LastDateModified"], ""),
                        LastTimeModified = CommonHelper.GetStringValueFromObject(dr["LastTimeModified"], ""),
                        Blocked = CommonHelper.GetIntValueFromObject(dr["Blocked"], 0) == 1,
                        BlockedSpecified = true
                    };

                    response.VendorContactListResponse.Add(vc);
                }


            }

           
            return response;
        }
    }
}
