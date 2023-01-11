using System;

namespace data.application.lib;

public abstract class DACManagerFactory
{

	public DACManagerFactory()
	{
	}


	public static IDACManager GetDACManager(string ConnectionString, DACManagers DACManager)
	{
		if (DateTime.Now <= new DateTime(2023, 12, 30))
		{
			switch (DACManager)
			{
				case DACManagers.SqlServerDACManager:
					return new SqlServerDACManager(ConnectionString);

				case DACManagers.SQLiteDACManager:
					return new SQLiteDACManager(ConnectionString);

				case DACManagers.OracleDACManager:
					return new OracleDACManager(ConnectionString);

				case DACManagers.OleDbDACManager:
					return null;//new DataAccessObjectsCore.OleDbDACManager(ConnectionString);

				case DACManagers.OdbcDACManager:
					return null;//new DataAccessObjectsCore.OdbcDACManager(ConnectionString);

				case DACManagers.MySqlDACManager:
					return null;//new DataAccessObjectsCore.MySqlDACManager(ConnectionString);

				default:
					throw new Exception("DACManager not supported");
			}
		}
		else
		{
			throw new Exception("License Expired");
		}
	}


	public static string BuildTrustedCS(string Server, string DataBase, string TimeOut, DACManagers DACManager)
	{
		if (DateTime.Now <= new DateTime(2023, 12, 30))
		{
			switch (DACManager)
			{
				case DACManagers.SqlServerDACManager:
					return string.Format("Server={0};Database={1};Trusted_Connection=True;Connection Timeout={2}", Server, DataBase, TimeOut);

				case DACManagers.OracleDACManager:
					return null;

				case DACManagers.OleDbDACManager:
					return null;

				case DACManagers.OdbcDACManager:
					return null;

				case DACManagers.MySqlDACManager:
					return null;

				default:
					throw new Exception("DACManager not supported");
			}
		}
		else
		{
			throw new Exception("License Expired");
		}
	}

}
