using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dashboard.Util
{
    public static class JsonUtil
    {
        public static async Task<string> JsonResultAsync(IQueryable queryable)
        {
            var jsonREsult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(queryable,
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    DateParseHandling = DateParseHandling.DateTime,
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                    StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Include,
                })
                );
            return jsonREsult;
        }
    }
}