using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace INT0010._4PS.Services.Entity
{
    

    public  class Project
    {

        private string domainField;

        private string projectNoField;

        private System.Nullable<int> singleMainSubProjectField;

        private bool singleMainSubProjectFieldSpecified;

        //private string mainProjectField;

        private string costCenterField;

        private string descriptionField;

        private string description2Field;

        private string addressField;

        private string address2Field;

        private string postCodeField;

        private string cityField;

        private string projectManagerField;

        private string projectAdministratorField;

        private string estimatorField;

        private int projectStatusField;

        private bool projectStatusFieldSpecified;

        private string projectTypeField;

        private string rowTypeField;

        private string disciplineField;

        private string expediterField;

        private System.Nullable<System.DateTime> startingDateField;

        private bool startingDateFieldSpecified;

        private System.Nullable<System.DateTime> endingDateField;

        private bool endingDateFieldSpecified;

        private System.Nullable<System.DateTime> endDateGuaranteeField;

        private bool endDateGuaranteeFieldSpecified;

        private bool invoiceReadyField;

        private bool invoiceReadyFieldSpecified;

        private string modifiedByField;

        private string createdByField;

        private string billtoCustomerNoField;

        private System.Nullable<decimal> contractAmountField;

        private bool contractAmountFieldSpecified;

        private System.Nullable<int> settlementMethodField;

        private bool settlementMethodFieldSpecified;

        private string orderNoCustomerField;

        private string principalReferenceField;

        private string contactPersonNoField;

        private string codeField;

        private string commentField;

        private string deliveryAddressNoteField;

        private string priceListCodeField;

        private System.Nullable<decimal> salesDiscountTermPercentField;

        private bool salesDiscountTermPercentFieldSpecified;

        private string salesDiscountTermGroupField;

        private System.Nullable<int> objectCodeField;

        private bool objectCodeFieldSpecified;

        private System.Nullable<int> jobTypeField;

        private bool jobTypeFieldSpecified;

        private System.Nullable<int> reimbursementFormField;

        private bool reimbursementFormFieldSpecified;

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
        public System.Nullable<int> SingleMainSubProject
        {
            get
            {
                return this.singleMainSubProjectField;
            }
            set
            {
                this.singleMainSubProjectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SingleMainSubProjectSpecified
        {
            get
            {
                return this.singleMainSubProjectFieldSpecified;
            }
            set
            {
                this.singleMainSubProjectFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string MainProject
        {
            get;set;
        } = String.Empty;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string CostCenter
        {
            get
            {
                return this.costCenterField;
            }
            set
            {
                this.costCenterField = value;
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
        public string Description2
        {
            get
            {
                return this.description2Field;
            }
            set
            {
                this.description2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Address2
        {
            get
            {
                return this.address2Field;
            }
            set
            {
                this.address2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string PostCode
        {
            get
            {
                return this.postCodeField;
            }
            set
            {
                this.postCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ProjectManager
        {
            get
            {
                return this.projectManagerField;
            }
            set
            {
                this.projectManagerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ProjectAdministrator
        {
            get
            {
                return this.projectAdministratorField;
            }
            set
            {
                this.projectAdministratorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Estimator
        {
            get
            {
                return this.estimatorField;
            }
            set
            {
                this.estimatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int ProjectStatus
        {
            get
            {
                return this.projectStatusField;
            }
            set
            {
                this.projectStatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProjectStatusSpecified
        {
            get
            {
                return this.projectStatusFieldSpecified;
            }
            set
            {
                this.projectStatusFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ProjectType
        {
            get
            {
                return this.projectTypeField;
            }
            set
            {
                this.projectTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string RowType
        {
            get
            {
                return this.rowTypeField;
            }
            set
            {
                this.rowTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Discipline
        {
            get
            {
                return this.disciplineField;
            }
            set
            {
                this.disciplineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Expediter
        {
            get
            {
                return this.expediterField;
            }
            set
            {
                this.expediterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<System.DateTime> StartingDate
        {
            get
            {
                return this.startingDateField;
            }
            set
            {
                this.startingDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartingDateSpecified
        {
            get
            {
                return this.startingDateFieldSpecified;
            }
            set
            {
                this.startingDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<System.DateTime> EndingDate
        {
            get
            {
                return this.endingDateField;
            }
            set
            {
                this.endingDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndingDateSpecified
        {
            get
            {
                return this.endingDateFieldSpecified;
            }
            set
            {
                this.endingDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<System.DateTime> EndDateGuarantee
        {
            get
            {
                return this.endDateGuaranteeField;
            }
            set
            {
                this.endDateGuaranteeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateGuaranteeSpecified
        {
            get
            {
                return this.endDateGuaranteeFieldSpecified;
            }
            set
            {
                this.endDateGuaranteeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool InvoiceReady
        {
            get
            {
                return this.invoiceReadyField;
            }
            set
            {
                this.invoiceReadyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InvoiceReadySpecified
        {
            get
            {
                return this.invoiceReadyFieldSpecified;
            }
            set
            {
                this.invoiceReadyFieldSpecified = value;
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
        public string CreatedBy
        {
            get
            {
                return this.createdByField;
            }
            set
            {
                this.createdByField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string BilltoCustomerNo
        {
            get
            {
                return this.billtoCustomerNoField;
            }
            set
            {
                this.billtoCustomerNoField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string OrderNoCustomer
        {
            get
            {
                return this.orderNoCustomerField;
            }
            set
            {
                this.orderNoCustomerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string PrincipalReference
        {
            get
            {
                return this.principalReferenceField;
            }
            set
            {
                this.principalReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ContactPersonNo
        {
            get
            {
                return this.contactPersonNoField;
            }
            set
            {
                this.contactPersonNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string DeliveryAddressNote
        {
            get
            {
                return this.deliveryAddressNoteField;
            }
            set
            {
                this.deliveryAddressNoteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string PriceListCode
        {
            get
            {
                return this.priceListCodeField;
            }
            set
            {
                this.priceListCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<decimal> SalesDiscountTermPercent
        {
            get
            {
                return this.salesDiscountTermPercentField;
            }
            set
            {
                this.salesDiscountTermPercentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SalesDiscountTermPercentSpecified
        {
            get
            {
                return this.salesDiscountTermPercentFieldSpecified;
            }
            set
            {
                this.salesDiscountTermPercentFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string SalesDiscountTermGroup
        {
            get
            {
                return this.salesDiscountTermGroupField;
            }
            set
            {
                this.salesDiscountTermGroupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<int> ObjectCode
        {
            get
            {
                return this.objectCodeField;
            }
            set
            {
                this.objectCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ObjectCodeSpecified
        {
            get
            {
                return this.objectCodeFieldSpecified;
            }
            set
            {
                this.objectCodeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<int> JobType
        {
            get
            {
                return this.jobTypeField;
            }
            set
            {
                this.jobTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool JobTypeSpecified
        {
            get
            {
                return this.jobTypeFieldSpecified;
            }
            set
            {
                this.jobTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public System.Nullable<int> ReimbursementForm
        {
            get
            {
                return this.reimbursementFormField;
            }
            set
            {
                this.reimbursementFormField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReimbursementFormSpecified
        {
            get
            {
                return this.reimbursementFormFieldSpecified;
            }
            set
            {
                this.reimbursementFormFieldSpecified = value;
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

   
    public class Projects
    {
        [JsonPropertyName("ProjectListResponse")]
        public List<Project> ProjectListResponse { get; set; } = new List<Project>();
    }

  
    public class CreateAndUpdateProjectRequest
    {
        public Project project{get;set;}
    }
    public class CreateAndUpdateProjectResponse
    {

        private string projectNoField;

        private bool errorField;

        private string errorTextField;

        private string errorStatusCodeField;

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

    public class WrappedCreateAndUpdateProjectResponse
    {
        [JsonPropertyName("createAndUpdateProjectResponse")]
        public CreateAndUpdateProjectResponse Response { get; set; }
    }
}
