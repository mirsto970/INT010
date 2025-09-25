
using Assemblin.BizTalk.InvoDAL.InvoWS;
using System;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Web;
using System.Net;
using System.Collections.Generic;
using INT0010._4PS.Services.Entity;
using INT0010._4PS.Services.Extensions;
using System.Text.Json.Serialization;

namespace INT0010._4PS.Services.CodeBase
{
   
    public class ContractCodeBase
    {
        //protected const string WebServiceEncoding = "ISO-8859-1";

        public ContractCodeBase()
        {

        }

        public Contracts GetExtensionProjects(CommonParameters common,  DateTime? changedAfter = null)
        {

            Contracts contracts = new Contracts();

            using (var sqlConnection = new SqlConnection(common._4PSSQLConnection))
            {
                SqlCommand sqlCommand = new SqlCommand();

                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";

                strSQLCommand += GetExtensionProjectSQL(common.Company);

                if (changedAfter != null)
                {
                    // TODO: Check Local / Universal time!
                    string strChangedAfter = String.Format("{0} {1}", changedAfter?.ToUniversalTime().ToShortDateString(), changedAfter?.ToUniversalTime().ToLongTimeString());
                    strSQLCommand += String.Format("WHERE ext.[$systemModifiedAt] > @ChangedAfter");
                    sqlCommand.Parameters.AddWithValue("@ChangedAfter", strChangedAfter);
                }

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strSQLCommand;

                sqlConnection.Open();

                using (var dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contract ec = GetExtensionContractFromDataReader(dr, common.Domain);
                        contracts.ExtensionProjectListResponse.Add(ec);
                    }


                }

            }

            return contracts;

        }

        public Contracts GetExtensionProject(CommonParameters common,string projectNo, string contractNo)
        {

            Contracts contracts = new Contracts();

            using (var sqlConnection = new SqlConnection(common._4PSSQLConnection))
            {
                SqlCommand sqlCommand = new SqlCommand();

                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";

                strSQLCommand += GetExtensionProjectSQL(common.Company);

                strSQLCommand += String.Format("WHERE ext.[Project No_] = @ProjectNoParam");
                sqlCommand.Parameters.AddWithValue("@ProjectNoParam", projectNo);

                if (!string.IsNullOrEmpty(contractNo))
                {
                    strSQLCommand += String.Format(" AND ext.[Contract No_] = @ContractNoParam");
                    sqlCommand.Parameters.AddWithValue("@ContractNoParam", contractNo);
                }

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strSQLCommand;

                sqlConnection.Open();

                using (var dr = sqlCommand.ExecuteReader())
                {
                    dr.Read();

                    if (dr.HasRows)
                        contracts.ExtensionProjectListResponse.Add(GetExtensionContractFromDataReader(dr, common.Domain));
                }

            }

          
            return contracts;

        }

    
        public CreateAndUpdateExtensionContractResponse CreateAndUpdateExtensionContract(CommonParameters common, Contract contract)
        {

            CreateAndUpdateExtensionContractResponse response = new CreateAndUpdateExtensionContractResponse();

            // Get URL from Settings using Domain
            string url = common.InvoUrl;

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Ntlm;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly; // Denna var viktig tillsammans med Ntlm

            // Create the endpoint address
            EndpointAddress endpointAddress = new EndpointAddress(url);
            InvoWS_PortClient client = new InvoWS_PortClient(binding, endpointAddress);

            // Inloggning via BizTalk servicekonto.
            client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            InvoCreateAndUpdateProjectExtension ir = Map(contract);
            InvoWSProjectExtension invoWs =
                new InvoWSProjectExtension { CreateAndUpdateProjectExtension = ir };

            // Convert .NET POCO to Xml.
            XmlDocument invoWsXmlDocument = invoWs.Serialize<InvoWSProjectExtension>();

            // Fix for Invo. Empty text nodes required (self closing tags not handles by Invo Web Service as empty).
            invoWsXmlDocument.LastChild.AddSpaceToEmptyNodes();

            // Get Outer Xml string to call Invo WS 
            string xmlString = invoWsXmlDocument.OuterXml;
            string contractNumberCreated;
            try
            {
                contractNumberCreated = client.CreateAndUpdateProjectExtension(xmlString);
            }

            catch (Exception e)
            {
                contractNumberCreated = e.Message;
            }


            // Web Service returns textual errors in ContractNo property (!!), so we need to try to check for errors
            // Currently, we check for errors by trying to parse ProjectNo as a number.
            long result;
            if (long.TryParse(contractNumberCreated, out result))
            {
                response.ContractNo = contractNumberCreated;
                response.ErrorStatusCode = ((int)HttpStatusCode.OK).ToString();
                response.ErrorText = String.Empty;
                response.Error = false;
            }
            else
            {
                response.ContractNo = String.Empty;
                response.Error = true;
                response.ErrorText = contractNumberCreated;
                response.ErrorStatusCode = ((int)HttpStatusCode.BadRequest).ToString();
            }

            return response;
        }
        private Contract GetExtensionContractFromDataReader(SqlDataReader dr, string domain)
        {

            
            return new Contract()
            {

                Domain = domain,
                ProjectNo = CommonHelper.GetStringValueFromObject(dr["Project No_"], ""),
                ContractNo = CommonHelper.GetStringValueFromObject(dr["Contract No_"], ""),
                Description = CommonHelper.GetStringValueFromObject(dr["Description"], ""),
                Principal = CommonHelper.GetStringValueFromObject(dr["Principal"], ""),
                PrincipalContact = CommonHelper.GetStringValueFromObject(dr["Principal Contact"], ""),
                Status = CommonHelper.GetIntValueFromObject(dr["Status"], 0),
                StatusSpecified = true,
                ContractAmount = CommonHelper.GetDecimalValueFromObject(dr["Contract Amount"], 0),
                ContractAmountSpecified = true,
                OfferedAmount = CommonHelper.GetDecimalValueFromObject(dr["Offered Amount"], 0),
                OfferedAmountSpecified = true,
                SettlementMethod = CommonHelper.GetIntValueFromObject(dr["Settlement Method"], 0),
                SettlementMethodSpecified = true,
                GenerateInstallments = (CommonHelper.GetIntValueFromObject(dr["Generate Installments"], 0) == 1),
                GenerateInstallmentsSpecified = true,
                InstallmentScheme = CommonHelper.GetStringValueFromObject(dr["Installment Scheme"], ""),
                InputBy = CommonHelper.GetStringValueFromObject(dr["Input by"], ""),
                ModifiedBy = CommonHelper.GetStringValueFromObject(dr["Modified by"], ""),
                InputDate = CommonHelper.GetDateTimeValueFromObject(dr["Input Date"], DateTime.Now),
                InputDateSpecified = true,
                LastDateModified = CommonHelper.GetStringValueFromObject(dr["LastDateModified"], ""),
                LastTimeModified = CommonHelper.GetStringValueFromObject(dr["LastTimeModified"], ""),



            };

        }

        private string GetExtensionProjectSQL(string strCompany)
        {

            string strFields = $@" ext.[Project No_]
	                            , ext.[Contract No_]
	                            , ext.[Description]
	                            , ext.[Principal]
	                            , ext.[Principal Contact]
	                            , ext.[Status]
	                            , ext.[Contract Amount]
	                            , ext.[Offered Amount]
	                            , ext.[Settlement Method]
	                            , ext.[Generate Installments]
	                            , ext.[Installment Scheme]
	                            , ext.[Input by]
	                            , ext.[Modified by]
	                            , ext.[Input Date]
	                            , ext.[Last Date Modified]
                                , ext.[$systemModifiedAt]
                             , CONVERT( varchar(10), ext.[$systemModifiedAt], 120) AS [LastDateModified]
                             , Right(CONVERT(varchar(19), ext.[$systemModifiedAt], 120), 8) AS [LastTimeModified]";


            string strSQLCommand = String.Format("SELECT {0} FROM [dbo].[{1}$Extension Contract] ext ", strFields, strCompany);

            return strSQLCommand;
        }

        private InvoCreateAndUpdateProjectExtension Map(Contract r)
        {
            if (r == null)
            {
                return null;
            }

            // TODO: Could use AutoMapper.
            return new InvoCreateAndUpdateProjectExtension()
            {
                ProjectNo = r.ProjectNo,
                ContractNo = r.ContractNo,
                Description = r.Description,
                Principal = r.Principal,
                PrincipalContact = r.PrincipalContact,
                Status = r.Status,
                ContractAmount = r.ContractAmount,
                OfferedAmount = r.OfferedAmount,
                SettlementMethod = r.SettlementMethod,
                GenerateInstallments = r.GenerateInstallments ? 1 : 0,
                InstallmentScheme = r.InstallmentScheme,
                InputBy = r.InputBy,

            };
        }


       

    }

    public class WrappedCreateAndUpdateExtensionContractResponse
    {
        [JsonPropertyName("createAndUpdateExtensionContractResponse")]
        public CreateAndUpdateExtensionContractResponse Response { get; set; }
    }
}
