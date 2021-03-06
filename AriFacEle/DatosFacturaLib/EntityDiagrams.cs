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
	public partial class FacturaEntity : OpenAccessContext, IFacturaEntityUnitOfWork
	{
		private static string connectionStringName = @"Facelec_ariadnaConnection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntityDiagrams.rlinq");
		
		public FacturaEntity()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public FacturaEntity(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public FacturaEntity(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public FacturaEntity(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public FacturaEntity(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Empresa> Empresas 
		{
			get
			{
				return this.GetAll<Empresa>();
			}
		}
		
		public IQueryable<Factura> Facturas 
		{
			get
			{
				return this.GetAll<Factura>();
			}
		}
		
		public IQueryable<Firma> Firmas 
		{
			get
			{
				return this.GetAll<Firma>();
			}
		}
		
		public IQueryable<Repositorio> Repositorios 
		{
			get
			{
				return this.GetAll<Repositorio>();
			}
		}
		
		public IQueryable<Cliente> Clientes 
		{
			get
			{
				return this.GetAll<Cliente>();
			}
		}
		
		public IQueryable<Superusuario> Superusuarios 
		{
			get
			{
				return this.GetAll<Superusuario>();
			}
		}
		
		public IQueryable<Sistema> Sistemas 
		{
			get
			{
				return this.GetAll<Sistema>();
			}
		}
		
		public IQueryable<Plantilla> Plantillas 
		{
			get
			{
				return this.GetAll<Plantilla>();
			}
		}
		
		public IQueryable<Unidad> Unidads 
		{
			get
			{
				return this.GetAll<Unidad>();
			}
		}
		
		public IQueryable<Usuario> Usuarios 
		{
			get
			{
				return this.GetAll<Usuario>();
			}
		}
		
		public IQueryable<Nifbase> Nifbases 
		{
			get
			{
				return this.GetAll<Nifbase>();
			}
		}
		
		public IQueryable<Departamento> Departamentos 
		{
			get
			{
				return this.GetAll<Departamento>();
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
	
	public interface IFacturaEntityUnitOfWork : IUnitOfWork
	{
		IQueryable<Empresa> Empresas
		{
			get;
		}
		IQueryable<Factura> Facturas
		{
			get;
		}
		IQueryable<Firma> Firmas
		{
			get;
		}
		IQueryable<Repositorio> Repositorios
		{
			get;
		}
		IQueryable<Cliente> Clientes
		{
			get;
		}
		IQueryable<Superusuario> Superusuarios
		{
			get;
		}
		IQueryable<Sistema> Sistemas
		{
			get;
		}
		IQueryable<Plantilla> Plantillas
		{
			get;
		}
		IQueryable<Unidad> Unidads
		{
			get;
		}
		IQueryable<Usuario> Usuarios
		{
			get;
		}
		IQueryable<Nifbase> Nifbases
		{
			get;
		}
		IQueryable<Departamento> Departamentos
		{
			get;
		}
	}
}
#pragma warning restore 1591
