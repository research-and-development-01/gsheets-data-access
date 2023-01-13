using System.Data;

namespace core.application.lib.Interfaces;

public interface IDataServiceSqlServer
{
    Task<DataTable> GetRawData();

    Task SaveRawDataToDB(DataTable dtTable, string dbTableName = "RawData");

    Task<string> BulkCopy(string dbTableName, DataTable dtTable);
}
