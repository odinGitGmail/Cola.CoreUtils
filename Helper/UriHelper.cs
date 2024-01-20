using Cola.CoreUtils.Extensions;

namespace Cola.CoreUtils.Helper;

public class UriHelper
{
    public static string CombineUriToString(string baseUri, string? relativeOrAbsoluteUri = null, string? query = null)
    {
        var uriBuilder = new UriBuilder(baseUri);
        if (relativeOrAbsoluteUri.StringIsNotNullOrEmpty())
        {
            uriBuilder.Path += relativeOrAbsoluteUri;
        }
        if (query.StringIsNotNullOrEmpty())
        {
            uriBuilder.Query += query;
        }
        return uriBuilder.ToString();
    }
}