using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotBrower.Models
{
    public class ShopModel
    {
        public string img { get; set; }

        [JsonIgnore]
        public string imgfirst
        {
            get
            {

                try
                {
                    var list = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(img);
                    if (list.Count > 0)
                        return ((Newtonsoft.Json.Linq.JProperty)list.First).Name;
                    else
                        return string.Empty;
                }
                catch (Exception)
                {

                    return string.Empty;
                }

            }
        }

        public string price { get; set; }
        public string sku { get; set; }

        public string sp { get; set; }
        public string title { get; set; }
    }


}
