using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace INT0010._4PS.Services.Entity
{
	
	[XmlRoot(ElementName = "CreateAndUpdateProjectExtension")]
	public class InvoCreateAndUpdateProjectExtension
	{

		[XmlElement(ElementName = "projectNo")]
		public string ProjectNo;

		[XmlElement(ElementName = "contractNo")]
		public string ContractNo;

		[XmlElement(ElementName = "description")]
		public string Description;

		[XmlElement(ElementName = "principal")]
		public string Principal;

		[XmlElement(ElementName = "principalContact")]
		public string PrincipalContact;

		[XmlElement(ElementName = "status")]
		public int? Status;

		[XmlElement(ElementName = "contractAmount")]
		public decimal? ContractAmount;

		[XmlElement(ElementName = "offeredAmount")]
		public decimal? OfferedAmount;

		[XmlElement(ElementName = "settlementMethod")]
		public int? SettlementMethod;

		[XmlElement(ElementName = "generateInstallments")]
		public int? GenerateInstallments;

		[XmlElement(ElementName = "installmentScheme")]
		public string InstallmentScheme;

		[XmlElement(ElementName = "inputby")] // Lowercase b!
		public string InputBy;

		
	}


	[XmlRoot(ElementName = "InvoWS", Namespace = "urn:microsoft-dynamics-nav/codeunit/InvoWS", IsNullable = false)]
	public class InvoWSProjectExtension
	{

		[XmlElement(ElementName = "CreateAndUpdateProjectExtension")]
		public InvoCreateAndUpdateProjectExtension CreateAndUpdateProjectExtension;

	}


}
