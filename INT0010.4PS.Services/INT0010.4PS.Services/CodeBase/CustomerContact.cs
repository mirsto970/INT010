using Assemblin.BizTalk.InvoDAL.ImdokWS;
using INT0010._4PS.Services.Entity;
using INT0010._4PS.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace INT0010._4PS.Services.CodeBase
{
    public class CustomerContactCodeBase
    {
        private const string ContactNoRegExpString = @"^KONT\d*$";
        private Regex ContactNoRegEx = new Regex(ContactNoRegExpString);
        public CustomerContacts GetCustomerContactList(CommonParameters common,DateTime? changedAfter)
        {
         
            CustomerContacts response = new CustomerContacts();

           
            //  Hämta connection string för databasanrop
            string connectionString = common._4PSSQLConnection;

          
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                DataSet dsReturn = new DataSet();
                SqlCommand sqlCommand = new SqlCommand();

                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";

                string strFields = "  cu.[No_] AS[CustomerNo]" +
                                   ", cu.[Name] AS[CustomerName]" +
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

                strSQLCommand += String.Format("SELECT {0} FROM [dbo].[{1}$Customer] cu ", strFields, common.Company);
                strSQLCommand += String.Format("INNER JOIN [dbo].[{0}$Contact Business Relation] cbr ON cbr.[Link to Table] = 1 AND cbr.[No_] = cu.[No_] ", common.Company);
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
                    CustomerContact cc = new CustomerContact()
                    {
                        Domain = common.Domain,
                        CustomerNo = CommonHelper.GetStringValueFromObject(dr["CustomerNo"], ""),
                        CustomerName = CommonHelper.GetStringValueFromObject(dr["CustomerName"], ""),
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

                    response.CustomerContactListResponse.Add(cc);
                }


            }

          
            return response;
        }

        public CreateAndUpdateCustomerContactResponse CreateAndCustomerContactPerson(CommonParameters common, INT0010._4PS.Services.Entity.CustomerContact contact)
        {

            CreateAndUpdateCustomerContactResponse response = new CreateAndUpdateCustomerContactResponse();

            // Get URL from Settings using Domain
            string url =common.ImdokUrl;

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Ntlm;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly; // Denna var viktig tillsammans med Ntlm

            // Create the endpoint address
            EndpointAddress endpointAddress = new EndpointAddress(url);
            ImdokWS_PortClient client = new ImdokWS_PortClient(binding, endpointAddress);

            // Inloggning via BizTalk servicekonto.
            client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            ImdokCreateUpdatePrincipalContactPerson ir = Map(contact);
            ImdokWS imdokWs =
                new ImdokWS { CreateUpdatePrincipalContactPerson = ir };

            XmlDocument imdokWsXml = imdokWs.Serialize<ImdokWS>();

            // Fix for Imdok. Empty text nodes required (self closing tags not handles by Invo Web Service as empty).
            imdokWsXml.LastChild.AddSpaceToEmptyNodes();

            string xmlString = imdokWsXml.OuterXml;
            string contactNumberCreated;
            try
            {
                contactNumberCreated = client.CreateUpdatePrincipalContactPerson(xmlString);
            }
            catch (Exception e)
            {
                contactNumberCreated = e.Message;
            }

            // Web Service returns textual errors in ContactNo property (!!), so we need to try to check for errors
            // Currently, we check for errors by trying to parse ContactNo using Regexp.
            if (ContactNoRegEx.IsMatch(contactNumberCreated))
            {
                response.ContactNo = contactNumberCreated;
                response.ErrorStatusCode = ((int)HttpStatusCode.OK).ToString();
                response.Error = false;
                response.ErrorText = String.Empty;
            }
            else
            {
                response.ContactNo = String.Empty;
                response.Error = true;
                response.ErrorText = contactNumberCreated;
                response.ErrorStatusCode = ((int)HttpStatusCode.BadRequest).ToString();
            }

            return response;

        }

        private ImdokCreateUpdatePrincipalContactPerson Map(INT0010._4PS.Services.Entity.CustomerContact r)
        {
            if (r == null)
            {
                return null;
            }

            // TODO: Could use AutoMapper.
            return new ImdokCreateUpdatePrincipalContactPerson()
            {
                ContNo = r.ContactNo,
                CustNo = r.CustomerNo,
                EMail = r.Email,
                FirstName = r.FirstName,
                JobTitle = r.JobTitle,
                MobilePhoneNo = r.MobilePhoneNo,
                ModifiedBy = r.ModifiedBy,
                PhoneNo = r.PhoneNo,
                SurName = r.Surname

            };
        }
    }
}
