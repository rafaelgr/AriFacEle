#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace GdesModel	
{
	public partial class Cau_FIN_FACEInvoiceLine
	{
		private string _iD;
		public virtual string ID
		{
			get
			{
				return this._iD;
			}
			set
			{
				this._iD = value;
			}
		}
		
		private string _invoiceNumber;
		public virtual string InvoiceNumber
		{
			get
			{
				return this._invoiceNumber;
			}
			set
			{
				this._invoiceNumber = value;
			}
		}
		
		private string _itemDescription;
		public virtual string ItemDescription
		{
			get
			{
				return this._itemDescription;
			}
			set
			{
				this._itemDescription = value;
			}
		}
		
		private decimal _quantity;
		public virtual decimal Quantity
		{
			get
			{
				return this._quantity;
			}
			set
			{
				this._quantity = value;
			}
		}
		
		private decimal _unitPriceWithoutTax;
		public virtual decimal UnitPriceWithoutTax
		{
			get
			{
				return this._unitPriceWithoutTax;
			}
			set
			{
				this._unitPriceWithoutTax = value;
			}
		}
		
		private decimal _totalCost;
		public virtual decimal TotalCost
		{
			get
			{
				return this._totalCost;
			}
			set
			{
				this._totalCost = value;
			}
		}
		
		private decimal _grossAmount;
		public virtual decimal GrossAmount
		{
			get
			{
				return this._grossAmount;
			}
			set
			{
				this._grossAmount = value;
			}
		}
		
		private int? _taxRate;
		public virtual int? TaxRate
		{
			get
			{
				return this._taxRate;
			}
			set
			{
				this._taxRate = value;
			}
		}
		
		private decimal? _taxAmount;
		public virtual decimal? TaxAmount
		{
			get
			{
				return this._taxAmount;
			}
			set
			{
				this._taxAmount = value;
			}
		}
		
	}
}
#pragma warning restore 1591
