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
using AriFacElec;

namespace AriFacElec	
{
	public partial class ArigesContext : OpenAccessContext, IArigesContextUnitOfWork
	{
		private static string connectionStringName = @"Ariges";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntityDiagrams.rlinq");
		
		public ArigesContext()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public ArigesContext(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public ArigesContext(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public ArigesContext(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public ArigesContext(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Scafac> Scafacs 
		{
			get
			{
				return this.GetAll<Scafac>();
			}
		}
		
		public IQueryable<Sclien> Scliens 
		{
			get
			{
				return this.GetAll<Sclien>();
			}
		}
		
		public IQueryable<Sparam> Sparams 
		{
			get
			{
				return this.GetAll<Sparam>();
			}
		}
		
		public IQueryable<Stipom> Stipoms 
		{
			get
			{
				return this.GetAll<Stipom>();
			}
		}
		
		public IQueryable<Slifac> Slifacs 
		{
			get
			{
				return this.GetAll<Slifac>();
			}
		}
		
		public IQueryable<Sartic> Sartics 
		{
			get
			{
				return this.GetAll<Sartic>();
			}
		}
		
		public IQueryable<Spara1> Spara1 
		{
			get
			{
				return this.GetAll<Spara1>();
			}
		}
		
		public IQueryable<Sdirec> Sdirecs 
		{
			get
			{
				return this.GetAll<Sdirec>();
			}
		}
		
		public IQueryable<Svenci> Svencis 
		{
			get
			{
				return this.GetAll<Svenci>();
			}
		}
		
		public IQueryable<Scafac1> Scafac1 
		{
			get
			{
				return this.GetAll<Scafac1>();
			}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "mysql";
			backend.ProviderName = "MySql.Data.MySqlClient";
			return backend;
		}
	}
	
	public interface IArigesContextUnitOfWork : IUnitOfWork
	{
		IQueryable<Scafac> Scafacs
		{
			get;
		}
		IQueryable<Sclien> Scliens
		{
			get;
		}
		IQueryable<Sparam> Sparams
		{
			get;
		}
		IQueryable<Stipom> Stipoms
		{
			get;
		}
		IQueryable<Slifac> Slifacs
		{
			get;
		}
		IQueryable<Sartic> Sartics
		{
			get;
		}
		IQueryable<Spara1> Spara1
		{
			get;
		}
		IQueryable<Sdirec> Sdirecs
		{
			get;
		}
		IQueryable<Svenci> Svencis
		{
			get;
		}
		IQueryable<Scafac1> Scafac1
		{
			get;
		}
	}
}
#pragma warning restore 1591
