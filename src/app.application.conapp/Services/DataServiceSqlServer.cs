using core.application.lib.Interfaces;
using core.application.lib.Models.Common;
using data.application.lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace app.application.conapp.Services;

public sealed class DataServiceSqlServer : IDataServiceSqlServer
{
    private readonly ILogger<DataServiceSqlServer> _log;
    private readonly IConfiguration _config;
    private IDACManager _dACManager;

    public DataServiceSqlServer(
        ILogger<DataServiceSqlServer> log,
        IConfiguration config)
    {
        _log = log;
        _config = config;
        _dACManager = DACManagerFactory.GetDACManager(
            _config.GetConnectionString(Constants.ConfigSections.ConectionStringSqlServer)
            , DACManagers.SqlServerDACManager);
    }

    public async Task<DataTable> GetRawData()
    {
        string sql = "Select * from RawData";
        DataTable? dt = new DataTable();
        await Task.Run(() =>
        {
            dt = _dACManager.GetDataTable(sql);
        });
        return dt;
    }

    public async Task SaveRawDataToDB(DataTable dtTable, string dbTableName="RawData")
    {
        if (dtTable is null || dtTable.Rows.Count == 0)
        {
            return;
        }

        DataTable newTable = new DataTable();
        newTable.Columns.Add("Id", typeof(long));
        newTable.Columns.Add("BatchId", typeof(string));
        foreach (DataColumn col in dtTable.Columns)
            newTable.Columns.Add(col.ColumnName, col.DataType);

        string BatchId = DateTime.Now.ToString("yyyyMMdd-HHmmss");
        foreach (DataRow row in dtTable.Rows)
        {
            DataRow newRow = newTable.NewRow();
            //newRow["Id"] = "NewData1";
            newRow["BatchId"] = BatchId;
            for (int i = 2; i < newTable.Columns.Count; i++)
                newRow[i] = row[i - 2];
            newTable.Rows.Add(newRow);
        }

        await BulkCopy(dbTableName, newTable);
    }


    public async Task<string> BulkCopy(string dbTableName, DataTable dtTable)
    {
        string result = "Data Saved";
        await Task.Run(() =>
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(_dACManager.Connection.ConnectionString))
            {
                sqlBulkCopy.DestinationTableName = dbTableName;
                try
                {
                    sqlBulkCopy.WriteToServer(dtTable);
                }
                catch (Exception exception)
                {
                    result = exception.Message;
                }
            }
        });

        return result;
    }
}
