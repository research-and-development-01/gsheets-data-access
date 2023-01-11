using core.application.lib.Interfaces;
using core.application.lib.Models.Common;
using data.application.lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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

    public async Task<DataTable?> GetEmployeeData()
    {
        string sql = "";
        DataTable? dt = null;
        await Task.Run(() =>
        {
            dt = _dACManager.GetDataTable(sql);
        });
        return dt;
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
