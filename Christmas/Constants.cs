namespace Christmas;

public class Constants
{
    /// <summary>
    /// Client Id of the Azure Active Directory App Registration
    /// </summary>
    public static string ClientId => "d1fb1775-22ea-4999-b72f-3964a42a8f4b";

    /// <summary>
    /// Tenant Id the Azure Active Directory is in
    /// </summary>
    public static string TenantId => "7ab1c5c1-f9cf-4a97-ac68-8e7e4b1823be";

    /// <summary>
    /// Defines the Microsoft Graph scopes the app can access
    /// </summary>
    public static string[] Scopes => new string[] { "User.Read" };
}
