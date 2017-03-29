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

namespace OWULRosterServer.Repositories
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Roster")]
	public partial class RosterDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTeam(Team instance);
    partial void UpdateTeam(Team instance);
    partial void DeleteTeam(Team instance);
    partial void InsertPlayer(Player instance);
    partial void UpdatePlayer(Player instance);
    partial void DeletePlayer(Player instance);
    #endregion
		
		public RosterDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["RosterConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public RosterDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RosterDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RosterDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RosterDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Team> Teams
		{
			get
			{
				return this.GetTable<Team>();
			}
		}
		
		public System.Data.Linq.Table<Player> Players
		{
			get
			{
				return this.GetTable<Player>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Team")]
	public partial class Team : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TeamId;
		
		private string _Name;
		
		private string _Avatar;
		
		private int _Wins;
		
		private int _Losses;
		
		private int _Ties;
		
		private int _Score;
		
		private EntitySet<Player> _Players;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTeamIdChanging(int value);
    partial void OnTeamIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAvatarChanging(string value);
    partial void OnAvatarChanged();
    partial void OnWinsChanging(int value);
    partial void OnWinsChanged();
    partial void OnLossesChanging(int value);
    partial void OnLossesChanged();
    partial void OnTiesChanging(int value);
    partial void OnTiesChanged();
    partial void OnScoreChanging(int value);
    partial void OnScoreChanged();
    #endregion
		
		public Team()
		{
			this._Players = new EntitySet<Player>(new Action<Player>(this.attach_Players), new Action<Player>(this.detach_Players));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TeamId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TeamId
		{
			get
			{
				return this._TeamId;
			}
			set
			{
				if ((this._TeamId != value))
				{
					this.OnTeamIdChanging(value);
					this.SendPropertyChanging();
					this._TeamId = value;
					this.SendPropertyChanged("TeamId");
					this.OnTeamIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Avatar", DbType="VarChar(500)")]
		public string Avatar
		{
			get
			{
				return this._Avatar;
			}
			set
			{
				if ((this._Avatar != value))
				{
					this.OnAvatarChanging(value);
					this.SendPropertyChanging();
					this._Avatar = value;
					this.SendPropertyChanged("Avatar");
					this.OnAvatarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Wins", DbType="Int NOT NULL")]
		public int Wins
		{
			get
			{
				return this._Wins;
			}
			set
			{
				if ((this._Wins != value))
				{
					this.OnWinsChanging(value);
					this.SendPropertyChanging();
					this._Wins = value;
					this.SendPropertyChanged("Wins");
					this.OnWinsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Losses", DbType="Int NOT NULL")]
		public int Losses
		{
			get
			{
				return this._Losses;
			}
			set
			{
				if ((this._Losses != value))
				{
					this.OnLossesChanging(value);
					this.SendPropertyChanging();
					this._Losses = value;
					this.SendPropertyChanged("Losses");
					this.OnLossesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ties", DbType="Int NOT NULL")]
		public int Ties
		{
			get
			{
				return this._Ties;
			}
			set
			{
				if ((this._Ties != value))
				{
					this.OnTiesChanging(value);
					this.SendPropertyChanging();
					this._Ties = value;
					this.SendPropertyChanged("Ties");
					this.OnTiesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Score", DbType="Int NOT NULL")]
		public int Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				if ((this._Score != value))
				{
					this.OnScoreChanging(value);
					this.SendPropertyChanging();
					this._Score = value;
					this.SendPropertyChanged("Score");
					this.OnScoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Player", Storage="_Players", ThisKey="TeamId", OtherKey="TeamId")]
		public EntitySet<Player> Players
		{
			get
			{
				return this._Players;
			}
			set
			{
				this._Players.Assign(value);
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
		
		private void attach_Players(Player entity)
		{
			this.SendPropertyChanging();
			entity.Team = this;
		}
		
		private void detach_Players(Player entity)
		{
			this.SendPropertyChanging();
			entity.Team = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Player")]
	public partial class Player : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PlayerId;
		
		private System.Nullable<int> _TeamId;
		
		private string _Name;
		
		private string _BNetTag;
		
		private string _Avatar;
		
		private int _SkillRating;
		
		private decimal _AverageKills;
		
		private decimal _AverageDeaths;
		
		private decimal _AverageAssists;
		
		private EntityRef<Team> _Team;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlayerIdChanging(int value);
    partial void OnPlayerIdChanged();
    partial void OnTeamIdChanging(System.Nullable<int> value);
    partial void OnTeamIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnBNetTagChanging(string value);
    partial void OnBNetTagChanged();
    partial void OnAvatarChanging(string value);
    partial void OnAvatarChanged();
    partial void OnSkillRatingChanging(int value);
    partial void OnSkillRatingChanged();
    partial void OnAverageKillsChanging(decimal value);
    partial void OnAverageKillsChanged();
    partial void OnAverageDeathsChanging(decimal value);
    partial void OnAverageDeathsChanged();
    partial void OnAverageAssistsChanging(decimal value);
    partial void OnAverageAssistsChanged();
    #endregion
		
		public Player()
		{
			this._Team = default(EntityRef<Team>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PlayerId
		{
			get
			{
				return this._PlayerId;
			}
			set
			{
				if ((this._PlayerId != value))
				{
					this.OnPlayerIdChanging(value);
					this.SendPropertyChanging();
					this._PlayerId = value;
					this.SendPropertyChanged("PlayerId");
					this.OnPlayerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TeamId", DbType="Int")]
		public System.Nullable<int> TeamId
		{
			get
			{
				return this._TeamId;
			}
			set
			{
				if ((this._TeamId != value))
				{
					if (this._Team.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTeamIdChanging(value);
					this.SendPropertyChanging();
					this._TeamId = value;
					this.SendPropertyChanged("TeamId");
					this.OnTeamIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BNetTag", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string BNetTag
		{
			get
			{
				return this._BNetTag;
			}
			set
			{
				if ((this._BNetTag != value))
				{
					this.OnBNetTagChanging(value);
					this.SendPropertyChanging();
					this._BNetTag = value;
					this.SendPropertyChanged("BNetTag");
					this.OnBNetTagChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Avatar", DbType="VarChar(500)")]
		public string Avatar
		{
			get
			{
				return this._Avatar;
			}
			set
			{
				if ((this._Avatar != value))
				{
					this.OnAvatarChanging(value);
					this.SendPropertyChanging();
					this._Avatar = value;
					this.SendPropertyChanged("Avatar");
					this.OnAvatarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SkillRating", DbType="Int NOT NULL")]
		public int SkillRating
		{
			get
			{
				return this._SkillRating;
			}
			set
			{
				if ((this._SkillRating != value))
				{
					this.OnSkillRatingChanging(value);
					this.SendPropertyChanging();
					this._SkillRating = value;
					this.SendPropertyChanged("SkillRating");
					this.OnSkillRatingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AverageKills", DbType="Decimal(5,2) NOT NULL")]
		public decimal AverageKills
		{
			get
			{
				return this._AverageKills;
			}
			set
			{
				if ((this._AverageKills != value))
				{
					this.OnAverageKillsChanging(value);
					this.SendPropertyChanging();
					this._AverageKills = value;
					this.SendPropertyChanged("AverageKills");
					this.OnAverageKillsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AverageDeaths", DbType="Decimal(5,2) NOT NULL")]
		public decimal AverageDeaths
		{
			get
			{
				return this._AverageDeaths;
			}
			set
			{
				if ((this._AverageDeaths != value))
				{
					this.OnAverageDeathsChanging(value);
					this.SendPropertyChanging();
					this._AverageDeaths = value;
					this.SendPropertyChanged("AverageDeaths");
					this.OnAverageDeathsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AverageAssists", DbType="Decimal(5,2) NOT NULL")]
		public decimal AverageAssists
		{
			get
			{
				return this._AverageAssists;
			}
			set
			{
				if ((this._AverageAssists != value))
				{
					this.OnAverageAssistsChanging(value);
					this.SendPropertyChanging();
					this._AverageAssists = value;
					this.SendPropertyChanged("AverageAssists");
					this.OnAverageAssistsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Player", Storage="_Team", ThisKey="TeamId", OtherKey="TeamId", IsForeignKey=true, DeleteRule="SET DEFAULT")]
		public Team Team
		{
			get
			{
				return this._Team.Entity;
			}
			set
			{
				Team previousValue = this._Team.Entity;
				if (((previousValue != value) 
							|| (this._Team.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Team.Entity = null;
						previousValue.Players.Remove(this);
					}
					this._Team.Entity = value;
					if ((value != null))
					{
						value.Players.Add(this);
						this._TeamId = value.TeamId;
					}
					else
					{
						this._TeamId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Team");
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