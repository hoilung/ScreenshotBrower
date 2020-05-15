using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    public class Result<T>
    {
        public string msg { get; set; }

        public bool state { get; set; }

        public T data { get; set; }
    }

    public class CreateResult
    {
        public int code { get; set; }
        public string msg { get; set; }
    }

}
