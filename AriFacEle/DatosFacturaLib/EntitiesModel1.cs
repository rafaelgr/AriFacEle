﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
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
using DatosFacturaLib;

namespace DatosFacturaLib	
{
	public partial class GdesModelo : OpenAccessContext, IGdesModeloUnitOfWork
	{
		private static string connectionStringName = @"GdesContext";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel1.rlinq");
		
		public GdesModelo()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public GdesModelo(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public GdesModelo(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public GdesModelo(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public GdesModelo(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Cau_FIN_FACEInvoiceTax> Cau_FIN_FACEInvoiceTaxes 
		{
			get
			{
				return this.GetAll<Cau_FIN_FACEInvoiceTax>();
			}
		}
		
		public IQueryable<Cau_FIN_FACEInvoiceLine> Cau_FIN_FACEInvoiceLines 
		{
			get
			{
				return this.GetAll<Cau_FIN_FACEInvoiceLine>();
			}
		}
		
		public IQueryable<Cau_FIN_FACEInvoiceHeader> Cau_FIN_FACEInvoiceHeaders 
		{
			get
			{
				return this.GetAll<Cau_FIN_FACEInvoiceHeader>();
			}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MsSql";
			backend.ProviderName = "System.Data.SqlClient";
			return backend;
		}
	}
	
	public interface IGdesModeloUnitOfWork : IUnitOfWork
	{
		IQueryable<Cau_FIN_FACEInvoiceTax> Cau_FIN_FACEInvoiceTaxes
		{
			get;
		}
		IQueryable<Cau_FIN_FACEInvoiceLine> Cau_FIN_FACEInvoiceLines
		{
			get;
		}
		IQueryable<Cau_FIN_FACEInvoiceHeader> Cau_FIN_FACEInvoiceHeaders
		{
			get;
		}
	}
}
#pragma warning restore 1591
