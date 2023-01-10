//using MySql.Data.MySqlClient;

namespace data.application.lib;

public class MySqlDACManager //: IDACManager
{
        /*

	#region Declarations
	private MySqlCommand _Command;
	private MySqlConnection _Connection;
	#endregion



	#region Constructors
	public MySqlDACManager(String ConnectionString)
	{
		this._Connection = new MySqlConnection(ConnectionString);
		this._Command = new MySqlCommand();
		this._Command.Connection = this._Connection;
	}
	#endregion



	#region Properties

	public System.Data.IDbConnection Connection
	{
		get
		{
			return this._Connection;
		}
		set
		{
			this._Connection = (MySqlConnection)value;
		}
	}

	public System.Data.IDbCommand Command
	{
		get
		{
			return this._Command;
		}
		set
		{
			this._Command = (MySqlCommand)value;
		}
	}

	#endregion



	#region Methods
	public System.Data.DataTable GetDataTable(String SQL)
	{
		try
		{
			DataTable dt = new DataTable();
			this._Command.Parameters.Clear();
			this._Command.CommandText = SQL;
			this._Command.CommandType = CommandType.Text;
			MySqlDataAdapter adapter = new MySqlDataAdapter(this._Command);
			adapter.Fill(dt);
			return dt;
		}
		catch (Exception ex)
		{
			throw (ex);
		}
		finally
		{
			this._Connection.Close();
		}
	}


	public DataTable GetDataTable(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			DataTable dt = new DataTable();
			this._Command.Parameters.Clear();
			this._Command.CommandText = SPName;
			this._Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (MySqlParameter param in Parameters)
				{
					this._Command.Parameters.Add(param);
				}
			}

			MySqlDataAdapter adapter = new MySqlDataAdapter(this._Command);
			adapter.Fill(dt);
			return dt;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			this._Connection.Close();
		}
	}


	public DataSet GetDataSet(string SQL)
	{
		try
		{
			DataSet ds = new DataSet();
			this._Command.Parameters.Clear();
			this._Command.CommandText = SQL;
			this._Command.CommandType = CommandType.Text;
			MySqlDataAdapter adapter = new MySqlDataAdapter(this._Command);
			adapter.Fill(ds);
			return ds;
		}
		catch (Exception ex)
		{
			throw (ex);
		}
		finally
		{
			this._Connection.Close();
		}
	}


	public DataSet GetDataSet(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			DataSet ds = new DataSet();
			this._Command.Parameters.Clear();
			this._Command.CommandText = SPName;
			this._Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (MySqlParameter param in Parameters)
				{
					this._Command.Parameters.Add(param);
				}
			}

			MySqlDataAdapter adapter = new MySqlDataAdapter(this._Command);
			adapter.Fill(ds);
			return ds;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			this._Connection.Close();
		}
	}


	public IDataReader ExecuteDataReader(string SQL)
	{
		try
		{
			this._Command.Parameters.Clear();
			this._Command.CommandType = CommandType.Text;
			this._Command.CommandText = SQL;
			this._Command.Connection.Open();
			return this._Command.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			this._Connection.Close();
			throw ex;
		}
		finally
		{
		}
	}


	public IDataReader ExecuteDataReader(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			this._Command.Parameters.Clear();
			this._Command.CommandText = SPName;
			this._Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (MySqlParameter param in Parameters)
				{
					this._Command.Parameters.Add(param);
				}
			}

			this._Command.Connection.Open();
			return this._Command.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			this._Connection.Close();
			throw ex;
		}
		finally
		{
		}
	}


	public object ExecuteScaler(string SQL)
	{
		try
		{
			this._Command.Parameters.Clear();
			this._Command.CommandText = SQL;
			this._Command.CommandType = CommandType.Text;
			this._Command.Connection.Open();
			return this._Command.ExecuteScalar();
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			this._Connection.Close();
		}
	}


	public object ExecuteScaler(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			this._Command.Parameters.Clear();
			this._Command.CommandText = SPName;
			this._Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (MySqlParameter param in Parameters)
				{
					this._Command.Parameters.Add(param);
				}
			}

			this._Command.Connection.Open();
			return this._Command.ExecuteScalar();
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			this._Connection.Close();
		}
	}


	public long ExecuteNonQuery(string SQL)
	{
		try
		{
			this._Command.Parameters.Clear();
			this._Command.CommandType = CommandType.Text;
			this._Command.CommandText = SQL;
			this._Command.Connection.Open();
			return this._Command.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			this._Connection.Close();
		}
	}


	public long ExecuteNonQuery(string SPName, IDataParameter[] Parameters)
	{
		try
		{
			this._Command.Parameters.Clear();
			this._Command.CommandText = SPName;
			this._Command.CommandType = CommandType.StoredProcedure;

			if (Parameters != null)
			{
				foreach (MySqlParameter param in Parameters)
				{
					this._Command.Parameters.Add(param);
				}
			}

			this._Command.Connection.Open();
			return this._Command.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			this._Connection.Close();
		}
	}
	#endregion

	*/

}
