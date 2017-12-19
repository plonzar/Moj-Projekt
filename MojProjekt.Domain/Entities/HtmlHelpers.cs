using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

public static class HtmlHelpers
{
    /// <summary>
    /// Converts a viewbag object to Json
    /// </summary>
    /// <param name="viewBagObject">Object to make into Json</param>
    /// <returns>Javascript object</returns>
    public static IHtmlString ToJson(HtmlHelper html, dynamic viewBagObject)
    {
        var json = JsonConvert.SerializeObject(
            viewBagObject,
            Formatting.Indented,
            new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
        );

        return html.Raw(json);
    }
}
