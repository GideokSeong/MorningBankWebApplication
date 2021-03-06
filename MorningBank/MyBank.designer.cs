﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MorningBank
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MyBank")]
	public partial class MyBankDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSavingAccount(SavingAccount instance);
    partial void UpdateSavingAccount(SavingAccount instance);
    partial void DeleteSavingAccount(SavingAccount instance);
    partial void InsertCheckingAccount(CheckingAccount instance);
    partial void UpdateCheckingAccount(CheckingAccount instance);
    partial void DeleteCheckingAccount(CheckingAccount instance);
    partial void InsertTransactionType(TransactionType instance);
    partial void UpdateTransactionType(TransactionType instance);
    partial void DeleteTransactionType(TransactionType instance);
    partial void InsertTransactionHistory(TransactionHistory instance);
    partial void UpdateTransactionHistory(TransactionHistory instance);
    partial void DeleteTransactionHistory(TransactionHistory instance);
    #endregion
		
		public MyBankDataContext() : 
				base(global::MorningBank.Properties.Settings.Default.MyBankConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MyBankDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyBankDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyBankDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyBankDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<SavingAccount> SavingAccounts
		{
			get
			{
				return this.GetTable<SavingAccount>();
			}
		}
		
		public System.Data.Linq.Table<CheckingAccount> CheckingAccounts
		{
			get
			{
				return this.GetTable<CheckingAccount>();
			}
		}
		
		public System.Data.Linq.Table<TransactionType> TransactionTypes
		{
			get
			{
				return this.GetTable<TransactionType>();
			}
		}
		
		public System.Data.Linq.Table<TransactionHistory> TransactionHistories
		{
			get
			{
				return this.GetTable<TransactionHistory>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SavingAccounts")]
	public partial class SavingAccount : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Username;
		
		private long _SavingAccountNumber;
		
		private decimal _Balance;
		
		private EntitySet<TransactionHistory> _TransactionHistories;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnSavingAccountNumberChanging(long value);
    partial void OnSavingAccountNumberChanged();
    partial void OnBalanceChanging(decimal value);
    partial void OnBalanceChanged();
    #endregion
		
		public SavingAccount()
		{
			this._TransactionHistories = new EntitySet<TransactionHistory>(new Action<TransactionHistory>(this.attach_TransactionHistories), new Action<TransactionHistory>(this.detach_TransactionHistories));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SavingAccountNumber", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long SavingAccountNumber
		{
			get
			{
				return this._SavingAccountNumber;
			}
			set
			{
				if ((this._SavingAccountNumber != value))
				{
					this.OnSavingAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._SavingAccountNumber = value;
					this.SendPropertyChanged("SavingAccountNumber");
					this.OnSavingAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Balance", DbType="Money NOT NULL")]
		public decimal Balance
		{
			get
			{
				return this._Balance;
			}
			set
			{
				if ((this._Balance != value))
				{
					this.OnBalanceChanging(value);
					this.SendPropertyChanging();
					this._Balance = value;
					this.SendPropertyChanged("Balance");
					this.OnBalanceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SavingAccount_TransactionHistory", Storage="_TransactionHistories", ThisKey="SavingAccountNumber", OtherKey="SavingAccountNumber")]
		public EntitySet<TransactionHistory> TransactionHistories
		{
			get
			{
				return this._TransactionHistories;
			}
			set
			{
				this._TransactionHistories.Assign(value);
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
		
		private void attach_TransactionHistories(TransactionHistory entity)
		{
			this.SendPropertyChanging();
			entity.SavingAccount = this;
		}
		
		private void detach_TransactionHistories(TransactionHistory entity)
		{
			this.SendPropertyChanging();
			entity.SavingAccount = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CheckingAccounts")]
	public partial class CheckingAccount : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Username;
		
		private long _CheckingAccountNumber;
		
		private decimal _Balance;
		
		private EntitySet<TransactionHistory> _TransactionHistories;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnCheckingAccountNumberChanging(long value);
    partial void OnCheckingAccountNumberChanged();
    partial void OnBalanceChanging(decimal value);
    partial void OnBalanceChanged();
    #endregion
		
		public CheckingAccount()
		{
			this._TransactionHistories = new EntitySet<TransactionHistory>(new Action<TransactionHistory>(this.attach_TransactionHistories), new Action<TransactionHistory>(this.detach_TransactionHistories));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckingAccountNumber", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long CheckingAccountNumber
		{
			get
			{
				return this._CheckingAccountNumber;
			}
			set
			{
				if ((this._CheckingAccountNumber != value))
				{
					this.OnCheckingAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._CheckingAccountNumber = value;
					this.SendPropertyChanged("CheckingAccountNumber");
					this.OnCheckingAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Balance", DbType="Money NOT NULL")]
		public decimal Balance
		{
			get
			{
				return this._Balance;
			}
			set
			{
				if ((this._Balance != value))
				{
					this.OnBalanceChanging(value);
					this.SendPropertyChanging();
					this._Balance = value;
					this.SendPropertyChanged("Balance");
					this.OnBalanceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CheckingAccount_TransactionHistory", Storage="_TransactionHistories", ThisKey="CheckingAccountNumber", OtherKey="CheckingAccountNumber")]
		public EntitySet<TransactionHistory> TransactionHistories
		{
			get
			{
				return this._TransactionHistories;
			}
			set
			{
				this._TransactionHistories.Assign(value);
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
		
		private void attach_TransactionHistories(TransactionHistory entity)
		{
			this.SendPropertyChanging();
			entity.CheckingAccount = this;
		}
		
		private void detach_TransactionHistories(TransactionHistory entity)
		{
			this.SendPropertyChanging();
			entity.CheckingAccount = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TransactionTypes")]
	public partial class TransactionType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _TransactionTypeId;
		
		private string _TransactionTypeName;
		
		private EntitySet<TransactionHistory> _TransactionHistories;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTransactionTypeIdChanging(long value);
    partial void OnTransactionTypeIdChanged();
    partial void OnTransactionTypeNameChanging(string value);
    partial void OnTransactionTypeNameChanged();
    #endregion
		
		public TransactionType()
		{
			this._TransactionHistories = new EntitySet<TransactionHistory>(new Action<TransactionHistory>(this.attach_TransactionHistories), new Action<TransactionHistory>(this.detach_TransactionHistories));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionTypeId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public long TransactionTypeId
		{
			get
			{
				return this._TransactionTypeId;
			}
			set
			{
				if ((this._TransactionTypeId != value))
				{
					this.OnTransactionTypeIdChanging(value);
					this.SendPropertyChanging();
					this._TransactionTypeId = value;
					this.SendPropertyChanged("TransactionTypeId");
					this.OnTransactionTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionTypeName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string TransactionTypeName
		{
			get
			{
				return this._TransactionTypeName;
			}
			set
			{
				if ((this._TransactionTypeName != value))
				{
					this.OnTransactionTypeNameChanging(value);
					this.SendPropertyChanging();
					this._TransactionTypeName = value;
					this.SendPropertyChanged("TransactionTypeName");
					this.OnTransactionTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TransactionType_TransactionHistory", Storage="_TransactionHistories", ThisKey="TransactionTypeId", OtherKey="TransactionTypeId")]
		public EntitySet<TransactionHistory> TransactionHistories
		{
			get
			{
				return this._TransactionHistories;
			}
			set
			{
				this._TransactionHistories.Assign(value);
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
		
		private void attach_TransactionHistories(TransactionHistory entity)
		{
			this.SendPropertyChanging();
			entity.TransactionType = this;
		}
		
		private void detach_TransactionHistories(TransactionHistory entity)
		{
			this.SendPropertyChanging();
			entity.TransactionType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TransactionHistories")]
	public partial class TransactionHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _TransactionId;
		
		private System.DateTime _TransactionDate;
		
		private long _CheckingAccountNumber;
		
		private long _SavingAccountNumber;
		
		private decimal _Amount;
		
		private decimal _Transactionfee;
		
		private long _TransactionTypeId;
		
		private EntityRef<CheckingAccount> _CheckingAccount;
		
		private EntityRef<SavingAccount> _SavingAccount;
		
		private EntityRef<TransactionType> _TransactionType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTransactionIdChanging(long value);
    partial void OnTransactionIdChanged();
    partial void OnTransactionDateChanging(System.DateTime value);
    partial void OnTransactionDateChanged();
    partial void OnCheckingAccountNumberChanging(long value);
    partial void OnCheckingAccountNumberChanged();
    partial void OnSavingAccountNumberChanging(long value);
    partial void OnSavingAccountNumberChanged();
    partial void OnAmountChanging(decimal value);
    partial void OnAmountChanged();
    partial void OnTransactionFeeChanging(decimal value);
    partial void OnTransactionFeeChanged();
    partial void OnTransactionTypeIdChanging(long value);
    partial void OnTransactionTypeIdChanged();
    #endregion
		
		public TransactionHistory()
		{
			this._CheckingAccount = default(EntityRef<CheckingAccount>);
			this._SavingAccount = default(EntityRef<SavingAccount>);
			this._TransactionType = default(EntityRef<TransactionType>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionId", DbType="BigInt NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		public long TransactionId
		{
			get
			{
				return this._TransactionId;
			}
			set
			{
				if ((this._TransactionId != value))
				{
					this.OnTransactionIdChanging(value);
					this.SendPropertyChanging();
					this._TransactionId = value;
					this.SendPropertyChanged("TransactionId");
					this.OnTransactionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionDate", DbType="DateTime NOT NULL")]
		public System.DateTime TransactionDate
		{
			get
			{
				return this._TransactionDate;
			}
			set
			{
				if ((this._TransactionDate != value))
				{
					this.OnTransactionDateChanging(value);
					this.SendPropertyChanging();
					this._TransactionDate = value;
					this.SendPropertyChanged("TransactionDate");
					this.OnTransactionDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckingAccountNumber", DbType="BigInt NOT NULL")]
		public long CheckingAccountNumber
		{
			get
			{
				return this._CheckingAccountNumber;
			}
			set
			{
				if ((this._CheckingAccountNumber != value))
				{
					if (this._CheckingAccount.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCheckingAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._CheckingAccountNumber = value;
					this.SendPropertyChanged("CheckingAccountNumber");
					this.OnCheckingAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SavingAccountNumber", DbType="BigInt NOT NULL")]
		public long SavingAccountNumber
		{
			get
			{
				return this._SavingAccountNumber;
			}
			set
			{
				if ((this._SavingAccountNumber != value))
				{
					if (this._SavingAccount.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSavingAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._SavingAccountNumber = value;
					this.SendPropertyChanged("SavingAccountNumber");
					this.OnSavingAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Money NOT NULL")]
		public decimal Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Transactionfee", Storage="_Transactionfee", DbType="Money NOT NULL")]
		public decimal TransactionFee
		{
			get
			{
				return this._Transactionfee;
			}
			set
			{
				if ((this._Transactionfee != value))
				{
					this.OnTransactionFeeChanging(value);
					this.SendPropertyChanging();
					this._Transactionfee = value;
					this.SendPropertyChanged("TransactionFee");
					this.OnTransactionFeeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionTypeId", DbType="BigInt NOT NULL")]
		public long TransactionTypeId
		{
			get
			{
				return this._TransactionTypeId;
			}
			set
			{
				if ((this._TransactionTypeId != value))
				{
					if (this._TransactionType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTransactionTypeIdChanging(value);
					this.SendPropertyChanging();
					this._TransactionTypeId = value;
					this.SendPropertyChanged("TransactionTypeId");
					this.OnTransactionTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CheckingAccount_TransactionHistory", Storage="_CheckingAccount", ThisKey="CheckingAccountNumber", OtherKey="CheckingAccountNumber", IsForeignKey=true)]
		public CheckingAccount CheckingAccount
		{
			get
			{
				return this._CheckingAccount.Entity;
			}
			set
			{
				CheckingAccount previousValue = this._CheckingAccount.Entity;
				if (((previousValue != value) 
							|| (this._CheckingAccount.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CheckingAccount.Entity = null;
						previousValue.TransactionHistories.Remove(this);
					}
					this._CheckingAccount.Entity = value;
					if ((value != null))
					{
						value.TransactionHistories.Add(this);
						this._CheckingAccountNumber = value.CheckingAccountNumber;
					}
					else
					{
						this._CheckingAccountNumber = default(long);
					}
					this.SendPropertyChanged("CheckingAccount");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SavingAccount_TransactionHistory", Storage="_SavingAccount", ThisKey="SavingAccountNumber", OtherKey="SavingAccountNumber", IsForeignKey=true)]
		public SavingAccount SavingAccount
		{
			get
			{
				return this._SavingAccount.Entity;
			}
			set
			{
				SavingAccount previousValue = this._SavingAccount.Entity;
				if (((previousValue != value) 
							|| (this._SavingAccount.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._SavingAccount.Entity = null;
						previousValue.TransactionHistories.Remove(this);
					}
					this._SavingAccount.Entity = value;
					if ((value != null))
					{
						value.TransactionHistories.Add(this);
						this._SavingAccountNumber = value.SavingAccountNumber;
					}
					else
					{
						this._SavingAccountNumber = default(long);
					}
					this.SendPropertyChanged("SavingAccount");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TransactionType_TransactionHistory", Storage="_TransactionType", ThisKey="TransactionTypeId", OtherKey="TransactionTypeId", IsForeignKey=true)]
		public TransactionType TransactionType
		{
			get
			{
				return this._TransactionType.Entity;
			}
			set
			{
				TransactionType previousValue = this._TransactionType.Entity;
				if (((previousValue != value) 
							|| (this._TransactionType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TransactionType.Entity = null;
						previousValue.TransactionHistories.Remove(this);
					}
					this._TransactionType.Entity = value;
					if ((value != null))
					{
						value.TransactionHistories.Add(this);
						this._TransactionTypeId = value.TransactionTypeId;
					}
					else
					{
						this._TransactionTypeId = default(long);
					}
					this.SendPropertyChanged("TransactionType");
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
}
#pragma warning restore 1591
