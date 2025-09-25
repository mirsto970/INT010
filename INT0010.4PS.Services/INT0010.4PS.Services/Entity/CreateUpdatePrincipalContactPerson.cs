using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace INT0010._4PS.Services.Entity
{
	
	[XmlRoot(ElementName = "CreateUpdatePrincipalContactPerson")]
	public class ImdokCreateUpdatePrincipalContactPerson
	{

		[XmlElement(ElementName = "custNo")]
		public string CustNo;

		[XmlElement(ElementName = "contNo")]
		public string ContNo;

		[XmlElement(ElementName = "firstName")]
		public string FirstName;

		[XmlElement(ElementName = "surName")]
		public string SurName;

		[XmlElement(ElementName = "phoneNo")]
		public string PhoneNo;

		[XmlElement(ElementName = "mobilePhoneNo")]
		public string MobilePhoneNo;

		[XmlElement(ElementName = "eMail")]
		public string EMail;

		[XmlElement(ElementName = "jobTitle")]
		public string JobTitle;

		[XmlElement(ElementName = "modifiedBy")]
		public string ModifiedBy;

	}


	[XmlRoot(ElementName = "ImdokWS", Namespace = "urn:microsoft-dynamics-nav/codeunit/ImdokWS", IsNullable = false)]
	public class ImdokWS
	{

		[XmlElement(ElementName = "CreateUpdatePrincipalContactPerson")]
		public ImdokCreateUpdatePrincipalContactPerson CreateUpdatePrincipalContactPerson;

	}


}
