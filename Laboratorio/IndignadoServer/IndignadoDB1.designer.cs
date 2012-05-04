﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignadoServer
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="IndignadoDB")]
	public partial class IndignadoDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertConvocatoria(Convocatoria instance);
    partial void UpdateConvocatoria(Convocatoria instance);
    partial void DeleteConvocatoria(Convocatoria instance);
    partial void InsertMovimiento(Movimiento instance);
    partial void UpdateMovimiento(Movimiento instance);
    partial void DeleteMovimiento(Movimiento instance);
    partial void InsertUsuarioFacebook(UsuarioFacebook instance);
    partial void UpdateUsuarioFacebook(UsuarioFacebook instance);
    partial void DeleteUsuarioFacebook(UsuarioFacebook instance);
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    #endregion
		
		public IndignadoDBDataContext() : 
				base(global::IndignadoServer.Properties.Settings.Default.IndignadoDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public IndignadoDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IndignadoDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IndignadoDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IndignadoDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Convocatoria> Convocatorias
		{
			get
			{
				return this.GetTable<Convocatoria>();
			}
		}
		
		public System.Data.Linq.Table<Movimiento> Movimientos
		{
			get
			{
				return this.GetTable<Movimiento>();
			}
		}
		
		public System.Data.Linq.Table<UsuarioFacebook> UsuarioFacebooks
		{
			get
			{
				return this.GetTable<UsuarioFacebook>();
			}
		}
		
		public System.Data.Linq.Table<Usuario> Usuarios
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Convocatorias")]
	public partial class Convocatoria : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _idMovimiento;
		
		private int _idAutor;
		
		private string _titulo;
		
		private string _descripcion;
		
		private string _geoUbicacion;
		
		private string _inicio;
		
		private string _fin;
		
		private System.Data.Linq.Binary _logo;
		
		private System.Nullable<int> _minQuorum;
		
		private EntityRef<Convocatoria> _Convocatoria2;
		
		private EntityRef<Convocatoria> _Convocatoria1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnidMovimientoChanging(int value);
    partial void OnidMovimientoChanged();
    partial void OnidAutorChanging(int value);
    partial void OnidAutorChanged();
    partial void OntituloChanging(string value);
    partial void OntituloChanged();
    partial void OndescripcionChanging(string value);
    partial void OndescripcionChanged();
    partial void OngeoUbicacionChanging(string value);
    partial void OngeoUbicacionChanged();
    partial void OninicioChanging(string value);
    partial void OninicioChanged();
    partial void OnfinChanging(string value);
    partial void OnfinChanged();
    partial void OnlogoChanging(System.Data.Linq.Binary value);
    partial void OnlogoChanged();
    partial void OnminQuorumChanging(System.Nullable<int> value);
    partial void OnminQuorumChanged();
    #endregion
		
		public Convocatoria()
		{
			this._Convocatoria2 = default(EntityRef<Convocatoria>);
			this._Convocatoria1 = default(EntityRef<Convocatoria>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					if (this._Convocatoria1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idMovimiento", DbType="Int NOT NULL")]
		public int idMovimiento
		{
			get
			{
				return this._idMovimiento;
			}
			set
			{
				if ((this._idMovimiento != value))
				{
					this.OnidMovimientoChanging(value);
					this.SendPropertyChanging();
					this._idMovimiento = value;
					this.SendPropertyChanged("idMovimiento");
					this.OnidMovimientoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idAutor", DbType="Int NOT NULL")]
		public int idAutor
		{
			get
			{
				return this._idAutor;
			}
			set
			{
				if ((this._idAutor != value))
				{
					this.OnidAutorChanging(value);
					this.SendPropertyChanging();
					this._idAutor = value;
					this.SendPropertyChanged("idAutor");
					this.OnidAutorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_titulo", DbType="VarChar(50)")]
		public string titulo
		{
			get
			{
				return this._titulo;
			}
			set
			{
				if ((this._titulo != value))
				{
					this.OntituloChanging(value);
					this.SendPropertyChanging();
					this._titulo = value;
					this.SendPropertyChanged("titulo");
					this.OntituloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcion", DbType="VarChar(50)")]
		public string descripcion
		{
			get
			{
				return this._descripcion;
			}
			set
			{
				if ((this._descripcion != value))
				{
					this.OndescripcionChanging(value);
					this.SendPropertyChanging();
					this._descripcion = value;
					this.SendPropertyChanged("descripcion");
					this.OndescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_geoUbicacion", DbType="VarChar(50)")]
		public string geoUbicacion
		{
			get
			{
				return this._geoUbicacion;
			}
			set
			{
				if ((this._geoUbicacion != value))
				{
					this.OngeoUbicacionChanging(value);
					this.SendPropertyChanging();
					this._geoUbicacion = value;
					this.SendPropertyChanged("geoUbicacion");
					this.OngeoUbicacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_inicio", DbType="VarChar(50)")]
		public string inicio
		{
			get
			{
				return this._inicio;
			}
			set
			{
				if ((this._inicio != value))
				{
					this.OninicioChanging(value);
					this.SendPropertyChanging();
					this._inicio = value;
					this.SendPropertyChanged("inicio");
					this.OninicioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fin", DbType="VarChar(50)")]
		public string fin
		{
			get
			{
				return this._fin;
			}
			set
			{
				if ((this._fin != value))
				{
					this.OnfinChanging(value);
					this.SendPropertyChanging();
					this._fin = value;
					this.SendPropertyChanged("fin");
					this.OnfinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logo", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary logo
		{
			get
			{
				return this._logo;
			}
			set
			{
				if ((this._logo != value))
				{
					this.OnlogoChanging(value);
					this.SendPropertyChanging();
					this._logo = value;
					this.SendPropertyChanged("logo");
					this.OnlogoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_minQuorum", DbType="Int")]
		public System.Nullable<int> minQuorum
		{
			get
			{
				return this._minQuorum;
			}
			set
			{
				if ((this._minQuorum != value))
				{
					this.OnminQuorumChanging(value);
					this.SendPropertyChanging();
					this._minQuorum = value;
					this.SendPropertyChanged("minQuorum");
					this.OnminQuorumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Convocatoria_Convocatoria", Storage="_Convocatoria2", ThisKey="id", OtherKey="id", IsUnique=true, IsForeignKey=false)]
		public Convocatoria Convocatoria2
		{
			get
			{
				return this._Convocatoria2.Entity;
			}
			set
			{
				Convocatoria previousValue = this._Convocatoria2.Entity;
				if (((previousValue != value) 
							|| (this._Convocatoria2.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Convocatoria2.Entity = null;
						previousValue.Convocatoria1 = null;
					}
					this._Convocatoria2.Entity = value;
					if ((value != null))
					{
						value.Convocatoria1 = this;
					}
					this.SendPropertyChanged("Convocatoria2");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Convocatoria_Convocatoria", Storage="_Convocatoria1", ThisKey="id", OtherKey="id", IsForeignKey=true)]
		public Convocatoria Convocatoria1
		{
			get
			{
				return this._Convocatoria1.Entity;
			}
			set
			{
				Convocatoria previousValue = this._Convocatoria1.Entity;
				if (((previousValue != value) 
							|| (this._Convocatoria1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Convocatoria1.Entity = null;
						previousValue.Convocatoria2 = null;
					}
					this._Convocatoria1.Entity = value;
					if ((value != null))
					{
						value.Convocatoria2 = this;
						this._id = value.id;
					}
					else
					{
						this._id = default(int);
					}
					this.SendPropertyChanged("Convocatoria1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Movimiento")]
	public partial class Movimiento : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _nombre;
		
		private string _descripcion;
		
		private string _geoUbicacion;
		
		private System.Data.Linq.Binary _logo;
		
		private int _plantillaEstilo;
		
		private System.Nullable<int> _maxMarcasInadecuadasRecursoX;
		
		private System.Nullable<int> _maxRecursosInadecuadosUsuarioZ;
		
		private System.Nullable<int> _maxRecursosPopularesN;
		
		private System.Nullable<int> _maxUltimosRecursosM;
		
		private bool _habilitado;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OndescripcionChanging(string value);
    partial void OndescripcionChanged();
    partial void OngeoUbicacionChanging(string value);
    partial void OngeoUbicacionChanged();
    partial void OnlogoChanging(System.Data.Linq.Binary value);
    partial void OnlogoChanged();
    partial void OnplantillaEstiloChanging(int value);
    partial void OnplantillaEstiloChanged();
    partial void OnmaxMarcasInadecuadasRecursoXChanging(System.Nullable<int> value);
    partial void OnmaxMarcasInadecuadasRecursoXChanged();
    partial void OnmaxRecursosInadecuadosUsuarioZChanging(System.Nullable<int> value);
    partial void OnmaxRecursosInadecuadosUsuarioZChanged();
    partial void OnmaxRecursosPopularesNChanging(System.Nullable<int> value);
    partial void OnmaxRecursosPopularesNChanged();
    partial void OnmaxUltimosRecursosMChanging(System.Nullable<int> value);
    partial void OnmaxUltimosRecursosMChanged();
    partial void OnhabilitadoChanging(bool value);
    partial void OnhabilitadoChanged();
    #endregion
		
		public Movimiento()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcion", DbType="VarChar(50)")]
		public string descripcion
		{
			get
			{
				return this._descripcion;
			}
			set
			{
				if ((this._descripcion != value))
				{
					this.OndescripcionChanging(value);
					this.SendPropertyChanging();
					this._descripcion = value;
					this.SendPropertyChanged("descripcion");
					this.OndescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_geoUbicacion", DbType="VarChar(50)")]
		public string geoUbicacion
		{
			get
			{
				return this._geoUbicacion;
			}
			set
			{
				if ((this._geoUbicacion != value))
				{
					this.OngeoUbicacionChanging(value);
					this.SendPropertyChanging();
					this._geoUbicacion = value;
					this.SendPropertyChanged("geoUbicacion");
					this.OngeoUbicacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logo", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary logo
		{
			get
			{
				return this._logo;
			}
			set
			{
				if ((this._logo != value))
				{
					this.OnlogoChanging(value);
					this.SendPropertyChanging();
					this._logo = value;
					this.SendPropertyChanged("logo");
					this.OnlogoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_plantillaEstilo", DbType="Int NOT NULL")]
		public int plantillaEstilo
		{
			get
			{
				return this._plantillaEstilo;
			}
			set
			{
				if ((this._plantillaEstilo != value))
				{
					this.OnplantillaEstiloChanging(value);
					this.SendPropertyChanging();
					this._plantillaEstilo = value;
					this.SendPropertyChanged("plantillaEstilo");
					this.OnplantillaEstiloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maxMarcasInadecuadasRecursoX", DbType="Int")]
		public System.Nullable<int> maxMarcasInadecuadasRecursoX
		{
			get
			{
				return this._maxMarcasInadecuadasRecursoX;
			}
			set
			{
				if ((this._maxMarcasInadecuadasRecursoX != value))
				{
					this.OnmaxMarcasInadecuadasRecursoXChanging(value);
					this.SendPropertyChanging();
					this._maxMarcasInadecuadasRecursoX = value;
					this.SendPropertyChanged("maxMarcasInadecuadasRecursoX");
					this.OnmaxMarcasInadecuadasRecursoXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maxRecursosInadecuadosUsuarioZ", DbType="Int")]
		public System.Nullable<int> maxRecursosInadecuadosUsuarioZ
		{
			get
			{
				return this._maxRecursosInadecuadosUsuarioZ;
			}
			set
			{
				if ((this._maxRecursosInadecuadosUsuarioZ != value))
				{
					this.OnmaxRecursosInadecuadosUsuarioZChanging(value);
					this.SendPropertyChanging();
					this._maxRecursosInadecuadosUsuarioZ = value;
					this.SendPropertyChanged("maxRecursosInadecuadosUsuarioZ");
					this.OnmaxRecursosInadecuadosUsuarioZChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maxRecursosPopularesN", DbType="Int")]
		public System.Nullable<int> maxRecursosPopularesN
		{
			get
			{
				return this._maxRecursosPopularesN;
			}
			set
			{
				if ((this._maxRecursosPopularesN != value))
				{
					this.OnmaxRecursosPopularesNChanging(value);
					this.SendPropertyChanging();
					this._maxRecursosPopularesN = value;
					this.SendPropertyChanged("maxRecursosPopularesN");
					this.OnmaxRecursosPopularesNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maxUltimosRecursosM", DbType="Int")]
		public System.Nullable<int> maxUltimosRecursosM
		{
			get
			{
				return this._maxUltimosRecursosM;
			}
			set
			{
				if ((this._maxUltimosRecursosM != value))
				{
					this.OnmaxUltimosRecursosMChanging(value);
					this.SendPropertyChanging();
					this._maxUltimosRecursosM = value;
					this.SendPropertyChanged("maxUltimosRecursosM");
					this.OnmaxUltimosRecursosMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_habilitado", DbType="Bit NOT NULL")]
		public bool habilitado
		{
			get
			{
				return this._habilitado;
			}
			set
			{
				if ((this._habilitado != value))
				{
					this.OnhabilitadoChanging(value);
					this.SendPropertyChanging();
					this._habilitado = value;
					this.SendPropertyChanged("habilitado");
					this.OnhabilitadoChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UsuarioFacebook")]
	public partial class UsuarioFacebook : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idUsuario;
		
		private int _idFacebook;
		
		private int _idMovimiento;
		
		private EntityRef<Usuario> _Usuario;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidUsuarioChanging(int value);
    partial void OnidUsuarioChanged();
    partial void OnidFacebookChanging(int value);
    partial void OnidFacebookChanged();
    partial void OnidMovimientoChanging(int value);
    partial void OnidMovimientoChanged();
    #endregion
		
		public UsuarioFacebook()
		{
			this._Usuario = default(EntityRef<Usuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idUsuario", DbType="Int NOT NULL")]
		public int idUsuario
		{
			get
			{
				return this._idUsuario;
			}
			set
			{
				if ((this._idUsuario != value))
				{
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidUsuarioChanging(value);
					this.SendPropertyChanging();
					this._idUsuario = value;
					this.SendPropertyChanged("idUsuario");
					this.OnidUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idFacebook", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int idFacebook
		{
			get
			{
				return this._idFacebook;
			}
			set
			{
				if ((this._idFacebook != value))
				{
					this.OnidFacebookChanging(value);
					this.SendPropertyChanging();
					this._idFacebook = value;
					this.SendPropertyChanged("idFacebook");
					this.OnidFacebookChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idMovimiento", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int idMovimiento
		{
			get
			{
				return this._idMovimiento;
			}
			set
			{
				if ((this._idMovimiento != value))
				{
					this.OnidMovimientoChanging(value);
					this.SendPropertyChanging();
					this._idMovimiento = value;
					this.SendPropertyChanged("idMovimiento");
					this.OnidMovimientoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_UsuarioFacebook", Storage="_Usuario", ThisKey="idUsuario", OtherKey="id", IsForeignKey=true)]
		public Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.UsuarioFacebooks.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.UsuarioFacebooks.Add(this);
						this._idUsuario = value.id;
					}
					else
					{
						this._idUsuario = default(int);
					}
					this.SendPropertyChanged("Usuario");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuarios")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _idMovimiento;
		
		private string _nombre;
		
		private string _apodo;
		
		private string _mail;
		
		private string _contraseña;
		
		private string _geoUbicacion;
		
		private string _fechaRegistro;
		
		private System.Nullable<bool> _banned;
		
		private string _privilegio;
		
		private EntitySet<UsuarioFacebook> _UsuarioFacebooks;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnidMovimientoChanging(int value);
    partial void OnidMovimientoChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OnapodoChanging(string value);
    partial void OnapodoChanged();
    partial void OnmailChanging(string value);
    partial void OnmailChanged();
    partial void OncontraseñaChanging(string value);
    partial void OncontraseñaChanged();
    partial void OngeoUbicacionChanging(string value);
    partial void OngeoUbicacionChanged();
    partial void OnfechaRegistroChanging(string value);
    partial void OnfechaRegistroChanged();
    partial void OnbannedChanging(System.Nullable<bool> value);
    partial void OnbannedChanged();
    partial void OnprivilegioChanging(string value);
    partial void OnprivilegioChanged();
    #endregion
		
		public Usuario()
		{
			this._UsuarioFacebooks = new EntitySet<UsuarioFacebook>(new Action<UsuarioFacebook>(this.attach_UsuarioFacebooks), new Action<UsuarioFacebook>(this.detach_UsuarioFacebooks));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idMovimiento", DbType="Int NOT NULL")]
		public int idMovimiento
		{
			get
			{
				return this._idMovimiento;
			}
			set
			{
				if ((this._idMovimiento != value))
				{
					this.OnidMovimientoChanging(value);
					this.SendPropertyChanging();
					this._idMovimiento = value;
					this.SendPropertyChanged("idMovimiento");
					this.OnidMovimientoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apodo", DbType="VarChar(50)")]
		public string apodo
		{
			get
			{
				return this._apodo;
			}
			set
			{
				if ((this._apodo != value))
				{
					this.OnapodoChanging(value);
					this.SendPropertyChanging();
					this._apodo = value;
					this.SendPropertyChanged("apodo");
					this.OnapodoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mail", DbType="VarChar(50)")]
		public string mail
		{
			get
			{
				return this._mail;
			}
			set
			{
				if ((this._mail != value))
				{
					this.OnmailChanging(value);
					this.SendPropertyChanging();
					this._mail = value;
					this.SendPropertyChanged("mail");
					this.OnmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contraseña", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string contraseña
		{
			get
			{
				return this._contraseña;
			}
			set
			{
				if ((this._contraseña != value))
				{
					this.OncontraseñaChanging(value);
					this.SendPropertyChanging();
					this._contraseña = value;
					this.SendPropertyChanged("contraseña");
					this.OncontraseñaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_geoUbicacion", DbType="VarChar(50)")]
		public string geoUbicacion
		{
			get
			{
				return this._geoUbicacion;
			}
			set
			{
				if ((this._geoUbicacion != value))
				{
					this.OngeoUbicacionChanging(value);
					this.SendPropertyChanging();
					this._geoUbicacion = value;
					this.SendPropertyChanged("geoUbicacion");
					this.OngeoUbicacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fechaRegistro", DbType="VarChar(50)")]
		public string fechaRegistro
		{
			get
			{
				return this._fechaRegistro;
			}
			set
			{
				if ((this._fechaRegistro != value))
				{
					this.OnfechaRegistroChanging(value);
					this.SendPropertyChanging();
					this._fechaRegistro = value;
					this.SendPropertyChanged("fechaRegistro");
					this.OnfechaRegistroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_banned", DbType="Bit")]
		public System.Nullable<bool> banned
		{
			get
			{
				return this._banned;
			}
			set
			{
				if ((this._banned != value))
				{
					this.OnbannedChanging(value);
					this.SendPropertyChanging();
					this._banned = value;
					this.SendPropertyChanged("banned");
					this.OnbannedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_privilegio", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string privilegio
		{
			get
			{
				return this._privilegio;
			}
			set
			{
				if ((this._privilegio != value))
				{
					this.OnprivilegioChanging(value);
					this.SendPropertyChanging();
					this._privilegio = value;
					this.SendPropertyChanged("privilegio");
					this.OnprivilegioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_UsuarioFacebook", Storage="_UsuarioFacebooks", ThisKey="id", OtherKey="idUsuario")]
		public EntitySet<UsuarioFacebook> UsuarioFacebooks
		{
			get
			{
				return this._UsuarioFacebooks;
			}
			set
			{
				this._UsuarioFacebooks.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UsuarioFacebooks(UsuarioFacebook entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_UsuarioFacebooks(UsuarioFacebook entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
	}
}
#pragma warning restore 1591