using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionCSharp.Models
{
    public class MessageTypeList
    {
        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("content")]
        public IList<String> Content;
    }
}
