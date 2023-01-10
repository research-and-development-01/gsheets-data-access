using System;
using System.Data;
using System.Data.SQLite;

namespace data.application.lib;

public class SQLiteDACManager : IDACManager
{
	#region Declarations
	private SQLiteConnection _Connection;
	private SQLiteCommand _Command;
	#endregion

	#region Constructors
	public SQLiteDACManager(string ConnectionString)
	{
		_Connection = new SQLiteConnection(ConnectionString, true);
		_Command = new SQLiteCommand();
		_Command.Connection = _Connection;
	}
	#endregion

	#region Methods
	public DataTable GetDataTable(string SQL)
	{
		try
		{
			DataTable dt = new DataTable();
			_Command.Parameters.Clear();
			_Command.CommandText = SQL;
			_Command.CommandType = CommandType.Text;
			SQLiteDataAdapter adapter = new SQLiteDataAdapter(_Command);
			adapter.Fill(dt);
			return dt;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.ToString());
		}
		finally
		{
			_Connection.Close();
		}
	}

	public DataTable GetDataTable(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			DataTable dt = new DataTable();
			_Command.Parameters.Clear();
			_Command.CommandText = SPName;
			_Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (SQLiteParameter param in Parameters)
				{
					_Command.Parameters.Add(param);
				}
			}

			SQLiteDataAdapter adapter = new SQLiteDataAdapter(_Command);
			adapter.Fill(dt);
			return dt;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.ToString());
		}
		finally
		{
			_Connection.Close();
		}
	}

	public DataSet GetDataSet(string SQL)
	{
		try
		{
			DataSet ds = new DataSet();
			_Command.Parameters.Clear();
			_Command.CommandText = SQL;
			_Command.CommandType = CommandType.Text;
			SQLiteDataAdapter adapter = new SQLiteDataAdapter(_Command);
			adapter.Fill(ds);
			return ds;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.ToString());
		}
		finally
		{
			_Connection.Close();
		}
	}

	public DataSet GetDataSet(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			DataSet ds = new DataSet();
			_Command.Parameters.Clear();
			_Command.CommandText = SPName;
			_Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (SQLiteParameter param in Parameters)
				{
					_Command.Parameters.Add(param);
				}
			}

			SQLiteDataAdapter adapter = new SQLiteDataAdapter(_Command);
			adapter.Fill(ds);
			return ds;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.ToString());
		}
		finally
		{
			_Connection.Close();
		}
	}

	public IDataReader ExecuteDataReader(string SQL)
	{
		try
		{
			_Command.Parameters.Clear();
			_Command.CommandType = CommandType.Text;
			_Command.CommandText = SQL;
			_Command.Connection.Open();
			return _Command.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			_Connection.Close();
			throw new Exception(ex.ToString());
		}
		finally
		{
		}
	}

	public IDataReader ExecuteDataReader(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			_Command.Parameters.Clear();
			_Command.CommandText = SPName;
			_Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (SQLiteParameter param in Parameters)
				{
					_Command.Parameters.Add(param);
				}
			}

			_Command.Connection.Open();
			return _Command.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			_Connection.Close();
			throw new Exception(ex.ToString());
		}
		finally
		{
		}
	}

	public object ExecuteScaler(string SQL)
	{
		try
		{
			_Command.Parameters.Clear();
			_Command.CommandText = SQL;
			_Command.CommandType = CommandType.Text;
			_Command.Connection.Open();
			return _Command.ExecuteScalar();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.ToString());
		}
		finally
		{
			_Connection.Close();
		}
	}

	public object ExecuteScaler(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			_Command.Parameters.Clear();
			_Command.CommandText = SPName;
			_Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (SQLiteParameter param in Parameters)
				{
					_Command.Parameters.Add(param);
				}
			}

			_Command.Connection.Open();
			return _Command.ExecuteScalar();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.ToString());
		}
		finally
		{
			_Connection.Close();
		}
	}

	public long ExecuteNonQuery(string SQL)
	{
		try
		{
			_Command.Parameters.Clear();
			_Command.CommandType = CommandType.Text;
			_Command.CommandText = SQL;
			_Command.Connection.Open();
			return _Command.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.ToString());
		}
		finally
		{
			_Connection.Close();
		}
	}

	public long ExecuteNonQuery(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			_Command.Parameters.Clear();
			_Command.CommandText = SPName;
			_Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (SQLiteParameter param in Parameters)
				{
					_Command.Parameters.Add(param);
				}
			}

			_Command.Connection.Open();
			return _Command.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.ToString());
		}
		finally
		{
			_Connection.Close();
		}
	}
	#endregion

	#region Properties
	public IDbConnection Connection
	{
		get
		{
			return _Connection;
		}
		set
		{
			_Connection = (SQLiteConnection)value;
		}
	}

	public IDbCommand Command
	{
		get
		{
			return _Command;
		}
		set
		{
			_Command = (SQLiteCommand)value;
		}
	}  
	#endregion

}
