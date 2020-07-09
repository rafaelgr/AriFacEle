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
using DatosFacturaLib;

namespace DatosFacturaLib	
{
	public partial class Cliente
	{
		private int iD;
		public virtual int ID
		{
			get
			{
				return this.iD;
			}
			set
			{
				this.iD = value;
			}
		}
		
		private string login;
		public virtual string Login
		{
			get
			{
				return this.login;
			}
			set
			{
				this.login = value;
			}
		}
		
		private string contraseña;
		public virtual string Contraseña
		{
			get
			{
				return this.contraseña;
			}
			set
			{
				this.contraseña = value;
			}
		}
		
		private string nombre;
		public virtual string Nombre
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = value;
			}
		}
		
		private string cif;
		public virtual string Cif
		{
			get
			{
				return this.cif;
			}
			set
			{
				this.cif = value;
			}
		}
		
		private string email;
		public virtual string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				this.email = value;
			}
		}
		
		private int? idEmpresa;
		public virtual int? Id_empresa
		{
			get
			{
				return this.idEmpresa;
			}
			set
			{
				this.idEmpresa = value;
			}
		}
		
		private bool? fNueva;
		public virtual bool? F_nueva
		{
			get
			{
				return this.fNueva;
			}
			set
			{
				this.fNueva = value;
			}
		}
		
		private int codclienAriges;
		public virtual int CodclienAriges
		{
			get
			{
				return this.codclienAriges;
			}
			set
			{
				this.codclienAriges = value;
			}
		}
		
		private int? codGesSoc;
		public virtual int? CodGesSoc
		{
			get
			{
				return this.codGesSoc;
			}
			set
			{
				this.codGesSoc = value;
			}
		}
		
		private int codSocioAritaxi;
		public virtual int CodSocioAritaxi
		{
			get
			{
				return this.codSocioAritaxi;
			}
			set
			{
				this.codSocioAritaxi = value;
			}
		}
		
		private string unidadTramitadoraCodigo;
		public virtual string UnidadTramitadoraCodigo
		{
			get
			{
				return this.unidadTramitadoraCodigo;
			}
			set
			{
				this.unidadTramitadoraCodigo = value;
			}
		}
		
		private string organoGestorCodigo;
		public virtual string OrganoGestorCodigo
		{
			get
			{
				return this.organoGestorCodigo;
			}
			set
			{
				this.organoGestorCodigo = value;
			}
		}
		
		private string oficinaContableCodigo;
		public virtual string OficinaContableCodigo
		{
			get
			{
				return this.oficinaContableCodigo;
			}
			set
			{
				this.oficinaContableCodigo = value;
			}
		}
		
		private int codclien_Arigasol;
		public virtual int CodclienArigasol
		{
			get
			{
				return this.codclien_Arigasol;
			}
			set
			{
				this.codclien_Arigasol = value;
			}
		}
		
		private int codclienAriagro;
		public virtual int CodclienAriagro
		{
			get
			{
				return this.codclienAriagro;
			}
			set
			{
				this.codclienAriagro = value;
			}
		}
		
		private bool tieneFacturaPROV;
		public virtual bool TieneFacturaPROV
		{
			get
			{
				return this.tieneFacturaPROV;
			}
			set
			{
				this.tieneFacturaPROV = value;
			}
		}
		
		private int codSocioAriagro;
		public virtual int CodSocioAriagro
		{
			get
			{
				return this.codSocioAriagro;
			}
			set
			{
				this.codSocioAriagro = value;
			}
		}
		
		private int codClienAriges2;
		public virtual int CodClienAriges2
		{
			get
			{
				return this.codClienAriges2;
			}
			set
			{
				this.codClienAriges2 = value;
			}
		}
		
		private int codTeletaxi;
		public virtual int CodTeletaxi
		{
			get
			{
				return this.codTeletaxi;
			}
			set
			{
				this.codTeletaxi = value;
			}
		}
		
		private string codGdes;
		public virtual string CodGdes
		{
			get
			{
				return this.codGdes;
			}
			set
			{
				this.codGdes = value;
			}
		}
		
		private string iban;
		public virtual string Iban
		{
			get
			{
				return this.iban;
			}
			set
			{
				this.iban = value;
			}
		}
		
		private string organoProponente;
		public virtual string OrganoProponente
		{
			get
			{
				return this.organoProponente;
			}
			set
			{
				this.organoProponente = value;
			}
		}
		
		private int codClienArigestion;
		public virtual int CodClienArigestion
		{
			get
			{
				return this.codClienArigestion;
			}
			set
			{
				this.codClienArigestion = value;
			}
		}
		
		private Empresa empresa;
		public virtual Empresa Empresa
		{
			get
			{
				return this.empresa;
			}
			set
			{
				this.empresa = value;
			}
		}
		
		private IList<Factura> facturas = new List<Factura>();
		public virtual IList<Factura> Facturas
		{
			get
			{
				return this.facturas;
			}
		}
		
	}
}
#pragma warning restore 1591
