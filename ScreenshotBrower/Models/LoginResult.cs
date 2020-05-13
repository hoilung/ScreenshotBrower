using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ScreenshotBrower.Models
{
    public class LoginResult
    {
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
