﻿namespace FacturaE
{
    using System.Xml.Serialization;
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae", IsNullable = false)]
    public partial class Facturae
    {

        private FileHeaderType fileHeaderField;

        private PartiesType partiesField;

        private InvoiceType[] invoicesField;

        private ExtensionsType extensionsField;

        private SignatureType signatureField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FileHeaderType FileHeader
        {
            get
            {
                return this.fileHeaderField;
            }
            set
            {
                this.fileHeaderField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PartiesType Parties
        {
            get
            {
                return this.partiesField;
            }
            set
            {
                this.partiesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Invoice", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public InvoiceType[] Invoices
        {
            get
            {
                return this.invoicesField;
            }
            set
            {
                this.invoicesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ExtensionsType Extensions
        {
            get
            {
                return this.extensionsField;
            }
            set
            {
                this.extensionsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class FileHeaderType
    {

        private SchemaVersionType schemaVersionField;

        private ModalityType modalityField;

        private InvoiceIssuerTypeType invoiceIssuerTypeField;

        private ThirdPartyType thirdPartyField;

        private BatchType batchField;

        private FactoringAssignmentDataType factoringAssignmentDataField;

        public FileHeaderType()
        {
            this.schemaVersionField = SchemaVersionType.Item31;
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SchemaVersionType SchemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ModalityType Modality
        {
            get
            {
                return this.modalityField;
            }
            set
            {
                this.modalityField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InvoiceIssuerTypeType InvoiceIssuerType
        {
            get
            {
                return this.invoiceIssuerTypeField;
            }
            set
            {
                this.invoiceIssuerTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ThirdPartyType ThirdParty
        {
            get
            {
                return this.thirdPartyField;
            }
            set
            {
                this.thirdPartyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BatchType Batch
        {
            get
            {
                return this.batchField;
            }
            set
            {
                this.batchField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FactoringAssignmentDataType FactoringAssignmentData
        {
            get
            {
                return this.factoringAssignmentDataField;
            }
            set
            {
                this.factoringAssignmentDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum SchemaVersionType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("3.1")]
        Item31,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum ModalityType
    {

        /// <comentarios/>
        I,

        /// <comentarios/>
        L,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum InvoiceIssuerTypeType
    {

        /// <comentarios/>
        EM,

        /// <comentarios/>
        RE,

        /// <comentarios/>
        TE,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class ThirdPartyType
    {

        private TaxIdentificationType taxIdentificationField;

        private object itemField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TaxIdentificationType TaxIdentification
        {
            get
            {
                return this.taxIdentificationField;
            }
            set
            {
                this.taxIdentificationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Individual", typeof(IndividualType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("LegalEntity", typeof(LegalEntityType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class TaxIdentificationType
    {

        private PersonTypeCodeType personTypeCodeField;

        private ResidenceTypeCodeType residenceTypeCodeField;

        private string taxIdentificationNumberField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PersonTypeCodeType PersonTypeCode
        {
            get
            {
                return this.personTypeCodeField;
            }
            set
            {
                this.personTypeCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ResidenceTypeCodeType ResidenceTypeCode
        {
            get
            {
                return this.residenceTypeCodeField;
            }
            set
            {
                this.residenceTypeCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TaxIdentificationNumber
        {
            get
            {
                return this.taxIdentificationNumberField;
            }
            set
            {
                this.taxIdentificationNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum PersonTypeCodeType
    {

        /// <comentarios/>
        F,

        /// <comentarios/>
        J,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum ResidenceTypeCodeType
    {

        /// <comentarios/>
        E,

        /// <comentarios/>
        R,

        /// <comentarios/>
        U,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Object", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class ObjectType
    {

        private System.Xml.XmlNode[] anyField;

        private string idField;

        private string mimeTypeField;

        private string encodingField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MimeType
        {
            get
            {
                return this.mimeTypeField;
            }
            set
            {
                this.mimeTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Encoding
        {
            get
            {
                return this.encodingField;
            }
            set
            {
                this.encodingField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SPKIData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SPKIDataType
    {

        private byte[][] sPKISexpField;

        private System.Xml.XmlElement anyField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("SPKISexp", DataType = "base64Binary")]
        public byte[][] SPKISexp
        {
            get
            {
                return this.sPKISexpField;
            }
            set
            {
                this.sPKISexpField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("PGPData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class PGPDataType
    {

        private object[] itemsField;

        private ItemsChoiceType1[] itemsElementNameField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("PGPKeyID", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlElementAttribute("PGPKeyPacket", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType1[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <comentarios/>
        PGPKeyID,

        /// <comentarios/>
        PGPKeyPacket,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class X509IssuerSerialType
    {

        private string x509IssuerNameField;

        private string x509SerialNumberField;

        /// <comentarios/>
        public string X509IssuerName
        {
            get
            {
                return this.x509IssuerNameField;
            }
            set
            {
                this.x509IssuerNameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string X509SerialNumber
        {
            get
            {
                return this.x509SerialNumberField;
            }
            set
            {
                this.x509SerialNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class X509DataType
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("X509CRL", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlElementAttribute("X509Certificate", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlElementAttribute("X509IssuerSerial", typeof(X509IssuerSerialType))]
        [System.Xml.Serialization.XmlElementAttribute("X509SKI", typeof(byte[]), DataType = "base64Binary")]
        [System.Xml.Serialization.XmlElementAttribute("X509SubjectName", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <comentarios/>
        X509CRL,

        /// <comentarios/>
        X509Certificate,

        /// <comentarios/>
        X509IssuerSerial,

        /// <comentarios/>
        X509SKI,

        /// <comentarios/>
        X509SubjectName,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("RetrievalMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class RetrievalMethodType
    {

        private TransformType[] transformsField;

        private string uRIField;

        private string typeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable = false)]
        public TransformType[] Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class TransformType
    {

        private object[] itemsField;

        private string[] textField;

        private string algorithmField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("XPath", typeof(string))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("RSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class RSAKeyValueType
    {

        private byte[] modulusField;

        private byte[] exponentField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Modulus
        {
            get
            {
                return this.modulusField;
            }
            set
            {
                this.modulusField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Exponent
        {
            get
            {
                return this.exponentField;
            }
            set
            {
                this.exponentField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("DSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class DSAKeyValueType
    {

        private byte[] pField;

        private byte[] qField;

        private byte[] gField;

        private byte[] yField;

        private byte[] jField;

        private byte[] seedField;

        private byte[] pgenCounterField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] P
        {
            get
            {
                return this.pField;
            }
            set
            {
                this.pField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Q
        {
            get
            {
                return this.qField;
            }
            set
            {
                this.qField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] G
        {
            get
            {
                return this.gField;
            }
            set
            {
                this.gField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Y
        {
            get
            {
                return this.yField;
            }
            set
            {
                this.yField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] J
        {
            get
            {
                return this.jField;
            }
            set
            {
                this.jField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Seed
        {
            get
            {
                return this.seedField;
            }
            set
            {
                this.seedField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] PgenCounter
        {
            get
            {
                return this.pgenCounterField;
            }
            set
            {
                this.pgenCounterField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("KeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class KeyValueType
    {

        private object itemField;

        private string[] textField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("DSAKeyValue", typeof(DSAKeyValueType))]
        [System.Xml.Serialization.XmlElementAttribute("RSAKeyValue", typeof(RSAKeyValueType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class KeyInfoType
    {

        private object[] itemsField;

        private ItemsChoiceType2[] itemsElementNameField;

        private string[] textField;

        private string idField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("KeyName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("KeyValue", typeof(KeyValueType))]
        [System.Xml.Serialization.XmlElementAttribute("MgmtData", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("PGPData", typeof(PGPDataType))]
        [System.Xml.Serialization.XmlElementAttribute("RetrievalMethod", typeof(RetrievalMethodType))]
        [System.Xml.Serialization.XmlElementAttribute("SPKIData", typeof(SPKIDataType))]
        [System.Xml.Serialization.XmlElementAttribute("X509Data", typeof(X509DataType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType2[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("##any:")]
        Item,

        /// <comentarios/>
        KeyName,

        /// <comentarios/>
        KeyValue,

        /// <comentarios/>
        MgmtData,

        /// <comentarios/>
        PGPData,

        /// <comentarios/>
        RetrievalMethod,

        /// <comentarios/>
        SPKIData,

        /// <comentarios/>
        X509Data,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignatureValueType
    {

        private string idField;

        private byte[] valueField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class DigestMethodType
    {

        private System.Xml.XmlNode[] anyField;

        private string algorithmField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class ReferenceType
    {

        private TransformType[] transformsField;

        private DigestMethodType digestMethodField;

        private byte[] digestValueField;

        private string idField;

        private string uRIField;

        private string typeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable = false)]
        public TransformType[] Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        /// <comentarios/>
        public DigestMethodType DigestMethod
        {
            get
            {
                return this.digestMethodField;
            }
            set
            {
                this.digestMethodField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] DigestValue
        {
            get
            {
                return this.digestValueField;
            }
            set
            {
                this.digestValueField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignatureMethodType
    {

        private string hMACOutputLengthField;

        private System.Xml.XmlNode[] anyField;

        private string algorithmField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string HMACOutputLength
        {
            get
            {
                return this.hMACOutputLengthField;
            }
            set
            {
                this.hMACOutputLengthField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class CanonicalizationMethodType
    {

        private System.Xml.XmlNode[] anyField;

        private string algorithmField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignedInfoType
    {

        private CanonicalizationMethodType canonicalizationMethodField;

        private SignatureMethodType signatureMethodField;

        private ReferenceType[] referenceField;

        private string idField;

        /// <comentarios/>
        public CanonicalizationMethodType CanonicalizationMethod
        {
            get
            {
                return this.canonicalizationMethodField;
            }
            set
            {
                this.canonicalizationMethodField = value;
            }
        }

        /// <comentarios/>
        public SignatureMethodType SignatureMethod
        {
            get
            {
                return this.signatureMethodField;
            }
            set
            {
                this.signatureMethodField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Reference")]
        public ReferenceType[] Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignatureType
    {

        private SignedInfoType signedInfoField;

        private SignatureValueType signatureValueField;

        private KeyInfoType keyInfoField;

        private ObjectType[] objectField;

        private string idField;

        /// <comentarios/>
        public SignedInfoType SignedInfo
        {
            get
            {
                return this.signedInfoField;
            }
            set
            {
                this.signedInfoField = value;
            }
        }

        /// <comentarios/>
        public SignatureValueType SignatureValue
        {
            get
            {
                return this.signatureValueField;
            }
            set
            {
                this.signatureValueField = value;
            }
        }

        /// <comentarios/>
        public KeyInfoType KeyInfo
        {
            get
            {
                return this.keyInfoField;
            }
            set
            {
                this.keyInfoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Object")]
        public ObjectType[] Object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class AttachmentType
    {

        private AttachmentCompressionAlgorithmType attachmentCompressionAlgorithmField;

        private bool attachmentCompressionAlgorithmFieldSpecified;

        private AttachmentFormatType attachmentFormatField;

        private AttachmentEncodingType attachmentEncodingField;

        private bool attachmentEncodingFieldSpecified;

        private string attachmentDescriptionField;

        private string attachmentDataField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AttachmentCompressionAlgorithmType AttachmentCompressionAlgorithm
        {
            get
            {
                return this.attachmentCompressionAlgorithmField;
            }
            set
            {
                this.attachmentCompressionAlgorithmField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AttachmentCompressionAlgorithmSpecified
        {
            get
            {
                return this.attachmentCompressionAlgorithmFieldSpecified;
            }
            set
            {
                this.attachmentCompressionAlgorithmFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AttachmentFormatType AttachmentFormat
        {
            get
            {
                return this.attachmentFormatField;
            }
            set
            {
                this.attachmentFormatField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AttachmentEncodingType AttachmentEncoding
        {
            get
            {
                return this.attachmentEncodingField;
            }
            set
            {
                this.attachmentEncodingField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AttachmentEncodingSpecified
        {
            get
            {
                return this.attachmentEncodingFieldSpecified;
            }
            set
            {
                this.attachmentEncodingFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AttachmentDescription
        {
            get
            {
                return this.attachmentDescriptionField;
            }
            set
            {
                this.attachmentDescriptionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AttachmentData
        {
            get
            {
                return this.attachmentDataField;
            }
            set
            {
                this.attachmentDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum AttachmentCompressionAlgorithmType
    {

        /// <comentarios/>
        ZIP,

        /// <comentarios/>
        GZIP,

        /// <comentarios/>
        NONE,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum AttachmentFormatType
    {

        /// <comentarios/>
        xml,

        /// <comentarios/>
        doc,

        /// <comentarios/>
        gif,

        /// <comentarios/>
        rtf,

        /// <comentarios/>
        pdf,

        /// <comentarios/>
        xls,

        /// <comentarios/>
        jpg,

        /// <comentarios/>
        bmp,

        /// <comentarios/>
        tiff,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum AttachmentEncodingType
    {

        /// <comentarios/>
        BASE64,

        /// <comentarios/>
        BER,

        /// <comentarios/>
        DER,

        /// <comentarios/>
        NONE,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class AdditionalDataType
    {

        private string relatedInvoiceField;

        private AttachmentType[] relatedDocumentsField;

        private string invoiceAdditionalInformationField;

        private ExtensionsType extensionsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RelatedInvoice
        {
            get
            {
                return this.relatedInvoiceField;
            }
            set
            {
                this.relatedInvoiceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Attachment", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public AttachmentType[] RelatedDocuments
        {
            get
            {
                return this.relatedDocumentsField;
            }
            set
            {
                this.relatedDocumentsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InvoiceAdditionalInformation
        {
            get
            {
                return this.invoiceAdditionalInformationField;
            }
            set
            {
                this.invoiceAdditionalInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ExtensionsType Extensions
        {
            get
            {
                return this.extensionsField;
            }
            set
            {
                this.extensionsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class ExtensionsType
    {

        private System.Xml.XmlElement[] anyField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class AccountType
    {

        private string iBANField;

        private string bankCodeField;

        private string branchCodeField;

        private object itemField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IBAN
        {
            get
            {
                return this.iBANField;
            }
            set
            {
                this.iBANField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BankCode
        {
            get
            {
                return this.bankCodeField;
            }
            set
            {
                this.bankCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BranchCode
        {
            get
            {
                return this.branchCodeField;
            }
            set
            {
                this.branchCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("BranchInSpainAddress", typeof(AddressType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("OverseasBranchAddress", typeof(OverseasAddressType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class AddressType
    {

        private string addressField;

        private string postCodeField;

        private string townField;

        private string provinceField;

        private CountryType countryCodeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Town
        {
            get
            {
                return this.townField;
            }
            set
            {
                this.townField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Province
        {
            get
            {
                return this.provinceField;
            }
            set
            {
                this.provinceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CountryType CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum CountryType
    {

        /// <comentarios/>
        AFG,

        /// <comentarios/>
        ALB,

        /// <comentarios/>
        DZA,

        /// <comentarios/>
        ASM,

        /// <comentarios/>
        AND,

        /// <comentarios/>
        AGO,

        /// <comentarios/>
        AIA,

        /// <comentarios/>
        ATG,

        /// <comentarios/>
        ARG,

        /// <comentarios/>
        ARM,

        /// <comentarios/>
        ABW,

        /// <comentarios/>
        AUS,

        /// <comentarios/>
        AUT,

        /// <comentarios/>
        AZE,

        /// <comentarios/>
        BHS,

        /// <comentarios/>
        BHR,

        /// <comentarios/>
        BGD,

        /// <comentarios/>
        BRB,

        /// <comentarios/>
        BLR,

        /// <comentarios/>
        BEL,

        /// <comentarios/>
        BLZ,

        /// <comentarios/>
        BEN,

        /// <comentarios/>
        BMU,

        /// <comentarios/>
        BTN,

        /// <comentarios/>
        BOL,

        /// <comentarios/>
        BIH,

        /// <comentarios/>
        BWA,

        /// <comentarios/>
        BRA,

        /// <comentarios/>
        BRN,

        /// <comentarios/>
        BGR,

        /// <comentarios/>
        BFA,

        /// <comentarios/>
        BDI,

        /// <comentarios/>
        KHM,

        /// <comentarios/>
        CMR,

        /// <comentarios/>
        CAN,

        /// <comentarios/>
        CPV,

        /// <comentarios/>
        CYM,

        /// <comentarios/>
        CAF,

        /// <comentarios/>
        TCD,

        /// <comentarios/>
        CHL,

        /// <comentarios/>
        CHN,

        /// <comentarios/>
        COD,

        /// <comentarios/>
        COL,

        /// <comentarios/>
        COM,

        /// <comentarios/>
        COG,

        /// <comentarios/>
        COK,

        /// <comentarios/>
        CRI,

        /// <comentarios/>
        CIV,

        /// <comentarios/>
        HRV,

        /// <comentarios/>
        CUB,

        /// <comentarios/>
        CYP,

        /// <comentarios/>
        CZE,

        /// <comentarios/>
        DNK,

        /// <comentarios/>
        DJI,

        /// <comentarios/>
        DMA,

        /// <comentarios/>
        DOM,

        /// <comentarios/>
        ECU,

        /// <comentarios/>
        EGY,

        /// <comentarios/>
        SLV,

        /// <comentarios/>
        GNQ,

        /// <comentarios/>
        ERI,

        /// <comentarios/>
        EST,

        /// <comentarios/>
        ETH,

        /// <comentarios/>
        FLK,

        /// <comentarios/>
        FRO,

        /// <comentarios/>
        FJI,

        /// <comentarios/>
        FIN,

        /// <comentarios/>
        FRA,

        /// <comentarios/>
        GUF,

        /// <comentarios/>
        PYF,

        /// <comentarios/>
        GAB,

        /// <comentarios/>
        GMB,

        /// <comentarios/>
        GEO,

        /// <comentarios/>
        GGY,

        /// <comentarios/>
        DEU,

        /// <comentarios/>
        GHA,

        /// <comentarios/>
        GIB,

        /// <comentarios/>
        GRC,

        /// <comentarios/>
        GRL,

        /// <comentarios/>
        GRD,

        /// <comentarios/>
        GLP,

        /// <comentarios/>
        GUM,

        /// <comentarios/>
        GTM,

        /// <comentarios/>
        GIN,

        /// <comentarios/>
        GNB,

        /// <comentarios/>
        GUY,

        /// <comentarios/>
        HTI,

        /// <comentarios/>
        HND,

        /// <comentarios/>
        HKG,

        /// <comentarios/>
        HUN,

        /// <comentarios/>
        ISL,

        /// <comentarios/>
        IND,

        /// <comentarios/>
        IDN,

        /// <comentarios/>
        IMN,

        /// <comentarios/>
        IRN,

        /// <comentarios/>
        IRQ,

        /// <comentarios/>
        IRL,

        /// <comentarios/>
        ISR,

        /// <comentarios/>
        ITA,

        /// <comentarios/>
        JAM,

        /// <comentarios/>
        JEY,

        /// <comentarios/>
        JPN,

        /// <comentarios/>
        JOR,

        /// <comentarios/>
        KAZ,

        /// <comentarios/>
        KEN,

        /// <comentarios/>
        KIR,

        /// <comentarios/>
        PRK,

        /// <comentarios/>
        KOR,

        /// <comentarios/>
        KWT,

        /// <comentarios/>
        KGZ,

        /// <comentarios/>
        LAO,

        /// <comentarios/>
        LVA,

        /// <comentarios/>
        LBN,

        /// <comentarios/>
        LSO,

        /// <comentarios/>
        LBR,

        /// <comentarios/>
        LBY,

        /// <comentarios/>
        LIE,

        /// <comentarios/>
        LTU,

        /// <comentarios/>
        LUX,

        /// <comentarios/>
        MAC,

        /// <comentarios/>
        MKD,

        /// <comentarios/>
        MDG,

        /// <comentarios/>
        MWI,

        /// <comentarios/>
        MYS,

        /// <comentarios/>
        MDV,

        /// <comentarios/>
        MLI,

        /// <comentarios/>
        MLT,

        /// <comentarios/>
        MHL,

        /// <comentarios/>
        MTQ,

        /// <comentarios/>
        MRT,

        /// <comentarios/>
        MUS,

        /// <comentarios/>
        MYT,

        /// <comentarios/>
        MEX,

        /// <comentarios/>
        FSM,

        /// <comentarios/>
        MDA,

        /// <comentarios/>
        MCO,

        /// <comentarios/>
        MNE,

        /// <comentarios/>
        MNG,

        /// <comentarios/>
        MSR,

        /// <comentarios/>
        MAR,

        /// <comentarios/>
        MOZ,

        /// <comentarios/>
        MMR,

        /// <comentarios/>
        NAM,

        /// <comentarios/>
        NRU,

        /// <comentarios/>
        NPL,

        /// <comentarios/>
        NLD,

        /// <comentarios/>
        ANT,

        /// <comentarios/>
        NCL,

        /// <comentarios/>
        NZL,

        /// <comentarios/>
        NIC,

        /// <comentarios/>
        NER,

        /// <comentarios/>
        NGA,

        /// <comentarios/>
        NIU,

        /// <comentarios/>
        NFK,

        /// <comentarios/>
        MNP,

        /// <comentarios/>
        NOR,

        /// <comentarios/>
        OMN,

        /// <comentarios/>
        PAK,

        /// <comentarios/>
        PLW,

        /// <comentarios/>
        PAN,

        /// <comentarios/>
        PNG,

        /// <comentarios/>
        PRY,

        /// <comentarios/>
        PSE,

        /// <comentarios/>
        PER,

        /// <comentarios/>
        PHL,

        /// <comentarios/>
        PCN,

        /// <comentarios/>
        POL,

        /// <comentarios/>
        PRT,

        /// <comentarios/>
        PRI,

        /// <comentarios/>
        QAT,

        /// <comentarios/>
        REU,

        /// <comentarios/>
        ROU,

        /// <comentarios/>
        RUS,

        /// <comentarios/>
        RWA,

        /// <comentarios/>
        KNA,

        /// <comentarios/>
        LCA,

        /// <comentarios/>
        VCT,

        /// <comentarios/>
        WSM,

        /// <comentarios/>
        SMR,

        /// <comentarios/>
        STP,

        /// <comentarios/>
        SAU,

        /// <comentarios/>
        SEN,

        /// <comentarios/>
        SRB,

        /// <comentarios/>
        SYC,

        /// <comentarios/>
        SLE,

        /// <comentarios/>
        SGP,

        /// <comentarios/>
        SVK,

        /// <comentarios/>
        SVN,

        /// <comentarios/>
        SLB,

        /// <comentarios/>
        SOM,

        /// <comentarios/>
        ZAF,

        /// <comentarios/>
        ESP,

        /// <comentarios/>
        LKA,

        /// <comentarios/>
        SHN,

        /// <comentarios/>
        SPM,

        /// <comentarios/>
        SDN,

        /// <comentarios/>
        SUR,

        /// <comentarios/>
        SJM,

        /// <comentarios/>
        SWZ,

        /// <comentarios/>
        SWE,

        /// <comentarios/>
        CHE,

        /// <comentarios/>
        SYR,

        /// <comentarios/>
        TWN,

        /// <comentarios/>
        TJK,

        /// <comentarios/>
        TZA,

        /// <comentarios/>
        THA,

        /// <comentarios/>
        TGO,

        /// <comentarios/>
        TKL,

        /// <comentarios/>
        TON,

        /// <comentarios/>
        TTO,

        /// <comentarios/>
        TUN,

        /// <comentarios/>
        TUR,

        /// <comentarios/>
        TKM,

        /// <comentarios/>
        TLS,

        /// <comentarios/>
        TCA,

        /// <comentarios/>
        TUV,

        /// <comentarios/>
        UGA,

        /// <comentarios/>
        UKR,

        /// <comentarios/>
        ARE,

        /// <comentarios/>
        GBR,

        /// <comentarios/>
        USA,

        /// <comentarios/>
        URY,

        /// <comentarios/>
        UZB,

        /// <comentarios/>
        VUT,

        /// <comentarios/>
        VAT,

        /// <comentarios/>
        VEN,

        /// <comentarios/>
        VNM,

        /// <comentarios/>
        VGB,

        /// <comentarios/>
        VIR,

        /// <comentarios/>
        WLF,

        /// <comentarios/>
        ESH,

        /// <comentarios/>
        YEM,

        /// <comentarios/>
        ZAR,

        /// <comentarios/>
        ZMB,

        /// <comentarios/>
        ZWE,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class OverseasAddressType
    {

        private string addressField;

        private string postCodeAndTownField;

        private string provinceField;

        private CountryType countryCodeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PostCodeAndTown
        {
            get
            {
                return this.postCodeAndTownField;
            }
            set
            {
                this.postCodeAndTownField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Province
        {
            get
            {
                return this.provinceField;
            }
            set
            {
                this.provinceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CountryType CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class InstallmentType
    {

        private System.DateTime installmentDueDateField;

        private double installmentAmountField;

        private PaymentMeansType paymentMeansField;

        private AccountType accountToBeCreditedField;

        private string paymentReconciliationReferenceField;

        private AccountType accountToBeDebitedField;

        private string collectionAdditionalInformationField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime InstallmentDueDate
        {
            get
            {
                return this.installmentDueDateField;
            }
            set
            {
                this.installmentDueDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType InstallmentAmount
        {
            get
            {
                return this.installmentAmountField;
            }
            set
            {
                this.installmentAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PaymentMeansType PaymentMeans
        {
            get
            {
                return this.paymentMeansField;
            }
            set
            {
                this.paymentMeansField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AccountType AccountToBeCredited
        {
            get
            {
                return this.accountToBeCreditedField;
            }
            set
            {
                this.accountToBeCreditedField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PaymentReconciliationReference
        {
            get
            {
                return this.paymentReconciliationReferenceField;
            }
            set
            {
                this.paymentReconciliationReferenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AccountType AccountToBeDebited
        {
            get
            {
                return this.accountToBeDebitedField;
            }
            set
            {
                this.accountToBeDebitedField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CollectionAdditionalInformation
        {
            get
            {
                return this.collectionAdditionalInformationField;
            }
            set
            {
                this.collectionAdditionalInformationField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum PaymentMeansType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("17")]
        Item17,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("18")]
        Item18,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("19")]
        Item19,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class DeliveryNoteType
    {

        private string deliveryNoteNumberField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DeliveryNoteNumber
        {
            get
            {
                return this.deliveryNoteNumberField;
            }
            set
            {
                this.deliveryNoteNumberField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class InvoiceLineType
    {

        private string issuerContractReferenceField;

        private string issuerTransactionReferenceField;

        private string receiverContractReferenceField;

        private string receiverTransactionReferenceField;

        private double purchaseOrderReferenceField;

        private bool purchaseOrderReferenceFieldSpecified;

        private DeliveryNoteType[] deliveryNotesReferencesField;

        private string itemDescriptionField;

        private double quantityField;

        private UnitOfMeasureType unitOfMeasureField;

        private bool unitOfMeasureFieldSpecified;

        private double unitPriceWithoutTaxField;

        private double totalCostField;

        private DiscountType[] discountsAndRebatesField;

        private ChargeType[] chargesField;

        private double grossAmountField;

        private TaxType[] taxesWithheldField;

        private InvoiceLineTypeTax[] taxesOutputsField;

        private PeriodDates lineItemPeriodField;

        private System.DateTime transactionDateField;

        private bool transactionDateFieldSpecified;

        private string additionalLineItemInformationField;

        private ExtensionsType extensionsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IssuerContractReference
        {
            get
            {
                return this.issuerContractReferenceField;
            }
            set
            {
                this.issuerContractReferenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IssuerTransactionReference
        {
            get
            {
                return this.issuerTransactionReferenceField;
            }
            set
            {
                this.issuerTransactionReferenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ReceiverContractReference
        {
            get
            {
                return this.receiverContractReferenceField;
            }
            set
            {
                this.receiverContractReferenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ReceiverTransactionReference
        {
            get
            {
                return this.receiverTransactionReferenceField;
            }
            set
            {
                this.receiverTransactionReferenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double PurchaseOrderReference
        {
            get
            {
                return this.purchaseOrderReferenceField;
            }
            set
            {
                this.purchaseOrderReferenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PurchaseOrderReferenceSpecified
        {
            get
            {
                return this.purchaseOrderReferenceFieldSpecified;
            }
            set
            {
                this.purchaseOrderReferenceFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("DeliveryNote", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public DeliveryNoteType[] DeliveryNotesReferences
        {
            get
            {
                return this.deliveryNotesReferencesField;
            }
            set
            {
                this.deliveryNotesReferencesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ItemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UnitOfMeasureType UnitOfMeasure
        {
            get
            {
                return this.unitOfMeasureField;
            }
            set
            {
                this.unitOfMeasureField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UnitOfMeasureSpecified
        {
            get
            {
                return this.unitOfMeasureFieldSpecified;
            }
            set
            {
                this.unitOfMeasureFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleSixDecimalType UnitPriceWithoutTax
        {
            get
            {
                return this.unitPriceWithoutTaxField;
            }
            set
            {
                this.unitPriceWithoutTaxField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalCost
        {
            get
            {
                return this.totalCostField;
            }
            set
            {
                this.totalCostField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Discount", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public DiscountType[] DiscountsAndRebates
        {
            get
            {
                return this.discountsAndRebatesField;
            }
            set
            {
                this.discountsAndRebatesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Charge", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public ChargeType[] Charges
        {
            get
            {
                return this.chargesField;
            }
            set
            {
                this.chargesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType GrossAmount
        {
            get
            {
                return this.grossAmountField;
            }
            set
            {
                this.grossAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Tax", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public TaxType[] TaxesWithheld
        {
            get
            {
                return this.taxesWithheldField;
            }
            set
            {
                this.taxesWithheldField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Tax", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public InvoiceLineTypeTax[] TaxesOutputs
        {
            get
            {
                return this.taxesOutputsField;
            }
            set
            {
                this.taxesOutputsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PeriodDates LineItemPeriod
        {
            get
            {
                return this.lineItemPeriodField;
            }
            set
            {
                this.lineItemPeriodField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime TransactionDate
        {
            get
            {
                return this.transactionDateField;
            }
            set
            {
                this.transactionDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TransactionDateSpecified
        {
            get
            {
                return this.transactionDateFieldSpecified;
            }
            set
            {
                this.transactionDateFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AdditionalLineItemInformation
        {
            get
            {
                return this.additionalLineItemInformationField;
            }
            set
            {
                this.additionalLineItemInformationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ExtensionsType Extensions
        {
            get
            {
                return this.extensionsField;
            }
            set
            {
                this.extensionsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum UnitOfMeasureType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("17")]
        Item17,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("18")]
        Item18,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("19")]
        Item19,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("20")]
        Item20,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("21")]
        Item21,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("22")]
        Item22,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("23")]
        Item23,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("24")]
        Item24,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("25")]
        Item25,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("26")]
        Item26,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("27")]
        Item27,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("28")]
        Item28,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("29")]
        Item29,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("30")]
        Item30,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("31")]
        Item31,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("32")]
        Item32,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class DiscountType
    {

        private string discountReasonField;

        private double discountRateField;

        private bool discountRateFieldSpecified;

        private double discountAmountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DiscountReason
        {
            get
            {
                return this.discountReasonField;
            }
            set
            {
                this.discountReasonField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleFourDecimalType DiscountRate
        {
            get
            {
                return this.discountRateField;
            }
            set
            {
                this.discountRateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DiscountRateSpecified
        {
            get
            {
                return this.discountRateFieldSpecified;
            }
            set
            {
                this.discountRateFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType DiscountAmount
        {
            get
            {
                return this.discountAmountField;
            }
            set
            {
                this.discountAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class ChargeType
    {

        private string chargeReasonField;

        private double chargeRateField;

        private bool chargeRateFieldSpecified;

        private double chargeAmountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ChargeReason
        {
            get
            {
                return this.chargeReasonField;
            }
            set
            {
                this.chargeReasonField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleFourDecimalType ChargeRate
        {
            get
            {
                return this.chargeRateField;
            }
            set
            {
                this.chargeRateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChargeRateSpecified
        {
            get
            {
                return this.chargeRateFieldSpecified;
            }
            set
            {
                this.chargeRateFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType ChargeAmount
        {
            get
            {
                return this.chargeAmountField;
            }
            set
            {
                this.chargeAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class TaxType
    {

        private TaxTypeCodeType taxTypeCodeField;

        private double taxRateField;

        private AmountType taxableBaseField;

        private AmountType taxAmountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TaxTypeCodeType TaxTypeCode
        {
            get
            {
                return this.taxTypeCodeField;
            }
            set
            {
                this.taxTypeCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TaxRate
        {
            get
            {
                return this.taxRateField;
            }
            set
            {
                this.taxRateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType TaxableBase
        {
            get
            {
                return this.taxableBaseField;
            }
            set
            {
                this.taxableBaseField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType TaxAmount
        {
            get
            {
                return this.taxAmountField;
            }
            set
            {
                this.taxAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum TaxTypeCodeType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class AmountType
    {

        private double totalAmountField;

        private double equivalentInEurosField;

        private bool equivalentInEurosFieldSpecified;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalAmount
        {
            get
            {
                return this.totalAmountField;
            }
            set
            {
                this.totalAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType EquivalentInEuros
        {
            get
            {
                return this.equivalentInEurosField;
            }
            set
            {
                this.equivalentInEurosField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EquivalentInEurosSpecified
        {
            get
            {
                return this.equivalentInEurosFieldSpecified;
            }
            set
            {
                this.equivalentInEurosFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class InvoiceLineTypeTax : TaxOutputType
    {
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class TaxOutputType
    {

        private TaxTypeCodeType taxTypeCodeField;

        private double taxRateField;

        private AmountType taxableBaseField;

        private AmountType taxAmountField;

        private AmountType specialTaxableBaseField;

        private AmountType specialTaxAmountField;

        private double equivalenceSurchargeField;

        private bool equivalenceSurchargeFieldSpecified;

        private AmountType equivalenceSurchargeAmountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TaxTypeCodeType TaxTypeCode
        {
            get
            {
                return this.taxTypeCodeField;
            }
            set
            {
                this.taxTypeCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TaxRate
        {
            get
            {
                return this.taxRateField;
            }
            set
            {
                this.taxRateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType TaxableBase
        {
            get
            {
                return this.taxableBaseField;
            }
            set
            {
                this.taxableBaseField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType TaxAmount
        {
            get
            {
                return this.taxAmountField;
            }
            set
            {
                this.taxAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType SpecialTaxableBase
        {
            get
            {
                return this.specialTaxableBaseField;
            }
            set
            {
                this.specialTaxableBaseField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType SpecialTaxAmount
        {
            get
            {
                return this.specialTaxAmountField;
            }
            set
            {
                this.specialTaxAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType EquivalenceSurcharge
        {
            get
            {
                return this.equivalenceSurchargeField;
            }
            set
            {
                this.equivalenceSurchargeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EquivalenceSurchargeSpecified
        {
            get
            {
                return this.equivalenceSurchargeFieldSpecified;
            }
            set
            {
                this.equivalenceSurchargeFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType EquivalenceSurchargeAmount
        {
            get
            {
                return this.equivalenceSurchargeAmountField;
            }
            set
            {
                this.equivalenceSurchargeAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class PeriodDates
    {

        private System.DateTime startDateField;

        private System.DateTime endDateField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime EndDate
        {
            get
            {
                return this.endDateField;
            }
            set
            {
                this.endDateField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class AmountsWithheldType
    {

        private string withholdingReasonField;

        private double withholdingRateField;

        private bool withholdingRateFieldSpecified;

        private double withholdingAmountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WithholdingReason
        {
            get
            {
                return this.withholdingReasonField;
            }
            set
            {
                this.withholdingReasonField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleFourDecimalType WithholdingRate
        {
            get
            {
                return this.withholdingRateField;
            }
            set
            {
                this.withholdingRateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WithholdingRateSpecified
        {
            get
            {
                return this.withholdingRateFieldSpecified;
            }
            set
            {
                this.withholdingRateFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType WithholdingAmount
        {
            get
            {
                return this.withholdingAmountField;
            }
            set
            {
                this.withholdingAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class ReimbursableExpensesType
    {

        private TaxIdentificationType reimbursableExpensesSellerPartyField;

        private TaxIdentificationType reimbursableExpensesBuyerPartyField;

        private System.DateTime issueDateField;

        private bool issueDateFieldSpecified;

        private string invoiceNumberField;

        private string invoiceSeriesCodeField;

        private double reimbursableExpensesAmountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TaxIdentificationType ReimbursableExpensesSellerParty
        {
            get
            {
                return this.reimbursableExpensesSellerPartyField;
            }
            set
            {
                this.reimbursableExpensesSellerPartyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TaxIdentificationType ReimbursableExpensesBuyerParty
        {
            get
            {
                return this.reimbursableExpensesBuyerPartyField;
            }
            set
            {
                this.reimbursableExpensesBuyerPartyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime IssueDate
        {
            get
            {
                return this.issueDateField;
            }
            set
            {
                this.issueDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IssueDateSpecified
        {
            get
            {
                return this.issueDateFieldSpecified;
            }
            set
            {
                this.issueDateFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InvoiceNumber
        {
            get
            {
                return this.invoiceNumberField;
            }
            set
            {
                this.invoiceNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InvoiceSeriesCode
        {
            get
            {
                return this.invoiceSeriesCodeField;
            }
            set
            {
                this.invoiceSeriesCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType ReimbursableExpensesAmount
        {
            get
            {
                return this.reimbursableExpensesAmountField;
            }
            set
            {
                this.reimbursableExpensesAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class PaymentOnAccountType
    {

        private System.DateTime paymentOnAccountDateField;

        private double paymentOnAccountAmountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime PaymentOnAccountDate
        {
            get
            {
                return this.paymentOnAccountDateField;
            }
            set
            {
                this.paymentOnAccountDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType PaymentOnAccountAmount
        {
            get
            {
                return this.paymentOnAccountAmountField;
            }
            set
            {
                this.paymentOnAccountAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class SubsidyType
    {

        private string subsidyDescriptionField;

        private double subsidyRateField;

        private bool subsidyRateFieldSpecified;

        private double subsidyAmountField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SubsidyDescription
        {
            get
            {
                return this.subsidyDescriptionField;
            }
            set
            {
                this.subsidyDescriptionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleFourDecimalType SubsidyRate
        {
            get
            {
                return this.subsidyRateField;
            }
            set
            {
                this.subsidyRateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubsidyRateSpecified
        {
            get
            {
                return this.subsidyRateFieldSpecified;
            }
            set
            {
                this.subsidyRateFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType SubsidyAmount
        {
            get
            {
                return this.subsidyAmountField;
            }
            set
            {
                this.subsidyAmountField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class InvoiceTotalsType
    {

        private double totalGrossAmountField;

        private DiscountType[] generalDiscountsField;

        private ChargeType[] generalSurchargesField;

        private double totalGeneralDiscountsField;

        private bool totalGeneralDiscountsFieldSpecified;

        private double totalGeneralSurchargesField;

        private bool totalGeneralSurchargesFieldSpecified;

        private double totalGrossAmountBeforeTaxesField;

        private double totalTaxOutputsField;

        private double totalTaxesWithheldField;

        private double invoiceTotalField;

        private SubsidyType[] subsidiesField;

        private PaymentOnAccountType[] paymentsOnAccountField;

        private ReimbursableExpensesType[] reimbursableExpensesField;

        private double totalFinancialExpensesField;

        private bool totalFinancialExpensesFieldSpecified;

        private double totalOutstandingAmountField;

        private double totalPaymentsOnAccountField;

        private bool totalPaymentsOnAccountFieldSpecified;

        private AmountsWithheldType amountsWithheldField;

        private double totalExecutableAmountField;

        private double totalReimbursableExpensesField;

        private bool totalReimbursableExpensesFieldSpecified;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalGrossAmount
        {
            get
            {
                return this.totalGrossAmountField;
            }
            set
            {
                this.totalGrossAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Discount", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public DiscountType[] GeneralDiscounts
        {
            get
            {
                return this.generalDiscountsField;
            }
            set
            {
                this.generalDiscountsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Charge", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public ChargeType[] GeneralSurcharges
        {
            get
            {
                return this.generalSurchargesField;
            }
            set
            {
                this.generalSurchargesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalGeneralDiscounts
        {
            get
            {
                return this.totalGeneralDiscountsField;
            }
            set
            {
                this.totalGeneralDiscountsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalGeneralDiscountsSpecified
        {
            get
            {
                return this.totalGeneralDiscountsFieldSpecified;
            }
            set
            {
                this.totalGeneralDiscountsFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalGeneralSurcharges
        {
            get
            {
                return this.totalGeneralSurchargesField;
            }
            set
            {
                this.totalGeneralSurchargesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalGeneralSurchargesSpecified
        {
            get
            {
                return this.totalGeneralSurchargesFieldSpecified;
            }
            set
            {
                this.totalGeneralSurchargesFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalGrossAmountBeforeTaxes
        {
            get
            {
                return this.totalGrossAmountBeforeTaxesField;
            }
            set
            {
                this.totalGrossAmountBeforeTaxesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalTaxOutputs
        {
            get
            {
                return this.totalTaxOutputsField;
            }
            set
            {
                this.totalTaxOutputsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalTaxesWithheld
        {
            get
            {
                return this.totalTaxesWithheldField;
            }
            set
            {
                this.totalTaxesWithheldField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType InvoiceTotal
        {
            get
            {
                return this.invoiceTotalField;
            }
            set
            {
                this.invoiceTotalField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Subsidy", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public SubsidyType[] Subsidies
        {
            get
            {
                return this.subsidiesField;
            }
            set
            {
                this.subsidiesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PaymentOnAccount", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public PaymentOnAccountType[] PaymentsOnAccount
        {
            get
            {
                return this.paymentsOnAccountField;
            }
            set
            {
                this.paymentsOnAccountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReimbursableExpenses", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public ReimbursableExpensesType[] ReimbursableExpenses
        {
            get
            {
                return this.reimbursableExpensesField;
            }
            set
            {
                this.reimbursableExpensesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalFinancialExpenses
        {
            get
            {
                return this.totalFinancialExpensesField;
            }
            set
            {
                this.totalFinancialExpensesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalFinancialExpensesSpecified
        {
            get
            {
                return this.totalFinancialExpensesFieldSpecified;
            }
            set
            {
                this.totalFinancialExpensesFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalOutstandingAmount
        {
            get
            {
                return this.totalOutstandingAmountField;
            }
            set
            {
                this.totalOutstandingAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalPaymentsOnAccount
        {
            get
            {
                return this.totalPaymentsOnAccountField;
            }
            set
            {
                this.totalPaymentsOnAccountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalPaymentsOnAccountSpecified
        {
            get
            {
                return this.totalPaymentsOnAccountFieldSpecified;
            }
            set
            {
                this.totalPaymentsOnAccountFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountsWithheldType AmountsWithheld
        {
            get
            {
                return this.amountsWithheldField;
            }
            set
            {
                this.amountsWithheldField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalExecutableAmount
        {
            get
            {
                return this.totalExecutableAmountField;
            }
            set
            {
                this.totalExecutableAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType TotalReimbursableExpenses
        {
            get
            {
                return this.totalReimbursableExpensesField;
            }
            set
            {
                this.totalReimbursableExpensesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalReimbursableExpensesSpecified
        {
            get
            {
                return this.totalReimbursableExpensesFieldSpecified;
            }
            set
            {
                this.totalReimbursableExpensesFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class ExchangeRateDetailsType
    {

        private double exchangeRateField;

        private System.DateTime exchangeRateDateField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DoubleTwoDecimalType ExchangeRate
        {
            get
            {
                return this.exchangeRateField;
            }
            set
            {
                this.exchangeRateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime ExchangeRateDate
        {
            get
            {
                return this.exchangeRateDateField;
            }
            set
            {
                this.exchangeRateDateField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class PlaceOfIssueType
    {

        private string postCodeField;

        private string placeOfIssueDescriptionField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PlaceOfIssueDescription
        {
            get
            {
                return this.placeOfIssueDescriptionField;
            }
            set
            {
                this.placeOfIssueDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class InvoiceIssueDataType
    {

        private System.DateTime issueDateField;

        private System.DateTime operationDateField;

        private bool operationDateFieldSpecified;

        private PlaceOfIssueType placeOfIssueField;

        private PeriodDates invoicingPeriodField;

        private CurrencyCodeType invoiceCurrencyCodeField;

        private ExchangeRateDetailsType exchangeRateDetailsField;

        private CurrencyCodeType taxCurrencyCodeField;

        private LanguageCodeType languageNameField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime IssueDate
        {
            get
            {
                return this.issueDateField;
            }
            set
            {
                this.issueDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime OperationDate
        {
            get
            {
                return this.operationDateField;
            }
            set
            {
                this.operationDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OperationDateSpecified
        {
            get
            {
                return this.operationDateFieldSpecified;
            }
            set
            {
                this.operationDateFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PlaceOfIssueType PlaceOfIssue
        {
            get
            {
                return this.placeOfIssueField;
            }
            set
            {
                this.placeOfIssueField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PeriodDates InvoicingPeriod
        {
            get
            {
                return this.invoicingPeriodField;
            }
            set
            {
                this.invoicingPeriodField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CurrencyCodeType InvoiceCurrencyCode
        {
            get
            {
                return this.invoiceCurrencyCodeField;
            }
            set
            {
                this.invoiceCurrencyCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ExchangeRateDetailsType ExchangeRateDetails
        {
            get
            {
                return this.exchangeRateDetailsField;
            }
            set
            {
                this.exchangeRateDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CurrencyCodeType TaxCurrencyCode
        {
            get
            {
                return this.taxCurrencyCodeField;
            }
            set
            {
                this.taxCurrencyCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LanguageCodeType LanguageName
        {
            get
            {
                return this.languageNameField;
            }
            set
            {
                this.languageNameField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum CurrencyCodeType
    {

        /// <comentarios/>
        AFN,

        /// <comentarios/>
        ALL,

        /// <comentarios/>
        AMD,

        /// <comentarios/>
        ANG,

        /// <comentarios/>
        AOA,

        /// <comentarios/>
        ARS,

        /// <comentarios/>
        AUD,

        /// <comentarios/>
        AWG,

        /// <comentarios/>
        AZN,

        /// <comentarios/>
        BAD,

        /// <comentarios/>
        BBD,

        /// <comentarios/>
        BDT,

        /// <comentarios/>
        BGN,

        /// <comentarios/>
        BHD,

        /// <comentarios/>
        BIF,

        /// <comentarios/>
        BMD,

        /// <comentarios/>
        BND,

        /// <comentarios/>
        BOB,

        /// <comentarios/>
        BRL,

        /// <comentarios/>
        BRR,

        /// <comentarios/>
        BSD,

        /// <comentarios/>
        BWP,

        /// <comentarios/>
        BYR,

        /// <comentarios/>
        BZD,

        /// <comentarios/>
        CAD,

        /// <comentarios/>
        CDF,

        /// <comentarios/>
        CDP,

        /// <comentarios/>
        CHF,

        /// <comentarios/>
        CLP,

        /// <comentarios/>
        CNY,

        /// <comentarios/>
        COP,

        /// <comentarios/>
        CRC,

        /// <comentarios/>
        CUP,

        /// <comentarios/>
        CVE,

        /// <comentarios/>
        CZK,

        /// <comentarios/>
        DJF,

        /// <comentarios/>
        DKK,

        /// <comentarios/>
        DOP,

        /// <comentarios/>
        DRP,

        /// <comentarios/>
        DZD,

        /// <comentarios/>
        EEK,

        /// <comentarios/>
        EGP,

        /// <comentarios/>
        ESP,

        /// <comentarios/>
        ETB,

        /// <comentarios/>
        EUR,

        /// <comentarios/>
        FJD,

        /// <comentarios/>
        FKP,

        /// <comentarios/>
        GBP,

        /// <comentarios/>
        GEK,

        /// <comentarios/>
        GHC,

        /// <comentarios/>
        GIP,

        /// <comentarios/>
        GMD,

        /// <comentarios/>
        GNF,

        /// <comentarios/>
        GTQ,

        /// <comentarios/>
        GWP,

        /// <comentarios/>
        GYD,

        /// <comentarios/>
        HKD,

        /// <comentarios/>
        HNL,

        /// <comentarios/>
        HRK,

        /// <comentarios/>
        HTG,

        /// <comentarios/>
        HUF,

        /// <comentarios/>
        IDR,

        /// <comentarios/>
        ILS,

        /// <comentarios/>
        INR,

        /// <comentarios/>
        IQD,

        /// <comentarios/>
        IRR,

        /// <comentarios/>
        ISK,

        /// <comentarios/>
        JMD,

        /// <comentarios/>
        JOD,

        /// <comentarios/>
        JPY,

        /// <comentarios/>
        KES,

        /// <comentarios/>
        KGS,

        /// <comentarios/>
        KHR,

        /// <comentarios/>
        KMF,

        /// <comentarios/>
        KPW,

        /// <comentarios/>
        KRW,

        /// <comentarios/>
        KWD,

        /// <comentarios/>
        KYD,

        /// <comentarios/>
        KZT,

        /// <comentarios/>
        LAK,

        /// <comentarios/>
        LBP,

        /// <comentarios/>
        LKR,

        /// <comentarios/>
        LRD,

        /// <comentarios/>
        LSL,

        /// <comentarios/>
        LTL,

        /// <comentarios/>
        LVL,

        /// <comentarios/>
        LYD,

        /// <comentarios/>
        MAD,

        /// <comentarios/>
        MDL,

        /// <comentarios/>
        MGF,

        /// <comentarios/>
        MNC,

        /// <comentarios/>
        MNT,

        /// <comentarios/>
        MOP,

        /// <comentarios/>
        MRO,

        /// <comentarios/>
        MUR,

        /// <comentarios/>
        MVR,

        /// <comentarios/>
        MWK,

        /// <comentarios/>
        MXN,

        /// <comentarios/>
        MYR,

        /// <comentarios/>
        MZM,

        /// <comentarios/>
        NGN,

        /// <comentarios/>
        NIC,

        /// <comentarios/>
        NIO,

        /// <comentarios/>
        NIS,

        /// <comentarios/>
        NOK,

        /// <comentarios/>
        NPR,

        /// <comentarios/>
        NZD,

        /// <comentarios/>
        OMR,

        /// <comentarios/>
        PAB,

        /// <comentarios/>
        PEI,

        /// <comentarios/>
        PEN,

        /// <comentarios/>
        PES,

        /// <comentarios/>
        PGK,

        /// <comentarios/>
        PHP,

        /// <comentarios/>
        PKR,

        /// <comentarios/>
        PLN,

        /// <comentarios/>
        PYG,

        /// <comentarios/>
        QAR,

        /// <comentarios/>
        RMB,

        /// <comentarios/>
        RON,

        /// <comentarios/>
        RUB,

        /// <comentarios/>
        RWF,

        /// <comentarios/>
        SAR,

        /// <comentarios/>
        SBD,

        /// <comentarios/>
        SCR,

        /// <comentarios/>
        SDP,

        /// <comentarios/>
        SEK,

        /// <comentarios/>
        SGD,

        /// <comentarios/>
        SHP,

        /// <comentarios/>
        SKK,

        /// <comentarios/>
        SLL,

        /// <comentarios/>
        SOL,

        /// <comentarios/>
        SOS,

        /// <comentarios/>
        SRD,

        /// <comentarios/>
        STD,

        /// <comentarios/>
        SVC,

        /// <comentarios/>
        SYP,

        /// <comentarios/>
        SZL,

        /// <comentarios/>
        THB,

        /// <comentarios/>
        TJS,

        /// <comentarios/>
        TMM,

        /// <comentarios/>
        TND,

        /// <comentarios/>
        TOP,

        /// <comentarios/>
        TPE,

        /// <comentarios/>
        TRY,

        /// <comentarios/>
        TTD,

        /// <comentarios/>
        TWD,

        /// <comentarios/>
        TZS,

        /// <comentarios/>
        UAH,

        /// <comentarios/>
        UGS,

        /// <comentarios/>
        USD,

        /// <comentarios/>
        UYP,

        /// <comentarios/>
        UYU,

        /// <comentarios/>
        VEF,

        /// <comentarios/>
        VND,

        /// <comentarios/>
        VUV,

        /// <comentarios/>
        WST,

        /// <comentarios/>
        XAF,

        /// <comentarios/>
        XCD,

        /// <comentarios/>
        XOF,

        /// <comentarios/>
        YER,

        /// <comentarios/>
        ZAR,

        /// <comentarios/>
        ZMK,

        /// <comentarios/>
        ZWD,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum LanguageCodeType
    {

        /// <comentarios/>
        ar,

        /// <comentarios/>
        be,

        /// <comentarios/>
        bg,

        /// <comentarios/>
        ca,

        /// <comentarios/>
        cs,

        /// <comentarios/>
        da,

        /// <comentarios/>
        de,

        /// <comentarios/>
        el,

        /// <comentarios/>
        en,

        /// <comentarios/>
        es,

        /// <comentarios/>
        et,

        /// <comentarios/>
        eu,

        /// <comentarios/>
        fi,

        /// <comentarios/>
        fr,

        /// <comentarios/>
        ga,

        /// <comentarios/>
        gl,

        /// <comentarios/>
        hr,

        /// <comentarios/>
        hu,

        /// <comentarios/>
        @is,

        /// <comentarios/>
        it,

        /// <comentarios/>
        lv,

        /// <comentarios/>
        lt,

        /// <comentarios/>
        mk,

        /// <comentarios/>
        mt,

        /// <comentarios/>
        nl,

        /// <comentarios/>
        no,

        /// <comentarios/>
        pl,

        /// <comentarios/>
        pt,

        /// <comentarios/>
        ro,

        /// <comentarios/>
        ru,

        /// <comentarios/>
        sk,

        /// <comentarios/>
        sl,

        /// <comentarios/>
        sq,

        /// <comentarios/>
        sr,

        /// <comentarios/>
        sv,

        /// <comentarios/>
        tr,

        /// <comentarios/>
        uk,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class CorrectiveType
    {

        private string invoiceNumberField;

        private string invoiceSeriesCodeField;

        private ReasonCodeType reasonCodeField;

        private ReasonDescriptionType reasonDescriptionField;

        private PeriodDates taxPeriodField;

        private CorrectionMethodType correctionMethodField;

        private CorrectionMethodDescriptionType correctionMethodDescriptionField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InvoiceNumber
        {
            get
            {
                return this.invoiceNumberField;
            }
            set
            {
                this.invoiceNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InvoiceSeriesCode
        {
            get
            {
                return this.invoiceSeriesCodeField;
            }
            set
            {
                this.invoiceSeriesCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ReasonCodeType ReasonCode
        {
            get
            {
                return this.reasonCodeField;
            }
            set
            {
                this.reasonCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ReasonDescriptionType ReasonDescription
        {
            get
            {
                return this.reasonDescriptionField;
            }
            set
            {
                this.reasonDescriptionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PeriodDates TaxPeriod
        {
            get
            {
                return this.taxPeriodField;
            }
            set
            {
                this.taxPeriodField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CorrectionMethodType CorrectionMethod
        {
            get
            {
                return this.correctionMethodField;
            }
            set
            {
                this.correctionMethodField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CorrectionMethodDescriptionType CorrectionMethodDescription
        {
            get
            {
                return this.correctionMethodDescriptionField;
            }
            set
            {
                this.correctionMethodDescriptionField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum ReasonCodeType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("80")]
        Item80,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("81")]
        Item81,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("82")]
        Item82,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("83")]
        Item83,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("84")]
        Item84,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("85")]
        Item85,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum ReasonDescriptionType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Número de la factura")]
        Númerodelafactura,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Serie de la factura")]
        Seriedelafactura,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Fecha expedición")]
        Fechaexpedición,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Nombre y apellidos/Razón Social-Emisor")]
        NombreyapellidosRazónSocialEmisor,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Nombre y apellidos/Razón Social-Receptor")]
        NombreyapellidosRazónSocialReceptor,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Identificación fiscal Emisor/obligado")]
        IdentificaciónfiscalEmisorobligado,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Identificación fiscal Receptor")]
        IdentificaciónfiscalReceptor,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Domicilio Emisor/Obligado")]
        DomicilioEmisorObligado,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Domicilio Receptor")]
        DomicilioReceptor,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Detalle Operación")]
        DetalleOperación,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Porcentaje impositivo a aplicar")]
        Porcentajeimpositivoaaplicar,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Cuota tributaria a aplicar")]
        Cuotatributariaaaplicar,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Fecha/Periodo a aplicar")]
        FechaPeriodoaaplicar,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Clase de factura")]
        Clasedefactura,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Literales legales")]
        Literaleslegales,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Base imponible")]
        Baseimponible,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Cálculo de cuotas repercutidas")]
        Cálculodecuotasrepercutidas,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Cálculo de cuotas retenidas")]
        Cálculodecuotasretenidas,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Base imponible modificada por devolución de envases / embalajes")]
        Baseimponiblemodificadapordevolucióndeenvasesembalajes,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Base imponible modificada por descuentos y bonificaciones")]
        Baseimponiblemodificadapordescuentosybonificaciones,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Base imponible modificada por resolución firme, judicial o administrativa")]
        Baseimponiblemodificadaporresoluciónfirmejudicialoadministrativa,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Base imponible modificada cuotas repercutidas no satisfechas. Auto de declaración" +
            " de concurso")]
        BaseimponiblemodificadacuotasrepercutidasnosatisfechasAutodedeclaracióndeconcurso,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum CorrectionMethodType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum CorrectionMethodDescriptionType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Rectificación íntegra")]
        Rectificacióníntegra,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Rectificación por diferencias")]
        Rectificaciónpordiferencias,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Rectificación por descuento por volumen de operaciones durante un periodo")]
        Rectificaciónpordescuentoporvolumendeoperacionesduranteunperiodo,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("Autorizadas por la Agencia Tributaria")]
        AutorizadasporlaAgenciaTributaria,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class InvoiceHeaderType
    {

        private string invoiceNumberField;

        private string invoiceSeriesCodeField;

        private InvoiceDocumentTypeType invoiceDocumentTypeField;

        private InvoiceClassType invoiceClassField;

        private CorrectiveType correctiveField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InvoiceNumber
        {
            get
            {
                return this.invoiceNumberField;
            }
            set
            {
                this.invoiceNumberField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InvoiceSeriesCode
        {
            get
            {
                return this.invoiceSeriesCodeField;
            }
            set
            {
                this.invoiceSeriesCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InvoiceDocumentTypeType InvoiceDocumentType
        {
            get
            {
                return this.invoiceDocumentTypeField;
            }
            set
            {
                this.invoiceDocumentTypeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InvoiceClassType InvoiceClass
        {
            get
            {
                return this.invoiceClassField;
            }
            set
            {
                this.invoiceClassField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CorrectiveType Corrective
        {
            get
            {
                return this.correctiveField;
            }
            set
            {
                this.correctiveField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum InvoiceDocumentTypeType
    {

        /// <comentarios/>
        FC,

        /// <comentarios/>
        FA,

        /// <comentarios/>
        AF,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum InvoiceClassType
    {

        /// <comentarios/>
        OO,

        /// <comentarios/>
        OR,

        /// <comentarios/>
        OC,

        /// <comentarios/>
        CO,

        /// <comentarios/>
        CR,

        /// <comentarios/>
        CC,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class InvoiceType
    {

        private InvoiceHeaderType invoiceHeaderField;

        private InvoiceIssueDataType invoiceIssueDataField;

        private TaxOutputType[] taxesOutputsField;

        private TaxType[] taxesWithheldField;

        private InvoiceTotalsType invoiceTotalsField;

        private InvoiceLineType[] itemsField;

        private InstallmentType[] paymentDetailsField;

        private string[] legalLiteralsField;

        private AdditionalDataType additionalDataField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InvoiceHeaderType InvoiceHeader
        {
            get
            {
                return this.invoiceHeaderField;
            }
            set
            {
                this.invoiceHeaderField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InvoiceIssueDataType InvoiceIssueData
        {
            get
            {
                return this.invoiceIssueDataField;
            }
            set
            {
                this.invoiceIssueDataField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Tax", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public TaxOutputType[] TaxesOutputs
        {
            get
            {
                return this.taxesOutputsField;
            }
            set
            {
                this.taxesOutputsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Tax", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public TaxType[] TaxesWithheld
        {
            get
            {
                return this.taxesWithheldField;
            }
            set
            {
                this.taxesWithheldField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InvoiceTotalsType InvoiceTotals
        {
            get
            {
                return this.invoiceTotalsField;
            }
            set
            {
                this.invoiceTotalsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("InvoiceLine", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public InvoiceLineType[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Installment", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public InstallmentType[] PaymentDetails
        {
            get
            {
                return this.paymentDetailsField;
            }
            set
            {
                this.paymentDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("LegalReference", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public string[] LegalLiterals
        {
            get
            {
                return this.legalLiteralsField;
            }
            set
            {
                this.legalLiteralsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AdditionalDataType AdditionalData
        {
            get
            {
                return this.additionalDataField;
            }
            set
            {
                this.additionalDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class AdministrativeCentreType
    {

        private string centreCodeField;

        private RoleTypeCodeType roleTypeCodeField;

        private bool roleTypeCodeFieldSpecified;

        private string nameField;

        private string firstSurnameField;

        private string secondSurnameField;

        private object itemField;

        private ContactDetailsType contactDetailsField;

        private string physicalGLNField;

        private string logicalOperationalPointField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CentreCode
        {
            get
            {
                return this.centreCodeField;
            }
            set
            {
                this.centreCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RoleTypeCodeType RoleTypeCode
        {
            get
            {
                return this.roleTypeCodeField;
            }
            set
            {
                this.roleTypeCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RoleTypeCodeSpecified
        {
            get
            {
                return this.roleTypeCodeFieldSpecified;
            }
            set
            {
                this.roleTypeCodeFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FirstSurname
        {
            get
            {
                return this.firstSurnameField;
            }
            set
            {
                this.firstSurnameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SecondSurname
        {
            get
            {
                return this.secondSurnameField;
            }
            set
            {
                this.secondSurnameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("AddressInSpain", typeof(AddressType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("OverseasAddress", typeof(OverseasAddressType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ContactDetailsType ContactDetails
        {
            get
            {
                return this.contactDetailsField;
            }
            set
            {
                this.contactDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PhysicalGLN
        {
            get
            {
                return this.physicalGLNField;
            }
            set
            {
                this.physicalGLNField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LogicalOperationalPoint
        {
            get
            {
                return this.logicalOperationalPointField;
            }
            set
            {
                this.logicalOperationalPointField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public enum RoleTypeCodeType
    {

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <comentarios/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class ContactDetailsType
    {

        private string telephoneField;

        private string teleFaxField;

        private string webAddressField;

        private string electronicMailField;

        private string contactPersonsField;

        private string cnoCnaeField;

        private string iNETownCodeField;

        private string additionalContactDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Telephone
        {
            get
            {
                return this.telephoneField;
            }
            set
            {
                this.telephoneField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TeleFax
        {
            get
            {
                return this.teleFaxField;
            }
            set
            {
                this.teleFaxField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WebAddress
        {
            get
            {
                return this.webAddressField;
            }
            set
            {
                this.webAddressField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ElectronicMail
        {
            get
            {
                return this.electronicMailField;
            }
            set
            {
                this.electronicMailField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ContactPersons
        {
            get
            {
                return this.contactPersonsField;
            }
            set
            {
                this.contactPersonsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CnoCnae
        {
            get
            {
                return this.cnoCnaeField;
            }
            set
            {
                this.cnoCnaeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string INETownCode
        {
            get
            {
                return this.iNETownCodeField;
            }
            set
            {
                this.iNETownCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AdditionalContactDetails
        {
            get
            {
                return this.additionalContactDetailsField;
            }
            set
            {
                this.additionalContactDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class BusinessType
    {

        private TaxIdentificationType taxIdentificationField;

        private string partyIdentificationField;

        private AdministrativeCentreType[] administrativeCentresField;

        private object itemField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TaxIdentificationType TaxIdentification
        {
            get
            {
                return this.taxIdentificationField;
            }
            set
            {
                this.taxIdentificationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PartyIdentification
        {
            get
            {
                return this.partyIdentificationField;
            }
            set
            {
                this.partyIdentificationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AdministrativeCentre", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public AdministrativeCentreType[] AdministrativeCentres
        {
            get
            {
                return this.administrativeCentresField;
            }
            set
            {
                this.administrativeCentresField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Individual", typeof(IndividualType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("LegalEntity", typeof(LegalEntityType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class IndividualType
    {

        private string nameField;

        private string firstSurnameField;

        private string secondSurnameField;

        private object itemField;

        private ContactDetailsType contactDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FirstSurname
        {
            get
            {
                return this.firstSurnameField;
            }
            set
            {
                this.firstSurnameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SecondSurname
        {
            get
            {
                return this.secondSurnameField;
            }
            set
            {
                this.secondSurnameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("AddressInSpain", typeof(AddressType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("OverseasAddress", typeof(OverseasAddressType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ContactDetailsType ContactDetails
        {
            get
            {
                return this.contactDetailsField;
            }
            set
            {
                this.contactDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class LegalEntityType
    {

        private string corporateNameField;

        private string tradeNameField;

        private RegistrationDataType registrationDataField;

        private object itemField;

        private ContactDetailsType contactDetailsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CorporateName
        {
            get
            {
                return this.corporateNameField;
            }
            set
            {
                this.corporateNameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TradeName
        {
            get
            {
                return this.tradeNameField;
            }
            set
            {
                this.tradeNameField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RegistrationDataType RegistrationData
        {
            get
            {
                return this.registrationDataField;
            }
            set
            {
                this.registrationDataField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("AddressInSpain", typeof(AddressType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("OverseasAddress", typeof(OverseasAddressType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ContactDetailsType ContactDetails
        {
            get
            {
                return this.contactDetailsField;
            }
            set
            {
                this.contactDetailsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class RegistrationDataType
    {

        private string bookField;

        private string registerOfCompaniesLocationField;

        private string sheetField;

        private string folioField;

        private string sectionField;

        private string volumeField;

        private string additionalRegistrationDataField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Book
        {
            get
            {
                return this.bookField;
            }
            set
            {
                this.bookField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RegisterOfCompaniesLocation
        {
            get
            {
                return this.registerOfCompaniesLocationField;
            }
            set
            {
                this.registerOfCompaniesLocationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Sheet
        {
            get
            {
                return this.sheetField;
            }
            set
            {
                this.sheetField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Folio
        {
            get
            {
                return this.folioField;
            }
            set
            {
                this.folioField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Section
        {
            get
            {
                return this.sectionField;
            }
            set
            {
                this.sectionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AdditionalRegistrationData
        {
            get
            {
                return this.additionalRegistrationDataField;
            }
            set
            {
                this.additionalRegistrationDataField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class PartiesType
    {

        private BusinessType sellerPartyField;

        private BusinessType buyerPartyField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BusinessType SellerParty
        {
            get
            {
                return this.sellerPartyField;
            }
            set
            {
                this.sellerPartyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BusinessType BuyerParty
        {
            get
            {
                return this.buyerPartyField;
            }
            set
            {
                this.buyerPartyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class PaymentDetailsType
    {

        private System.DateTime assignmentDuePaymentDateField;

        private string assignmentPaymentMeansField;

        private string iBANField;

        private string paymentReferenceField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
        public System.DateTime AssignmentDuePaymentDate
        {
            get
            {
                return this.assignmentDuePaymentDateField;
            }
            set
            {
                this.assignmentDuePaymentDateField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AssignmentPaymentMeans
        {
            get
            {
                return this.assignmentPaymentMeansField;
            }
            set
            {
                this.assignmentPaymentMeansField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IBAN
        {
            get
            {
                return this.iBANField;
            }
            set
            {
                this.iBANField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PaymentReference
        {
            get
            {
                return this.paymentReferenceField;
            }
            set
            {
                this.paymentReferenceField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class AssigneeType
    {

        private TaxIdentificationType taxIdentificationField;

        private object itemField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TaxIdentificationType TaxIdentification
        {
            get
            {
                return this.taxIdentificationField;
            }
            set
            {
                this.taxIdentificationField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Individual", typeof(IndividualType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("LegalEntity", typeof(LegalEntityType), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class FactoringAssignmentDataType
    {

        private AssigneeType assigneeField;

        private PaymentDetailsType paymentDetailsField;

        private string factoringAssignmentClausesField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AssigneeType Assignee
        {
            get
            {
                return this.assigneeField;
            }
            set
            {
                this.assigneeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PaymentDetailsType PaymentDetails
        {
            get
            {
                return this.paymentDetailsField;
            }
            set
            {
                this.paymentDetailsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FactoringAssignmentClauses
        {
            get
            {
                return this.factoringAssignmentClausesField;
            }
            set
            {
                this.factoringAssignmentClausesField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public partial class BatchType
    {

        private string batchIdentifierField;

        private long invoicesCountField;

        private AmountType totalInvoicesAmountField;

        private AmountType totalOutstandingAmountField;

        private AmountType totalExecutableAmountField;

        private CurrencyCodeType invoiceCurrencyCodeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BatchIdentifier
        {
            get
            {
                return this.batchIdentifierField;
            }
            set
            {
                this.batchIdentifierField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long InvoicesCount
        {
            get
            {
                return this.invoicesCountField;
            }
            set
            {
                this.invoicesCountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType TotalInvoicesAmount
        {
            get
            {
                return this.totalInvoicesAmountField;
            }
            set
            {
                this.totalInvoicesAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType TotalOutstandingAmount
        {
            get
            {
                return this.totalOutstandingAmountField;
            }
            set
            {
                this.totalOutstandingAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AmountType TotalExecutableAmount
        {
            get
            {
                return this.totalExecutableAmountField;
            }
            set
            {
                this.totalExecutableAmountField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CurrencyCodeType InvoiceCurrencyCode
        {
            get
            {
                return this.invoiceCurrencyCodeField;
            }
            set
            {
                this.invoiceCurrencyCodeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class TransformsType
    {

        private TransformType[] transformField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Transform")]
        public TransformType[] Transform
        {
            get
            {
                return this.transformField;
            }
            set
            {
                this.transformField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("Manifest", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class ManifestType
    {

        private ReferenceType[] referenceField;

        private string idField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("Reference")]
        public ReferenceType[] Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignatureProperties", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignaturePropertiesType
    {

        private SignaturePropertyType[] signaturePropertyField;

        private string idField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("SignatureProperty")]
        public SignaturePropertyType[] SignatureProperty
        {
            get
            {
                return this.signaturePropertyField;
            }
            set
            {
                this.signaturePropertyField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute("SignatureProperty", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignaturePropertyType
    {

        private System.Xml.XmlElement[] itemsField;

        private string[] textField;

        private string targetField;

        private string idField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string Target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
}
