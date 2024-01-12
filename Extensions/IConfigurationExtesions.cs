using Microsoft.Extensions.Configuration;

namespace Cola.CoreUtils.Extensions;

public static class IConfigurationExtesions
{
    public static T GetColaSection<T>(this IConfiguration configuration, string sectionName)
    {
        return configuration.GetSection(sectionName).Get<T>();
    }
}