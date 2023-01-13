using System.Data;

namespace core.application.lib.Interfaces;

public interface IGSheetService
{
    Task<IList<IList<object>>>? ReadGoogleSheet(string? range = null );

    Task<DataTable> ReadGoogleSheetAsDataTable(string? range = null, int? headerRow=null);

    Task<(string spreadsheetId, string spreadsheetURL)> CreateGSheet();

    Task<string> WriteGoogleSheet(DataTable dtTable);
}
