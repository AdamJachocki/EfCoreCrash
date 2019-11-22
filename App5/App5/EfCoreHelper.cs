using Microsoft.EntityFrameworkCore;
using System;

namespace App5
{
	public enum DbType
	{
		Sqlite,
		Mssql,
		Unknown
	}

	public class DbInfo
	{
		public string Name { get; set; }
		public DbType Type { get; set; }
		public string ConnectionString { get; set; }
		public bool IsDefault { get; set; }
		public bool InMemory { get; set; }

		public DbInfo()
		{
			Name = string.Empty;
			Type = DbType.Unknown;
			ConnectionString = string.Empty;
			IsDefault = false;
			InMemory = false;
		}
	}

	static class DbInitializer
	{
		public static DbType DatabaseType { get; private set; }
		public static AppDbContext DbCtx { get; set; }

		public static void InitDb(DbInfo dbInfo, DbContextOptionsBuilder<AppDbContext> ctxBuilder)
		{
			DatabaseType = dbInfo.Type;
			switch (dbInfo.Type)
			{
				case DbType.Mssql:
					InitSqlServer(dbInfo, ctxBuilder);
					break;

				case DbType.Sqlite:
					InitSqlite(dbInfo, ctxBuilder);
					break;
			}
		}

		static void InitSqlite(DbInfo dbInfo, DbContextOptionsBuilder<AppDbContext> ctx)
		{
			ctx.UseSqlite(dbInfo.ConnectionString);
		}

		static void InitSqlServer(DbInfo dbInfo, DbContextOptionsBuilder<AppDbContext> ctx)
		{
			ctx.UseSqlServer(dbInfo.ConnectionString);
		}

	}


	public static class EfCoreHelper
	{
		static bool isInitialized = false;
		static DbContextOptionsBuilder<AppDbContext> optionsBuilder;

		public static void Init(DbInfo dbInfo)
		{
			if (isInitialized)
				throw new InvalidOperationException("EfCore is already initialized!");

			optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

			DbInitializer.InitDb(dbInfo, optionsBuilder);

			using (AppDbContext ctx = new AppDbContext(optionsBuilder.Options))
			{
				try
				{
					DbInitializer.DbCtx = ctx;
					ctx.Database.Migrate();

				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}

		public static void UnInit()
		{
			isInitialized = false;
			optionsBuilder = null;
		}

		public static AppDbContext GetContext()
		{
			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
