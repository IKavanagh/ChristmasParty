namespace Christmas;

public class PlatformConfiguration
{
    public static PlatformConfiguration Instance { get; } = new PlatformConfiguration();
    
    /// <summary>
    /// Platform specific redirect URI
    /// </summary>
    public string RedirectUri { get; set; }

    /// <summary>
    /// Platform specific parent window
    /// </summary>
    public object ParentWindow { get; set; }

    /// <summary>
    /// Private constructor to ensure all access is through static Instance property
    /// </summary>
    private PlatformConfiguration() { }
}
