using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.Entity
{

    public class CustomerContactRequest
    {
        [JsonPropertyName("customerContact")]
        public CustomerContact CustomerContact { get; set; }
    }
    public class CustomerContact
    {

        private string domainField;

        private string customerNoField;

        private string customerNameField;

        private string contactNoField;

        private string firstNameField;

        private string surnameField;

        private string phoneNoField;

        private string mobilePhoneNoField;

        private string emailField;

        private string jobTitleField;

        private string modifiedByField;

        private string lastDateModifiedField;

        private string lastTimeModifiedField;

        private System.Nullable<bool> blockedField;

        private bool blockedFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string CustomerNo
        {
            get
            {
                return this.customerNoField;
            }
            set
            {
                this.customerNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string CustomerName
        {
            get
            {
                return this.customerNameField;
            }
            set
            {
                this.customerNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ContactNo
        {
            get
            {
                return this.contactNoField;
            }
            set
            {
                this.contactNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string PhoneNo
        {
            get
            {
                return this.phoneNoField;
            }
            set
            {
                this.phoneNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string MobilePhoneNo
        {
            get
            {
                return this.mobilePhoneNoField;
            }
            set
            {
                this.mobilePhoneNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string JobTitle
        {
            get
            {
                return this.jobTitleField;
            }
            set
            {
                this.jobTitleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ModifiedBy
        {
            get
            {
                return this.modifiedByField;
            }
            set
            {
                this.modifiedByField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string LastDateModified
        {
            get
            {
                return this.lastDateModifiedField;
            }
            set
            {
                this.lastDateModifiedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string LastTimeModified
        {
            get
            {
                return this.lastTimeModifiedField;
            }
            set
            {
                this.lastTimeModifiedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<bool> Blocked
        {
            get
            {
                return this.blockedField;
            }
            set
            {
                this.blockedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BlockedSpecified
        {
            set
            {
                this.blockedFieldSpecified = value;
            }
        }
    }

    public  class CustomerContacts
    {
        [JsonPropertyName("CustomerContactListResponse")]
        public List<CustomerContact> CustomerContactListResponse
        {
            get; set;
        } = new List<CustomerContact>();
    }

    public class WrappedCreateAndUpdateCustomerContactResponse
    {
        [JsonPropertyName("createAndUpdateCustomerContactResponse")]
        public CreateAndUpdateCustomerContactResponse Response { get;set;}
    }
    public  class CreateAndUpdateCustomerContactResponse
    {

        private string contactNoField;

        private bool errorField;

        private string errorTextField;

        private string errorStatusCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ContactNo
        {
            get
            {
                return this.contactNoField;
            }
            set
            {
                this.contactNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ErrorText
        {
            get
            {
                return this.errorTextField;
            }
            set
            {
                this.errorTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ErrorStatusCode
        {
            get
            {
                return this.errorStatusCodeField;
            }
            set
            {
                this.errorStatusCodeField = value;
            }
        }
    }
}
