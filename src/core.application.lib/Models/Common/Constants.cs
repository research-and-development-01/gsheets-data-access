namespace core.application.lib.Models.Common;

public static class Constants
{
    public static class ConfigSections
    {
        public const string ConnectionStringsSection = "ConnectionStrings";
        public const string ConectionStringSqlServer = "ConectionStringSqlServer";

        public const string GSheetSection = "GSheet";
    }

    public static class Mappings 
    {
        public static readonly Dictionary<string, string> GSheetToEmployeeVM = new()
            {
                { "Full Legal Name", "FullName" },
                { "Legal Name - First Name", "FirstName" },
                { "Legal Name - Last Name", "LastName" },
                { "Employee ID", "Id" }
            };

        public static readonly Dictionary<string, string> GSheetToContractVM = new()
            {
                { "Status Effective Date", "EffectiveDate" }               
            };

        public static readonly Dictionary<string, string> GSheetToCompensationPlanVM = new()
            {
                { "Compensation Effective Date", "EffectiveDate" }               
            };
    }
}
