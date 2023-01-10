using System.Data;

namespace data.application.lib;

public interface IDACManager
{
	#region Properties
	IDbConnection Connection { get; set; }
    IDbCommand Command { get; set; }
	#endregion

	#region Methods
	DataTable GetDataTable(string SQL);
	DataTable GetDataTable(string SPName, IDataParameter []Parameters);

	DataSet GetDataSet(string SQL);
	DataSet GetDataSet(string SPName, IDataParameter[] Parameters);

	IDataReader ExecuteDataReader(string SQL);
	IDataReader ExecuteDataReader(string SPName, IDataParameter[] Parameters);

	object ExecuteScaler(string SQL);
    object ExecuteScaler(string SPName, IDataParameter[] Parameters);

    long ExecuteNonQuery(string SQL);
	long ExecuteNonQuery(string SPName, IDataParameter[] Parameters);
	#endregion
}
