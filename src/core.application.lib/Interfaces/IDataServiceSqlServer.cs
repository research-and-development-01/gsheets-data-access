using System.Data;

namespace core.application.lib.Interfaces;

public interface IDataServiceSqlServer
{
    Task<DataTable?> GetEmployeeData();
    Task<string> BulkCopy(string dbTableName, DataTable dtTable);
}
