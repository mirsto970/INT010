using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace INT0010._4PS.Services.Entity
{
	
	[XmlRoot(ElementName = "CreateAndUpdateProject")]
	public class InvoCreateAndUpdateProject
	{

		[XmlElement(ElementName = "no")]
		public string No;

		[XmlElement(ElementName = "singleMainSubProject")]
		public int? SingleMainSubProject;

		[XmlElement(ElementName = "mainProject")]
		public string MainProject;

		[XmlElement(ElementName = "globalDimension1Code")]
		public string GlobalDimension1Code;

		[XmlElement(ElementName = "description")]
		public string Description;

		[XmlElement(ElementName = "description2")]
		public string Description2;

		[XmlElement(ElementName = "address")]
		public string Address;

		[XmlElement(ElementName = "address2")]
		public string Address2;

		[XmlElement(ElementName = "postCode")]
		public string PostCode;

		[XmlElement(ElementName = "city")]
		public string City;

		[XmlElement(ElementName = "projectManager")]
		public string ProjectManager;

		[XmlElement(ElementName = "projectAdministrator")]
		public string ProjectAdministrator;

		[XmlElement(ElementName = "estimator")]
		public string Estimator;

		[XmlElement(ElementName = "projectStatus")]
		public int? ProjectStatus;

		[XmlElement(ElementName = "projectType")]
		public string ProjectType;

		[XmlElement(ElementName = "type")]
		public string Type;

		[XmlElement(ElementName = "discipline")]
		public string Discipline;

		[XmlElement(ElementName = "expediter")]
		public string Expediter;

		[XmlElement(ElementName = "startingDate", DataType = "date")]
		public DateTime StartingDate;

		[XmlElement(ElementName = "endingDate", DataType = "date")]
		public DateTime EndingDate;

		[XmlElement(ElementName = "endDateGuarantee", DataType = "date")]
		public DateTime EndDateGuarantee;

		[XmlElement(ElementName = "invoiceReady")]
		public int? InvoiceReady;

		[XmlElement(ElementName = "modifiedBy")]
		public string ModifiedBy;

		[XmlElement(ElementName = "createdBy")]
		public string CreatedBy;

		[XmlElement(ElementName = "billtoCustomerNo")]
		public string BilltoCustomerNo;

		[XmlElement(ElementName = "contractAmount")]
		public decimal? ContractAmount;

		[XmlElement(ElementName = "settlementMethod")]
		public int? SettlementMethod;

		[XmlElement(ElementName = "orderNoCustomer")]
		public string OrderNoCustomer;

		[XmlElement(ElementName = "principalReference")]
		public string PrincipalReference;

		[XmlElement(ElementName = "contactPersonNo")]
		public string ContactPersonNo;

		[XmlElement(ElementName = "code")]
		public string Code;

		[XmlElement(ElementName = "comment")]
		public string Comment;

		[XmlElement(ElementName = "deliveryAddressNote")]
		public string DeliveryAddressNote;

		[XmlElement(ElementName = "priceListCode")]
		public string PriceListCode;

		[XmlElement(ElementName = "salesDiscountTermPercent")]
		public decimal? SalesDiscountTermPercent;

		[XmlElement(ElementName = "salesDiscountTermGroup1")]
		public string SalesDiscountTermGroup1;

		[XmlElement(ElementName = "objectCode")]
		public int? ObjectCode;

		[XmlElement(ElementName = "jobType")]
		public int? JobType;

		[XmlElement(ElementName = "reimbursementForm")]
		public int? ReimbursementForm;
	}


	[XmlRoot(ElementName = "InvoWS", Namespace = "urn:microsoft-dynamics-nav/codeunit/InvoWS", IsNullable = false)]
	public class InvoWSProject
	{

		[XmlElement(ElementName = "CreateAndUpdateProject")]
		public InvoCreateAndUpdateProject CreateAndUpdateProject;

	}


}
