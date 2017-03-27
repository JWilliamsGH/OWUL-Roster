using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OWULRosterServer.Utils
{
    public class JSONUtil
    {
        public static string GetJSON(object obj, bool hasCircularReference = false)
        {
            var serializerSettigns = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            return JsonConvert.SerializeObject(obj, Formatting.Indented, (hasCircularReference ? serializerSettigns : null));
        }
    }
}