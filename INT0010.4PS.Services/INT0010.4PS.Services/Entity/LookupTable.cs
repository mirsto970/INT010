using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.Entity
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TableType
    {
        ObjectCode,
        JobType,
        ReimbursementForm,
        RowType,
        ProjectType,
        Discipline,
        HandyManNoteType,
        CustomerPriceList,
        DiscountTermGroup
    }

    public class LookupTable
    {
        [JsonPropertyName("LookupTableResponse")]
        public List<LookupTableRow> LookupTableResponse
        {
            get; set;
        } = new List<LookupTableRow>();
            

      
    }

    public class LookupTableRow
    {

        private string domainField;

        private string codeField;

        private string descriptionField;

        private string extraInfo1Field;

        private string extraInfo2Field;

        private string extraInfo3Field;

        private string extraInfo4Field;

        private string extraInfo5Field;

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
        public string ExtraInfo1
        {
            get
            {
                return this.extraInfo1Field == null ? "": this.extraInfo1Field;
            }
            set
            {
                this.extraInfo1Field = value;
            } 
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ExtraInfo2
        {
            get
            {
                return this.extraInfo2Field == null ? "" : this.extraInfo2Field;
            }
            set
            {
                this.extraInfo2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ExtraInfo3
        {
            get
            {
                return this.extraInfo3Field == null ? "" : this.extraInfo3Field;
            }
            set
            {
                this.extraInfo3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ExtraInfo4
        {
            get
            {
                return this.extraInfo4Field == null ? "" : this.extraInfo4Field;
            }
            set
            {
                this.extraInfo4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public string ExtraInfo5
        {
            get
            {
                return this.extraInfo5Field == null ? "" : this.extraInfo5Field;
            }
            set
            {
                this.extraInfo5Field = value;
            }
        }
    }

   
}
