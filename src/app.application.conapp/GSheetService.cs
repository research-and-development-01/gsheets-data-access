using core.application.lib.Models.Common;
using core.application.lib.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace app.application.conapp;

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

        _log.LogInformation("Config: {SettingA}", _gSheetOptions.SettingA);
        _log.LogInformation("Config: {SettingB}", _gSheetOptions.SettingB);

    }

}
