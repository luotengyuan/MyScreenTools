using System.Collections.Generic;
using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    public class SimpleMeans
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("word_means")]
        public List<string> WordMeans { get; set; }
    }
}