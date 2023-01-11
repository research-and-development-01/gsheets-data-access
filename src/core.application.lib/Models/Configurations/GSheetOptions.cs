
namespace core.application.lib.Models.Configurations;

public sealed class GSheetOptions
{
    public int? HeaderRow { get; set; }
    public string? InputSheetId { get; set; }
    public string? OutputSheetName { get; set; }
}
