using core.application.lib.Interfaces;
using core.application.lib.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using static Google.Apis.Requests.BatchRequest;
using System.Data;

namespace app.application.conapp.Services;

public class GSheetService : IGSheetService
{
    private readonly ILogger<GSheetService> _log;
    private readonly IConfiguration _config;
    private readonly GSheetOptions _gSheetOptions;

    private readonly string[] _scopes = { SheetsService.Scope.Spreadsheets };
    private readonly string _applicationName;
    private readonly string _spreadsheetId;

    public GSheetService(
        ILogger<GSheetService> log,
        IConfiguration config,
        IOptions<GSheetOptions> gSheetOptions)
    {
        _log = log;
        _config = config;
        _gSheetOptions = gSheetOptions.Value;
        _applicationName = _gSheetOptions.ApplicationName;
        _spreadsheetId = _gSheetOptions.InputSheetId??string.Empty;
    }   

    public async Task<IList<IList<object>>>? ReadGoogleSheet(string? range)
    {        
        return await ReadData(range ?? _gSheetOptions.DefaultSheetName)!;
    }

    public async Task<DataTable> ReadGoogleSheetAsDataTable(string? range, int? headerRow)
    {
        var rawData = await ReadData(range ?? _gSheetOptions.DefaultSheetName)!;
        headerRow ??= _gSheetOptions.HeaderRow;

        DataTable dtTable = new DataTable();

        if (rawData != null && rawData.Count > 0) // build data table 
        {
            int iteration = 1; //none-zero based index
            foreach (var row in rawData)
            {
                if (iteration < headerRow)
                {
                    iteration++;
                    continue;
                }

                if (iteration == headerRow) // add columns 
                {
                    foreach (var col in row)
                    {
                        dtTable.Columns.Add($"[{col}]", typeof(string));
                    }
                }

                if (iteration > headerRow)
                {
                    var drNew = dtTable.NewRow();
                    int colIndex = 0;
                    foreach (var col in row)
                    {
                        drNew[colIndex] = col.ToString();
                        colIndex++;
                    }
                    dtTable.Rows.Add(drNew);
                }

                iteration++;
            }
        }

        return dtTable;
    }

    public void WriteGoogleSheet()
    { }

    public async Task<IList<IList<object>>>? ReadData(string range)
    {
        var credential = GoogleCredential.FromFile("credentials.json").CreateScoped(_scopes);
        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = _applicationName,
        });

        var rangeToRead = range;
        var request = service.Spreadsheets.Values.Get(_spreadsheetId, rangeToRead);
        IList<IList<object>>? values = null;
        await Task.Run(() =>
        {
            var response = request.Execute();
            values = response.Values;
        });       
        
        return values!;
    }

}
