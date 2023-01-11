using core.application.lib.Interfaces;
using core.application.lib.Models.Common;
using core.application.lib.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace app.application.conapp.Services;

public class GSheetService : IGSheetService
{
    private readonly ILogger<GSheetService> _log;
    private readonly IConfiguration _config;
    private readonly GSheetOptions _gSheetOptions;

    public GSheetService(
        ILogger<GSheetService> log,
        IConfiguration config,
        IOptions<GSheetOptions> gSheetOptions)
    {
        _log = log;
        _config = config;
        _gSheetOptions = gSheetOptions.Value;
    }

    public void Run()
    {
        _log.LogInformation("Starting Entrypoint: {entrypoint}", "Run");

        var sqlServerConnectionString = _config.GetConnectionString(Constants.ConfigSections.ConectionStringSqlServer);

        _log.LogInformation("Config: {ConectionStringSqlServer}", sqlServerConnectionString);

        _log.LogInformation("ConfigSheet: {HeaderRow}", _gSheetOptions.HeaderRow);
        _log.LogInformation("ConfigSheet: {InputSheetId}", _gSheetOptions.InputSheetId);
        _log.LogInformation("ConfigSheet: {OutputSheetName}", string.Format(_gSheetOptions.OutputSheetName??"NewSheet", DateTime.Now.ToString("yyyyMMdd-hhmmss")));
    }

}
