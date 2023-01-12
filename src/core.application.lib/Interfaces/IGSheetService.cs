namespace core.application.lib.Interfaces;

public interface IGSheetService
{
    Task<IList<IList<object>>>? ReadGoogleSheet(string? range=null );
    void WriteGoogleSheet();
}
