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
