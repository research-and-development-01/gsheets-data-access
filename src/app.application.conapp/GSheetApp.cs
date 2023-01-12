using core.application.lib.Interfaces;
using core.application.lib.Models.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace app.application.conapp;

public sealed class GSheetApp
{
    private readonly ILogger<GSheetApp> _log;
    private readonly IConfiguration _config;
    private readonly IGSheetService _gSheetService;
    private readonly IDataServiceSqlServer _dataServiceSqlServer;

    public GSheetApp (
        ILogger<GSheetApp> log,
        IConfiguration config,
        IGSheetService gSheetService,
        IDataServiceSqlServer dataServiceSqlServer)
    {
        _log = log;
        _config = config;
        _gSheetService = gSheetService;
        _dataServiceSqlServer = dataServiceSqlServer;
    }

    public void Run()
    {
        _log.LogInformation("Starting Entrypoint: {entrypoint}", "Run");

        var sqlServerConnectionString = _config.GetConnectionString(Constants.ConfigSections.ConectionStringSqlServer);
        _log.LogInformation("Config: {ConectionStringSqlServer}", sqlServerConnectionString);


        string inOption;
        do
        {
            DisplayOptions();
            inOption = Console.ReadLine() ?? "...";
            Console.Clear();

            switch (inOption)
            {
                case "0":
                    break;
                case "1":
                    ReadFromGoogleToDB();
                    break;
                case "2":
                    WriteToGoogleFromDB();                    
                    break;
                case "3":
                    ClearDB();
                    break;
                default:
                    Console.WriteLine("Invalid Option Selected");
                    break;
            }

        } while (inOption != "0");

        void DisplayOptions()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("1 - Read From Google Sheet To DB");
            Console.WriteLine("2 - Write To Google Sheet From DB");
            Console.WriteLine("3 - Clear DB");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter Option > ");
        }
    }

    private async void ReadFromGoogleToDB()
    {
        Console.WriteLine("ReadFromGoogleToDB");
        var values = await _gSheetService.ReadGoogleSheet()!;
        if (values != null && values.Count > 0)
        {            
            foreach (var row in values)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                foreach (var col in row)
                {
                    Console.Write("{0}, ", col);
                }
            }            
        }
        else
        {
            Console.WriteLine("No data found.");
        }
        Console.Read();
    }

    private void WriteToGoogleFromDB()
    {
        Console.WriteLine("WriteToGoogleFromDB");
    }

    private void ClearDB()
    {
        Console.WriteLine("ClearDB");
    }
}
