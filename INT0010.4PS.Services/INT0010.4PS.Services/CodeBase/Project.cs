
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

namespace INT0010._4PS.Services.CodeBase
{
   
    public class ProjectCodeBase
    {
        //protected const string WebServiceEncoding = "ISO-8859-1";

        public ProjectCodeBase()
        {

        }


        static ProjectCodeBase()
        {

        }

        public Projects GetProject(CommonParameters common, string project)
        {
            Projects response = new Projects();

            using (var sqlConnection = new SqlConnection(common._4PSSQLConnection))
            {
                SqlCommand sqlCommand = new SqlCommand();

                // DONE: Code received from Assemblin contains SQL Injection vulnerability! Use params to fix this.
                // DONE: SQL Injection vulnerability below!
                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";

                strSQLCommand += GetProjectSQL(common.Company);

                strSQLCommand += String.Format("WHERE job.[No_] = @ProjectNoParam");
                sqlCommand.Parameters.AddWithValue("@ProjectNoParam", project);

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strSQLCommand;


                sqlConnection.Open();

                using (var dr = sqlCommand.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        response.ProjectListResponse.Add(GetProjectFromDataReader(dr, common.Domain));

                    }
                    
                }

            }



            return response;
        }

        
        public Projects GetProjects(CommonParameters common, DateTime? changedAfter = null)
        {

            Projects projects = new Projects();

            using (var sqlConnection = new SqlConnection(common._4PSSQLConnection))
            {
                SqlCommand sqlCommand = new SqlCommand();

                string strSQLCommand = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\r";

                strSQLCommand += GetProjectSQL(common.Company);

                if (changedAfter != null)
                {
                    string strChangedAfter = String.Format("{0} {1}", changedAfter?.ToUniversalTime().ToShortDateString(), changedAfter?.ToUniversalTime().ToLongTimeString());
                    strSQLCommand += String.Format("WHERE job.[$systemModifiedAt] > @ChangedAfter");
                    sqlCommand.Parameters.AddWithValue("@ChangedAfter", strChangedAfter);
                }

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strSQLCommand;

                sqlConnection.Open();

                using (var dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Project p = GetProjectFromDataReader(dr, common.Domain);
                        projects.ProjectListResponse.Add(p);
                    }
                }

            }

          
            return projects;

        }

        public CreateAndUpdateProjectResponse CreateAndUpdateProject(CommonParameters common, Project project)
        {

            CreateAndUpdateProjectResponse response = new CreateAndUpdateProjectResponse();

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

            InvoCreateAndUpdateProject ir = Map(project);
            InvoWSProject invoWs =
                new InvoWSProject() { CreateAndUpdateProject = ir };

            // Convert .NET POCO to Xml.
            XmlDocument invoWsXmlDocument = invoWs.Serialize<InvoWSProject>();

            // Fix for Invo. Empty text nodes required (self closing tags not handles by Invo Web Service as empty).
            invoWsXmlDocument.LastChild.AddSpaceToEmptyNodes();

            // Get Outer Xml string to call Invo WS 
            string xmlString = invoWsXmlDocument.OuterXml;
            string projectNumberCreated;
            try
            {
                projectNumberCreated = client.CreateAndUpdateProject(xmlString);
            }
            catch (Exception e)
            {
                projectNumberCreated = e.Message;
            }


            // Web Service returns textual errors in ProjectNo property (!!), so we need to try to check for errors
            // Currently, we check for errors by trying to parse ProjectNo as a number.
            long result;
            if (long.TryParse(projectNumberCreated, out result))
            {
                response.ProjectNo = projectNumberCreated;
                response.ErrorStatusCode = ((int)HttpStatusCode.OK).ToString();
            }
            else
            {
                response.ProjectNo = null;
                response.Error = true;
                response.ErrorText = projectNumberCreated;
                response.ErrorStatusCode = ((int)HttpStatusCode.BadRequest).ToString();
            }

            return response;
        }

        private Project GetProjectFromDataReader(SqlDataReader dr, string domain)
        {
            return new Project()
            {
                Domain = domain,
                ProjectNo = CommonHelper.GetStringValueFromObject(dr["No_"], ""),
                SingleMainSubProject = CommonHelper.GetIntValueFromObject(dr["Single_Main_Sub Project"], 0),
                SingleMainSubProjectSpecified = true,
                MainProject = CommonHelper.GetStringValueFromObject(dr["Main Project"], ""),
                CostCenter = CommonHelper.GetStringValueFromObject(dr["Global Dimension 1 Code"], ""),
                Description = CommonHelper.GetStringValueFromObject(dr["Description"], ""),
                Description2 = CommonHelper.GetStringValueFromObject(dr["Description 2"], ""),
                Address = CommonHelper.GetStringValueFromObject(dr["Bill-to Address"], ""),
                Address2 = CommonHelper.GetStringValueFromObject(dr["Bill-to Address 2"], ""),
                PostCode = CommonHelper.GetStringValueFromObject(dr["Bill-to Post Code"], ""),
                City = CommonHelper.GetStringValueFromObject(dr["Bill-to City"], ""),
                ProjectManager = CommonHelper.GetStringValueFromObject(dr["Project Manager"], ""),
                ProjectAdministrator = CommonHelper.GetStringValueFromObject(dr["Project Administrator"], ""),
                Estimator = CommonHelper.GetStringValueFromObject(dr["Estimator"], ""),
                ProjectStatus = CommonHelper.GetIntValueFromObject(dr["Project Status"], 0),
                ProjectType = CommonHelper.GetStringValueFromObject(dr["Project Type"], ""),
                ProjectStatusSpecified = true,
                RowType = CommonHelper.GetStringValueFromObject(dr["Type"], ""),
                Discipline = CommonHelper.GetStringValueFromObject(dr["Discipline"], ""),
                Expediter = CommonHelper.GetStringValueFromObject(dr["Expediter"], ""),
                StartingDate = CommonHelper.GetDateTimeValueFromObject(dr["Starting Date"], DateTime.Now),
                StartingDateSpecified = true,
                EndingDate = CommonHelper.GetDateTimeValueFromObject(dr["Ending Date"], DateTime.Now),
                EndingDateSpecified = true,
                EndDateGuarantee = CommonHelper.GetDateTimeValueFromObject(dr["End Date Guarantee"], DateTime.Now),
                EndDateGuaranteeSpecified = true,
                InvoiceReady = (CommonHelper.GetIntValueFromObject(dr["ORA Invoiced (ready)"], 0) == 1),
                InvoiceReadySpecified = true,
                ModifiedBy = CommonHelper.GetStringValueFromObject(dr["Modified by"], ""),
                CreatedBy = CommonHelper.GetStringValueFromObject(dr["Created by"], ""),
                BilltoCustomerNo = CommonHelper.GetStringValueFromObject(dr["Bill-to Customer No_"], ""),
                ContractAmount = CommonHelper.GetDecimalValueFromObject(dr["Contract Amount"], 0),
                ContractAmountSpecified = true,
                SettlementMethod = CommonHelper.GetIntValueFromObject(dr["Settlement Method"], 0),
                SettlementMethodSpecified = true,
                OrderNoCustomer = CommonHelper.GetStringValueFromObject(dr["Order No_ Customer"], ""),
                PrincipalReference = CommonHelper.GetStringValueFromObject(dr["Principal Reference"], ""),
                ContactPersonNo = CommonHelper.GetStringValueFromObject(dr["Contact Person No_"], ""),
                DeliveryAddressNote = CommonHelper.GetStringValueFromObject(dr["ORA SYM Delivery Address Note"], ""),
                PriceListCode = CommonHelper.GetStringValueFromObject(dr["ASM PL Price List Code"], ""),
                SalesDiscountTermPercent = CommonHelper.GetDecimalValueFromObject(dr["ORA Sales Discount Term Perc"], 0),
                SalesDiscountTermPercentSpecified = true,
                SalesDiscountTermGroup = CommonHelper.GetStringValueFromObject(dr["Sales Discount Term Group 1"], ""),
                ObjectCode = CommonHelper.GetIntValueFromObject(dr["Object Code"], 0),
                ObjectCodeSpecified = true,
                JobType = CommonHelper.GetIntValueFromObject(dr["Job Type"], 0),
                JobTypeSpecified = true,
                ReimbursementForm = CommonHelper.GetIntValueFromObject(dr["Reimbursement Form"], 0),
                ReimbursementFormSpecified = true,
                LastDateModified = CommonHelper.GetStringValueFromObject(dr["LastDateModified"], ""),
                LastTimeModified = CommonHelper.GetStringValueFromObject(dr["LastTimeModified"], ""),

            };

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


        private string GetProjectSQL(string strCompany)
        {

            string strFields = "  job.[No_]" +
                             ", job.[Single_Main_Sub Project]" +
                             ", job.[Main Project]" +
                             ", job.[Global Dimension 1 Code] " +
                             ", job.[Description]" +
                             ", job.[Description 2]" +
                             ", job.[Bill-to Address]" +
                             ", job.[Bill-to Address 2]" +
                             ", job.[Bill-to Post Code]" +
                             ", job.[Bill-to City]" +
                             ", job.[Project Manager]" +
                             ", job.[Project Administrator]" +
                             ", job.[Estimator]" +
                             ", job.[Project Status]" +
                             ", job.[Project Type]" +
                             ", job.[Type]" +
                             ", job.[Discipline]" +
                             ", job.[Expediter]" +
                             ", job.[Starting Date]" +
                             ", job.[Ending Date]" +
                             ", job.[End Date Guarantee]" +
                             ", job.[ORA Invoiced (ready)]" +
                             ", job.[Modified by]" +
                             ", job.[Created by]" +
                             ", job.[Bill-to Customer No_]" +
                             ", IsNull(ppr.[Contract Amount], 0) AS [Contract Amount]" +
                             ", job.[Settlement Method]" +
                             ", IsNull(ppr.[Order No_ Customer], '') AS [Order No_ Customer]" +
                             ", IsNull(ppr.[Principal Reference], '') AS [Principal Reference]" +
                             ", IsNull(ppr.[Contact Person No_], '') AS[Contact Person No_]" +
                             ", job.[ORA SYM Delivery Address Note]" +
                             ", job.[ASM PL Price List Code]" +
                             ", job.[ORA Sales Discount Term Perc]" +
                             ", job.[Sales Discount Term Group 1]" +
                             ", jex.[Object Code]" +
                             ", jex.[Job Type]" +
                             ", jex.[Reimbursement Form]" +
                             ", job.[$systemModifiedAt]" +
                             ", CONVERT(varchar(10), job.[$systemModifiedAt], 120) AS [LastDateModified]" +
                             ", CONVERT(varchar(8), job.[$systemModifiedAt], 108) AS [LastTimeModified]";



            string strSQLCommand = String.Format("SELECT {0} FROM [dbo].[{1}$Job] job ", strFields, strCompany);
            strSQLCommand += String.Format("LEFT OUTER JOIN [dbo].[{0}$Project Principal] ppr ON ppr.[Project No_] = job.[No_] AND ppr.[Bill-to Customer No_] = job.[Bill-to Customer No_] ", strCompany);
            strSQLCommand += String.Format("LEFT OUTER JOIN [dbo].[{0}$ORA Job Extension Nordic] jex ON jex.[Job No_] = job.[No_] ", strCompany);

            return strSQLCommand;
        }

        private InvoCreateAndUpdateProject Map(Project r)
        {
            if (r == null)
            {
                return null;
            }

            // TODO: Could use AutoMapper.
            return new InvoCreateAndUpdateProject()
            {
                No = r.ProjectNo,
                SingleMainSubProject = r.SingleMainSubProject ?? 0, // Or set non nullable in schema?
                MainProject = r.MainProject,
                GlobalDimension1Code = r.CostCenter, // CostCenter mapped to GlobalDimension1Code in code received from Assemblin
                Description = r.Description,
                Description2 = r.Description2,
                Address = r.Address,
                Address2 = r.Address2,
                PostCode = r.PostCode,
                City = r.City,
                ProjectManager = r.ProjectManager,
                ProjectAdministrator = r.ProjectAdministrator,
                Estimator = r.Estimator,
                ProjectStatus = r.ProjectStatus,
                ProjectType = r.ProjectType,
                Type = r.RowType,
                Discipline = r.Discipline,
                Expediter = r.Expediter,
                StartingDate = r.StartingDate != null ? (DateTime)r.StartingDate : DateTime.Now,
                EndingDate = r.EndingDate != null ? (DateTime)r.EndingDate : DateTime.Now,
                EndDateGuarantee = r.EndDateGuarantee != null ? (DateTime)r.EndDateGuarantee : DateTime.Now,
                InvoiceReady = r.InvoiceReady  ? 1: 0,
                ModifiedBy = r.ModifiedBy,
                CreatedBy = r.CreatedBy,
                BilltoCustomerNo = r.BilltoCustomerNo,
                ContractAmount = r.ContractAmount,
                SettlementMethod = r.SettlementMethod,
                OrderNoCustomer = r.OrderNoCustomer,
                PrincipalReference = r.PrincipalReference,
                ContactPersonNo = r.ContactPersonNo,
                Code = r.Code,
                Comment = r.Comment,
                DeliveryAddressNote = r.DeliveryAddressNote,
                PriceListCode = r.PriceListCode,
                SalesDiscountTermPercent = r.SalesDiscountTermPercent ?? 0,
                SalesDiscountTermGroup1 = r.SalesDiscountTermGroup,
                ObjectCode = r.ObjectCode,
                JobType = r.JobType,
                ReimbursementForm = r.ReimbursementForm,

            };
        }


        

    }
}
