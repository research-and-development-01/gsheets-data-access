using core.application.lib.Interfaces;
using core.application.lib.Models.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

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

    public async Task Run()
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
                    await ReadFromGoogleToDB();
                    break;
                case "2":
                    await WriteToGoogleFromDB();                    
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

    private async Task ReadFromGoogleToDB()
    {
        Console.WriteLine("ReadFromGoogleToDB");
        var dtTable = await _gSheetService.ReadGoogleSheetAsDataTable()!;
        await _dataServiceSqlServer.SaveRawDataToDB(dtTable);
        if (dtTable != null && dtTable.Rows.Count > 0)
        {            
            foreach (DataRow row in dtTable.Rows)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                foreach (DataColumn col in dtTable.Columns)
                {
                    Console.Write("{0}, ", row[col.ColumnName]);
                }
            }            
        }
        else
        {
            Console.WriteLine("No data found.");
        }
        Console.Read();
    }

    private async Task WriteToGoogleFromDB()
    {
        Console.WriteLine("WriteToGoogleFromDB");
        var dtTable = await _dataServiceSqlServer.GetRawData();
        var sheetUrl = await _gSheetService.WriteGoogleSheet(dtTable);
        Console.WriteLine($"SpreadSheet Generated: {sheetUrl}");
    }

    private void ClearDB()
    {
        Console.WriteLine("not implemented yet");
    }
}
