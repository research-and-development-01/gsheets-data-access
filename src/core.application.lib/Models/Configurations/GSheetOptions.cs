
namespace core.application.lib.Models.Configurations;

public sealed class GSheetOptions
{
    public string DefaultSheetName { get; set; } = "Sheet 1";
    public int HeaderRow { get; set; } = 1;
    public string? InputSheetId { get; set; }
    public string? OutputSheetName { get; set; }
    public string ApplicationName { get; set; } = "gsheet";
}
