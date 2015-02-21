using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Variel.Helpers.Web
{
    public static class UriHelper
    {
        public static string Build(string uri, object query)
        {
            return Build(uri, query.ToStringDictionary());
        }

        public static string Build(string uri, IDictionary<string, string> query)
        {
            if (uri.Contains("?"))
                throw new ArgumentException("uri는 Query String을 포함할 수 없습니다", "uri");

            uri += "?" +
                   String.Concat(query.Select(x => String.Format("{0}={1}&",
                                                                 WebUtility.UrlEncode(x.Key),
                                                                 WebUtility.UrlEncode(x.Value))));
            return uri;
        }
    }
}
