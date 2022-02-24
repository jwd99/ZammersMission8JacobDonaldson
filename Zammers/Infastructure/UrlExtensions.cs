using Microsoft.AspNetCore.Http;

namespace Zammers.Infastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.PathAndQuery().ToString();

    }
}
