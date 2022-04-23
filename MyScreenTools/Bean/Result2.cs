using System.Collections.Generic;
using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    public class Result2
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("trans_result")]
        public List<TransResultItem2> TransResult { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }
    }
}