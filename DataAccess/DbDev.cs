﻿using LinqToDB;
using Model;

namespace DataAccess
{
	public class DbDev : LinqToDB.Data.DataConnection
	{
		public DbDev() : base("devdb") { }
		public ITable<KFZ> Kfz => GetTable<KFZ>();
	}
}
