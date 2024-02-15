using System.Text;

namespace Cola.CoreUtils.Extensions;

public static class DictionaryExtensions
{
    /// <summary>
    /// ConvertDictionaryToQueryString
    /// </summary>
    /// <param name="dic">dic</param>
    /// <returns>QueryString</returns>
    public static string ConvertDictionaryToQueryString(this Dictionary<string, string> dic)
    {
        StringBuilder queryStringBuilder = new StringBuilder();
        List<string> queryString = new List<string>();
        foreach (var dicKey in dic.Keys)
        {
            if (dic[dicKey].StringIsNotNullOrEmpty())
            {
                queryString.Add($"{dicKey}={dic[dicKey]}");
            }
        }

        return string.Join('&', queryString);
    }
}