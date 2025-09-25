using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.Entity
{
    public class CreateAndUpdateContractRequest
    {
        [JsonPropertyName("extensionContract")]
        public Contract contract { get; set; }
    }
    public class Contracts
    {
        [JsonPropertyName("ExtensionProjectListResponse")]
        public List<Contract> ExtensionProjectListResponse { get; set; } = new List<Contract>();


    }
    public  class Contract
    {

        private string domainField;

        private string projectNoField;

        private string contractNoField;

        private string descriptionField;

        private string principalField;

        private string principalContactField;

        private int statusField;

        private bool statusFieldSpecified;

        private System.Nullable<decimal> contractAmountField;

        private bool contractAmountFieldSpecified;

        private System.Nullable<decimal> offeredAmountField;

        private bool offeredAmountFieldSpecified;

        private System.Nullable<int> settlementMethodField;

        private bool settlementMethodFieldSpecified;

        private bool generateInstallmentsField;

        private bool generateInstallmentsFieldSpecified;

        private string installmentSchemeField;

        private string inputByField;

        private string modifiedByField;

        private System.Nullable<System.DateTime> inputDateField;

        private bool inputDateFieldSpecified;

        private string lastDateModifiedField;

        private string lastTimeModifiedField;

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
        public string ProjectNo
        {
            get
            {
                return this.projectNoField;
            }
            set
            {
                this.projectNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ContractNo
        {
            get
            {
                return this.contractNoField;
            }
            set
            {
                this.contractNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Principal
        {
            get
            {
                return this.principalField;
            }
            set
            {
                this.principalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string PrincipalContact
        {
            get
            {
                return this.principalContactField;
            }
            set
            {
                this.principalContactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified
        {
            get
            {
                return this.statusFieldSpecified;
            }
            set
            {
                this.statusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<decimal> ContractAmount
        {
            get
            {
                return this.contractAmountField;
            }
            set
            {
                this.contractAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContractAmountSpecified
        {
            get
            {
                return this.contractAmountFieldSpecified;
            }
            set
            {
                this.contractAmountFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<decimal> OfferedAmount
        {
            get
            {
                return this.offeredAmountField;
            }
            set
            {
                this.offeredAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OfferedAmountSpecified
        {
            get
            {
                return this.offeredAmountFieldSpecified;
            }
            set
            {
                this.offeredAmountFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<int> SettlementMethod
        {
            get
            {
                return this.settlementMethodField;
            }
            set
            {
                this.settlementMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SettlementMethodSpecified
        {
            get
            {
                return this.settlementMethodFieldSpecified;
            }
            set
            {
                this.settlementMethodFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool GenerateInstallments
        {
            get
            {
                return this.generateInstallmentsField;
            }
            set
            {
                this.generateInstallmentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenerateInstallmentsSpecified
        {
            get
            {
                return this.generateInstallmentsFieldSpecified;
            }
            set
            {
                this.generateInstallmentsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string InstallmentScheme
        {
            get
            {
                return this.installmentSchemeField;
            }
            set
            {
                this.installmentSchemeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string InputBy
        {
            get
            {
                return this.inputByField;
            }
            set
            {
                this.inputByField = value;
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
        public System.Nullable<System.DateTime> InputDate
        {
            get
            {
                return this.inputDateField;
            }
            set
            {
                this.inputDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InputDateSpecified
        {
            get
            {
                return this.inputDateFieldSpecified;
            }
            set
            {
                this.inputDateFieldSpecified = value;
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
    }

    public  class CreateAndUpdateExtensionContractResponse
    {

        private string contractNoField;

        private bool errorField;

        private string errorTextField;

        private string errorStatusCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ContractNo
        {
            get
            {
                return this.contractNoField;
            }
            set
            {
                this.contractNoField = value;
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
