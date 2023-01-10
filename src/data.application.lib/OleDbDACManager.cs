using System.Data;
using System.Data.OleDb;

namespace data.application.lib;

public class OleDbDACManager // : IDACManager
{
        /*
	#region Declarations
	private OleDbCommand _Command;
	private OleDbConnection _Connection;
	#endregion


	
	#region Constructors
	public OleDbDACManager(String ConnectionString)
	{
		this._Connection = new OleDbConnection(ConnectionString);
		this._Command = new OleDbCommand();
		this._Command.Connection = this._Connection;
	}
	#endregion


	
	#region Properties

	public System.Data.IDbConnection Connection
	{
		get
		{
			return this.Connection; 
		}
		set
		{
			this._Connection = (OleDbConnection)value;
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
			this._Command = (OleDbCommand)value;
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
			OleDbDataAdapter adapter = new OleDbDataAdapter(this._Command);
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
				foreach (OleDbParameter param in Parameters)
				{
					this._Command.Parameters.Add(param);
				}
			}

			OleDbDataAdapter adapter = new OleDbDataAdapter(this._Command);
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
			OleDbDataAdapter adapter = new OleDbDataAdapter(this._Command);
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
				foreach (OleDbParameter param in Parameters)
				{
					this._Command.Parameters.Add(param);
				}
			}

			OleDbDataAdapter adapter = new OleDbDataAdapter(this._Command);
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
				foreach (OleDbParameter param in Parameters)
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
				foreach (OleDbParameter param in Parameters)
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
				foreach (OleDbParameter param in Parameters)
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
