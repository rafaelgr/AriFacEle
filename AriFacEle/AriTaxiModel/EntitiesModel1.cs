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
using AriTaxiModel;

namespace AriTaxiModel	
{
	public partial class AriTaxiContext : OpenAccessContext, IAriTaxiContextUnitOfWork
	{
		private static string connectionStringName = @"AritaxiConnection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel1.rlinq");
		
		public AriTaxiContext()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public AriTaxiContext(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public AriTaxiContext(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public AriTaxiContext(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public AriTaxiContext(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<SparamTaxi> SparamTaxis 
		{
			get
			{
				return this.GetAll<SparamTaxi>();
			}
		}
		
		public IQueryable<Sfactusoc> Sfactusocs 
		{
			get
			{
				return this.GetAll<Sfactusoc>();
			}
		}
		
		public IQueryable<Scliente> Sclientes 
		{
			get
			{
				return this.GetAll<Scliente>();
			}
		}
		
		public IQueryable<Sclien> Scliens 
		{
			get
			{
				return this.GetAll<Sclien>();
			}
		}
		
		public IQueryable<Scafaccli> Scafacclis 
		{
			get
			{
				return this.GetAll<Scafaccli>();
			}
		}
		
		public IQueryable<StipomTaxi> StipomTaxis 
		{
			get
			{
				return this.GetAll<StipomTaxi>();
			}
		}
		
		public IQueryable<Scafacuota> Scafacuotas 
		{
			get
			{
				return this.GetAll<Scafacuota>();
			}
		}
		
		public IQueryable<Slifaccli> Slifacclis 
		{
			get
			{
				return this.GetAll<Slifaccli>();
			}
		}
		
		public IQueryable<Sartic> Sartics 
		{
			get
			{
				return this.GetAll<Sartic>();
			}
		}
		
		public IQueryable<Svencicli> Svenciclis 
		{
			get
			{
				return this.GetAll<Svencicli>();
			}
		}
		
		public IQueryable<Sbanpr> Sbanprs 
		{
			get
			{
				return this.GetAll<Sbanpr>();
			}
		}
		
		public IQueryable<Sforpa> Sforpas 
		{
			get
			{
				return this.GetAll<Sforpa>();
			}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MySql";
			backend.ProviderName = "MySql.Data.MySqlClient";
			backend.Logging.MetricStoreSnapshotInterval = 0;
			return backend;
		}
	}
	
	public interface IAriTaxiContextUnitOfWork : IUnitOfWork
	{
		IQueryable<SparamTaxi> SparamTaxis
		{
			get;
		}
		IQueryable<Sfactusoc> Sfactusocs
		{
			get;
		}
		IQueryable<Scliente> Sclientes
		{
			get;
		}
		IQueryable<Sclien> Scliens
		{
			get;
		}
		IQueryable<Scafaccli> Scafacclis
		{
			get;
		}
		IQueryable<StipomTaxi> StipomTaxis
		{
			get;
		}
		IQueryable<Scafacuota> Scafacuotas
		{
			get;
		}
		IQueryable<Slifaccli> Slifacclis
		{
			get;
		}
		IQueryable<Sartic> Sartics
		{
			get;
		}
		IQueryable<Svencicli> Svenciclis
		{
			get;
		}
		IQueryable<Sbanpr> Sbanprs
		{
			get;
		}
		IQueryable<Sforpa> Sforpas
		{
			get;
		}
	}
}
#pragma warning restore 1591
